//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class LifeMan
    {
        private LifeMan()
        {
            this.lifes = 3;

            this.pLifeFont = FontMan.Add(Font.Name.Life, SpriteBatch.Name.Texts, this.lifes.ToString(), Glyph.Name.SpaceInvaders, 25, 30);
            this.pLifeFont.SetScale(3.0f);
            //this.AddDisplay();
        }

        private static LifeMan privInstance()
        {
            if (instance == null)
            {
                instance = new LifeMan();
            }
            return instance;
        }

        public static void Create()
        {
            // Do the initialization
            if (instance == null)
            {
                instance = new LifeMan();
            }
            Debug.Assert(instance != null);
        }

        public static void Destroy()
        {
            instance = null;
        }

        public static void UpdateLife()
        {
            LifeMan pMan = LifeMan.privInstance();
            pMan.lifes--;
            pMan.pLifeFont.UpdateMessage(pMan.lifes.ToString());
            switch(pMan.lifes)
            {
                case 2:
                    pMan.pReserveShip_3.Remove();
                    break;
                case 1:
                    pMan.pReserveShip_2.Remove();
                    break;
                case 0:
                    pMan.pReserveShip_1.Remove();
                    //CHANGE SCENE
                    GameOverCommand pCommand = new GameOverCommand();
                    TimerEventMan.Add(TimerEvent.Name.GameOverCommand, pCommand, 1.0f);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
        }
        public static bool isPlayerDead()
        {
            return (LifeMan.privInstance().lifes == 0);
        }
        public static void Reset()
        {
            LifeMan pMan = LifeMan.privInstance();
            pMan.lifes = 3;
            pMan.AddDisplay();
        }
        public void AddDisplay()
        {
            LifeMan pMan = LifeMan.privInstance();
            ReserveShipRoot pReserveRoot = new ReserveShipRoot(GameObject.Name.ReserveShipRoot, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            GameObjectNodeMan.Attach(pReserveRoot);

            pMan.pReserveShip_1 = (ReserveShip)pMan.CreateReserveShips(GameObject.Name.ReserveShip1, SpriteGame.Name.Player, 88.0f, 33.0f);
            pMan.pReserveShip_2 = (ReserveShip)pMan.CreateReserveShips(GameObject.Name.ReserveShip2, SpriteGame.Name.Player, 133.0f, 33.0f);
            pMan.pReserveShip_3 = (ReserveShip)pMan.CreateReserveShips(GameObject.Name.ReserveShip3, SpriteGame.Name.Player, 178.0f, 33.0f);

            pReserveRoot.Add(pMan.pReserveShip_1);
            pReserveRoot.Add(pMan.pReserveShip_2);
            pReserveRoot.Add(pMan.pReserveShip_3);

            pMan.pLifeFont.UpdateMessage(pMan.lifes.ToString());

        }

        private GameObject CreateReserveShips(GameObject.Name gameName, SpriteGame.Name spriteName, float posX, float posY)
        {
            GameObject pReserveShip = null;
            GameObjectNode pGameObjNode = GhostMan.Find(gameName);
            if (pGameObjNode != null)
            {
                pReserveShip = pGameObjNode.pGameObj;
                GhostMan.Remove(pGameObjNode);

                ((ReserveShip)pReserveShip).Resurrect();
                pReserveShip.x = posX;
                pReserveShip.y = posY;
                //pReserveShip.UpdateColor(new Azul.Color(0.85f, 0.8f, 0.58f));
            }
            else
            {
                pReserveShip = new ReserveShip(gameName, spriteName, posX, posY);
               
            }
            pReserveShip.ActivateSprite(SpriteBatch.Name.LifeMan);
            pReserveShip.ActivateCollisionSprite(SpriteBatch.Name.Boxes);

            return pReserveShip;
        }

        // Data: ----------------------------------------------
        private static LifeMan instance = null;
        private int lifes;
        private ReserveShip pReserveShip_1;
        private ReserveShip pReserveShip_2;
        private ReserveShip pReserveShip_3;
        private Font pLifeFont;


    }
}

// --- End of File ---
