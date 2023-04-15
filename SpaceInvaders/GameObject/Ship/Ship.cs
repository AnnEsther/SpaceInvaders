//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Ship : ShipBase
    {

        public Ship(GameObject.Name name, SpriteGame.Name spriteName, float posX, float posY)
         : base(name, spriteName, posX, posY, ShipBase.Type.Ship)
        {
            this.x = posX;
            this.y = posY;

            this.shipSpeed = 3.0f;

            this.MoveState = null;
            this.MissileState = null;

            this.pSpriteGame = spriteName;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Bomb
            // Call the appropriate collision reaction
            other.VisitShip(this);
        }
        public override void VisitBumperRoot(BumperRoot b)
        {
            //Debug.WriteLine("collide: {0} with {1}", this, b);

            GameObject pGameObj = (GameObject)IteratorForwardComposite.GetChild(b);
            ColPair.Collide(pGameObj, this);
        }

        public override void VisitBumperRight(BumperRight b)
        {
            //Debug.WriteLine("collide: {0} with {1}", this, b);

            ColPair pColPair = ColPairMan.GetActiveColPair();
            Debug.Assert(pColPair != null);

            pColPair.SetCollision(b, this);
            pColPair.NotifyListeners();
        }
        public override void VisitBumperLeft(BumperLeft b)
        {
            //Debug.WriteLine("collide: {0} with {1}", this, b);

            ColPair pColPair = ColPairMan.GetActiveColPair();
            Debug.Assert(pColPair != null);

            pColPair.SetCollision(b, this);
            pColPair.NotifyListeners();
        }
        public void MoveRight()
        {
            this.MoveState.MoveRight(this);
        }

        public void MoveLeft()
        {
            this.MoveState.MoveLeft(this);
        }

        public void ShootMissile()
        {
            this.MissileState.ShootMissile(this);
        }
        public void SetState(ShipMan.MissileState inState)
        {
            this.MissileState = ShipMan.GetState(inState);
            Debug.WriteLine("Set STate : {0}", this.MissileState);
        }
        public void SetState(ShipMan.MoveState inState)
        {
            this.MoveState = ShipMan.GetState(inState);
        }
       
        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void VisitBombRoot(BombRoot b)
        {
            ColPair.Collide((GameObject)IteratorForwardComposite.GetChild(b), this);
        }

        public override void VisitBomb(Bomb b)
        {
            // no differed to subcass
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(b, this);
            pColPair.NotifyListeners();
        }
        public void BombHit()
        {
            this.pSpriteProxy.SwapImage(SpriteGame.Name.PlayerExplosionA);
        }
        override public void Resurrect()
        {
            base.Resurrect();
            this.pSpriteProxy.SwapImage(pSpriteGame);
        }
        // Data: --------------------
        public float shipSpeed;
        private ShipMoveState MoveState;
        private ShipMissileState MissileState;
        SpriteGame.Name pSpriteGame;
    }
}

// --- End of File ---
