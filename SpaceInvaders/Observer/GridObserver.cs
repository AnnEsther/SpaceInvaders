//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GridObserver : ColObserver
    {
        public GridObserver()
        {
           
        }
        override public void Notify()
        {
           // Debug.WriteLine("Grid_Observer: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            // OK do some magic
            this.pGrid = (AlienGrid)this.pSubject.pObjA;
            WallBase pWall = (WallBase)this.pSubject.pObjB;
            if (pWall.GetCategoryType() == WallBase.Type.Right)
            {
                this.pGrid.UpdateDelta(true);
            }
            else if (pWall.GetCategoryType() == WallBase.Type.Left)
            {
                this.pGrid.UpdateDelta(false);
            }
            else
            {
                //Debug.Assert(false);
            }

        }

        override public void Dump()
        {
            Debug.Assert(false);
        }
        override public System.Enum GetName()
        {
            return Name.GridObserver;
        }
        AlienGrid pGrid;

    }
}

// --- End of File ---
