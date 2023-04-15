//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienColumn : Composite
    {
        public AlienColumn()
            : base()
        {
            this.name = Name.AlienColumn;
            this.UpdateBoxColor(1.0f, 0.0f, 0.0f);
            this.bombActive = false;
        }
        public override void Update()
        {
            
            base.BaseUpdateBoundingBox(this);
            base.Update();

            //update grid too
            // Update the parent (missile root)
            GameObject pParent = (GameObject)this.pParent;
            pParent.Update();
        }
        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an BirdColumn
            // Call the appropriate collision reaction            
            other.VisitColumn(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            // BirdColumn vs MissileGroup
            //Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            // MissileGroup vs Columns
            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }
        public override void Print()
        {
            Debug.WriteLine("");
            Debug.WriteLine("Column:");

            // walk through the list and render
            Iterator pIt = this.poDLinkMan.GetIterator();
            Debug.Assert(pIt != null);

            // Walk through the nodes
            for (pIt.Current(); !pIt.IsDone(); pIt.Next())
            {
                GameObject pNode = (GameObject)pIt.Current();
                Debug.Assert(pNode != null);

                pNode.Dump();
            }
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void Remove()
        {
            base.Remove();
            this.poColObj.poColRect.Set(0, 0, 0, 0);
        }

        public AlienBase getBottomAlien()
        {
            Iterator pIt = this.GetIterator();
            Debug.Assert(pIt != null);
            float minY = 1000.0f;
            AlienBase pTemp = null;

            AlienBase pNode = (AlienBase)pIt.Current();
            for (pIt.First(); !pIt.IsDone(); pIt.Next())
            {
                pNode = (AlienBase)pIt.Current();
                Debug.Assert(pNode != null);

                if(pNode.y < minY)
                {
                    minY = pNode.y;
                    pTemp = pNode;
                }
            }
            return pTemp;
        }

        public void ClearAliens()
        {
            //IteratorReverseComposite alienItr = new IteratorReverseComposite(this);
            Iterator alienItr = this.GetIterator();
            Component pNode = (Component)alienItr.First();
            while (!alienItr.IsDone())
            {
                GameObject pGameObj = (GameObject)pNode;
                pGameObj.poColObj.poColRect.Set(0, 0, 0, 0);
                pNode = (Component)alienItr.Next();
                pGameObj.Remove();
            }
        }


        //--Data--
        /* private static SpriteGameProxyNull psSpriteGameProxyNull = new SpriteGameProxyNull();*/
        public bool bombActive;

    }
}

// --- End of File ---
