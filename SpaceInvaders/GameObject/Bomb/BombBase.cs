//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class BombBase : Leaf
    {
        public enum Type
        {
            Bomb,
            BombRoot,
            Unitialized
        }

        protected BombBase(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY, BombBase.Type bombType)
            : base(name, spriteName, posX, posY)
        {
            this.BombType = bombType;
        }

        // Data: ---------------
        ~BombBase()
        {
        }

        // this is just a placeholder, who knows what data will be stored here
        protected BombBase.Type BombType;
        public AlienColumn pSpawnColumn;

    }
}

// --- End of File ---
