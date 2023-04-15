//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneSelect : SceneState
    {
        public SceneSelect()
        {
          

            this.Initialize();
        }
        private static void LoadTextures()
        {
            TextureMan.Add(Texture.Name.SpaceInvaders, "SpaceInvaders_ROM.tga");
        }
        private static void LoadGlyphs()
        {
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('A'), Texture.Name.SpaceInvaders, 3, 36, 5, 8);    // .A
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('B'), Texture.Name.SpaceInvaders, 11, 36, 5, 8);   // .B
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('C'), Texture.Name.SpaceInvaders, 19, 36, 5, 8);   // .C
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('D'), Texture.Name.SpaceInvaders, 27, 36, 5, 8);   // .D
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('E'), Texture.Name.SpaceInvaders, 35, 36, 5, 8);   // .E
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('F'), Texture.Name.SpaceInvaders, 43, 36, 5, 8);   // .F
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('G'), Texture.Name.SpaceInvaders, 51, 36, 5, 8);   // .G
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('H'), Texture.Name.SpaceInvaders, 59, 36, 5, 8);   // .H
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('I'), Texture.Name.SpaceInvaders, 67, 36, 5, 8);   // .I
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('J'), Texture.Name.SpaceInvaders, 75, 36, 5, 8);   // .J
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('K'), Texture.Name.SpaceInvaders, 83, 36, 5, 8);   // .K
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('L'), Texture.Name.SpaceInvaders, 91, 36, 5, 8);   // .L
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('M'), Texture.Name.SpaceInvaders, 99, 36, 5, 8);   // .M
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('N'), Texture.Name.SpaceInvaders, 3, 46, 5, 8);    // .N
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('O'), Texture.Name.SpaceInvaders, 11, 46, 5, 8);   // .O
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('P'), Texture.Name.SpaceInvaders, 19, 46, 5, 8);   // .P
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('Q'), Texture.Name.SpaceInvaders, 27, 46, 5, 8);   // .Q
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('R'), Texture.Name.SpaceInvaders, 35, 46, 5, 8);   // .R
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('S'), Texture.Name.SpaceInvaders, 43, 46, 5, 8);   // .S
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('T'), Texture.Name.SpaceInvaders, 51, 46, 5, 8);   // .T
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('U'), Texture.Name.SpaceInvaders, 59, 46, 5, 8);   // .U
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('V'), Texture.Name.SpaceInvaders, 67, 46, 5, 8);   // .V
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('W'), Texture.Name.SpaceInvaders, 75, 46, 5, 8);   // .W
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('X'), Texture.Name.SpaceInvaders, 83, 46, 5, 8);   // .X
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('Y'), Texture.Name.SpaceInvaders, 91, 46, 5, 8);   // .Y
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('Z'), Texture.Name.SpaceInvaders, 99, 46, 5, 8);   // .Z
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('0'), Texture.Name.SpaceInvaders, 3, 56, 5, 8);    // 0
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('1'), Texture.Name.SpaceInvaders, 11, 56, 5, 8);   // 1
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('2'), Texture.Name.SpaceInvaders, 19, 56, 5, 8);   // 2
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('3'), Texture.Name.SpaceInvaders, 27, 56, 5, 8);   // 3
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('4'), Texture.Name.SpaceInvaders, 35, 56, 5, 8);   // 4
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('5'), Texture.Name.SpaceInvaders, 43, 56, 5, 8);   // 5
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('6'), Texture.Name.SpaceInvaders, 51, 56, 5, 8);   // 6
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('7'), Texture.Name.SpaceInvaders, 59, 56, 5, 8);   // 7
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('8'), Texture.Name.SpaceInvaders, 67, 56, 5, 8);   // 8
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('9'), Texture.Name.SpaceInvaders, 75, 56, 5, 8);   // 9
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('<'), Texture.Name.SpaceInvaders, 83, 56, 5, 8);   // <
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('>'), Texture.Name.SpaceInvaders, 91, 56, 5, 8);   // >
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte(' '), Texture.Name.SpaceInvaders, 99, 56, 1, 8);   // Space
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('='), Texture.Name.SpaceInvaders, 107, 56, 5, 8);  // =
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('*'), Texture.Name.SpaceInvaders, 115, 56, 5, 8);  // *
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('?'), Texture.Name.SpaceInvaders, 123, 56, 5, 8);  // ?
            GlyphMan.Add(Glyph.Name.SpaceInvaders, Convert.ToByte('-'), Texture.Name.SpaceInvaders, 131, 56, 5, 8);  // -
        }
        public override void Initialize()
        {
            LoadTextures();

            LoadGlyphs();


            this.poSpriteBatchMan = new SpriteBatchMan(3, 1);
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);

            this.poFontMan = new FontMan(3, 1);
            FontMan.SetActive(this.poFontMan);

            //Create Input manager scpecific to this scene
            this.poInputMan = new InputMan();
            InputMan.SetActive(this.poInputMan);

            this.pScoreMan = ScoreMan.Create();
            ScoreMan.SetActive(this.pScoreMan);
            //ScoreMan.SetActive(this.pScoreMan);

            SpriteBatchMan.Add(SpriteBatch.Name.Texts);
            SpriteBatchMan.Add(SpriteBatch.Name.ScoreSceneAlien);


            ScoreMan.AddDisplay();
        }

        private void LoadOnEntry()
        {

            //   (string pMessage, float deltaTimeToTrigger, float delayTime,
            //   float xPos, float yPos, float scale,
            //   float red, float green, float blue)

            SpriteBatchMan.Add(SpriteBatch.Name.Texts);

            GameObject pUFORoot = new UFORoot(GameObject.Name.UFORoot, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            GameObjectNodeMan.Attach(pUFORoot);

            TimedCharacterFactory.Install("P L A Y",               0.1f,  0.10f, 300, 600, 3.8f, 0.75f, 0.41f, 0.37f);
            TimedCharacterFactory.Install("S P A C E  I N V A D E R S",    1.0f,  0.01f, 200, 550, 4.0f, 0.75f, 0.41f, 0.37f);

            TimedCharacterFactory.Install("*  S C O R E  A D V A N C E  T A B L E  *",    1.4f,  0.01f, 100, 425, 4.0f, 0.69f, 0.89f, 0.94f);

            DrawAlienCmd pCommand = new DrawAlienCmd(GameObject.Name.UFO, 230, 320);
            TimerEventMan.Add(TimerEvent.Name.DrawAlienCmd, pCommand, 2.5f);

            pCommand = new DrawAlienCmd(GameObject.Name.Squid, 230, 275);
            TimerEventMan.Add(TimerEvent.Name.DrawAlienCmd, pCommand, 2.6f);

            pCommand = new DrawAlienCmd(GameObject.Name.Crab, 230, 235);
            TimerEventMan.Add(TimerEvent.Name.DrawAlienCmd, pCommand, 2.7f);

            pCommand = new DrawAlienCmd(GameObject.Name.Octopus, 230, 195);
            TimerEventMan.Add(TimerEvent.Name.DrawAlienCmd, pCommand, 2.8f);

            TimedCharacterFactory.Install("=    ?    M Y S T E R Y",        3.0f,  0.01f, 300, 320, 3.6f, 0.61f, 0.4f, 0.67f);
            TimedCharacterFactory.Install("=   3 0   P O I N T S",        4.0f, 0.01f, 300, 275, 3.6f, 0.66f, 0.83f, 0.55f);
            TimedCharacterFactory.Install("=   2 0   P O I N T S",        5.0f, 0.01f, 300, 235, 3.6f, 0.85f, 0.8f, 0.58f);
            TimedCharacterFactory.Install("=   1 0   P O I N T S",        6.0f, 0.01f, 300, 195, 3.6f, 0.75f, 0.41f, 0.37f);
            
            TimedCharacterFactory.Install("P R E S S   - S -   T O   S T A R T",        7.0f, 0.01f, 150.0f, 100.0f, 3.6f);

            //---------------------------------------------------------------------------------------------------------
            // Input
            //---------------------------------------------------------------------------------------------------------
            InputMan.SetActive(this.poInputMan);

            InputSubject pInputSubject = InputMan.GetKeyS_Subject();
            pInputSubject.Attach(new StartGameObserver());
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
                // Fire off the timer events
                TimerEventMan.Update(Simulation.GetTotalTime());

                /*// Do the collision checks
                ColPairMan.Process();*/

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
            Simulation.Reset();
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);
            FontMan.SetActive(this.poFontMan);

            this.poTimerEventMan = new TimerEventMan(3, 1);
            TimerEventMan.SetActive(this.poTimerEventMan);

            ScoreMan.SetActive(this.pScoreMan);

            SpriteBatchMan.Add(SpriteBatch.Name.Texts);
            SpriteBatchMan.Add(SpriteBatch.Name.ScoreSceneAlien);

            //FontMan.Dump();
            //  TimerEventMan.Dump();


            // Update timer since last pause
            float t0 = GlobalTimer.GetTime();
            float t1 = this.TimeAtPause;
            float delta = t0 - t1;
            TimerEventMan.PauseUpdate(-t1);


            this.LoadOnEntry();

            ScoreMan.updateDisplay();

        }
        public override void Leaving()
        {
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
        public InputMan poInputMan;
        public TimerEventMan poTimerEventMan;
        public ScoreMan pScoreMan;

    }
}

// --- End of File ---
