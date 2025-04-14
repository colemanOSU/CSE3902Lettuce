using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.Collisions;
using sprint0Real.Interfaces;

namespace sprint0Real.Commands.CollisionCommands
{
    public class EnemyBlockCommand : ICollisionCommand
    {
        private void Adjust(IEnemy Enemy, IBlock Block, CollisionDirections direction)
        {

            Rectangle rectA = Enemy.Rect;
            Rectangle rectB = Block.Rect;

            //calculate overlap
            int overlapBottom = rectB.Bottom - rectA.Top;
            int overlapTop = rectA.Bottom - rectB.Top;
            int overlapRight = rectB.Right - rectA.Left;
            int overlapLeft = rectA.Right - rectB.Left;

            switch (direction)
            {
                case CollisionDirections.Left:
                    Enemy.location = new Vector2(Enemy.location.X - overlapLeft, Enemy.location.Y);
                    break;
                case CollisionDirections.Right:
                    Enemy.location = new Vector2(Enemy.location.X + overlapRight, Enemy.location.Y);
                    break;
                case CollisionDirections.Up:
                    Enemy.location = new Vector2(Enemy.location.X, Enemy.location.Y - overlapTop);
                    break;
                case CollisionDirections.Down:
                    Enemy.location = new Vector2(Enemy.location.X, Enemy.location.Y + overlapBottom);
                    break;
            }

        }
        public void Execute(IObject objA, IObject objB, CollisionDirections direction)
        {

            ((IEnemy)objA).ChangeDirection();
            Adjust((IEnemy)objA, (IBlock)objB, direction);
        }
    }
}
