//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SoundMan
    {
        private SoundMan()
        {
            this.sndEngine = new IrrKlang.ISoundEngine();
            this.soundIndex = 0;

            // Resident loads
            this.explosionSnd = sndEngine.AddSoundSourceFromFile("explosion.wav");

            this.sndVader0 = sndEngine.AddSoundSourceFromFile("fastinvader1.wav");
            this.sndVader1 = sndEngine.AddSoundSourceFromFile("fastinvader2.wav");
            this.sndVader2 = sndEngine.AddSoundSourceFromFile("fastinvader3.wav");
            this.sndVader3 = sndEngine.AddSoundSourceFromFile("fastinvader4.wav");

            this.playerDead = sndEngine.AddSoundSourceFromFile("invaderkilled.wav");
            this.shoot = sndEngine.AddSoundSourceFromFile("shoot.wav");
            this.ufoHighPitch = sndEngine.AddSoundSourceFromFile("ufo_highpitch.wav");
            this.ufoLowPitch = sndEngine.AddSoundSourceFromFile("ufo_lowpitch.wav");
        }
        
        private static SoundMan privInstance()
        {
            if(instance == null)
            {
                instance = new SoundMan();
            }
            return instance;
        }

        public static void Create()
        {
            // Do the initialization
            if (instance == null)
            {
                instance = new SoundMan();
            }
            Debug.Assert(instance != null);
        }

        public static void Destroy()
        {
            instance = null;
        }

        public static void PlayMoveSound()
        {
            SoundMan pMan = SoundMan.privInstance();
            switch (pMan.soundIndex)
            {
                case 0:
                    pMan.music = pMan.sndEngine.Play2D(pMan.sndVader0, false, false, false);
                    pMan.soundIndex++;
                    break;
                case 1:
                    pMan.music = pMan.sndEngine.Play2D(pMan.sndVader1, false, false, false);
                    pMan.soundIndex++;
                    break;
                case 2:
                    pMan.music = pMan.sndEngine.Play2D(pMan.sndVader2, false, false, false);
                    pMan.soundIndex++;
                    break;
                case 3:
                    pMan.music = pMan.sndEngine.Play2D(pMan.sndVader3, false, false, false);
                    pMan.soundIndex = 0;
                    break;
            }
            pMan.music.Volume = 0.2f;
        }

        public static void PlayExplosionSound()
        {
            SoundMan pMan = SoundMan.privInstance();
            pMan.music = pMan.sndEngine.Play2D(pMan.explosionSnd, false, false, false);
            pMan.music.Volume = 0.2f;
        }

        public static void PlayPlayerDieSound()
        {
            SoundMan pMan = SoundMan.privInstance();
            pMan.music = pMan.sndEngine.Play2D(pMan.playerDead, false, false, false);
            pMan.music.Volume = 0.2f;
        }
        public static void PlayPlayerShootSound()
        {
            SoundMan pMan = SoundMan.privInstance();
            pMan.music = pMan.sndEngine.Play2D(pMan.shoot, false, false, false);
            pMan.music.Volume = 0.2f;
        }

       /* public static void PlayUFOSoundHigh()
        {
            SoundMan pMan = SoundMan.privInstance();
            pMan.music = pMan.sndEngine.Play2D(pMan.ufoHighPitch, false, false, false);
            pMan.music.Volume = 0.2f;
        }*/
        public static void PlayUFOSound()
        {
            SoundMan pMan = SoundMan.privInstance();
            pMan.music = pMan.sndEngine.Play2D(pMan.ufoLowPitch, true, false, false);
            pMan.music.Volume = 0.2f;
        }
        public static void Stop()
        {
            SoundMan pMan = SoundMan.privInstance();
            pMan.sndEngine.StopAllSounds();
        }

        // Data: ----------------------------------------------
        private static SoundMan instance = null;
        public IrrKlang.ISoundEngine sndEngine = null;
        public IrrKlang.ISoundSource explosionSnd = null;
        public IrrKlang.ISoundSource sndVader0 = null;
        public IrrKlang.ISoundSource sndVader1 = null;
        public IrrKlang.ISoundSource sndVader2 = null;
        public IrrKlang.ISoundSource sndVader3 = null;
        public IrrKlang.ISoundSource playerDead = null;
        public IrrKlang.ISoundSource shoot = null;
        public IrrKlang.ISoundSource ufoHighPitch = null;
        public IrrKlang.ISoundSource ufoLowPitch = null;
        public IrrKlang.ISound music = null;
        int soundIndex;


    }
}

// --- End of File ---
