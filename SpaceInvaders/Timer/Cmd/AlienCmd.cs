//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienCmd : Command
    {

        public AlienCmd()
        {
            //LTN - AlienCmd
            this.pSquidAnim = new AnimationCmd(SpriteGame.Name.SquidA);
            Debug.Assert(this.pSquidAnim != null);
            this.pSquidAnim.Attach(Image.Name.SquidA);
            this.pSquidAnim.Attach(Image.Name.SquidB);

            this.pCrabAnim = new AnimationCmd(SpriteGame.Name.CrabA);
            Debug.Assert(this.pCrabAnim != null);
            this.pCrabAnim.Attach(Image.Name.CrabA);
            this.pCrabAnim.Attach(Image.Name.CrabB);

            this.pOctopusAnim = new AnimationCmd(SpriteGame.Name.OctopusA);
            Debug.Assert(this.pOctopusAnim != null);
            this.pOctopusAnim.Attach(Image.Name.OctopusA);
            this.pOctopusAnim.Attach(Image.Name.OctopusB);

            this.pGrid = GameObjectNodeMan.Find(GameObject.Name.AlienRoot);
            this.pGrid = ((AlienRoot)this.pGrid).GetGrid();
            //((AlienGrid)this.pGrid).SetDelta(4.0f);

            count = 0;
            maxCount = 20;

        }


        public override void Execute(float deltaTime)
        {
            //count++;
            //((AlienGrid)this.pGrid).delta
            //if (count == this.maxCount && deltaTime >= 0.1)
            //{
                //deltaTime -= 0.05f;
                //count = 0;
           // }
                /*
                //400
                {
                   
                    delta *= -1.0f;
                    count = 0;
                }*/
            ((AlienGrid)this.pGrid).Move();


            this.pSquidAnim.Execute(deltaTime);
            this.pCrabAnim.Execute(deltaTime);
            this.pOctopusAnim.Execute(deltaTime);

            SoundMan.PlayMoveSound();

            // Add itself back to timer
            TimerEventMan.Add(TimerEvent.Name.Alien, this, deltaTime);
        }

        // Data: ---------------
        private AnimationCmd pSquidAnim;
        private AnimationCmd pCrabAnim;
        private AnimationCmd pOctopusAnim;


        GameObject pGrid;
        int count;
        int maxCount;

    }

   
}

// --- End of File ---
