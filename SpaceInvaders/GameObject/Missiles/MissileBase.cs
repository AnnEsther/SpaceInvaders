//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class MissileBase : Leaf
    {
        public enum Type
        {
            Missile,
            MissileGroup,
            Unitialized
        }

        protected MissileBase(GameObject.Name gameName, SpriteGame.Name spriteName, float _x, float _y)
        : base(gameName, spriteName, _x, _y)
        {
        }

        ~MissileBase()
        {
        }
        override public void Resurrect()
        {
            base.Resurrect();
        }
        public override void VisitBomb(Bomb b)
        {
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(b, this);
            pColPair.NotifyListeners();
        }

        // Data: ---------------
    }
}

// --- End of File ---
