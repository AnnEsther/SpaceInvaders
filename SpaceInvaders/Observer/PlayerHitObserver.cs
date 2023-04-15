//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class PlayerHitObserver : ColObserver
    {
        public PlayerHitObserver()
        {
            this.pShip = null;
            this.revive = true;
        }

        public PlayerHitObserver(PlayerHitObserver m)
        {
            this.pShip = m.pShip;
            this.revive = m.revive;
        }

        public override void Notify()
        {
            this.pShip = ShipMan.GetShip();
            Debug.Assert(this.pShip != null);
            LifeMan.UpdateLife();

           /* TimerEventMan.Pause(true);*/

            if (LifeMan.isPlayerDead())
            {
                this.revive = false;
            }
            else
            {
                this.revive = true;
            }

            PlayerDieCmd pCommand = new PlayerDieCmd(this);
            TimerEventMan.Add(TimerEvent.Name.PlayerDieCmd, pCommand, 0.3f);

            this.pShip.BombHit();

            SoundMan.PlayPlayerDieSound();
            ShipMan.GetShip().SetState(ShipMan.MissileState.Flying);

        }

        public override void Execute()
        {
            //GameObject pA = (GameObject)IteratorForwardComposite.GetParent((GameObject)this.pShip);
            
            this.pShip.Remove();
            

            if (this.revive)
            {
                TimerEventMan.Add(TimerEvent.Name.RevivePlayer, new RevivePlayer(), 1.5f);
            }

        }


        override public void Dump()
        {
        //    Debug.Assert(false);
        }
        override public System.Enum GetName()
        {
            return Name.PlayerHitObserver;
        }

        // data
        Ship pShip;
        bool revive;


    }
}

// --- End of File ---
