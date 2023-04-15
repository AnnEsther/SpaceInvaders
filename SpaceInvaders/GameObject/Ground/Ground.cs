//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Ground : Leaf
    {
        public enum Type
        {
            Ground,
            GroundRoot,
            Unitialized
        }
        public Ground(GameObject.Name gameName, SpriteGame.Name spriteName, float x, float y)
            : base(gameName,spriteName, x, y)
        {
            this.type = Type.Ground;
            //this.poColObj.pColSprite.SetColor(1, 0, 1);
        }
       

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void Accept(ColVisitor other)
        {
            throw new NotImplementedException();
        }

        public override void VisitBomb(Bomb b)
        {
            // no differed to subcass
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(b, this);
            pColPair.NotifyListeners();
        }

        // Data: --------------------
        protected Ground.Type type;
    }
}

// --- End of File ---
