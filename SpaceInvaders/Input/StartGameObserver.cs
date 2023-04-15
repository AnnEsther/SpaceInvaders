//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class StartGameObserver : InputObserver
    {
        public override void Notify()
        {
            if(started)
            {
                return;
            }
            SceneContext.SetState(SceneContext.Scene.Play);
            started = true;
            // Update the scene
            //SceneContext.GetState().Update(this.GetTime());

        }
        override public void Dump()
        {
            Debug.Assert(false);
        }
        override public System.Enum GetName()
        {
            return Name.StartGameObserver;
        }
        bool started = false;
    }
}

// --- End of File ---
