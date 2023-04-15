//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class BumperBase : Leaf
    {
        public enum Type
        {
            Right,
            Left,

            Unitialized
        }

        protected BumperBase(GameObject.Name gameName, SpriteGame.Name spriteName, float _x, float _y, BumperBase.Type _type)
        : base(gameName, spriteName, _x, _y)
        {
            BumperType = _type;
        }

        ~BumperBase()
        {
        }

        public BumperBase.Type GetCategoryType()
        {
            return this.BumperType;
        }

        // Data ----------
        protected BumperBase.Type BumperType;

    }
}// --- End of File ---
