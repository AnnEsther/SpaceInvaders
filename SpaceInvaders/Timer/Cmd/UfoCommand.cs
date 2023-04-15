//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class UfoCommand : Command
    {
      
        public UfoCommand(GameObject _pUFO, float deltaRepeatTime)
        {/*
            GameObject ufo = GameObjectNodeMan.Find(GameObject.Name.UFO);
            Debug.Assert(ufo != null);*/

            // string only here for testing purposes
            this.pUFO = (UFO)_pUFO;
            this.repeatDelta = deltaRepeatTime;
            this.pBombCommand = new UFOBombCommand(_pUFO, 1.0f);
        }

        public override void Execute(float deltaTime)
        {
            // Debug.WriteLine(" {0} time:{1} ", this.pString, TimerEventMan.GetCurrTime());

            GameObject ufoRoot = GameObjectNodeMan.Find(GameObject.Name.UFORoot);
            UFO ufo = (UFO)IteratorForwardComposite.GetChild(ufoRoot);
            if (ufo != null)
            {
                this.pUFO = (UFO)ufo;
                this.pUFO.isActive = true;
                // Add itself back to timer
                TimerEventMan.Add(TimerEvent.Name.UfoCommand, this, this.repeatDelta);
                TimerEventMan.Add(TimerEvent.Name.UFOBombCommand, this.pBombCommand, 1.0f);

                SoundMan.PlayUFOSound();
            }
           
        }

        private UFO pUFO;
        private float repeatDelta;
        UFOBombCommand pBombCommand;
    }
}

// --- End of File ---
