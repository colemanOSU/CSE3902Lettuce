using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0Real.Commands;
using static Link;

namespace sprint0Real.Interfaces
{
    public interface ILink
    {
        public void MoveInDirection(Direction dir);

        public Rectangle GetLocation();

        public void SetLocation(Rectangle location);

        public bool CanMove();

        public bool CanAttack();

        public void SetCanMove(bool move);

        public Direction GetFacing();

        public void SetFacing(Direction facing);

        public void SetCanAttack(bool canAttack);
        public void Damaged();
        public void SetItem(int num);
        public void NextItem();
        public void LastItem();

    }
}
