//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienRoot : Composite
    {
        public AlienRoot(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

        }
        ~AlienRoot()
        {
        }
        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitAlienRoot(this);
        }
      
        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }
        public override void VisitBombRoot(BombRoot b)
        {
            // BombRoot vs AlienRoot
            ColPair.Collide((GameObject)IteratorForwardComposite.GetChild(b), this);
        }
        public override void VisitBomb(Bomb b)
        {
            // Missile vs AlienRoot
            ColPair.Collide(b, (GameObject)IteratorForwardComposite.GetChild(this));
        }
        public override void VisitMissileGroup(MissileGroup m)
        {
            // BirdGroup vs MissileGroup
            //Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            if(this.GetNumChildren() == 0)
            {
                //HACK
            }
            else
            {
                // MissileGroup vs Columns
                GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
                ColPair.Collide(m, pGameObj);
            }
            
        }
        public override void VisitMissile(Missile m)
        {
            if (this.GetNumChildren() != 0)
            {
                // Missile vs AlienRoot
                GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
                ColPair.Collide(m, pGameObj);
            }
            else
            {
               // Debug.WriteLine("Shouldnt be here \n");
            }

        }

        public GameObject GetGrid()
        {
            Iterator pIt = this.GetIterator();
            Debug.Assert(pIt != null);
            GameObject pNode = (GameObject)pIt.First();
            while (!pIt.IsDone())
            {
                GameObject pTemp = pNode;
                pTemp = (GameObject)pIt.Current();
                if (pTemp.GetType().Name == "AlienGrid")
                {
                    return pNode;
                }
                pNode = (GameObject)pIt.Next();
            }
            return null;
        }

        public void ClearGrid()
        {
          /*  AlienGrid pGrid = (AlienGrid)IteratorForwardComposite.GetChild(this);
            pGrid.ClearColumns();
            pGrid.poColObj.poColRect.Set(0,0,0,0);
            pGrid.Remove();*/




            Iterator pIt = this.GetIterator();
            Debug.Assert(pIt != null);
            GameObject pNode = (GameObject)pIt.First();
            while (!pIt.IsDone())
            {
                GameObject pTemp = pNode;
                pTemp = (GameObject)pIt.Current();
                if (pTemp.GetType().Name == "AlienGrid")
                {
                    ((AlienGrid)pTemp).ClearColumns();
                }
                pTemp.poColObj.poColRect.Set(0, 0, 0, 0);
                pNode = (GameObject)pIt.Next();
                pTemp.Remove();
            }


        }

        // ------------------------------------------
        // Data:
        // ------------------------------------------


    }
}

// --- End of File ---
