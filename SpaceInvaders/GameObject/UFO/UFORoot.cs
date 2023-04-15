//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class UFORoot : Composite
    {
        public UFORoot(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

        }
        ~UFORoot()
        {
        }
        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitUFORoot(this);
        }
      
        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }
        public override void VisitBombRoot(BombRoot b)
        {
            // BombRoot vs AlienRoot
            ColPair.Collide((GameObject)IteratorForwardComposite.GetChild(b), this);
        }
        public override void VisitBomb(Bomb b)
        {
            // Missile vs AlienRoot
            ColPair.Collide(b, (GameObject)IteratorForwardComposite.GetChild(this));
        }
        public override void VisitMissileGroup(MissileGroup m)
        {
            // BirdGroup vs MissileGroup
            //Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            if(this.GetNumChildren() == 0)
            {
                //HACK
            }
            else
            {
                // MissileGroup vs Columns
                GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
                ColPair.Collide(m, pGameObj);
            }
            
        }
        public override void VisitMissile(Missile m)
        {
            if (this.GetNumChildren() != 0)
            {
                // Missile vs AlienRoot
                GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
                ColPair.Collide(m, pGameObj);
            }
            else
            {
               // Debug.WriteLine("Shouldnt be here \n");
            }

        }


        // ------------------------------------------
        // Data:
        // ------------------------------------------


    }
}

// --- End of File ---
