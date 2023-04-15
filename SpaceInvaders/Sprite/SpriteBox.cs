//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteBox : SpriteBase
    {
        public enum Name
        {
            Box,
            Box1,
            Box2,
            Box3,
            Box4,

            NullObject,

            Uninitialized
        }
        //------------------------------------
        // Constructors
        //------------------------------------

        public SpriteBox()
        : base()   // <--- Delegate (kick the can)
        {
            this.name = SpriteBox.Name.Uninitialized;

            Debug.Assert(SpriteBox.psTmpRect != null);
            SpriteBox.psTmpRect.Set(0, 0, 1, 1);

            // Here is the actual new
            //LTN - SpriteBox
            this.poColor = new Azul.Color(1, 1, 1);
            Debug.Assert(this.poColor != null);

            // Here is the actual new
            //LTN - SpriteBox
            this.poAzulSpriteBox = new Azul.SpriteBox(psTmpRect, this.poColor);
            Debug.Assert(this.poAzulSpriteBox != null);

            this.x = poAzulSpriteBox.x;
            this.y = poAzulSpriteBox.y;
            this.sx = poAzulSpriteBox.sx;
            this.sy = poAzulSpriteBox.sy;
            this.angle = poAzulSpriteBox.angle;
        }


        //------------------------------------
        // Methods
        //------------------------------------
        public override void Update()
        {
            this.poAzulSpriteBox.x = this.x;
            this.poAzulSpriteBox.y = this.y;
            this.poAzulSpriteBox.sx = this.sx;
            this.poAzulSpriteBox.sy = this.sy;
            this.poAzulSpriteBox.angle = this.angle;

            this.poAzulSpriteBox.Update();
        }
        public override void Render()
        {
            this.poAzulSpriteBox.Render();
        }

        public void Set(System.Enum name, float x, float y, float width, float height, Azul.Color pLineColor)
        {
            Debug.Assert(this.poAzulSpriteBox != null);
            Debug.Assert(this.poColor != null);

            Debug.Assert(psTmpRect != null);
            SpriteBox.psTmpRect.Set(x, y, width, height);

            this.name = (SpriteBox.Name)name;

            if (pLineColor == null)
            {
                this.poColor.Set(1, 1, 1);
            }
            else
            {
                this.poColor.Set(pLineColor);
            }

            this.poAzulSpriteBox.Swap(psTmpRect, this.poColor);
       
            this.x = poAzulSpriteBox.x;
            this.y = poAzulSpriteBox.y;
            this.sx = poAzulSpriteBox.sx;
            this.sy = poAzulSpriteBox.sy;
            this.angle = poAzulSpriteBox.angle;

            this.Update();
        }
        public void Set(SpriteBox.Name name, float x, float y, float width, float height)
        {
            Debug.Assert(this.poAzulSpriteBox != null);
            Debug.Assert(this.poColor != null);

            Debug.Assert(psTmpRect != null);
            SpriteBox.psTmpRect.Set(x, y, width, height);

            this.name = name;

            this.poAzulSpriteBox.Swap(psTmpRect, this.poColor);

            this.x = poAzulSpriteBox.x;
            this.y = poAzulSpriteBox.y;
            this.sx = poAzulSpriteBox.sx;
            this.sy = poAzulSpriteBox.sy;
            this.angle = poAzulSpriteBox.angle;
        }
        private void privClear()
        {
            this.name = SpriteBox.Name.Uninitialized;

            // NOTE:
            // Do not null the poAzulBoxSprite it is created once in Default then reused
            // Do not null the poLineColor it is created once in Default then reused

            this.poColor.Set(1, 1, 1);

            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;
        }
        public void SwapColor(Azul.Color _pColor)
        {
            Debug.Assert(_pColor != null);
            this.poAzulSpriteBox.SwapColor(_pColor);
        }
        public void SetColor(float red, float green, float blue, float alpha = 1.0f)
        {
            Debug.Assert(this.poColor != null);
            this.poColor.Set(red, green, blue, alpha);
            this.poAzulSpriteBox.SwapColor(this.poColor);
        }
        public void SetRect(float x, float y, float width, float height)
        {
            this.Set((SpriteBox.Name)this.name, x, y, width, height);
        }
        //------------------------------------
        // Override
        //------------------------------------
        public override System.Enum GetName()
        {
            return this.name;
        }
        override public void Wash()
        {
            this.baseClear();
            this.privClear();
        }

        override public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   Name: {0} ({1})", this.name, this.GetHashCode());
            Debug.WriteLine("      Color(r,b,g): {0},{1},{2} ({3})", this.poColor.red, this.poColor.green, this.poColor.blue, this.poColor.GetHashCode());
            Debug.WriteLine("        AzulSprite: ({0})", this.poAzulSpriteBox.GetHashCode());
            Debug.WriteLine("             (x,y): {0},{1}", this.x, this.y);
            Debug.WriteLine("           (sx,sy): {0},{1}", this.sx, this.sy);
            Debug.WriteLine("           (angle): {0}", this.angle);

            // Let the base print its contribution
            this.baseDump();
        }

        //------------------------------------
        // Data
        //------------------------------------
        public float x;
        public float y;
        public float sx;
        public float sy;
        public float angle;

        public Name name;
        public Azul.Color poColor; 
        private Azul.SpriteBox poAzulSpriteBox;

        //------------------------------------------------------------------------
        // Static Data - prevent unecessary "new" in the above methods
        //------------------------------------------------------------------------
        //LTN - SpriteBox
        static private Azul.Rect psTmpRect =  new Azul.Rect();
        
    }
}

// --- End of File ---

