//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

// -----------------------------------------------
// Add CODE/REFACTOR here
// -----------------------------------------------
//    Fill in methods
//    Add additional methods if desired
//    Add additional data if desired
// -----------------------------------------------

namespace SpaceInvaders
{
    class PriorityQueueMan : ListBase
    {
        public PriorityQueueMan()
            : base()
        {
            //LTN - PriorityQueueMan
            this.poIterator = new DLinkIterator();
            this.poHead = null;
        }

        override public void AddToFront(NodeBase pNode, float priority)
        {
            ((DLink)pNode).SetPriority(priority);
            this.Add(pNode);
        }

        public override NodeBase RemoveFromFront()
        {
            //STN - Only to throw exception
            throw new NotImplementedException();
        }

        public NodeBase GetHead()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------

            return (NodeBase)this.poHead;
        }

        public override void Remove( NodeBase _pNode )
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------

            DLink pNode = (DLink)_pNode;
            if(pNode == this.GetHead())
            {
                this.poHead = pNode.pNext;
                if (pNode.pNext != null)
                {
                    pNode.pNext.pPrev = null;
                }
            }
            else
            {
                pNode.pPrev.pNext = pNode.pNext;
                if (pNode.pNext != null) { pNode.pNext.pPrev = pNode.pPrev; }
            }
           

        }
        public void Add( NodeBase _pNode )
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            DLink pNode = (DLink)_pNode;
            if(this.poHead == null)
            {
                this.poHead = pNode;
            }
            else
            {
                DLink pTemp = (DLink)this.GetHead();
                while(pTemp.pNext != null && pNode.GetPriority() > pTemp.GetPriority())
                {
                    pTemp = pTemp.pNext;
                }
                if(pTemp.GetPriority() == ((NodeBase)this.poHead).GetPriority())
                {
                    if (pTemp.GetPriority() < pNode.GetPriority())
                    {
                        this.poHead.pNext = pNode;
                        pNode.pPrev = this.poHead;
                    }
                    else
                    {
                        pNode.pNext = this.poHead;
                        this.poHead.pPrev = pNode;
                        this.poHead = pNode;
                    }
                }
                else if(pTemp.pNext == null)
                {
                    if(pTemp.GetPriority() < pNode.GetPriority())
                    {
                        pTemp.pNext = pNode;
                        pNode.pPrev = pTemp;
                    }
                   else
                    {
                        pTemp.pPrev.pNext = pNode;
                        pNode.pPrev = pTemp.pPrev;

                        pTemp.pPrev = pNode;
                        pNode.pNext = pTemp;
                    }
                }
                else
                {
                    pTemp.pPrev.pNext = pNode;
                    pNode.pPrev = pTemp.pPrev;

                    pTemp.pPrev = pNode;
                    pNode.pNext = pTemp;
                }
            }

        }



        override public Iterator GetIterator()
        {
            Debug.Assert(this.poIterator != null);
            this.poIterator.Reset(this.poHead);

            return this.poIterator;
        }

        // ---------------------------------------
        // DO not add/modify variables
        // ---------------------------------------
        // Data:
        public DLink poHead;
        public DLinkIterator poIterator;
    }
}

// --- End of File ---

