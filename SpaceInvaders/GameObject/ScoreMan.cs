//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ScoreMan
    {
        private ScoreMan()
        {
            score1 = 0;
            score2 = 0;
            highScore = 0;
            highScoreString = "0 0 0 0";
            stringReset = "0 0 0 0";
            pActiveInstance = null;
        }
        public static ScoreMan Create()
        {
            ScoreMan pMan = ScoreMan.privInstance();
            // initialize the singleton here
            //Debug.Assert(pMan.pActiveInstance == null);

            // Do the initialization
          //  if (pMan.pActiveInstance == null)
            {
                pMan.pActiveInstance = new ScoreMan();
            }

            return pMan.pActiveInstance;
        }
        public static void SetActive(ScoreMan pScoreMan)
        {
            ScoreMan pMan = ScoreMan.privInstance();
            
            Debug.Assert(pScoreMan != null);
            pMan.pActiveInstance = pScoreMan;
        }
        private static ScoreMan privInstance()
        {
            if(instance == null)
            {
                instance = new ScoreMan();
            }
            return instance;
        }
        
        public static void AddDisplay()
        {
            // Store the states
            Font pFont = FontMan.Add(Font.Name.Score1, SpriteBatch.Name.Texts, "S C O R E  < 1 >", Glyph.Name.SpaceInvaders, 26, 740);
            pFont.SetColor(0.0f, 1.0f, 1.0f);
            pFont.SetScale(3.0f);

            pFont = FontMan.Add(Font.Name.HighScore, SpriteBatch.Name.Texts, "H I G H  S C O R E", Glyph.Name.SpaceInvaders, 265, 740);
            pFont.SetColor(0.62f, 0.12f, 0.94f);
            pFont.SetScale(3.0f);

            pFont = FontMan.Add(Font.Name.Score2, SpriteBatch.Name.Texts, "S C O R E  < 2 >", Glyph.Name.SpaceInvaders, 503, 740);
            pFont.SetColor(0.90f, 0.90f, 0.0f);
            pFont.SetScale(3.0f);

            ScoreMan pMan = ScoreMan.privInstance();

            pMan.pActiveInstance.pScore1 = FontMan.Add(Font.Name.Score1Value, SpriteBatch.Name.Texts, pMan.stringReset, Glyph.Name.SpaceInvaders, 63, 700);
            pMan.pActiveInstance.pScore1.SetScale(3.0f);

            pMan.pActiveInstance.pHighScore = FontMan.Add(Font.Name.HighScoreValue, SpriteBatch.Name.Texts, pMan.highScoreString, Glyph.Name.SpaceInvaders, 302, 700);
            pMan.pActiveInstance.pHighScore.SetScale(3.0f);

            pMan.pActiveInstance.pScore2 = FontMan.Add(Font.Name.Score2Value, SpriteBatch.Name.Texts, pMan.stringReset, Glyph.Name.SpaceInvaders, 540, 700);
            pMan.pActiveInstance.pScore2.SetScale(3.0f);
        }

        public static void AlienHit(AlienBase _pAlien)
        {
             ScoreMan pMan = ScoreMan.privInstance();
            switch (_pAlien.GetType().Name)
            {
                case "Alien_Squid":
                    pMan.score1 += 30;
                    break;
                case "Alien_Crab":
                    pMan.score1 += 20;
                    break;
                case "Alien_Octopus":
                    pMan.score1 += 10;
                    break;
                case "UFO":
                    pMan.score1 += 100;
                    break;
            }
            int numDigits = count_digit(pMan.score1);
            string scoreString = "";
            for(int i = 0; i < (4-numDigits); i++)
            {
                scoreString += "0 ";
            }

            int num = pMan.score1;
            string a = "";
            string b = "";
            while (num > 0)
            {
                a = "";
                a += (num % 10);
                b = a + " " + b;
                num = num / 10;
            }

            scoreString += b;

            pMan.pActiveInstance.pScore1.UpdateMessage(scoreString);

            if(pMan.score1 > pMan.highScore)
            {
                pMan.highScore = pMan.score1;
                pMan.highScoreString = scoreString;
               // pMan.pHighScore.UpdateMessage(scoreString);
            }

        }

        public static int count_digit(int number)
        {
            int count = 0;
            while (number != 0)
            {
                number = number / 10;
                count++;
            }
            return count;
        }

        public static void updateDisplay()
        {
            ScoreMan pMan = ScoreMan.privInstance();
            pMan.score1 = 0;
            pMan.pActiveInstance.pScore1.UpdateMessage(pMan.stringReset);
            pMan.pActiveInstance.pScore2.UpdateMessage(pMan.stringReset);
            pMan.pActiveInstance.pHighScore.UpdateMessage(pMan.highScoreString);
        }

        // Data: ----------------------------------------------
        private static ScoreMan instance = null;
        private ScoreMan pActiveInstance = null;

        private Font pScore1;
        private Font pScore2;
        private Font pHighScore;
        private int score1;
        private int score2;
        private int highScore;
        String  highScoreString;
        String  stringReset;


    }
}

// --- End of File ---
