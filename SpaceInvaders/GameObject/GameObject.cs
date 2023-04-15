//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class GameObject : Component
    {
        public enum Name
        {

            Null_Object,
           
            Squid,
            Crab,
            Octopus,

            AlienColumn,
            AlienGrid,
            AlienRoot,

            Missile,
            MissileGroup,


            WallGroup,
            WallRight,
            WallLeft,
            WallTop,

            Ship,
            ShipRoot,

            Rolling,
            Swiggly,
            Plunger,
            BombRoot,

            WallBottom,

            ShieldRoot,
            ShieldColumn_0,
            ShieldColumn_1,
            ShieldColumn_2,
            ShieldColumn_3,
            ShieldColumn_4,
            ShieldColumn_5,
            ShieldColumn_6,
            ShieldColumn_7,
            ShieldColumn_8,
            ShieldColumn_9,
            ShieldColumn_10,
            ShieldBrick,
            ShieldBrickRightTop,
            ShieldBrickRightBottom,
            ShieldBrickLeftBottom,
            ShieldBrickLeftTop,
            ShieldGrid_0,
            ShieldGrid_1,
            ShieldGrid_2,
            ShieldGrid_3,

            BumperRoot,
            BumperRight,
            BumperLeft,

            ReserveShipRoot,
            ReserveShip1,
            ReserveShip2,
            ReserveShip3,

            GroundRoot,
            Ground,

            UFORoot,
            UFO,

            NullObject,

            Uninitialized
        }

        protected GameObject(Component.Container type, 
            GameObject.Name gameName,
            SpriteGame.Name proxyName)
             : base(type)
        {
            this.name = gameName;
            this.x = 0.0f;
            this.y = 0.0f;
            this.spriteName = proxyName;
            //SpriteGameProxy pProxy = SpriteGameProxyMan.Find(proxyName);
            // BUG... this needs to be ADD not FIND  (10 hrs to find that)
            SpriteGameProxy pProxy = SpriteGameProxyMan.Add(proxyName);

            Debug.Assert(pProxy != null);

            this.pSpriteProxy = pProxy;

            //LTN - GameObject
            this.poColObj = new ColObject(this.pSpriteProxy);
            Debug.Assert(this.poColObj != null);

            this.bMarkForDeath = false;
        }

        protected GameObject(Component.Container type,
                                GameObject.Name gameName,
                                SpriteGame.Name _spriteName,
                                float _x,
                                float _y)
             : base(type)
        {
            this.name = gameName;
            this.x = _x;
            this.y = _y;

            this.bMarkForDeath = false;
            this.spriteName = _spriteName;
            this.pSpriteProxy = SpriteGameProxyMan.Add(this.spriteName);

            // Owned by the gameobject... don't delete it
            // its going on the ghostMan
            this.poColObj = new ColObject(this.pSpriteProxy);
            Debug.Assert(this.poColObj != null);

        }
        override public void Resurrect()
        {
            this.bMarkForDeath = false;

            Debug.Assert(this.pSpriteProxy != null);
            Debug.Assert(this.poColObj != null);

            //this.pSpriteProxy = SpriteGameProxyMan.Add(this.spriteName);

            //// poColObj is still valid... don't renew it
            //// Need more work on this
            //// the new is temporary.. need a "update" to reset ColObject
            //// for now call new
            // this.poColObj = new ColObject(this.pSpriteProxy)

            this.poColObj.Resurrect(this.pSpriteProxy);

            Debug.Assert(this.poColObj != null);
            base.Resurrect();
        }

        ~GameObject()
        {

        }

        public virtual void Update()
        {
            Debug.Assert(this.pSpriteProxy != null);
            Debug.Assert(this.poColObj != null);
            Debug.Assert(this.poColObj.pColSprite != null);

            this.pSpriteProxy.x = this.x;
            this.pSpriteProxy.y = this.y;

            this.poColObj.UpdatePos(this.x, this.y);
            this.poColObj.pColSprite.Update();
        }
        public void ActivateCollisionSprite(SpriteBatch.Name spriteBatchName)
        {
            Debug.Assert(this.poColObj != null);

            SpriteBatch pSpriteGameBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(pSpriteGameBatch != null);
            pSpriteGameBatch.Attach(this.poColObj.pColSprite);
        }

        public void ActivateSprite(SpriteBatch.Name spriteBatchName)
        {
            SpriteBatch pSpriteGameBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(pSpriteGameBatch != null);
            pSpriteGameBatch.Attach(this.pSpriteProxy);
        }
        public virtual void Remove()
        {
            //Debug.WriteLine("REMOVE: {0}", this);
            // Keenan(delete.A)
            // -----------------------------------------------------------------
            // Very difficult at first... if you are messy, you will pay here!
            // Given a game object....
            // -----------------------------------------------------------------

            // Remove from SpriteBatch

            // Find the SpriteNode
            Debug.Assert(this.pSpriteProxy != null);
            SpriteNode pSpriteNode = this.pSpriteProxy.GetSpriteNode();

            // Remove it from the manager
            Debug.Assert(pSpriteNode != null);
            SpriteBatchMan.Remove(pSpriteNode);

            // 1) Don't Need to remove it from ProxySpriteMan
            // Since it is being recycled on the GhostMan

            // Remove collision sprite from spriteBatch

            Debug.Assert(this.poColObj != null);
            Debug.Assert(this.poColObj.pColSprite != null);
            pSpriteNode = this.poColObj.pColSprite.GetSpriteNode();

            Debug.Assert(pSpriteNode != null);
            SpriteBatchMan.Remove(pSpriteNode);

            // 2) Don't Need to remove it from BoxSpriteMan
            // Since it is being recycled on the GhostMan

            // Remove from GameObjectMan

            GameObjectNodeMan.Remove(this);

            // future is now
            GhostMan.Attach(this);
        }

        override public void Dump()
        {
            // Data:
            Debug.WriteLine("");
            Debug.WriteLine("\tGameObject: --------------");
            Debug.WriteLine("\t\t\t       name: {0} ({1})", this.name, this.GetHashCode());

            if (this.pSpriteProxy != null)
            {
                Debug.WriteLine("\t\t   pProxySprite: {0}", this.pSpriteProxy.name);
                if (this.pSpriteProxy.pRealSprite == null)
                {
                    Debug.WriteLine("\t\t    pRealSprite: null");
                }
                else
                {
                    Debug.WriteLine("\t\t    pRealSprite: {0}", this.pSpriteProxy.pRealSprite.GetName());
                }
            }
            else
            {
                Debug.WriteLine("\t\t   pProxySprite: null");
                Debug.WriteLine("\t\t    pRealSprite: null");
            }
            Debug.WriteLine("\t\t\t      (x,y): {0}, {1}", this.x, this.y);

            base.baseDump();
        }

        override public System.Enum GetName()
        {
            return this.name;
        }

        public SpriteGameProxy GetSpriteProxy()
        {
            return this.pSpriteProxy;
        }

        public void UpdateBoxColor(float red, float green, float blue, float alpha = 1.0f)
        {
            this.poColObj.UpdateColor(red, green, blue, alpha);
        }
        protected void BaseUpdateBoundingBox(Component pStart)
        {
            GameObject pNode = (GameObject)pStart;

            // point to ColTotal
            ColRect ColTotal = this.poColObj.poColRect;

            // Get the first child
            pNode = (GameObject)IteratorForwardComposite.GetChild(pNode);

            if (pNode != null)
            {
                // Initialized the union to the first block
                ColTotal.Set(pNode.poColObj.poColRect);

                // loop through sliblings
                while (pNode != null)
                {
                    ColTotal.Union(pNode.poColObj.poColRect);

                    // go to next sibling
                    pNode = (GameObject)IteratorForwardComposite.GetSibling(pNode);
                }

                this.x = this.poColObj.poColRect.x;
                this.y = this.poColObj.poColRect.y;

                //  Debug.WriteLine("x:{0} y:{1} w:{2} h:{3}", ColTotal.x, ColTotal.y, ColTotal.width, ColTotal.height);
            }
            //no children, so we shouldn't have a rect
            else
            {
                this.poColObj.poColRect.Clear();
            }

        }
        public ColObject GetColObject()
        {
            Debug.Assert(this.poColObj != null);
            return this.poColObj;
        }
        public void SetCollisionColor(float red, float green, float blue)
        {
            Debug.Assert(this.poColObj != null);
            Debug.Assert(this.poColObj.pColSprite != null);

            this.poColObj.pColSprite.SetColor(red, green, blue);
        }
        public void Resurrect(float posX, float posY)
        {
            this.Resurrect();

            this.x = posX;
            this.y = posY;
            this.SetCollisionColor(1.0f, 0.0f, 0.0f);
        }
        public void UpdateColor(Azul.Color _pColor)
        {
            this.pSpriteProxy.SwapColor(_pColor);
        }
        // Data: ---------------
        public GameObject.Name name;

        public float x;
        public float y;
        public SpriteGameProxy pSpriteProxy;
        public ColObject poColObj;
        public bool bMarkForDeath;
        public SpriteGame.Name spriteName;
    }

}

// --- End of File ---
