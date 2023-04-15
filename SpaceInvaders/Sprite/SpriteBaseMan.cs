/*//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteBaseMan : ManBase
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public SpriteBaseMan(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMan(), new DLinkMan(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            // initialize derived data here
            SpriteBaseMan.poSpriteCompare = new SpriteBase();
            Debug.Assert(SpriteBaseMan.poSpriteCompare != null);
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
                psInstance = new SpriteBaseMan(reserveNum, reserveGrow);
            }
        }
        public static void Destroy(bool bPrintEnable = false)
        {
            SpriteBaseMan pMan = SpriteBaseMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton

            if (bPrintEnable)
            {
                SpriteBaseMan.DumpStats();
            }
        }

        public static void DumpStats()
        {
            Debug.WriteLine("\n   ------ SpriteBase Man: ------");

            SpriteBaseMan pMan = SpriteBaseMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDumpStats();

            Debug.WriteLine("   ------------\n");
        }

        //----------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------

        public static SpriteBase Add(System.Enum name, Image.Name pImage, float x, float y, float w, float h)
        {
            

            SpriteBase pSprite = (SpriteBase)SpriteBaseMan.privGetInstance().baseAdd();
            Debug.Assert(pSprite != null);

            // Initialize the data
            pSprite.Set(name, pImage, x, y, w, h);
            return pSprite;
        }

        public static SpriteBase Add(System.Enum name, float x, float y, float width, float height, Azul.Color pColor = null)
        {
            SpriteBaseMan pMan = SpriteBaseMan.privGetInstance();
            Debug.Assert(pMan != null);

            SpriteBase pNode = (SpriteBox)pMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.Set(name, x, y, width, height, pColor);

            return pNode;
        }

        public static SpriteBase Find(System.Enum name)
        {
            // Compare functions only compares two Sprites

            // So:  Use the Compare SpriteBase - as a reference
            //      use in the Compare() function
            SpriteBaseMan.poSpriteCompare.name = name;

            SpriteBase pData = (SpriteBase)SpriteBaseMan.privGetInstance().baseFind(SpriteBaseMan.poSpriteCompare);
            return pData;
        }
        public void Remove(SpriteBase pSprite)
        {
            Debug.Assert(pSprite != null);
            this.baseRemove(pSprite);
        }
        public static void Dump()
        {
            Debug.WriteLine("\n   ------ SpriteBase Man: ------");

            SpriteBaseMan pMan = SpriteBaseMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDump();
        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        override protected NodeBase derivedCreateNode()
        {
            NodeBase pNodeBase = new SpriteBase();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }
        
        //------------------------------------
        // Private methods
        //------------------------------------
        private static SpriteBaseMan privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(psInstance != null);

            return psInstance;
        }

        //----------------------------------------------------------------------
        // Data: unique data for this manager 
        //----------------------------------------------------------------------
        private static SpriteBase poSpriteCompare;
        private static SpriteBaseMan psInstance = null;
    }
}

// --- End of File ---
*/