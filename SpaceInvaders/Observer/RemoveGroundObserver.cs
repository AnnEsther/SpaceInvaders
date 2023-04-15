//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//-----------------------------------------------------------------------------
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class RemoveGroundObserver : ColObserver
    {
        public RemoveGroundObserver()
        {
            this.pGround = null;
        }
        public RemoveGroundObserver(RemoveGroundObserver b)
        {
            Debug.Assert(b != null);
            this.pGround = b.pGround;
        }

        public override void Notify()
        {

            this.pGround = (Ground)this.pSubject.pObjB;
            Debug.Assert(this.pGround != null);

            if (pGround.bMarkForDeath == false)
            {
                pGround.bMarkForDeath = true;
                //   Delay
                RemoveGroundObserver pObserver = new RemoveGroundObserver(this);
                DelayedObjectMan.Attach(pObserver);
            }
        }
        public override void Execute()
        {
            this.pGround.Remove();
        }
      
        override public void Dump()
        {

        }
        override public System.Enum GetName()
        {
            return ColObserver.Name.RemoveGroundObserver;
        }



        // -------------------------------------------
        // data:
        // -------------------------------------------

        private Ground pGround;
    }
}

// --- End of File ---
