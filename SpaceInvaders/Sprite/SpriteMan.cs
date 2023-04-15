//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteMan : ManBase
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public SpriteMan(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            SpriteMan.poSpriteCompare = new Sprite();
            Debug.Assert(SpriteMan.poSpriteCompare != null);
        }

        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum >= 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(psInstance == null);

            // Do the initialization
            if (psInstance == null)
            {
                psInstance = new SpriteMan(reserveNum, reserveGrow);
            }
        }
        public static void Destroy(bool bPrintEnable = false)
        {
            SpriteMan pMan = SpriteMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton

            if (bPrintEnable)
            {
                SpriteMan.DumpStats();
            }
        }

        public static void DumpStats()
        {
            Debug.WriteLine("\n   ------ Sprite Man: ------");

            SpriteMan pMan = SpriteMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDumpStats();

            Debug.WriteLine("   ------------\n");
        }

        //----------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------

        public static Sprite Add(Sprite.Name name, Image.Name pImage, float x, float y, float w, float h)
        {
            

            Sprite pSprite = (Sprite)SpriteMan.privGetInstance().baseAdd();
            Debug.Assert(pSprite != null);

            // Initialize the data
            pSprite.Set(name, pImage, x, y, w, h);
            return pSprite;
        }

        public static Sprite Find(Sprite.Name name)
        {
            // Compare functions only compares two Sprites

            // So:  Use the Compare Sprite - as a reference
            //      use in the Compare() function
            SpriteMan.poSpriteCompare.name = name;

            Sprite pData = (Sprite)SpriteMan.privGetInstance().baseFind(SpriteMan.poSpriteCompare);
            return pData;
        }
        public void Remove(Sprite pSprite)
        {
            Debug.Assert(pSprite != null);
            this.baseRemove(pSprite);
        }
        public void Dump()
        {
            this.baseDump();
        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        override protected NodeBase derivedCreateNode()
        {
            NodeBase pNodeBase = new Sprite();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }
        
        //------------------------------------
        // Private methods
        //------------------------------------
        private static SpriteMan privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(psInstance != null);

            return psInstance;
        }

        //----------------------------------------------------------------------
        // Data: unique data for this manager 
        //----------------------------------------------------------------------
        private static Sprite poSpriteCompare;
        private static SpriteMan psInstance = null;
    }
}

// --- End of File ---
