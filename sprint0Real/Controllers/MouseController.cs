using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using sprint0Real.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0Real.Controllers
{
    class MouseController : IController
    {

        MouseState mouse = Mouse.GetState();

        //This is literally all we have from Sprint 0 that is usable
        //Have fun :)
        void IController.Update(GameTime gameTime)
        {
            
        }
    }
}
