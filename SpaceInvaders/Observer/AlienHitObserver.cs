//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienHitObserver : ColObserver
    {
        public AlienHitObserver()
        {
            //this.pMissile = null;
        }

        public AlienHitObserver(AlienHitObserver m)
        {
            this.pAlien = m.pAlien;
            this.pAlienColumn = m.pAlienColumn;
        }

        public override void Notify()
        {
            Debug.WriteLine("AlienHitObserver: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

           /* Missile pMissile = (Missile)this.pSubject.pObjA;
            pMissile.SetActive(false);
            pMissile.SetPos(-10.0f, -10.0f);*/

            ShipMan.GetShip().SetState(ShipMan.MissileState.Ready);

            this.pAlien = this.pSubject.pObjB;
            ((AlienBase)this.pAlien).MissileHit();

            this.pAlienColumn = (GameObject)((AlienBase)this.pAlien).pParent;

            //TO REMOVE MISSILE
            //Debug.WriteLine("AlienHitObserver: --> delete alien {0}", this.pAlien);

            AlienDieCmd pCommand = new AlienDieCmd((AlienBase)this.pAlien, this);
            TimerEventMan.Add(TimerEvent.Name.AlienDieCmd, pCommand, 0.3f);

            

        }

        public override void Execute()
        {
            //  if this brick removed the last child in the column, then remove column
            //Debug.WriteLine(" brick {0}  parent {1}", this.pBrick, this.pBrick.pParent);
            //  if this brick removed the last child in the column, then remove column
            // Debug.WriteLine(" brick {0}  parent {1}", this.pBrick, this.pBrick.pParent);
            GameObject pA = (GameObject)this.pAlien;
            if (pA.GetType().Name == "UFO")
            {
                ((UFO)pA).isActive = false;
                pA.Remove();
                SoundMan.Stop();
                return;
            }
            GameObject pB = (GameObject)IteratorForwardComposite.GetParent(pA);
            GameObject pC = (GameObject)IteratorForwardComposite.GetParent(pB);

            // Root - do not delete
            //GameObject pD = (GameObject)IteratorForwardComposite.GetParent(pC);

            ScoreMan.AlienHit((AlienBase)pA);
            ((AlienGrid)pC).UpdateSpeed();

            
            {
                // Alien
                if (pA.GetNumChildren() == 0)
                {
                    pA.Remove();
                }

                // Column 
                if (pB.GetNumChildren() == 0)
                {
                    pB.Remove();
                }

                // Grid 
                if (pC.GetNumChildren() == 0)
                {
                    pC.Remove();
                    /*((AlienGrid)pC).x = -10.0f;
                    ((AlienGrid)pC).y = -10.0f;*/
                    //NEW LEVEL
                    AlienFactory.CreateSingleAlienRow(true);

                }
            }
            
        }


        override public void Dump()
        {
        //    Debug.Assert(false);
        }
        override public System.Enum GetName()
        {
            return Name.AlienHitObserver;
        }

        // data
        private GameObject pAlien;
        private GameObject pAlienColumn;


    }
}

// --- End of File ---
