using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneContext
    {
        public enum Scene
        {
            Select,
            Play,
            Over
        }
        public static void Create()
        {
            // initialize the singleton here
            Debug.Assert(psInstance == null);

            // Do the initialization
            if (psInstance == null)
            {
                //LTN - TextureMan
                //Singleton
                psInstance = new SceneContext();
            }
        }
        private SceneContext()
        {
            // reserve the states
            this.poSceneSelect = new SceneSelect();
            this.poScenePlay = new ScenePlay();
            this.poSceneOver = new SceneOver();

            // initialize to the select state
            this.pSceneState = this.poSceneSelect;
            //this.pSceneState.Transition();
            this.pSceneState.Entering();
        }

        public static SceneState GetState()
        {
            return SceneContext.privGetInstance().pSceneState;
        }
        public static void SetState(Scene eScene)
        {
            SceneContext pSceneContext = SceneContext.privGetInstance();
            switch (eScene)
            {
                case Scene.Select:

                    pSceneContext.pSceneState.Leaving();
                    pSceneContext.pSceneState = pSceneContext.poSceneSelect;
                    pSceneContext.pSceneState.Entering();
                    break;

                case Scene.Play:
                    pSceneContext.pSceneState.Leaving();
                    pSceneContext.pSceneState = pSceneContext.poScenePlay;
                    pSceneContext.pSceneState.Entering();
                    break;

                case Scene.Over:
                    pSceneContext.pSceneState.Leaving();
                    pSceneContext.pSceneState = pSceneContext.poSceneOver;
                    pSceneContext.pSceneState.Entering();
                    break;

            }
        }
        private static SceneContext privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(psInstance != null);

            return psInstance;
        }
        // ----------------------------------------------------
        // Data: 
        // -------------------------------------------o---------
        SceneState pSceneState;
        SceneSelect poSceneSelect;
        SceneOver poSceneOver;
        ScenePlay poScenePlay;

        private static SceneContext psInstance;

    }
}