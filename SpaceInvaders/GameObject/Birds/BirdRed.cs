﻿//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BirdRed : BirdBase
    {
        public BirdRed(SpriteGame.Name spriteName, float posX, float posY)
        : base(GameObject.Name.RedBird, spriteName, posX, posY)
        {
        }
        public override void Update()
        {
            this.y += 1.0f;
            if (this.y > 600.0f)
            {
                this.y = 0.0f;
            }
            base.Update();
        }
        // Data: ---------------

    }
}

// --- End of File ---
