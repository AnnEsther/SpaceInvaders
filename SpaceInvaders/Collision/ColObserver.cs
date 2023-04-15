//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{

    abstract public class ColObserver : SLink
    {
        //------------------------------------
        // Enum
        //------------------------------------
        public enum Name
        {
            SoundObserver,
            GridObserver,
            ShipReadyObserver,
            ShipRemoveMissileObserver,
            ShipMoveObserver,
            AlienHitObserver,
            BombObserver,
            RemoveBrickObserver,
            RemoveMissileObserver,
            RemoveBombObserver,
            PlayerHitObserver,
            RemoveGroundObserver,
            Uninitialized
        }
        public abstract void Notify();
        override public void Wash()
        {
            Debug.Assert(false);
        }

        // WHY not add a Command pattern into our Observer!
        public virtual void Execute()
        {
            // default implementation
        }

        public ColSubject pSubject;
    }

}

// --- End of File ---
