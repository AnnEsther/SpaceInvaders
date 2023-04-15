//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Missile : MissileBase
    {
        public Missile(SpriteGame.Name spriteName, float posX, float posY)
            : base(GameObject.Name.Missile, spriteName, posX, posY)
        {
            this.x = posX;
            this.y = posY;
            this.poColObj.pColSprite.SetColor(0, 0, 0);

            this.enable = false;
            this.delta = 3.0f;

            this.poColObj.pColSprite.SetColor(1, 1, 0);
        }
       
        public override void Update()
        {
            if(this.enable)
            {
                this.y += delta;
            }
            base.Update();

            /*if (!bHit)
            {
            }*/
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

        ~Missile()
        {

        }

        public void Hit()
        {
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Missile
            // Call the appropriate collision reaction            
            other.VisitMissile(this);
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public void SetPos(float xPos, float yPos)
        {
            this.x = xPos;
            this.y = yPos;
        }

        public void SetActive(bool state)
        {
            this.enable = state;
        }

        // Data -------------------------------------
        private bool enable;
        public float delta;
    }
}

// --- End of File ---
