//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipMissileReady : ShipMissileState
    {

        public override void ShootMissile(Ship pShip)
        {
            Missile pMissile = ShipMan.ActivateMissile();
            pMissile.SetPos(pShip.x, pShip.y + 20);
            SoundMan.PlayPlayerShootSound();

            pShip.SetState(ShipMan.MissileState.Flying);
        }

    }
}

// --- End of File ---
