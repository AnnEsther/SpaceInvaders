using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ScenePlay : SceneState
    {
        public ScenePlay()
        {
            this.Initialize();
        }
        private static void LoadTextures()
        {
            TextureMan.Add(Texture.Name.Consolas36pt, "consolas36pt.tga");
            TextureMan.Add(Texture.Name.SpaceInvaders, "SpaceInvaders_ROM.tga");
            TextureMan.Add(Texture.Name.Birds, "Birds_N_Shield.tga");
        }
        private static void CreateImages()
        {
            ImageMan.Add(Image.Name.OctopusA, Texture.Name.SpaceInvaders, 3, 3, 12, 8);
            ImageMan.Add(Image.Name.OctopusB, Texture.Name.SpaceInvaders, 18, 3, 12, 8);
            ImageMan.Add(Image.Name.CrabA, Texture.Name.SpaceInvaders, 33, 3, 11, 8);
            ImageMan.Add(Image.Name.CrabB, Texture.Name.SpaceInvaders, 47, 3, 11, 8);
            ImageMan.Add(Image.Name.SquidA, Texture.Name.SpaceInvaders, 61, 3, 8, 8);
            ImageMan.Add(Image.Name.SquidB, Texture.Name.SpaceInvaders, 72, 3, 8, 8);
            ImageMan.Add(Image.Name.AlienExplosion, Texture.Name.SpaceInvaders, 83, 3, 13, 8);
           

            ImageMan.Add(Image.Name.Player, Texture.Name.SpaceInvaders, 3, 14, 13, 8);
            ImageMan.Add(Image.Name.PlayerExplosionA, Texture.Name.SpaceInvaders, 19, 14, 16, 8);
            ImageMan.Add(Image.Name.PlayerExplosionB, Texture.Name.SpaceInvaders, 38, 14, 16, 8);
            ImageMan.Add(Image.Name.AlienPullYA, Texture.Name.SpaceInvaders, 57, 14, 15, 8);
            ImageMan.Add(Image.Name.AlienPullYB, Texture.Name.SpaceInvaders, 75, 14, 15, 8);
            ImageMan.Add(Image.Name.AlienPullUpisdeDownYA, Texture.Name.SpaceInvaders, 93, 14, 14, 8);
            ImageMan.Add(Image.Name.AlienPullUpsideDownYB, Texture.Name.SpaceInvaders, 110, 14, 14, 8);

            ImageMan.Add(Image.Name.PlayerShot, Texture.Name.SpaceInvaders, 3, 29, 1, 4);
            ImageMan.Add(Image.Name.PlayerShotExplosion, Texture.Name.SpaceInvaders, 7, 25, 8, 8);
            ImageMan.Add(Image.Name.SquigglyShotA, Texture.Name.SpaceInvaders, 18, 26, 3, 7);
            ImageMan.Add(Image.Name.SquigglyShotB, Texture.Name.SpaceInvaders, 24, 26, 3, 7);
            ImageMan.Add(Image.Name.SquigglyShotC, Texture.Name.SpaceInvaders, 30, 26, 3, 7);
            ImageMan.Add(Image.Name.SquigglyShotD, Texture.Name.SpaceInvaders, 36, 26, 3, 7);
            ImageMan.Add(Image.Name.PlungerShotA, Texture.Name.SpaceInvaders, 42, 27, 3, 6);
            ImageMan.Add(Image.Name.PlungerShotB, Texture.Name.SpaceInvaders, 48, 27, 3, 6);
            ImageMan.Add(Image.Name.PlungerShotC, Texture.Name.SpaceInvaders, 54, 27, 3, 6);
            ImageMan.Add(Image.Name.PlungerShotD, Texture.Name.SpaceInvaders, 60, 27, 3, 6);
            ImageMan.Add(Image.Name.RollingShotA, Texture.Name.SpaceInvaders, 65, 26, 3, 7);
            ImageMan.Add(Image.Name.RollingShotB, Texture.Name.SpaceInvaders, 70, 26, 3, 7);
            ImageMan.Add(Image.Name.RollingShotC, Texture.Name.SpaceInvaders, 75, 26, 3, 7);
            ImageMan.Add(Image.Name.RollingShotD, Texture.Name.SpaceInvaders, 80, 26, 3, 7);
            ImageMan.Add(Image.Name.AlienShotExplosion, Texture.Name.SpaceInvaders, 86, 25, 6, 8);

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

            ImageMan.Add(Image.Name.Brick, Texture.Name.Birds, 20, 210, 10, 5);
            ImageMan.Add(Image.Name.BrickLeft_Top0, Texture.Name.Birds, 15, 180, 10, 10);
            ImageMan.Add(Image.Name.BrickLeft_Bottom, Texture.Name.Birds, 36, 215, 10, 5);
            ImageMan.Add(Image.Name.BrickRight_Top0, Texture.Name.Birds, 75, 180, 10, 10);
            ImageMan.Add(Image.Name.BrickRight_Bottom, Texture.Name.Birds, 55, 215, 10, 5);

            ImageMan.Add(Image.Name.Saucer, Texture.Name.SpaceInvaders, 99, 3, 16, 8);
            ImageMan.Add(Image.Name.SaucerExplosion, Texture.Name.SpaceInvaders, 118, 3, 21, 8);

        }

        private static void CreateSprites()
        {
            SpriteGameMan.Add(SpriteGame.Name.SquidA, Image.Name.SquidA, 125, 550, 24, 25);
            SpriteGameMan.Add(SpriteGame.Name.SquidB, Image.Name.SquidB, 125, 550, 24, 25);
            SpriteGameMan.Add(SpriteGame.Name.CrabA, Image.Name.CrabA, 125, 550, 28, 25);
            SpriteGameMan.Add(SpriteGame.Name.CrabB, Image.Name.CrabB, 125, 550, 28, 25);
            SpriteGameMan.Add(SpriteGame.Name.OctopusA, Image.Name.OctopusA, 125, 550, 36, 25);
            SpriteGameMan.Add(SpriteGame.Name.OctopusB, Image.Name.OctopusB, 125, 550, 36, 25);
            SpriteGameMan.Add(SpriteGame.Name.AlienExplosion, Image.Name.AlienExplosion, 125, 550, 36, 25);

            SpriteGameMan.Add(SpriteGame.Name.PlayerShot, Image.Name.PlayerShot, 125, 550, 3, 12);
            SpriteGameMan.Add(SpriteGame.Name.Player, Image.Name.Player, 125, 550, 39, 24);
            SpriteGameMan.Add(SpriteGame.Name.PlayerExplosionA, Image.Name.PlayerExplosionA, 125, 550, 39, 24);

            SpriteGameMan.Add(SpriteGame.Name.SquigglyShotA, Image.Name.SquigglyShotA, 125, 550, 9, 21);
            SpriteGameMan.Add(SpriteGame.Name.PlungerShotA, Image.Name.PlungerShotA, 125, 550, 9, 21);
            SpriteGameMan.Add(SpriteGame.Name.PlungerShotB, Image.Name.PlungerShotB, 125, 550, 9, 21);
            SpriteGameMan.Add(SpriteGame.Name.RollingShotA, Image.Name.RollingShotA, 125, 550, 9, 21);

            SpriteGameMan.Add(SpriteGame.Name.Brick, Image.Name.Brick, 50, 25,                          10.0f, 10.0f);
            SpriteGameMan.Add(SpriteGame.Name.Brick_LeftTop0, Image.Name.BrickLeft_Top0, 50, 25,        10.0f, 10.0f);
            SpriteGameMan.Add(SpriteGame.Name.Brick_LeftBottom, Image.Name.BrickLeft_Bottom, 50, 25,    10.0f, 10.0f);
            SpriteGameMan.Add(SpriteGame.Name.Brick_RightTop0, Image.Name.BrickRight_Top0, 131, 31,     10.0f, 10.0f);
            SpriteGameMan.Add(SpriteGame.Name.Brick_RightBottom, Image.Name.BrickRight_Bottom, 50, 25,  10.0f, 10.0f);

            SpriteGameMan.Add(SpriteGame.Name.Hyphen, Image.Name.Hyphen, 50, 25,  3.0f, 1.0f);

            SpriteGameMan.Add(SpriteGame.Name.Saucer, Image.Name.Saucer, 50, 25,  48.0f, 24.0f);


        }
        private static void CreateSpriteBatches()
        {
            SpriteBatchMan.Add(SpriteBatch.Name.AlienBatch);
            SpriteBatchMan.Add(SpriteBatch.Name.SpriteBoxBatch);
            SpriteBatchMan.Add(SpriteBatch.Name.Missile);
            SpriteBatchMan.Add(SpriteBatch.Name.Texts);
            SpriteBatchMan.Add(SpriteBatch.Name.Boxes);
            SpriteBatchMan.Add(SpriteBatch.Name.Shields);
            SpriteBatchMan.Add(SpriteBatch.Name.Bombs);
            SpriteBatchMan.Add(SpriteBatch.Name.Player);
            SpriteBatchMan.Add(SpriteBatch.Name.Ground);
            SpriteBatchMan.Add(SpriteBatch.Name.LifeMan);

        }
        private static void CreateInputs()
        {
            //---------------------------------------------------------------------------------------------------------
            // Input
            //---------------------------------------------------------------------------------------------------------

            InputSubject pInputSubject = InputMan.GetArrowRightSubject();
            pInputSubject.Attach(new MoveRightObserver());

            pInputSubject = InputMan.GetArrowLeftSubject();
            pInputSubject.Attach(new MoveLeftObserver());

            pInputSubject = InputMan.GetSpaceSubject();
            pInputSubject.Attach(new ShootObserver());
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
            GameStart = false;

            LoadTextures();
            CreateImages();

            this.poSpriteBatchMan = new SpriteBatchMan(3, 1);
            this.poFontMan = new FontMan(3, 1);

            SpriteBatchMan.SetActive(this.poSpriteBatchMan);
            FontMan.SetActive(this.poFontMan);


            CreateSprites();
            CreateSpriteBatches();
            LoadGlyphs();


            //Create Input manager scpecific to this scene
            this.poInputMan = new InputMan();

            Simulation.SetState(Simulation.State.Realtime);

            CreateCredits();

            this.pScoreMan = ScoreMan.Create();
            ScoreMan.AddDisplay();

            SoundMan.Create();

            LifeMan.Create();

            InputMan.SetActive(this.poInputMan);
            CreateInputs();

        }

        private static BumperRoot CreateBumpers()
        {
            BumperRoot pBumperRoot = new BumperRoot(GameObject.Name.BumperRoot, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            pBumperRoot.ActivateSprite(SpriteBatch.Name.Boxes);

            BumperRight pBumperRight = new BumperRight(GameObject.Name.BumperRight, SpriteGame.Name.NullObject, 650, 100, 50, 100);
            pBumperRight.ActivateCollisionSprite(SpriteBatch.Name.Boxes);

            BumperLeft pBumperLeft = new BumperLeft(GameObject.Name.BumperLeft, SpriteGame.Name.NullObject, 0, 100, 50, 100);
            pBumperLeft.ActivateCollisionSprite(SpriteBatch.Name.Boxes);

            // Add to the composite the children
            pBumperRoot.Add(pBumperRight);
            pBumperRoot.Add(pBumperLeft);

            GameObjectNodeMan.Attach(pBumperRoot);
            return pBumperRoot;
        }

        private static GameObject CreateShields()
        {
            GameObject pShieldRoot = ShieldFactory.CreateSingleShield(GameObject.Name.ShieldGrid_0, 91.0f, 190, 10.0f, 10.0f);
            pShieldRoot = ShieldFactory.CreateSingleShield(GameObject.Name.ShieldGrid_1, 232.0f, 190, 10.0f, 10.0f);
            pShieldRoot = ShieldFactory.CreateSingleShield(GameObject.Name.ShieldGrid_2, 373.0f, 190, 10.0f, 10.0f);
            pShieldRoot = ShieldFactory.CreateSingleShield(GameObject.Name.ShieldGrid_3, 514.0f, 190, 10.0f, 10.0f);
            return pShieldRoot;
        }

        private static void CreateCredits()
        {
            Font pCreditsFont = FontMan.Add(Font.Name.Credits, SpriteBatch.Name.Texts, "C R E D I T", Glyph.Name.SpaceInvaders, 485, 30);
            pCreditsFont.SetScale(3.0f);

            Font pCreditsValueFont = FontMan.Add(Font.Name.Credits, SpriteBatch.Name.Texts, "0 0", Glyph.Name.SpaceInvaders, 608, 30);
            pCreditsValueFont.SetScale(3.0f);
        }

        private static ShipRoot CreateShipRoot()
        {
            ShipRoot pShipRoot = null;
            GameObjectNode pGameObjectNode = GhostMan.Find(GameObject.Name.ShipRoot);
            if (pGameObjectNode == null)
            {
                 pShipRoot = new ShipRoot(GameObject.Name.ShipRoot, SpriteGame.Name.NullObject, 0.0f, 0.0f);
                /*  pShipRoot.ActivateSprite(SpriteBatch.Name.Player);*/
                pShipRoot.ActivateCollisionSprite(SpriteBatch.Name.Boxes);
                GameObjectNodeMan.Attach(pShipRoot);
            }
            else
            {
                pShipRoot = (ShipRoot)pGameObjectNode.pGameObj;
                GhostMan.Remove(pGameObjectNode);
                pShipRoot.Resurrect();
                pShipRoot.x = 0;
                pShipRoot.y = 0;
            }
            return pShipRoot;
        }

        private static MissileGroup CreateMissileGroup()
        {
            MissileGroup pMissileGroup = new MissileGroup();
            pMissileGroup.ActivateSprite(SpriteBatch.Name.Missile);
            pMissileGroup.ActivateCollisionSprite(SpriteBatch.Name.Missile);

            GameObjectNodeMan.Attach(pMissileGroup);
            return pMissileGroup;
        }

        private static void CreateWalls(out WallGroup pWallGroup, out WallTop pWallTop)
        {
            pWallGroup = new WallGroup(GameObject.Name.WallGroup, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            pWallGroup.ActivateCollisionSprite(SpriteBatch.Name.Boxes);

            WallRight pWallRight = new WallRight(GameObject.Name.WallRight, SpriteGame.Name.NullObject, 650, 400, 20, 650);
            pWallRight.ActivateCollisionSprite(SpriteBatch.Name.Boxes);

            WallLeft pWallLeft = new WallLeft(GameObject.Name.WallLeft, SpriteGame.Name.NullObject, 20, 400, 20, 650);
            pWallLeft.ActivateCollisionSprite(SpriteBatch.Name.Boxes);

            pWallTop = new WallTop(GameObject.Name.WallTop, SpriteGame.Name.NullObject, 336, 705, 640, 30);
            pWallTop.ActivateCollisionSprite(SpriteBatch.Name.Boxes);

            WallBottom pWallBottom = new WallBottom(GameObject.Name.WallBottom, SpriteGame.Name.NullObject, 448, 0, 1000, 30);
            pWallBottom.ActivateCollisionSprite(SpriteBatch.Name.Boxes);
            // pWallBottom.ActivateSprite(SpriteBatch.Name.AlienBatch);


            // Add to the composite the children
            pWallGroup.Add(pWallTop);
            pWallGroup.Add(pWallRight);
            pWallGroup.Add(pWallLeft);
            pWallGroup.Add(pWallBottom);
        }

        private static BombRoot CreateBombRoot()
        {
            BombRoot pBombRoot = new BombRoot(GameObject.Name.BombRoot, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            pBombRoot.ActivateCollisionSprite(SpriteBatch.Name.Boxes);
            pBombRoot.ActivateSprite(SpriteBatch.Name.Bombs);

            GameObjectNodeMan.Attach(pBombRoot);
            return pBombRoot;
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

                // Do the collision checks
                ColPairMan.Process();

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

            this.poTimerEventMan = new TimerEventMan(3, 1);
            TimerEventMan.SetActive(this.poTimerEventMan);


            //Simulation.Reset();
            // update SpriteBatchMan()
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);
            FontMan.SetActive(this.poFontMan);
            InputMan.SetActive(this.poInputMan);
           // CreateInputs();


            // Update timer since last pause
            float t0 = GlobalTimer.GetTime();
            float t1 = this.TimeAtPause;
            float delta = t0 - t1;
            TimerEventMan.PauseUpdate(delta);

            CreateSpriteBatches();

            if (GameStart == false)
            {
                GameStart = true;
            }
            else
            {
                CreateSprites();
                LoadGlyphs();
            }

            ScoreMan.SetActive(this.pScoreMan);
            ScoreMan.updateDisplay();

            

            ShipRoot pShipRoot = CreateShipRoot();
            ShipMan.Create();

            LifeMan.Reset();
            

            GameObject pAlienRoot = AlienFactory.CreateSingleAlienRow();
            AlienCmd pAlienCmd = new AlienCmd();
            TimerEventMan.Add(TimerEvent.Name.Alien, pAlienCmd, 0.5f);

            BombRoot pBombRoot = CreateBombRoot();
            BombCommand pbombCommand = new BombCommand((AlienRoot)pAlienRoot, 1.0f);
            TimerEventMan.Add(TimerEvent.Name.BombSpawn, pbombCommand, 1.0f);

            //Create UFO
            GameObject pUFORoot = new UFORoot(GameObject.Name.UFORoot, SpriteGame.Name.NullObject, 0.0f, 0.0f);
            GameObject pUFO = new UFO(SpriteGame.Name.Saucer, 700.0f, 650.0f);
            pUFORoot.Add(pUFO);
            pUFO.ActivateSprite(SpriteBatch.Name.AlienBatch);
            pUFO.ActivateCollisionSprite(SpriteBatch.Name.Boxes);
            GameObjectNodeMan.Attach(pUFORoot);

            UfoCommand pCommand = new UfoCommand(pUFO, 25.0f); //25
            TimerEventMan.Add(TimerEvent.Name.UfoCommand, pCommand, 35.0f); ///35

            MissileGroup pMissileGroup = CreateMissileGroup();

            GameObject pShieldRoot = CreateShields();
            GameObject pGroundRoot = GroundFactory.CreateGround(0.0f, 50.0f, 3.0f, 1.0f);
            BumperRoot pBumperRoot = CreateBumpers();

            WallGroup pWallGroup;
            WallTop pWallTop;
            CreateWalls(out pWallGroup, out pWallTop);
            GameObjectNodeMan.Attach(pWallGroup);

            

            CollideBombVsShield(pBombRoot, pShieldRoot);
            CollideMissileVsUFO(pMissileGroup, pUFORoot);
            CollideMissileVsWall(pMissileGroup, pWallTop);
            CollideBombVsGround(pBombRoot, pGroundRoot);
            CollideBombVsBottom(pBombRoot, pWallGroup);
            CollideMissileVsShield(pMissileGroup, pShieldRoot);
            CollideBombVsShip(pBombRoot, pShipRoot);
            CollideBumperVsShip(pShipRoot, pBumperRoot);
            CollideBombVsMissile(pBombRoot, pMissileGroup);
            CollideMissileVsAlien(pAlienRoot, pMissileGroup);
            CollideGridVsWall(((AlienRoot)pAlienRoot).GetGrid(), pWallGroup);

            SpriteBatchMan.Find(SpriteBatch.Name.Boxes).SetDrawEnable(false);

        }

        private static void CollideBombVsMissile(GameObject pBombRoot, GameObject pMissileGroup)
        {
            ColPair pColPair = ColPairMan.Add(ColPair.Name.Bumper_Ship, pMissileGroup, pBombRoot);
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new RemoveBombObserver());
        }
        private static void CollideBumperVsShip(GameObject pShipRoot, GameObject pBumperRoot)
        {
            ColPair pColPair = ColPairMan.Add(ColPair.Name.Bumper_Ship, pBumperRoot, pShipRoot);
            pColPair.Attach(new ShipMoveObserver());
        }
        private static void CollideMissileVsShield(GameObject pMissileGroup, GameObject pShieldRoot)
        {
            ColPair pColPair = ColPairMan.Add(ColPair.Name.Misslie_Shield, pMissileGroup, pShieldRoot);
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new RemoveBrickObserver());
            pColPair.Attach(new ShipReadyObserver());
        }
        private static void CollideBombVsShip(GameObject pBombRoot, GameObject pShipRoot)
        {
            ColPair pColPair = ColPairMan.Add(ColPair.Name.Bumper_Ship, pBombRoot, pShipRoot);
            pColPair.Attach(new PlayerHitObserver());
            pColPair.Attach(new RemoveBombObserver());
        }
        private static void CollideMissileVsUFO(GameObject pMissileRoot, GameObject pUFORoot)
        {
            ColPair pColPair = ColPairMan.Add(ColPair.Name.Missile_UFO, pMissileRoot, pUFORoot);
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new AlienHitObserver());
        }
        private static void CollideBombVsShield(GameObject pBombRoot, GameObject pShieldRoot)
        {
            ColPair pColPair = ColPairMan.Add(ColPair.Name.Bomb_Shield, pBombRoot, pShieldRoot);
            pColPair.Attach(new RemoveBombObserver());
            pColPair.Attach(new RemoveBrickObserver());
        }
        private static void CollideBombVsBottom(GameObject pBombRoot, GameObject pWallGroup)
        {
            ColPair pColPair = ColPairMan.Add(ColPair.Name.Bomb_Wall, pBombRoot, pWallGroup);
            pColPair.Attach(new RemoveBombObserver());
        }
        private static void CollideBombVsGround(GameObject pBombRoot, GameObject pGroundRoot)
        {
            ColPair pColPair = ColPairMan.Add(ColPair.Name.Bomb_Wall, pBombRoot, pGroundRoot);
            pColPair.Attach(new RemoveBombObserver());
            pColPair.Attach(new RemoveGroundObserver());
        }
        private static void CollideMissileVsAlien(GameObject pAlienRoot, GameObject pMissileGroup)
        {
            ColPair pColPair = ColPairMan.Add(ColPair.Name.Alien_Missile, pMissileGroup, pAlienRoot);
            Debug.Assert(pColPair != null);
            pColPair.Attach(new AlienHitObserver());
            pColPair.Attach(new RemoveMissileObserver());
        }
        private static void CollideMissileVsWall(GameObject pMissileGroup, GameObject pWallTop)
        {
            ColPair pColPair = ColPairMan.Add(ColPair.Name.Missile_Wall, pMissileGroup, pWallTop);
            Debug.Assert(pColPair != null);
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new ShipReadyObserver());
        }
        private static void CollideGridVsWall(GameObject pAlienGrid, GameObject pWallTop)
        {
            ColPair pColPair = ColPairMan.Add(ColPair.Name.Alien_Wall, pAlienGrid, pWallTop);
            Debug.Assert(pColPair != null);
            pColPair.Attach(new GridObserver());
        }

        public override void Leaving()
        {

            // Need a better way to do this
            this.TimeAtPause = GlobalTimer.GetTime();

            //CLEAR ALIEN GRID
            AlienRoot pAlienRoot = (AlienRoot)GameObjectNodeMan.Find(GameObject.Name.AlienRoot);
            pAlienRoot.ClearGrid();

            ShieldRoot pShieldRoot = (ShieldRoot)GameObjectNodeMan.Find(GameObject.Name.ShieldRoot);
            pShieldRoot.ClearGrids();

            ShipMan.Destroy();

            GameObjectNodeMan.Destroy();
            TimerEventMan.Destroy();

            ImageMan.Destroy();
            TextureMan.Destroy();
            SpriteGameMan.Destroy();

            SpriteBatchMan.Destroy();

            SpriteBoxMan.Destroy();
            ColPairMan.Destroy();
            GlyphMan.Destroy();
            FontMan.Destroy();
            GhostMan.Destroy();

            this.poTimerEventMan = null;

        }

        // ---------------------------------------------------
        // Data
        // ---------------------------------------------------
        public SpriteBatchMan poSpriteBatchMan;
        public FontMan poFontMan;
        public InputMan poInputMan;
        public TimerEventMan poTimerEventMan;
        public ScoreMan pScoreMan;
        public bool GameStart;
        
    }
}