//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Alien_Squid : AlienBase
    {
        public Alien_Squid(SpriteGame.Name spriteName, float posX, float posY)
        : base(GameObject.Name.Squid, spriteName, posX, posY)
        {
            
                
        }
        public override void SetColor()
        {
            this.UpdateColor(new Azul.Color(0.66f, 0.83f, 0.55f));
        }
        override public System.Enum GetName()
        {
            return AlienBase.Name.Squid;
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
            other.VisitAlienSquid(this);
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
