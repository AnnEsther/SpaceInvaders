//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class AlienBase : Leaf
    {
        public enum Type
        {
            Squid,
            Crab,
            Octopus,
            AlienGrid,
            AlienColumn
        }

        protected AlienBase(GameObject.Name gameName, SpriteGame.Name spriteName, float _x, float _y)
            : base(gameName, spriteName, _x, _y)
        {
            this.pSpriteGame = spriteName;
            this.UpdateBoxColor(1.0f, 1.0f, 0.0f);
            this.SetColor();
        }
        public override void VisitMissile(Missile m)
        {
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
        }
        public override void Remove()
        {
            // Since the Root object is being drawn
            // 1st set its size to zero
            this.poColObj.poColRect.Set(0, 0, 0, 0);

            base.Update();
            // Now remove it
            base.Remove();
        }
        public void MissileHit()
        {
            this.pSpriteProxy.SwapImage(SpriteGame.Name.AlienExplosion);
            this.SetColor();
           // this.pSpriteProxy.SwapColor(this.GetSpriteProxy().pRealSprite.poColor);
        }
        public virtual void SetColor()
        {
            
        }
        override public void Resurrect()
        {
            base.Resurrect();
            this.pSpriteProxy.SwapImage(pSpriteGame);
            this.SetColor();
        }
        SpriteGame.Name pSpriteGame;

    }
}

// --- End of File ---
