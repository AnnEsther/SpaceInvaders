//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BirdFactory
    {
        public BirdFactory(SpriteBatch.Name spriteBatchName)
        {
            this.pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);
        }
       

        public void Create(BirdBase.Type type, float posX, float posY)
        {
            GameObject pGameObj = null;

            switch (type)
            {
                case BirdBase.Type.Green:
                    pGameObj = new BirdGreen(SpriteGame.Name.Bird_Green, posX, posY);
                    break;

                case BirdBase.Type.Red:
                    pGameObj = new BirdRed(SpriteGame.Name.Bird_Red, posX, posY);
                    break;

                case BirdBase.Type.White:
                    pGameObj = new BirdWhite(SpriteGame.Name.Bird_White, posX, posY);
                    break;

                case BirdBase.Type.Yellow:
                    pGameObj = new BirdYellow(SpriteGame.Name.Bird_Yellow, posX, posY);
                    break;

                default:
                    // something is wrong
                    Debug.Assert(false);
                    break;
            }

            // add it to the gameObjectManager
            Debug.Assert(pGameObj != null);
            GameObjectNodeMan.Attach(pGameObj);

            // Attached to Group
            this.pSpriteBatch.Attach(pGameObj);
        }

        // Data: ---------------------

        SpriteBatch pSpriteBatch;
    }
}

// --- End of File ---
