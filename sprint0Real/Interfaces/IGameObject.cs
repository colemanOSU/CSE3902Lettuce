﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0Real.Interfaces
{
    public interface IGameObject : IObject, IDrawn, IUpdates
    {
        // Just an interface that combines Rect, Update, and Draw to make 
        // organization easier. 
    }
}
