//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ReserveShipBase : Leaf
    {
        public enum Type
        {
            Ship,
            ShipRoot,
            Unitialized
        }
        protected ReserveShipBase(GameObject.Name gameName, SpriteGame.Name spriteName, float x, float y, ReserveShipBase.Type shipType)
            : base(gameName,spriteName, x, y)
        {
            this.ShipType = shipType;
        }

        public override void Remove()
        {
            // Since the Root object is being drawn
            // 1st set its size to zero
            this.poColObj.poColRect.Set(0, 0, 0, 0);

            base.Update();
            // Now remove it
            base.Remove();
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void Accept(ColVisitor other)
        {
            throw new NotImplementedException();
        }

        // Data: --------------------
        protected ReserveShipBase.Type ShipType;
    }
}

// --- End of File ---
