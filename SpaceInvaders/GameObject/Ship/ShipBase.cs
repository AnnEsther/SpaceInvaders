//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class ShipBase : Leaf
    {
        public enum Type
        {
            Ship,
            ShipRoot,
            Unitialized
        }

        protected ShipBase(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY, ShipBase.Type shipType)
            : base(name, spriteName, posX, posY)
        {
            this.ShipType = shipType;
        }

        // Data: ---------------
        ~ShipBase()
        {
        }

        // this is just a placeholder, who knows what data will be stored here
        protected ShipBase.Type ShipType;

    }
}

// --- End of File ---
