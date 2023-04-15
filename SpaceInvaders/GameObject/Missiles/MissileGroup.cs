//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class MissileGroup : Composite
    {
        public MissileGroup()
            : base()
        {
            this.name = Name.MissileGroup;

            this.poColObj.pColSprite.SetColor(1,0,0);
        }

        ~MissileGroup()
        {

        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an MissileGroup
            if(this.GetNumChildren() != 0)
            {
                other.VisitMissileGroup(this);
            }
            else
            {
                //Debug.WriteLine("Shouldnt be here\n");
            }
            // Call the appropriate collision reaction            
        }

        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        public override void VisitBomb(Bomb b)
        {
            // no differed to subcass
            ColPair.Collide(b, (GameObject)IteratorForwardComposite.GetChild(this));
        }

        // Data: ---------------


    }
}

// --- End of File ---

