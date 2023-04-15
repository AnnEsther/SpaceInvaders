//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PlayerDieCmd : Command
    {

        
        public PlayerDieCmd(PlayerHitObserver playerHitObserver)
        {
            this.pPlayerHitObserver = playerHitObserver;
        }

        public override void Execute(float deltaTime)
        {
            Ship pShip = ShipMan.GetShip(); ;
            if (pShip.bMarkForDeath == false)
            {
                pShip.bMarkForDeath = true;
                PlayerHitObserver pObserver = new PlayerHitObserver(this.pPlayerHitObserver);
                DelayedObjectMan.Attach(pObserver);
            }
        }
       

        private PlayerHitObserver pPlayerHitObserver;
    }
}

// --- End of File ---
