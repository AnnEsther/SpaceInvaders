//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class DrawAlienCmd : Command
    {
      
        public DrawAlienCmd(GameObject.Name _typeName, float _posX, float _posY)
        {
            // string only here for testing purposes
            this.typeName = _typeName;
            this.posX = _posX;
            this.posY = _posY;
        }

        public override void Execute(float deltaTime)
        {
            GameObject pGameObj = null;
            SpriteGame pSprite = null;
            switch (this.typeName)
            {
                case GameObject.Name.Squid:
                    pGameObj = new Alien_Squid(SpriteGame.Name.SquidA, this.posX, this.posY);
                    pSprite = SpriteGameMan.Find(SpriteGame.Name.SquidA);
                    break;
                case GameObject.Name.Crab:
                    pGameObj = new Alien_Crab(SpriteGame.Name.CrabA, this.posX, this.posY);
                    pSprite = SpriteGameMan.Find(SpriteGame.Name.CrabA);
                    break;
                case GameObject.Name.Octopus:
                    pGameObj = new Alien_Octopus(SpriteGame.Name.OctopusA, this.posX, this.posY);
                    pSprite = SpriteGameMan.Find(SpriteGame.Name.OctopusA);
                    break;
                case GameObject.Name.UFO:
                    pGameObj = new UFO(SpriteGame.Name.Saucer, this.posX, this.posY, true);
                    pSprite = SpriteGameMan.Find(SpriteGame.Name.Saucer);
                    break;
            }
            pGameObj.ActivateSprite(SpriteBatch.Name.ScoreSceneAlien);
            GameObject pRoot = GameObjectNodeMan.Find(GameObject.Name.UFORoot);
            pRoot.Add(pGameObj);
        }

        private GameObject.Name typeName;
        private float posX;
        private float posY;
    }
}

// --- End of File ---
