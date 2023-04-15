//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienGrid : Composite
    {
        public AlienGrid()
            : base()
        {
            this.name = Name.AlienGrid;
            this.speed = 4.0f;
            this.delta = 1.0f;
            this.moveDown = false;
            //this.UpdateBoxColor(0.0f, 1.0f, 0.0f);
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an BirdGroup
            // Call the appropriate collision reaction            
            other.VisitGrid(this);
        }

        

        public override void Update()
        {
            //Debug.WriteLine("update: {0}", this);
            base.BaseUpdateBoundingBox(this);

            // proof its working
            //this.poColObj.poColRect.width -= 40.0f;

            base.Update();
        }
        public float GetDelta()
        {
            return this.delta;
        }
        public void UpdateDelta(bool rightWall)
        {
            if(rightWall)
            {
                this.delta = -1.0f;
            }
            else
            {
                this.delta = 1.0f;
            }
            this.moveDown = true;

            //this.speed += 0.05f;

            /* if(this.delta > 0)
             {
                 this.delta += 0.05f;
             }
             else
             {
                 this.delta -= 0.05f;
             }*/
        }
        public override void Move()
        {

            IteratorForwardComposite pFor = new IteratorForwardComposite(this);

            Component pNode = pFor.First();
            while (!pFor.IsDone())
            {
                GameObject pGameObj = (GameObject)pNode;
                if (pGameObj.GetType().Name != "AlienColumn" && pGameObj.GetType().Name != "AlienGrid")
                {
                    pGameObj.x += this.delta * this.speed;
                    if (this.moveDown == true)
                    {
                        pGameObj.y -= 2.5f;
                    }
                }
                pNode = pFor.Next();
            }
            if (this.moveDown == true)
            {
                this.moveDown = false;
            }
            
        }
        public override void Remove()
        {
            base.Remove();
            this.poColObj.poColRect.Set(0, 0, 0, 0);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            // BirdGroup vs MissileGroup
            //Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            // MissileGroup vs Columns
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }
        public int getNumOfActiveColumns()
        {
            int activeColumns = 0;
            Iterator pIt = this.GetIterator();
            Debug.Assert(pIt != null);

            for (pIt.First(); !pIt.IsDone(); pIt.Next())
            {
                AlienColumn pNode = (AlienColumn)pIt.Current();
                Debug.Assert(pNode != null);
                if (!pNode.bombActive)
                {
                    activeColumns++;
                }
            }
            return activeColumns;
        }

        public AlienColumn getNthActiveColumn(int n)
        {
            Iterator pIt = this.GetIterator();
            Debug.Assert(pIt != null);
            int i = 0;
            AlienColumn pNode = (AlienColumn)pIt.Current();
            for (pIt.First(); !pIt.IsDone() && i < n; pIt.Next())
            {
                pNode = (AlienColumn)pIt.Current();
                Debug.Assert(pNode != null);

                if (!pNode.bombActive)
                {
                    i++;
                }
            }
            return pNode;
        }
        public void ClearColumns()
        {
            this.speed = 4.0f;
            Iterator pIt = this.GetIterator();
            Debug.Assert(pIt != null);
            GameObject pNode = (GameObject)pIt.First();
            while(!pIt.IsDone())
            {
                GameObject pTemp = pNode;
                pTemp = (GameObject)pIt.Current();
                if (pTemp.GetType().Name == "AlienColumn")
                {
                    ((AlienColumn)pTemp).ClearAliens();
                }
                pTemp.poColObj.poColRect.Set(0, 0, 0, 0);
                pNode = (GameObject)pIt.Next();
                pTemp.Remove();
            }
        }
        public void UpdateSpeed()
        {
            this.speed += 0.5f;
        }
        // Data
        private float delta;
        private float speed;
        private bool moveDown;
    }
}

// --- End of File ---
