//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BombCommand : Command
    {

        public BombCommand(AlienRoot _pAlienRoot, float deltaRepeatTime, GameObject _pUFO = null)
        {
            // string only here for testing purposes
            this.isUFO = true;
            if (_pAlienRoot != null)
            {
                this.pAlienGrid = (AlienGrid)_pAlienRoot.GetHead();
                this.isUFO = false;
            }
            
            this.repeatDelta = deltaRepeatTime;
            this.pRandomColumn = new Random();
            this.pRandomBomb = new Random();

            pBombRoot =  GameObjectNodeMan.Find(GameObject.Name.BombRoot);
            Debug.Assert(this.pBombRoot != null);

            
            this.pUFO = _pUFO;
        }

        public override void Execute(float deltaTime)
        {
            GameObject pAlien = null;
            AlienColumn pAlienColumn = null;

            if (!this.isUFO)
            {
                int activeColumns = this.pAlienGrid.getNumOfActiveColumns();

                if (activeColumns == 0)
                {
                    TimerEventMan.Add(TimerEvent.Name.BombCommand, this, this.repeatDelta);
                    return;
                }

                int randomColumn = pRandomColumn.Next(0, activeColumns);

                pAlienColumn = this.pAlienGrid.getNthActiveColumn(randomColumn);
                pAlienColumn.bombActive = true;
                pAlien = pAlienColumn.getBottomAlien();
            }
            else
            {
                if(((UFO)this.pUFO).isActive == false)
                {
                   // Debug.WriteLine("BOMB STOPPED\n");
                    return;
                }
                pAlien = this.pUFO;
            }

            // Attach the missile to the Bomb root
            GameObject pBombRoot = GameObjectNodeMan.Find(GameObject.Name.BombRoot);
            Debug.Assert(pBombRoot != null);

            //Randomize which bomb
            int bombType = pRandomBomb.Next(0, 3);
            GameObject.Name _bombName = GameObject.Name.Uninitialized;
            switch (bombType)
            {
                case 0:
                    _bombName = GameObject.Name.Rolling;
                    break;
                case 1:
                    _bombName = GameObject.Name.Swiggly;
                    break;
                case 2:
                    _bombName = GameObject.Name.Plunger;
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            GameObjectNode pGameObjNode = GhostMan.Find(_bombName);
            /*if (pGameObjNode != null)
                {
                    pBomb = (Bomb)pGameObjNode.pGameObj;
                    GhostMan.Remove(pGameObjNode);
                    pBomb.Resurrect(pAlien.x, pAlien.y);
                }
                else
                { }*/
            Bomb pBomb = null;
            switch (bombType)
            {
                case 0:
                    pBomb = new Bomb(_bombName, SpriteGame.Name.RollingShotA, new FallStraight(), pAlien.x, pAlien.y);
                    break;
                case 1:
                    pBomb = new Bomb(_bombName, SpriteGame.Name.SquigglyShotA, new FallDagger(), pAlien.x, pAlien.y);
                    break;
                case 2:
                    pBomb = new Bomb(_bombName, SpriteGame.Name.PlungerShotA, new FallZigZag(), pAlien.x, pAlien.y);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            pBomb.ActivateCollisionSprite(SpriteBatch.Name.Boxes);
            pBomb.ActivateSprite(SpriteBatch.Name.Bombs);
            pBombRoot.Add(pBomb);
            //Debug.WriteLine("BOMB ADDED\n");
            pBomb.pSpawnColumn = pAlienColumn;


            if(!this.isUFO)
            {
                TimerEventMan.Add(TimerEvent.Name.BombCommand, this, this.repeatDelta);
            }





               
                
                
            
        }

        private AlienGrid pAlienGrid;
        private float repeatDelta;
        Random pRandomColumn;
        Random pRandomBomb;
        GameObject pBombRoot;
        bool isUFO;
        GameObject pUFO;
    }
}

// --- End of File ---
