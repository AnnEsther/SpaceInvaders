//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GroundRoot : Composite
    {
        public GroundRoot(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

            this.poColObj.pColSprite.SetColor(0, 0, 1);

        }
        ~GroundRoot()
        {

        }
        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            //other.VisitBumperRoot(this);
        }
        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }
        public override void VisitBombRoot(BombRoot b)
        {
            ColPair.Collide((GameObject)IteratorForwardComposite.GetChild(b), this);
        }
        public override void VisitBomb(Bomb b)
        {
            ColPair.Collide(b, (GameObject)IteratorForwardComposite.GetChild(this));
            // no differed to subcass
            /*ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(b, this);
            pColPair.NotifyListeners();*/
        }

        // Data: ---------------


    }
}// --- End of File ---
