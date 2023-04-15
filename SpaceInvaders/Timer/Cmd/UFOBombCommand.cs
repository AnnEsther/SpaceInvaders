//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class UFOBombCommand : Command
    {

        public UFOBombCommand(GameObject _pUFO, float deltaRepeatTime)
        {
            
            this.repeatDelta = deltaRepeatTime;

            pBombRoot =  GameObjectNodeMan.Find(GameObject.Name.BombRoot);
            Debug.Assert(this.pBombRoot != null);
            
            this.pUFO = _pUFO;
        }

        public override void Execute(float deltaTime)
        {
            
            // Attach the missile to the Bomb root
            GameObject pBombRoot = GameObjectNodeMan.Find(GameObject.Name.BombRoot);
            Debug.Assert(pBombRoot != null);


            /*
            GameObjectNode pGameObjNode = GhostMan.Find(_bombName);
            if (pGameObjNode != null)
                {
                    pBomb = (Bomb)pGameObjNode.pGameObj;
                    GhostMan.Remove(pGameObjNode);
                    pBomb.Resurrect(pAlien.x, pAlien.y);
                }
                else
                { }*/

            Bomb pBomb = new Bomb(GameObject.Name.Plunger, SpriteGame.Name.PlungerShotB, new FallZigZag(), this.pUFO.x, this.pUFO.y);

            pBomb.ActivateCollisionSprite(SpriteBatch.Name.Boxes);
            pBomb.ActivateSprite(SpriteBatch.Name.Bombs);
            pBombRoot.Add(pBomb);
            //Debug.WriteLine("BOMB ADDED\n");
            pBomb.pSpawnColumn = null;

            if(((UFO)this.pUFO).isActive == true)
            {
                TimerEventMan.Add(TimerEvent.Name.BombCommand, this, this.repeatDelta);
            }

            
        }

        private float repeatDelta;
        GameObject pBombRoot;
        GameObject pUFO;
    }
}

// --- End of File ---
