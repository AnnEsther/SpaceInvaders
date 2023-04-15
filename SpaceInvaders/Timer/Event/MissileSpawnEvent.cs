//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//-----------------------------------------------------------------------------
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class MissileSpawnEvent : Command
    {
        public MissileSpawnEvent(Random pRandom)
        {
            this.pMissileRoot = GameObjectNodeMan.Find(GameObject.Name.MissileGroup);
            Debug.Assert(this.pMissileRoot != null);

            this.pRandom = pRandom;
        }

        override public void Execute(float deltaTime)
        {
            //Debug.WriteLine("event: {0}", deltaTime);

            // Create missile
            float value = this.pRandom.Next(300, 700);

            Missile pMissile = new Missile(SpriteGame.Name.Missile, value, 100);
            //     Debug.WriteLine("----x:{0}", value);

            pMissile.ActivateCollisionSprite(SpriteBatch.Name.Boxes);
            pMissile.ActivateSprite(SpriteBatch.Name.AlienBatch);

            // Attach the missile to the missile root
            GameObject pMissileGroup = GameObjectNodeMan.Find(GameObject.Name.MissileGroup);
            Debug.Assert(pMissileGroup != null);

            // Add to GameObject Tree - {update and collisions}
            pMissileGroup.Add(pMissile);

        }


        GameObject pMissileRoot;
        Random pRandom;
    }
}

// --- End of File ---
