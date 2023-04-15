//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShieldRoot : Composite
    {
        public ShieldRoot(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

        }
        ~ShieldRoot()
        {
        }
        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitShieldRoot(this);
        }
        public override void VisitMissileGroup(MissileGroup m)
        {
            // MissileRoot vs ShieldRoot
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }
        public override void VisitMissile(Missile m)
        {
            if(this.GetNumChildren() != 0)
            {
                // Missile vs ShieldRoot
                GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
                ColPair.Collide(m, pGameObj);
            }
            else
            {
                //Debug.WriteLine("Shouldnt be here \n");
            }
            
        }
        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }
        public override void VisitBombRoot(BombRoot b)
        {
            // BombRoot vs ShieldRoot
            if(this.GetNumChildren() != 0)
            {
                GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
                ColPair.Collide(b, pGameObj);
            }
            
        }
        public override void VisitBomb(Bomb b)
        {
            // Missile vs ShieldRoot
            ColPair.Collide(b, (GameObject)IteratorForwardComposite.GetChild(this));
        }
        public void ClearGrids()
        {
            Iterator pIt = this.GetIterator();
            Debug.Assert(pIt != null);
            ShieldGrid pNode = (ShieldGrid)pIt.First();
            while(!pIt.IsDone())
            {
                ShieldGrid pTemp = (ShieldGrid)pIt.Current();
                pNode = (ShieldGrid)pIt.Next();
                pTemp.ClearColums();
                pTemp.Remove();
            }

        }

        // ------------------------------------------
        // Data:
        // ------------------------------------------
        

    }
}

// --- End of File ---
