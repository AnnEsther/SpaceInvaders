//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//-----------------------------------------------------------------------------
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShieldGrid : Composite
    {
        public ShieldGrid(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            //Debug.WriteLine("Grid proxy sprite: {0}", this.pSpriteProxy.GetHashCode());
            //Debug.WriteLine("Grid col   sprite: {0}",this.poColObj.pColSprite.GetHashCode());

            this.x = posX;
            this.y = posY;

            this.SetCollisionColor(0.0f, 0.0f, 1.0f);
        }
        public void Resurrect(float posX, float posY)
        {
            this.x = posX;
            this.y = posY;

            base.Resurrect();

            this.SetCollisionColor(0.0f, 0.0f, 1.0f);
        }
        ~ShieldGrid()
        {
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitShieldGrid(this);
        }

        public override void VisitMissile(Missile m)
        {
            // Missile vs ShieldGrid
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }

        public override void VisitBomb(Bomb m)
        {
            // Missile vs ShieldGrid
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }

        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }
        public override void VisitBombRoot(BombRoot b)
        {
            // BombRoot vs ShieldRoot
            if (this.GetNumChildren() != 0)
            {
                GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
                ColPair.Collide(b, pGameObj);
            }

        }

        public void ClearColums()
        {
            Iterator pIt = this.GetIterator();
            Debug.Assert(pIt != null);
            ShieldColumn pNode = (ShieldColumn)pIt.First();
            while (!pIt.IsDone())
            {
                ShieldColumn pTemp = (ShieldColumn)pIt.Current();
                pNode = (ShieldColumn)pIt.Next();
                pTemp.ClearBricks();
                pTemp.Remove();
            }
        }

        // -------------------------------------------
        // Data: 
        // -------------------------------------------

     
    }
}

// --- End of File ---
