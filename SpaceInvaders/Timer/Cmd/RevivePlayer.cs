//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class RevivePlayer : Command
    {

        
        public RevivePlayer()
        {
        }

        public override void Execute(float deltaTime)
        {
            ShipMan.ReActivateShip();
            ShipMan.GetShip().SetState(ShipMan.MissileState.Ready);
            /* TimerEventMan.Pause(false);*/
        }
    }
}

// --- End of File ---
