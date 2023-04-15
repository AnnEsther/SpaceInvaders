//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipMoveObserver : ColObserver
    {
        public override void Notify()
        {
            Ship pShip = ShipMan.GetShip();

            BumperBase pBumper = (BumperBase)this.pSubject.pObjA;
            if (pBumper.GetCategoryType() == BumperBase.Type.Left)
            {
                pShip.SetState(ShipMan.MoveState.MoveRight);
            }
            else if (pBumper.GetCategoryType() == BumperBase.Type.Right)
            {
                pShip.SetState(ShipMan.MoveState.MoveLeft);
            }
        }
        override public void Dump()
        {
            Debug.Assert(false);
        }
        override public System.Enum GetName()
        {
            return Name.ShipMoveObserver;
        }
    }

    // data
}

// --- End of File ---
