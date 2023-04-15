//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpaceInvaders : Azul.Game
    {
       
        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("SPACE INVADERS");
            this.SetWidthHeight(672, 768);
            this.SetClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {
            

            LoadManagers();


            /* // start up the engine
             pSndEngine = new IrrKlang.ISoundEngine(IrrKlang.SoundOutputDriver.DirectSound8, IrrKlang.SoundEngineOptionFlag.PrintDebugInfoIntoDebugger);
             pSndVader0 = pSndEngine.AddSoundSourceFromFile("fastinvader1.wav");
             pSndVader0.DefaultVolume = 0.0f;
             IrrKlang.ISound pSnd = pSndEngine.Play2D(pSndVader0, false, false, false);
             pSndVader0.DefaultVolume = 1.0f;*/


            SceneContext.Create();

           

        }

        

        private static void LoadManagers()
        {
            Simulation.Create();
            TextureMan.Create();
            
            ImageMan.Create();

            SpriteBatchMan.Create();
            SpriteGameMan.Create();
            SpriteBoxMan.Create();
            TimerEventMan.Create();
            SpriteGameProxyMan.Create(10, 1);
            GameObjectNodeMan.Create();
            ColPairMan.Create();
            GlyphMan.Create();
            FontMan.Create();
            GhostMan.Create();


        }


       

       

       


        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        /*bool lastKeyR = false;
        bool lastKeyE = false;*/
        public override void Update()
        {
            GlobalTimer.Update(this.GetTime());
            //  stuff called every update no matter the scene here... 
            //  example: like audio update

            // Hack to proof of concept... 
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_1) == true)
            {
                SpriteBatchMan.Find(SpriteBatch.Name.Boxes).SetDrawEnable(false);
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_2) == true)
            {
                SpriteBatchMan.Find(SpriteBatch.Name.Boxes).SetDrawEnable(true);
            }

            

            // Update the scene
            SceneContext.GetState().Update(this.GetTime());


            /*if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_T) == true)
            {
                SpriteBatch pSB = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
                Debug.Assert(pSB != null);
                pSB.SetDrawEnable(false);
                
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_Y) == true)
            {
                SpriteBatch pSB = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
                Debug.Assert(pSB != null);
                pSB.SetDrawEnable(true);
            }*/

        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            /*     // draw all objects
                 SpriteBatchMan.Draw();*/

            SceneContext.GetState().Draw();

        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {
            /*GameObjectNodeMan.Destroy();
            TimerEventMan.Destroy();
            ImageMan.Destroy();
            TextureMan.Destroy();
            SpriteGameMan.Destroy();
            SpriteBatchMan.Destroy();
            SpriteBoxMan.Destroy();
            ColPairMan.Destroy();
            GlyphMan.Destroy();
            FontMan.Destroy();
            GhostMan.Destroy();*/
        }

    }
}

// --- End of File ---
