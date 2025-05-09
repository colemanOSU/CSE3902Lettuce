﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using sprint0Real.Collisions;

namespace sprint0Real.Interfaces
{
    public interface IBlock : IGameObject, ITouchesLink
    {
        void Move(Vector2 direction);
        Vector2 Position { get; set; }
    }
}
