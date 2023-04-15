//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class UFO : AlienBase
    {
        public UFO(SpriteGame.Name spriteName, float posX, float posY)
        : base(GameObject.Name.UFO, spriteName, posX, posY)
        {
            isActive = false;
            this.delta = -1.0f;
            this.moveToLeft = true;
        }
        override public System.Enum GetName()
        {
            return AlienBase.Name.UFO;
        }

        public override void Update()
        {
            if(isActive)
            {
                this.x += this.delta;
                if(this.moveToLeft && this.x == -25.0f) // END Conditions
                {
                    this.delta *= -1;
                    this.moveToLeft = false;
                    isActive = false;
                }
                else if(this.x == 700.0f)
                {
                    this.delta *= -1;
                    this.moveToLeft = true;
                    isActive = false;
                }
            }
            base.Update();
        }

        public override void Move()
        {
            /*this.x += _x;
            this.y += _y;*/
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an GreenBird
            // Call the appropriate collision reaction            
            other.VisitUFO(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }


        // Data: ---------------
        public bool isActive;
        public bool moveToLeft;
        float delta;

    }
}

// --- End of File ---
