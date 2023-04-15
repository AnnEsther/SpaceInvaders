//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Alien_Octopus : AlienBase
    {
        public Alien_Octopus(SpriteGame.Name spriteName, float posX, float posY)
        : base(GameObject.Name.Octopus, spriteName, posX, posY)
        {
            
        }
        public override void SetColor()
        {
            this.UpdateColor(new Azul.Color(0.75f, 0.41f, 0.37f));
        }
        override public System.Enum GetName()
        {
            return AlienBase.Name.Octopus;
        }
        public override void Update()
        {
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
            other.VisitAlienOctopus(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            // Bird vs MissileGroup
            //Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            // Missile vs Bird
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }
       
       /* public override void VisitMissile(Missile m)
        {
            // Bird vs Missile
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            // Missile vs Bird
            Debug.WriteLine("-------> Done  <--------");

            m.Hit();
        }*/
        // Data: ---------------

    }
}

// --- End of File ---
