//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System.Diagnostics;

namespace SpaceInvaders
{
    public class Bomb : BombBase
    {
        public Bomb(GameObject.Name name, SpriteGame.Name spriteName, FallStrategy _pStrategy, float posX, float posY)
            : base(name, spriteName, posX, posY, BombBase.Type.Bomb)
        {
            this.x = posX;
            this.y = posY;
            this.delta = 2.0f;

            Debug.Assert(_pStrategy != null);
            this.pStrategy = _pStrategy;

            this.pStrategy.Reset(this.y);

            this.poColObj.pColSprite.SetColor(1, 1, 0);
        }
        public void Reset()
        {
            this.y = 500.0f;
            this.pStrategy.Reset(this.y);
        }
        public override void Remove()
        {
            // Since the Root object is being drawn
            // 1st set its size to zero
            this.poColObj.poColRect.Set(0, 0, 0, 0);
            base.Update();

            // Update the parent (missile root)
            GameObject pParent = (GameObject)this.pParent;
            pParent.Update();

            // Now remove it
            base.Remove();
        }

        public override void Update()
        {
            base.Update();
            this.y -= delta;

            // Strategy
            this.pStrategy.Fall(this);
        }
        public float GetBoundingBoxHeight()
        {
            return this.poColObj.poColRect.height;
        }
        /*private void StrategyStraightFall()
        {

        }

        private void StrategyNegXFall()
        {
            float targetY = oldPosY - 1.0f * this.poColObj.poColRect.height;

            if (this.y < targetY)
            {
                this.pSpriteProxy.sx *= -1.0f;
                oldPosY = targetY;
            }
        }

        private void StrategyNegYFall()
        {
            float targetY = oldPosY - 1.0f * this.poColObj.poColRect.height;

            if (this.y < targetY)
            {
                this.pSpriteProxy.sy *= -1.0f;
                oldPosY = targetY;
            }
        }*/

        ~Bomb()
        {
        }


        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitBomb(this);
        }

        public void SetPos(float xPos, float yPos)
        {
            this.x = xPos;
            this.y = yPos;
        }
        public void MultiplyScale(float sx, float sy)
        {
            Debug.Assert(this.pSpriteProxy != null);

            this.pSpriteProxy.sx *= sx;
            this.pSpriteProxy.sy *= sy;
        }
        public override void Move()
        {
            throw new System.NotImplementedException();
        }
      

        // Data
        public float delta;
        private FallStrategy pStrategy;
    }
}

// --- End of File ---
