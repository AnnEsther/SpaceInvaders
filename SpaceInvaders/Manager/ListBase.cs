//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class ListBase
    {
        abstract public void AddToFront(NodeBase pNode, float priority = 0.0f);
        abstract public void Remove(NodeBase pNode);
        abstract public NodeBase RemoveFromFront();
        abstract public Iterator GetIterator();
    }
}

// --- End of File ---
