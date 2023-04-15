//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Alien_Crab : AlienBase
    {
        public Alien_Crab(SpriteGame.Name spriteName, float posX, float posY)
        : base(GameObject.Name.Crab, spriteName, posX, posY)
        {
            
        }
        public override void SetColor()
        {
            this.UpdateColor(new Azul.Color(0.85f, 0.8f, 0.58f));
        }
        override public System.Enum GetName()
        {
            return AlienBase.Name.Crab;
        }

        public override void Update()
        {
           /* this.x += this.delta;
            this.cnt++;

            if (this.cnt == 100)
            {
                this.delta *= -1.0f;
            }*/

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
            other.VisitAlienCrab(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            // Bird vs MissileGroup
            //Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            // Missile vs Bird
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }


        // Data: ---------------

    }
}

// --- End of File ---
