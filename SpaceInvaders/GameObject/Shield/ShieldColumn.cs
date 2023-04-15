//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShieldColumn : Composite
    {
        public ShieldColumn(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            if(name == GameObject.Name.ShieldBrick)
            {
                Debug.Assert(false);
            }
            this.x = posX;
            this.y = posY;
            this.SetCollisionColor(1.0f, 0.0f, 0.0f);
        }

        ~ShieldColumn()
        {
        }
        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitShieldColumn(this);
        }
        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }
        public override void VisitMissile(Missile m)
        {
            // Missile vs ShieldColumn
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }
        public override void VisitBomb(Bomb b)
        {
            // Bomb vs ShieldColumn
            ColPair.Collide(b, (GameObject)IteratorForwardComposite.GetChild(this));
        }
        public override void VisitBombRoot(BombRoot b)
        {
            ColPair.Collide(b, (GameObject)IteratorForwardComposite.GetChild(this));
        }

        public void ClearBricks()
        {
            Iterator pIt = this.GetIterator();
            Debug.Assert(pIt != null);
            ShieldBrick pNode = (ShieldBrick)pIt.First();
            while (!pIt.IsDone())
            {
                ShieldBrick pTemp = (ShieldBrick)pIt.Current();
                pNode = (ShieldBrick)pIt.Next();
                pTemp.Remove();
            }
        }
        // ---------------------------------------------
        // Data: 
        // ---------------------------------------------


    }
}

// --- End of File ---
