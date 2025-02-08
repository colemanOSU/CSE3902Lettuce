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

        public Rectangle getLocation();

        public void setLocation(Rectangle location);
    }
}
