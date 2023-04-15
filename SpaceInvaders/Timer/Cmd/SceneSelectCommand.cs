//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SceneSelectCommand : Command
    {

        public SceneSelectCommand()
        {

        }

        public override void Execute(float deltaTime)
        {
            SceneContext.SetState(SceneContext.Scene.Select);
        }

    }
}

// --- End of File ---
