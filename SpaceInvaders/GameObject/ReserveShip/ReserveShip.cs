//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ReserveShip : ReserveShipBase
    {
        public ReserveShip(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY)
                : base(name, spriteName, posX, posY, ReserveShipBase.Type.Ship)
        {
            this.x = posX;
            this.y = posY;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        

    }
}

// --- End of File ---
