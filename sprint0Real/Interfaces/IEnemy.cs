﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0Real.Interfaces
{
    public interface IEnemy : IDamagesLink, IGameObject
    {
        void TakeDamage(int damage);
        void ChangeDirection();
        Vector2 location { get; set; }
        void Stun(TimeSpan duration);
        bool IsStunned { get; }
    }
}
