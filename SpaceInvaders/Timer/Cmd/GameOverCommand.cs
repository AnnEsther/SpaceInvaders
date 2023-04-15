//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameOverCommand : Command
    {

        public GameOverCommand()
        {

        }

        public override void Execute(float deltaTime)
        {
            SceneContext.SetState(SceneContext.Scene.Over);
        }

    }
}

// --- End of File ---
