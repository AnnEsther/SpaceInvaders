using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class AlienFactory
    {
        private AlienFactory()
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
        ~AlienFactory()
        {
        }
        private GameObject privCreate(AlienBase.Type type, GameObject.Name gameName, float posX = 0.0f, float posY = 0.0f)
        {
            GameObjectNode pGameObjNode = GhostMan.Find(gameName);
            GameObject pGameObj = null;
            if(pGameObjNode != null)
            {
                pGameObj = pGameObjNode.pGameObj;
                GhostMan.Remove(pGameObjNode);

               // ((AlienBase)pGameObj).Resurrect(posX, posY);

                switch (type)
                {
                    case AlienBase.Type.Squid:
                    case AlienBase.Type.Crab:
                    case AlienBase.Type.Octopus:
                    /*case AlienBase.Type.UFO:*/
                        ((AlienBase)pGameObj).Resurrect();
                        pGameObj.x = posX;
                        pGameObj.y = posY;
                        break;
                    case AlienBase.Type.AlienGrid:
                        ((AlienGrid)pGameObj).Resurrect();
                        break;

                    case AlienBase.Type.AlienColumn:
                        ((AlienColumn)pGameObj).Resurrect();
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
                    case AlienBase.Type.Squid:
                        pGameObj = new Alien_Squid(SpriteGame.Name.SquidA, posX, posY);

                        break;
                    case AlienBase.Type.Crab:
                        pGameObj = new Alien_Crab(SpriteGame.Name.CrabA, posX, posY);

                        break;
                    case AlienBase.Type.Octopus:
                        pGameObj = new Alien_Octopus(SpriteGame.Name.OctopusA, posX, posY);

                        break;
                    case AlienBase.Type.AlienGrid:
                        pGameObj = new AlienGrid();
                        break;

                    case AlienBase.Type.AlienColumn:
                        pGameObj = new AlienColumn();
                        break;

                    /*case AlienBase.Type.UFO:
                        pGameObj = new UFO(SpriteGame.Name.Saucer, posX, posY);
                        break;*/

                    default:
                        // something is wrong
                        Debug.Assert(false);
                        break;
                }
            }

            // add to the tree
            this.pTree.Add(pGameObj);

            // Attached to Group
            pGameObj.ActivateSprite(this.pSpriteBatchName);
            pGameObj.ActivateCollisionSprite(this.pCollisionSpriteBatchName);

            return pGameObj;
        }
        private static AlienFactory privInstance()
        {
            if (pInstance == null)
            {
                AlienFactory.pInstance = new AlienFactory();
            }

            Debug.Assert(pInstance != null);

            return pInstance;
        }
        public static GameObject CreateSingleAlienRow(bool updateLevel = false)
        {
            AlienFactory pFactory = AlienFactory.privInstance();

            Composite pAlienRoot = null;
            GameObject pGameObjNode = GameObjectNodeMan.Find(GameObject.Name.AlienRoot);
            if (pGameObjNode == null)
            {
                pAlienRoot = (Composite)new AlienRoot(GameObject.Name.AlienRoot, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            }
            else
            {
                pAlienRoot = (Composite)pGameObjNode;
            }
            GameObjectNodeMan.Attach(pAlienRoot);

            pFactory.privSet(SpriteBatch.Name.AlienBatch, SpriteBatch.Name.Boxes, pAlienRoot);
            
            // create a grid
            GameObject pGrid = pFactory.privCreate(AlienBase.Type.AlienGrid, GameObject.Name.AlienGrid);
            GameObject pColumn;

            float posYstart = 600.0f;
            if(updateLevel)
            {
                posYstart -= 50.0f;
            }
            float posY;
            for (int i = 0; i < 11; i++)
            {
                posY = posYstart;

                pFactory.privSetParent(pGrid);
                pColumn = pFactory.privCreate(AlienBase.Type.AlienColumn, GameObject.Name.AlienColumn);
                pFactory.privSetParent(pColumn);

                pFactory.privCreate(AlienBase.Type.Squid, GameObject.Name.Squid,     86.0f + i * 50.0f, posY);
                posY -= 50.0f;

                pFactory.privCreate(AlienBase.Type.Crab, GameObject.Name.Crab,       86.0f + i * 50.0f, posY);
                posY -= 50.0f;

                pFactory.privCreate(AlienBase.Type.Crab, GameObject.Name.Crab,       86.0f + i * 50.0f, posY);
                posY -= 50.0f;

                pFactory.privCreate(AlienBase.Type.Octopus, GameObject.Name.Octopus, 86.0f + i * 50.0f, posY);
                posY -= 50.0f;

                pFactory.privCreate(AlienBase.Type.Octopus, GameObject.Name.Octopus, 86.0f + i * 50.0f, posY);
                posY -= 50.0f;


            }

            pGrid.UpdateBoxColor(0.0f, 1.0f, 0.0f);

            return pAlienRoot;

        }

        // Data: ---------------------

        private SpriteBatch.Name pSpriteBatchName;
        private SpriteBatch.Name pCollisionSpriteBatchName;

        private Composite pTree;
        private static AlienFactory pInstance = null;
    }
}
