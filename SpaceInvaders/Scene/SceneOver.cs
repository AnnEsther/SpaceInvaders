using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneOver : SceneState
    {
        public SceneOver()
        {
            this.Initialize();
        }
        private static void LoadTextures()
        {
            TextureMan.Add(Texture.Name.SpaceInvaders, "SpaceInvaders_ROM.tga");
        }
        private static void CreateImages()
        {

            ImageMan.Add(Image.Name.A, Texture.Name.SpaceInvaders, 3, 36, 5, 7);
            ImageMan.Add(Image.Name.B, Texture.Name.SpaceInvaders, 11, 36, 5, 7);
            ImageMan.Add(Image.Name.C, Texture.Name.SpaceInvaders, 19, 36, 5, 7);
            ImageMan.Add(Image.Name.D, Texture.Name.SpaceInvaders, 27, 36, 5, 7);
            ImageMan.Add(Image.Name.E, Texture.Name.SpaceInvaders, 35, 36, 5, 7);
            ImageMan.Add(Image.Name.F, Texture.Name.SpaceInvaders, 43, 36, 5, 7);
            ImageMan.Add(Image.Name.G, Texture.Name.SpaceInvaders, 51, 36, 5, 7);
            ImageMan.Add(Image.Name.H, Texture.Name.SpaceInvaders, 59, 36, 5, 7);
            ImageMan.Add(Image.Name.I, Texture.Name.SpaceInvaders, 67, 36, 5, 7);
            ImageMan.Add(Image.Name.J, Texture.Name.SpaceInvaders, 75, 36, 5, 7);
            ImageMan.Add(Image.Name.K, Texture.Name.SpaceInvaders, 83, 36, 5, 7);
            ImageMan.Add(Image.Name.L, Texture.Name.SpaceInvaders, 91, 36, 5, 7);
            ImageMan.Add(Image.Name.M, Texture.Name.SpaceInvaders, 99, 36, 5, 7);

            ImageMan.Add(Image.Name.N, Texture.Name.SpaceInvaders, 3, 46, 5, 7);
            ImageMan.Add(Image.Name.O, Texture.Name.SpaceInvaders, 11, 46, 5, 7);
            ImageMan.Add(Image.Name.P, Texture.Name.SpaceInvaders, 19, 46, 5, 7);
            ImageMan.Add(Image.Name.Q, Texture.Name.SpaceInvaders, 27, 46, 5, 7);
            ImageMan.Add(Image.Name.R, Texture.Name.SpaceInvaders, 35, 46, 5, 7);
            ImageMan.Add(Image.Name.S, Texture.Name.SpaceInvaders, 43, 46, 5, 7);
            ImageMan.Add(Image.Name.T, Texture.Name.SpaceInvaders, 51, 46, 5, 7);
            ImageMan.Add(Image.Name.U, Texture.Name.SpaceInvaders, 59, 46, 5, 7);
            ImageMan.Add(Image.Name.V, Texture.Name.SpaceInvaders, 67, 46, 5, 7);
            ImageMan.Add(Image.Name.W, Texture.Name.SpaceInvaders, 75, 46, 5, 7);
            ImageMan.Add(Image.Name.X, Texture.Name.SpaceInvaders, 83, 46, 5, 7);
            ImageMan.Add(Image.Name.Y, Texture.Name.SpaceInvaders, 91, 46, 5, 7);
            ImageMan.Add(Image.Name.Z, Texture.Name.SpaceInvaders, 99, 46, 5, 7);

            ImageMan.Add(Image.Name.Zero, Texture.Name.SpaceInvaders, 3, 56, 5, 7);
            ImageMan.Add(Image.Name.One, Texture.Name.SpaceInvaders, 11, 56, 5, 7);
            ImageMan.Add(Image.Name.Two, Texture.Name.SpaceInvaders, 19, 56, 5, 7);
            ImageMan.Add(Image.Name.Three, Texture.Name.SpaceInvaders, 27, 56, 5, 7);
            ImageMan.Add(Image.Name.Four, Texture.Name.SpaceInvaders, 35, 56, 5, 7);
            ImageMan.Add(Image.Name.Five, Texture.Name.SpaceInvaders, 43, 56, 5, 7);
            ImageMan.Add(Image.Name.Six, Texture.Name.SpaceInvaders, 51, 56, 5, 7);
            ImageMan.Add(Image.Name.Seven, Texture.Name.SpaceInvaders, 59, 56, 5, 7);
            ImageMan.Add(Image.Name.Eight, Texture.Name.SpaceInvaders, 67, 56, 5, 7);
            ImageMan.Add(Image.Name.Nine, Texture.Name.SpaceInvaders, 75, 56, 5, 7);
            ImageMan.Add(Image.Name.LessThan, Texture.Name.SpaceInvaders, 83, 56, 5, 7);
            ImageMan.Add(Image.Name.GreaterThan, Texture.Name.SpaceInvaders, 91, 56, 5, 7);
            ImageMan.Add(Image.Name.Space, Texture.Name.SpaceInvaders, 99, 56, 5, 7);
            ImageMan.Add(Image.Name.Equals, Texture.Name.SpaceInvaders, 107, 56, 5, 7);
            ImageMan.Add(Image.Name.Asterisk, Texture.Name.SpaceInvaders, 115, 56, 5, 7);
            ImageMan.Add(Image.Name.Question, Texture.Name.SpaceInvaders, 123, 56, 5, 7);
            ImageMan.Add(Image.Name.Hyphen, Texture.Name.SpaceInvaders, 131, 56, 5, 7);

        }
        
        public override void Initialize()
        {
            this.poSpriteBatchMan = new SpriteBatchMan(3, 1);
            this.poFontMan = new FontMan(3, 1);
            this.poTimerEventMan = new TimerEventMan(3, 1);
            this.poInputMan = new InputMan();

            SpriteBatchMan.SetActive(this.poSpriteBatchMan);
            FontMan.SetActive(this.poFontMan);
            TimerEventMan.SetActive(this.poTimerEventMan);

            SpriteBatchMan.Add(SpriteBatch.Name.Texts);

            LoadTextures();
            CreateImages();

            this.pScoreMan = ScoreMan.Create();
            ScoreMan.SetActive(this.pScoreMan);
            ScoreMan.AddDisplay();

        }
        public override void Update(float systemTime)
        {
            // Single Step, Free running...
            Simulation.Update(systemTime);

            // Input
            InputMan.Update();

            // Run based on simulation stepping
            if (Simulation.GetTimeStep() > 0.0f)
            {
                //TO DO
                // Fire off the timer events
                TimerEventMan.Update(Simulation.GetTotalTime());

                // Do the collision checks
                //ColPairMan.Process();

                // walk through all objects and push to flyweight
                GameObjectNodeMan.Update();

                // Delete any objects here...
                DelayedObjectMan.Process();
            }
        }
        public override void Draw()
        {
            // draw all objects
            SpriteBatchMan.Draw();
        }
        public override void Entering()
        {
            //Clear previous Timer
            //TimerEventMan.Destroy();


            Simulation.Reset();
            // update SpriteBatchMan()
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);
            FontMan.SetActive(this.poFontMan);
            TimerEventMan.SetActive(this.poTimerEventMan);
            InputMan.SetActive(this.poInputMan);

            SpriteBatchMan.Add(SpriteBatch.Name.Texts);

            TimedCharacterFactory.Install("G A M E   O V E R", 0.10f, 0.01f, 250, 400, 3.0f);

            SceneSelectCommand pCommand = new SceneSelectCommand();
            TimerEventMan.Add(TimerEvent.Name.SceneSelectCommand, pCommand, 2.0f);

            //TimedCharacterFactory.Install("P R E S S   S P A C E   T O   S T A R T", 0.0f, 0.30f, 200, 450, 3.0f, 0.0f, 0.0f, 0.0f);
            ScoreMan.SetActive(this.pScoreMan);
            ScoreMan.updateDisplay();
        }
        public override void Leaving()
        {
            // update SpriteBatchMan()
            this.TimeAtPause = TimerEventMan.GetCurrTime();

            SpriteBatchMan.Destroy();


            // FontMan.RemoveAll();

            // FontMan.Dump();
            TimerEventMan.Destroy();
        }
        // ---------------------------------------------------
        // Data
        // ---------------------------------------------------
        public SpriteBatchMan poSpriteBatchMan;
        public FontMan poFontMan;
        public TimerEventMan poTimerEventMan;
        public InputMan poInputMan;
        public ScoreMan pScoreMan;
    }
}