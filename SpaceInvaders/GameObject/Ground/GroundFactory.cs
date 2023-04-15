//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GroundFactory
    {
        private GroundFactory()
        {
            this.pTree = null;
        }
        private void privSet(SpriteBatch.Name spriteBatchName, SpriteBatch.Name collisionSpriteBatch, Composite pTree)
        {
            Debug.Assert(pTree != null);
            this.pTree = pTree;

            this.pSpriteBatchName = spriteBatchName;
            this.pCollisionSpriteBatchName = collisionSpriteBatch;
        }
        private void privSetParent(GameObject pParentNode)
        {
            // OK being null
            Debug.Assert(pParentNode != null);
            this.pTree = (Composite)pParentNode;
        }
        ~GroundFactory()
        {
        }
        private GameObject privCreate(Ground.Type type, GameObject.Name gameName, float posX = 0.0f, float posY = 0.0f)
        {
            GameObject pGround = null;

            GameObjectNode pGameObjNode = GhostMan.Find(gameName);
            if (pGameObjNode != null)
            {
                pGround = pGameObjNode.pGameObj;
                GhostMan.Remove(pGameObjNode);

                //GhostMan.Dump();

                switch (type)
                {
                    case Ground.Type.Ground:
                        ((Ground)pGround).Resurrect();
                        pGround.x = posX;
                        pGround.y = posY;
                        break;

                    case Ground.Type.GroundRoot:
                        ((GroundRoot)pGround).Resurrect();
                        pGround.x = posX;
                        pGround.y = posY;
                        break;

                    default:
                        // something is wrong
                        Debug.Assert(false);
                        break;
                }
            }
            else
            {
                switch (type)
                {
                    case Ground.Type.Ground:
                        pGround = new Ground(gameName, SpriteGame.Name.Hyphen, posX, posY);
                        break;

                    case Ground.Type.GroundRoot:
                        pGround = new GroundRoot(gameName, SpriteGame.Name.NullObject, posX, posY);
                        break;

                    default:
                        // something is wrong
                        Debug.Assert(false);
                        break;
                }
            }
            

            // add to the tree
            this.pTree.Add(pGround);

            // Attached to Group
            pGround.ActivateSprite(this.pSpriteBatchName);
            pGround.ActivateCollisionSprite(this.pCollisionSpriteBatchName);

            return pGround;
        }

        public static GameObject CreateGround(float startX = 0.0f, float startY = 0.0f, float width = 1.0f, float height = 1.0f)
        {

            GroundFactory pFactory = GroundFactory.privInstance();

            GroundRoot pGroundRoot = (GroundRoot)GameObjectNodeMan.Find(GameObject.Name.GroundRoot);
            if (pGroundRoot == null)
            {
                pGroundRoot = new GroundRoot(GameObject.Name.GroundRoot, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            }
            GameObjectNodeMan.Attach(pGroundRoot);

            pFactory.privSet(SpriteBatch.Name.Ground, SpriteBatch.Name.Ground, pGroundRoot);

            int i = 0;

            // create a grid
            pFactory.privSetParent(pGroundRoot);

            while((i * width) < 672)
            {
                pFactory.privCreate(Ground.Type.Ground, GameObject.Name.Ground, startX + (width * i++), startY);
            }

            return pGroundRoot;
        }

        private static GroundFactory privInstance()
        {
            if (pInstance == null)
            {
                GroundFactory.pInstance = new GroundFactory();
            }

            Debug.Assert(pInstance != null);

            return pInstance;
        }

        // Data: ---------------------
        /*        private SpriteBatch pSpriteBatch;
                private SpriteBatch pCollisionSpriteBatch;*/

        private SpriteBatch.Name pSpriteBatchName;
        private SpriteBatch.Name pCollisionSpriteBatchName;

        private Composite pTree;

        private static GroundFactory pInstance = null;
    }
}

// --- End of File ---
