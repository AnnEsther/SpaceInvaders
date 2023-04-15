//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GameObjectNull : Leaf
    {
        public GameObjectNull()
            : base(GameObject.Name.NullObject, SpriteGame.Name.NullObject, 0, 0)
        {

        }

        public override void Update()
        {
            // do nothing - its a null object
        }

        public override void Move()
        {
            /*this.x += _x;
            this.y += _y;*/
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an NullGameObject
            // Call the appropriate collision reaction            
            other.VisitNullGameObject(this);
        }

        private static SpriteGameProxyNull psSpriteGameProxyNull = new SpriteGameProxyNull();
    }
}

// --- End of File ---
