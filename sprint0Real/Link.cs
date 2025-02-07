using sprint0Real;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

public class Link
{
    private LinkStateMachine stateMachine;
    private KeyboardControllerTemp keyboardControllerTemp;
    private Game1 game;
    public Link()
    {
        stateMachine = new LinkStateMachine();
    }
        public void Damaged()
    {
        stateMachine.Damaged();
    }
        public void Draw(SpriteBatch spritebatch,Texture2D texture)
    {
        stateMachine.Draw(spritebatch, texture);
    }
}
