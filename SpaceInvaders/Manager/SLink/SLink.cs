//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class SLink : NodeBase
    {
        // ------------------------------
        // Add CODE/REFACTOR here
        // ------------------------------
        protected SLink()
        {
            this.Clear();
        }
        public void Clear()
        {
            this.pNext = null;
        }
        protected void baseClear()
        {
            this.pNext = null;
        }
        protected void baseDump()
        {
            
            if (this.pNext == null)
            {
                Debug.WriteLine("      next: null");
            }
            else
            {
                NodeBase pTmp = (NodeBase)this.pNext;
                Debug.WriteLine("      next: {0} ({1})", pTmp.GetName(), pTmp.GetHashCode());
            }
        }
        // ------------------------------
        // Data:
        // ------------------------------
        public SLink pNext;

    }
}

// --- End of File ---
