//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipMan
    {
        public enum MissileState
        {
            Ready,
            Flying
        }

        public enum MoveState
        {
            MoveRight,
            MoveLeft,
            MoveBoth
        }

        private ShipMan()
        {
            // Store the states
            this.pStateMissileReady = new ShipMissileReady();
            this.pStateMissileFlying = new ShipMissileFlying();

            this.pStateMoveBoth = new ShipMoveBoth();
            this.pStateMoveRight = new ShipMoveRight();
            this.pStateMoveLeft = new ShipMoveLeft();

            // set active
            this.pShip = null;
            this.pMissile = null;
        }

        public static void Create()
        {
            // make sure its the first time
            //Debug.Assert(instance == null);

            // Do the initialization
            if (instance == null)
            {
                instance = new ShipMan();
            }

            Debug.Assert(instance != null);

            // Stuff to initialize after the instance was created
            instance.pShip = ActivateShip();
            instance.pShip.SetState(ShipMan.MoveState.MoveBoth);
            instance.pShip.SetState(ShipMan.MissileState.Ready);

        }

        public static void Destroy()
        {
            instance = null;
            // make sure its the first time
            Debug.Assert(instance == null);
        }

        private static ShipMan privInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        public static Ship GetShip()
        {
            ShipMan pShipMan = ShipMan.privInstance();

            Debug.Assert(pShipMan != null);
            Debug.Assert(pShipMan.pShip != null);

            return pShipMan.pShip;
        }

        public static ShipMissileState GetState(MissileState state)
        {
            ShipMan pShipMan = ShipMan.privInstance();
            Debug.Assert(pShipMan != null);

            ShipMissileState pShipState = null;

            switch (state)
            {
                case ShipMan.MissileState.Ready:
                    pShipState = pShipMan.pStateMissileReady;
                    break;

                case ShipMan.MissileState.Flying:
                    pShipState = pShipMan.pStateMissileFlying;
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            return pShipState;
        }
        public static ShipMoveState GetState(MoveState state)
        {
            ShipMan pShipMan = ShipMan.privInstance();
            Debug.Assert(pShipMan != null);

            ShipMoveState pShipState = null;

            switch (state)
            {
                case ShipMan.MoveState.MoveBoth:
                    pShipState = pShipMan.pStateMoveBoth;
                    break;

                case ShipMan.MoveState.MoveLeft:
                    pShipState = pShipMan.pStateMoveLeft;
                    break;

                case ShipMan.MoveState.MoveRight:
                    pShipState = pShipMan.pStateMoveRight;
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            return pShipState;
        }

        public static Missile GetMissile()
        {
            ShipMan pShipMan = ShipMan.privInstance();

            Debug.Assert(pShipMan != null);
            Debug.Assert(pShipMan.pMissile != null);

            return pShipMan.pMissile;
        }

        public static Missile ActivateMissile()
        {
            ShipMan pShipMan = ShipMan.privInstance();
            Debug.Assert(pShipMan != null);

            Missile pMissile = null;
            GameObjectNode pGameObjNode = GhostMan.Find(GameObject.Name.Missile);
            if (pGameObjNode == null)
            {
                pMissile = new Missile(SpriteGame.Name.PlayerShot, 400, 100);
            }
            else
            {
                // Recycle it.
                pMissile = (Missile)pGameObjNode.pGameObj;
                GhostMan.Remove(pGameObjNode);

                //GhostMan.Dump();
                pMissile.Resurrect();
                pMissile.x = 400;
                pMissile.y = 100;
            }
            pShipMan.pMissile = pMissile;

            pMissile.SetActive(true);

            pMissile.ActivateCollisionSprite(SpriteBatch.Name.Boxes);
            pMissile.ActivateSprite(SpriteBatch.Name.Missile);

            // Attach the missile to the missile root
            GameObject pMissileGroup = GameObjectNodeMan.Find(GameObject.Name.MissileGroup);
            Debug.Assert(pMissileGroup != null);

            // Add to GameObject Tree - {update and collisions}
            pMissileGroup.Add(pShipMan.pMissile);

            return pShipMan.pMissile;
        }


        private static Ship ActivateShip()
        {
            ShipMan pShipMan = ShipMan.privInstance();
            Debug.Assert(pShipMan != null);

            Ship pShip;
            GameObjectNode pGameObjectNode = GhostMan.Find(GameObject.Name.Ship);
            if(pGameObjectNode == null)
            {
                pShip = new Ship(GameObject.Name.Ship, SpriteGame.Name.Player, 336, 100);
            }
            else
            {
                pShip = (Ship)pGameObjectNode.pGameObj;
                GhostMan.Remove(pGameObjectNode);
                pShip.Resurrect();
                pShip.x = 336;
                pShip.y = 100;
               // pShip.UpdateColor(new Azul.Color(0.85f, 0.8f, 0.58f));

            }

            GameObject pShipRoot = GameObjectNodeMan.Find(GameObject.Name.ShipRoot);
            Debug.Assert(pShipRoot != null);
            pShipRoot.Add(pShip);

            pShipMan.pShip = pShip;

            pShip.ActivateSprite(SpriteBatch.Name.Player);
            pShip.ActivateCollisionSprite(SpriteBatch.Name.Boxes);

            // Add to GameObject Tree - {update and collisions}

            return pShipMan.pShip;
        }

        public static void ReActivateShip()
        {
            instance.pShip = ActivateShip();
            instance.pShip.SetState(ShipMan.MoveState.MoveBoth);
            instance.pShip.SetState(ShipMan.MissileState.Ready);
        }

        public static void DeleteShip()
        {
            instance.pShip = null;
        }

        // Data: ----------------------------------------------
        private static ShipMan instance = null;

        // Active
        private Ship pShip;
        private Missile pMissile;

        // Reference
        private ShipMissileReady pStateMissileReady;
        private ShipMissileFlying pStateMissileFlying;

        private ShipMoveBoth pStateMoveBoth;
        private ShipMoveRight pStateMoveRight;
        private ShipMoveLeft pStateMoveLeft;


    }
}

// --- End of File ---
