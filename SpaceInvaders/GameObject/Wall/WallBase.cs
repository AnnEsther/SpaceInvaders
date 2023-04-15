//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class WallBase : Leaf
    {
        public enum Type
        {
            WallGroup,
            Right,
            Left,
            Bottom,
            Top,

            Unitialized
        }

        protected WallBase(GameObject.Name gameName, SpriteGame.Name spriteName, float _x, float _y, WallBase.Type _type)
        : base(gameName, spriteName, _x, _y)
        {
            WallType = _type;
        }

        ~WallBase()
        {
        }
        public WallBase.Type GetCategoryType()
        {
            return this.WallType;
        }
        public override void VisitGrid(AlienGrid b)
        {
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(b, this);
            pColPair.NotifyListeners();
        }
        

        // Data ----------
        protected WallBase.Type WallType;

    }
}

// --- End of File ---
