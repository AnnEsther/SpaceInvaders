//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//-----------------------------------------------------------------------------
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class RemoveMissileObserver : ColObserver
    {
        public RemoveMissileObserver()
        {
            this.pMissile = null;
        }
        public RemoveMissileObserver(RemoveMissileObserver m)
        {
            this.pMissile = m.pMissile;
        }
        public override void Notify()
        {

            Ship pShip = ShipMan.GetShip();
            pShip.SetState(ShipMan.MissileState.Ready);

            // Delete missile
            //Debug.WriteLine("RemoveMissileObserver: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            /* Missile pMissile = (Missile)this.pMissile;
             pMissile.SetActive(false);
             pMissile.SetPos(-10.0f, -10.0f);*/
            if(this.pSubject.pObjA.GetType().Name == "Missile")
            {
                this.pMissile = (Missile)this.pSubject.pObjA;
            }
            else
            {
                this.pMissile = (Missile)this.pSubject.pObjB;
            }

           // this.pMissile = (Missile)this.pSubject.pObjA;
            ((Missile)this.pMissile).SetActive(false);
            ((Missile)this.pMissile).SetPos(-10.0f, -10.0f);
            Debug.Assert(this.pMissile != null);

            if (this.pMissile.bMarkForDeath == false)
            {
                this.pMissile.bMarkForDeath = true;
                //   Delay
                RemoveMissileObserver pObserver = new RemoveMissileObserver(this);
                DelayedObjectMan.Attach(pObserver);
            }
            if (this.pSubject.pObjB.GetType().Name != "WallTop")
            {
                SoundMan.PlayExplosionSound();
            }

        }
        public override void Execute()
        {
            // Let the gameObject deal with this... 
            this.pMissile.Remove();
        }

        override public void Dump()
        {

        }
        override public System.Enum GetName()
        {
            return ColObserver.Name.RemoveMissileObserver;
        }

        // --------------------------------------
        // data:
        // --------------------------------------

        private GameObject pMissile;
    }
}

// --- End of File ---
