//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class ShieldBase : Leaf
    {
        public enum Type
        {
            Root,
            Column,
            Brick,
            Grid,

            LeftTop0,
            LeftTop1,
            LeftBottom,
            RightTop0,
            RightTop1,
            RightBottom,

            Unitialized
        }

        protected ShieldBase(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY, ShieldBase.Type shieldType)
            : base(name, spriteName, posX, posY)
        {
            this.ShieldType = shieldType;
        }
        // Data: ---------------
        ~ShieldBase()
        {
        }
        override public void Resurrect()
        {
            base.Resurrect();
        }
        public ShieldBase.Type GetCategoryType()
        {
            return this.ShieldType;
        }

        // --------------------------------------------------------------------
        // Data:
        // --------------------------------------------------------------------

        // this is just a placeholder, who knows what data will be stored here
        protected ShieldBase.Type ShieldType;

    }
}

// --- End of File ---
