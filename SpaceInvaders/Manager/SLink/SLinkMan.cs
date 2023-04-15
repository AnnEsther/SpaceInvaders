using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class SLinkMan : ListBase
    {
        public SLinkMan()
            : base()
        {
            //LTN - SLinkMan
            this.poIterator = new SLinkIterator();
            this.poHead = null;
        }

        override public void AddToFront(NodeBase _pNode, float priority = 0.0f)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------

            Debug.Assert(_pNode != null);

            SLink pNode = (SLink)_pNode;

            if (poHead == null)
            {
                poHead = pNode;
                pNode.pNext = null;
            }
            else
            {
                // push to front
                pNode.pNext = poHead;

                // update head
                poHead = pNode;
            }
            Debug.Assert(poHead != null);
        }
        public void AddToEnd(NodeBase _pNode)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------
            Debug.Assert(_pNode != null);
            SLink pNode = (SLink)_pNode;
            if (this.poHead == null)
            {
                this.poHead = pNode;
                this.poHead.pNext = null;
                return;
            }
            SLink pTemp = this.poHead;
            while (pTemp.pNext != null)
            {
                pTemp = pTemp.pNext;
            }
            pTemp.pNext = pNode;
            pTemp = pTemp.pNext;
            pTemp.pNext = null;
        }

        override public void Remove(NodeBase _pNode)
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------

            // There should always be something on list
            Debug.Assert(poHead != null);
            Debug.Assert(_pNode != null);
            SLink pNode = (SLink)_pNode;

            if (pNode == this.poHead)
            {
                this.poHead = this.poHead.pNext;
                return;
            }
            SLink pTemp = this.poHead;
            SLink pPrev = this.poHead;
            while (pTemp != pNode)
            {
                pPrev = pTemp;
                pTemp = pTemp.pNext;
            }
            pPrev.pNext = pTemp.pNext;
        }

        override public NodeBase RemoveFromFront()
        {
            // ------------------------------
            // Add CODE/REFACTOR here
            // ------------------------------

            // There should always be something on list
            Debug.Assert(poHead != null);

            SLink pTemp = this.poHead;
            this.poHead = this.poHead.pNext;
            return pTemp;
        }

        // HACK
       /* override public NodeBase GetFirst()
        {
            // can be null
            return poHead;
        }*/
       /* public void Dump()
        {
            Debug.WriteLine("DLinkMan: \n");
            SLink pTmp = this.poHead;
            while (pTmp != null)
            {
                Node pNode = (Node)pTmp;
                pNode.Dump();

                pTmp = pTmp.pNext;
            }


            Debug.WriteLine("----- \n");
        }*/

        public override Iterator GetIterator()
        {
            Debug.Assert(this.poIterator != null);
            this.poIterator.Reset(this.poHead);

            return this.poIterator;
        }

        // ---------------------------------------
        // DO not add/modify variables
        // ---------------------------------------
        // Data:
        public SLink poHead;
        public SLinkIterator poIterator;
    }
}
