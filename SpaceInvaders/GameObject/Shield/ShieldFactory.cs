//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShieldFactory
    {
        private ShieldFactory()
        {
            this.pTree = null;
        }
        private void privSet(SpriteBatch.Name spriteBatchName, SpriteBatch.Name collisionSpriteBatch, Composite pTree)
        {
           /* SpriteBatch pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(pSpriteBatch != null);

            SpriteBatch pCollisionSpriteBatch = SpriteBatchMan.Find(collisionSpriteBatch);
            Debug.Assert(pCollisionSpriteBatch != null);*/

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
        ~ShieldFactory()
        {
        }
        private GameObject privCreate(ShieldBase.Type type, GameObject.Name gameName, float posX = 0.0f, float posY = 0.0f)
        {
            GameObject pShield = null;

            GameObjectNode pGameObjNode = GhostMan.Find(gameName);
            if (pGameObjNode != null)
            {
                pShield = pGameObjNode.pGameObj;
                GhostMan.Remove(pGameObjNode);

                //GhostMan.Dump();

                switch (type)
                {
                    case ShieldBase.Type.Brick:
                    case ShieldBase.Type.LeftTop1:
                    case ShieldBase.Type.LeftTop0:
                    case ShieldBase.Type.LeftBottom:
                    case ShieldBase.Type.RightTop1:
                    case ShieldBase.Type.RightTop0:
                    case ShieldBase.Type.RightBottom:
                        ((ShieldBrick)pShield).Resurrect();
                        pShield.x = posX;
                        pShield.y = posY;
                        break;

                    case ShieldBase.Type.Root:
                        Debug.Assert(false);
                        break;

                    case ShieldBase.Type.Grid:
                        ((ShieldGrid)pShield).Resurrect();
                        pShield.x = posX;
                        pShield.y = posY;
                        break;

                    case ShieldBase.Type.Column:
                        ((ShieldColumn)pShield).Resurrect();
                        pShield.x = posX;
                        pShield.y = posY;
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
                    case ShieldBase.Type.Brick:
                        pShield = new ShieldBrick(gameName, SpriteGame.Name.Brick, posX, posY);
                        break;

                    case ShieldBase.Type.LeftTop1:
                        pShield = new ShieldBrick(gameName, SpriteGame.Name.Brick_LeftTop1, posX, posY);
                        break;

                    case ShieldBase.Type.LeftTop0:
                        pShield = new ShieldBrick(gameName, SpriteGame.Name.Brick_LeftTop0, posX, posY);
                        break;

                    case ShieldBase.Type.LeftBottom:
                        pShield = new ShieldBrick(gameName, SpriteGame.Name.Brick_LeftBottom, posX, posY);
                        break;

                    case ShieldBase.Type.RightTop1:
                        pShield = new ShieldBrick(gameName, SpriteGame.Name.Brick_RightTop1, posX, posY);
                        break;

                    case ShieldBase.Type.RightTop0:
                        pShield = new ShieldBrick(gameName, SpriteGame.Name.Brick_RightTop0, posX, posY);
                        break;

                    case ShieldBase.Type.RightBottom:
                        pShield = new ShieldBrick(gameName, SpriteGame.Name.Brick_RightBottom, posX, posY);
                        break;

                    case ShieldBase.Type.Root:
                        /*pShield = new ShieldRoot(gameName, SpriteGame.Name.NullObject, posX, posY);
                        pShield.SetCollisionColor(0.0f, 0.0f, 1.0f);*/
                        Debug.Assert(false);
                        break;

                    case ShieldBase.Type.Column:
                        pShield = new ShieldColumn(gameName, SpriteGame.Name.NullObject, posX, posY);
                        /* pShield.SetCollisionColor(1.0f, 0.0f, 0.0f);*/
                        break;

                    case ShieldBase.Type.Grid:
                        pShield = new ShieldGrid(gameName, SpriteGame.Name.NullObject, posX, posY);
                        /* pShield.SetCollisionColor(0.0f, 0.0f, 1.0f);*/
                        break;

                    default:
                        // something is wrong
                        Debug.Assert(false);
                        break;
                }
            }
                

            // add to the tree
            this.pTree.Add(pShield);

            // Attached to Group
            pShield.ActivateSprite(this.pSpriteBatchName);
            pShield.ActivateCollisionSprite(this.pCollisionSpriteBatchName);

            return pShield;
        }

        public static GameObject CreateSingleShield(GameObject.Name shieldGridName, float startX = 91.0f, float startY = 190.0f, float width = 2.5f, float height = 5.0f)
        {

            ShieldFactory pFactory = ShieldFactory.privInstance();

            ShieldRoot pShieldRoot = (ShieldRoot)GameObjectNodeMan.Find(GameObject.Name.ShieldRoot);
            if (pShieldRoot == null)
            {
                pShieldRoot = new ShieldRoot(GameObject.Name.ShieldRoot, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            }
            GameObjectNodeMan.Attach(pShieldRoot);

            pFactory.privSet(SpriteBatch.Name.Shields, SpriteBatch.Name.Boxes, pShieldRoot);

            int i = 0;
            int j = 0;

            // create a grid
            pFactory.privSetParent(pShieldRoot);
            GameObject pGrid = pFactory.privCreate(ShieldBase.Type.Grid, shieldGridName);
            GameObject pColumn;

            pFactory.privSetParent(pGrid);
            pColumn = pFactory.privCreate(ShieldBase.Type.Column, GameObject.Name.ShieldColumn_0 + i++);
            pFactory.privSetParent(pColumn);
            // /_|
            // |_|
            // |_|
            // |_|
            // |_|
            pFactory.privCreate(ShieldBase.Type.LeftTop0, GameObject.Name.ShieldBrickLeftTop, (startX + (width*i)), (startY - (height*(j++))));     
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width * i)), (startY - (height * (j++))));           
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width*i)), (startY - (height * (j++))));             
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width*i)), (startY - (height * (j++))));             
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width * i)), (startY - (height * (j++))));           

            pFactory.privSetParent(pGrid);
            pColumn = pFactory.privCreate(ShieldBase.Type.Column, GameObject.Name.ShieldColumn_0 + i++);
            pFactory.privSetParent(pColumn);

            j = 0;
            // |_|
            // |_|
            // |_|
            // |_|
            // |_|
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width*i)), (startY - (height * (j++)))); 
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width*i)), (startY - (height * (j++)))); 
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width*i)), (startY - (height * (j++)))); 
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width*i)), (startY - (height * (j++))));
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width * i)), (startY - (height * (j++))));

            pFactory.privSetParent(pGrid);
            pColumn = pFactory.privCreate(ShieldBase.Type.Column, GameObject.Name.ShieldColumn_0 + i++);
            pFactory.privSetParent(pColumn);

            j = 0;
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width*i)), (startY - (height * (j++))));        // |_|
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width*i)), (startY - (height * (j++))));        // |_|
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width * i)), (startY - (height * (j++))));        // |_|
            pFactory.privCreate(ShieldBase.Type.LeftBottom, GameObject.Name.ShieldBrickLeftBottom, (startX + (width * i)), (startY - (height * (j++))));        // |/
                                                                                                       // 
            pFactory.privSetParent(pGrid);
            pColumn = pFactory.privCreate(ShieldBase.Type.Column, GameObject.Name.ShieldColumn_0 + i++);
            pFactory.privSetParent(pColumn);

            j = 0;
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width*i)), (startY - (height * (j++))));   // |_|
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width*i)), (startY - (height * (j++))));   // |_|
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width * i)), (startY - (height * (j++))));   // |_|

            pFactory.privSetParent(pGrid);
            pColumn = pFactory.privCreate(ShieldBase.Type.Column, GameObject.Name.ShieldColumn_0 + i++);
            pFactory.privSetParent(pColumn);

            j = 0;
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width*i)), (startY - (height * (j++))));          // |_|
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width*i)), (startY - (height * (j++))));          // |_|
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width * i)), (startY - (height * (j++))));          // |_|
            pFactory.privCreate(ShieldBase.Type.RightBottom, GameObject.Name.ShieldBrickRightBottom, (startX + (width * i)), (startY - (height * (j++))));          //  \|

            pFactory.privSetParent(pGrid);
            pColumn = pFactory.privCreate(ShieldBase.Type.Column, GameObject.Name.ShieldColumn_0 + i++);
            pFactory.privSetParent(pColumn);

            j = 0;
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width*i)), (startY - (height * (j++))));          // |_|
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width*i)), (startY - (height * (j++))));          // |_|
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width*i)), (startY - (height * (j++))));          // |_|
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width*i)), (startY - (height * (j++))));          // |_|
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width * i)), (startY - (height * (j++))));          // |_|

            pFactory.privSetParent(pGrid);
            pColumn = pFactory.privCreate(ShieldBase.Type.Column, GameObject.Name.ShieldColumn_0 + i++);
            pFactory.privSetParent(pColumn);

            j = 0;
            pFactory.privCreate(ShieldBase.Type.RightTop0, GameObject.Name.ShieldBrickRightTop, (startX + (width * i)), (startY - (height * (j++))));      // |\
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width*i)), (startY - (height * (j++))));          // |_|
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width*i)), (startY - (height * (j++))));          // |_|
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width*i)), (startY - (height * (j++))));          // |_|
            pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, (startX + (width * i)), (startY - (height * (j++))));          // |_|







        //   ShieldFactory pFactory = ShieldFactory.privInstance();
        //
        //   ShieldRoot pShieldRoot = (ShieldRoot)GameObjectNodeMan.Find(GameObject.Name.ShieldRoot);
        //   if (pShieldRoot == null)
        //   {
        //       pShieldRoot = new ShieldRoot(GameObject.Name.ShieldRoot, SpriteGame.Name.NullObject, 0.0f, 0.0f);
        //   }
        //   GameObjectNodeMan.Attach(pShieldRoot);
        //   pFactory.privSet(SpriteBatch.Name.Shields, SpriteBatch.Name.Boxes, pShieldRoot);
        //   // create a grid
        //   GameObject pGrid = pFactory.privCreate(ShieldBase.Type.Grid, GameObject.Name.ShieldGrid);
        //   int j = 0;
        //   GameObject pColumn;
        //
        //   pFactory.privSetParent(pGrid);
        //   pColumn = pFactory.privCreate(ShieldBase.Type.Column, GameObject.Name.ShieldColumn_0 + j++);
        //   pFactory.privSetParent(pColumn);
        //  
        //   pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y);
        //   pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + brickHeight);
        //   pFactory.privCreate(ShieldBase.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 2 * brickHeight);

            return pShieldRoot;
        }

        private static ShieldFactory privInstance()
        {
            if (pInstance == null)
            {
                ShieldFactory.pInstance = new ShieldFactory();
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

        private static ShieldFactory pInstance = null;
    }
}

// --- End of File ---
