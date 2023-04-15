//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShieldBrick : ShieldBase
    {
        public ShieldBrick(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY)
            : base(name, spriteName, posX, posY, ShieldBase.Type.Brick)
        {
            this.x = posX;
            this.y = posY;

            this.SetCollisionColor(1.0f, 1.0f, 1.0f);
        }
        ~ShieldBrick()
        {

        }
        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitShieldBrick(this);
        }
        
        public override void Move()
        {
            throw new NotImplementedException();
        }
        public override void VisitMissile(Missile m)
        {
            // Missile vs ShieldBrick
            //Debug.WriteLine(" ---> Done");
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
        }
        public override void VisitBomb(Bomb b)
        {
            // Bomb vs ShieldBrick
            //Debug.WriteLine(" ---> Done");
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(b, this);
            pColPair.NotifyListeners();
        }
        public override void Update()
        {
            base.Update();
        }
        public override void VisitBombRoot(BombRoot b)
        {
            ColPair.Collide((GameObject)IteratorForwardComposite.GetChild(b), this);
        }

        // ---------------------------------
        // Data: 
        // ---------------------------------


    }
}

// --- End of File ---
