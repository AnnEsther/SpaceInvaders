//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class InputMan
    {
        public InputMan()
        {
            this.poSubjectArrowLeft = new InputSubject();
            this.poSubjectArrowRight = new InputSubject();
            this.poSubjectSpace = new InputSubject();
            this.poSubjectS = new InputSubject();

            this.privSpaceKeyPrev = false;
            this.privsKeyPrev = false;
        }
        public static void Create()
        {
            
            if (pInstance == null)
            {
                pInstance = new InputMan();
            }
            Debug.Assert(pInstance != null);

            //return pInstance;
        }
        public static void Destroy(bool bPrintEnable = false)
        {
            InputMan pMan = InputMan.pActiveMan;
            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton
            if (bPrintEnable)
            {
                SpriteBatchMan.DumpStats();
            }
        }
        public static void SetActive(InputMan pMan)
        {
            Debug.Assert(pMan != null);
            InputMan.pActiveMan = pMan;
        }
        public static InputSubject GetArrowRightSubject()
        {
            InputMan pMan = InputMan.pActiveMan;
            return pMan.poSubjectArrowRight;
        }

        public static InputSubject GetArrowLeftSubject()
        {
            InputMan pMan = InputMan.pActiveMan;
            return pMan.poSubjectArrowLeft;
        }

        public static InputSubject GetSpaceSubject()
        {
            InputMan pMan = InputMan.pActiveMan;
            return pMan.poSubjectSpace;
        }

        public static InputSubject GetKeyS_Subject()
        {
            InputMan pMan = InputMan.pActiveMan;
            return pMan.poSubjectS;
        }

        public static void Update()
        {
            InputMan pMan = InputMan.pActiveMan;

            // SpaceKey: (with key history) -----------------------------------------------------------
            bool spaceKeyCurr = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE);

            if (spaceKeyCurr == true && pMan.privSpaceKeyPrev == false)
            {
                pMan.poSubjectSpace.Notify();
            }

            // LeftKey: (no history) -----------------------------------------------------------
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_LEFT) == true)
            {
                pMan.poSubjectArrowLeft.Notify();
            }

            // RightKey: (no history) -----------------------------------------------------------
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_RIGHT) == true)
            {
                pMan.poSubjectArrowRight.Notify();
            }
            // S Key: (with key history) -----------------------------------------------------------
            bool sKeyCurr = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_S);
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_S) == true && pMan.privsKeyPrev == false)
            {
                pMan.poSubjectS.Notify();
            }
            pMan.privSpaceKeyPrev = spaceKeyCurr;
            pMan.privsKeyPrev = sKeyCurr;

        }

        // Data: ----------------------------------------------
        private static InputMan pActiveMan = null;
        private static InputMan pInstance = null;
        private bool privSpaceKeyPrev;
        private bool privsKeyPrev;

        private InputSubject poSubjectArrowRight;
        private InputSubject poSubjectArrowLeft;
        private InputSubject poSubjectSpace;
        private InputSubject poSubjectS;
    }
}

// --- End of File ---
