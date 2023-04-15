//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MoveCmd : Command
    {
      
        public MoveCmd(GameObject.Name objectName, float _deltaX = 0.0f, float _deltaY = 0.0f)
        {
            //LTN - MoveCmd
            this.pObject = GameObjectNodeMan.Find(objectName);
            Debug.Assert(this.pObject != null);

            this.pIt = new IteratorForwardComposite(this.pObject);
            Debug.Assert(this.pIt != null);

            this.deltaX = _deltaX;
            this.deltaY = _deltaY;

        }


        public override void Execute(float deltaTime)
        {

            for (pIt.First(); !pIt.IsDone(); pIt.Next())
            {
                Component pNode = pIt.Curr();
                if(pNode.type == Component.Container.LEAF)
                {
                    ((Leaf)pNode).x += this.deltaX;
                    ((Leaf)pNode).y += this.deltaY;
                }
                //pNode.Dump();
            }


            // Add itself back to timer
            //TimerEventMan.Add(TimerEvent.Name.Move, this, deltaTime);
        }

        public void UpdateDelta(float _deltaX = 0.0f, float _deltaY = 0.0f)
        {
            this.deltaX = _deltaX;
            this.deltaY = _deltaY;
        }
        public void NegateDelta()
        {
            this.deltaX *= -1.0f;
            this.deltaY *= -1.0f;
        }
        

        // Data: ---------------
        private GameObject pObject;
        private IteratorForwardComposite pIt;
        private float deltaX;
        private float deltaY;
    }

}

// --- End of File ---
