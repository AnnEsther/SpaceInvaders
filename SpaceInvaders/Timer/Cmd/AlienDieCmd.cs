//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienDieCmd : Command
    {

        
        public AlienDieCmd(AlienBase _pAlien, AlienHitObserver alienHitObserver)
        {
            this.pAlien = _pAlien;
            this.pAlienHitObserver = alienHitObserver;
        }

        public override void Execute(float deltaTime)
        {
            if (this.pAlien.bMarkForDeath == false)
            {
                this.pAlien.bMarkForDeath = true;

                // Delay - remove object later
                // TODO - reduce the new functions
                AlienHitObserver pObserver = new AlienHitObserver(this.pAlienHitObserver);
                DelayedObjectMan.Attach(pObserver);
            }
        }

       

        private AlienBase pAlien;
        private AlienHitObserver pAlienHitObserver;
    }
}

// --- End of File ---
