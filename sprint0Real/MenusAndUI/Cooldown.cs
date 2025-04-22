using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;
using sprint0Real.Items.ItemSprites;
using sprint0Real;
using System.Collections.Generic;
using System;

internal class Cooldown : ICooldown
{
    private Texture2D _texture;
    private Game1 myGame;

    private List<Rectangle> animationFrames;
    private int currentFrame = 0;
    private double animationTimer = 0;
    private double frameTime = 0.1; // Time per frame in seconds

    private Rectangle destinationRectangle;
    private Vector2 _position;
    private bool animationDone = false;

    public Cooldown(Texture2D texture, Game1 game)
    {
        _texture = texture;
        myGame = game;

        GenerateFrames();
        destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, 24, 24); // Adjust scale if needed
    }

    private void GenerateFrames()
    {
        animationFrames = new List<Rectangle>();

        int frameWidth = 16;
        int frameHeight = 16;

        // This example assumes 6 columns and 6 rows based on the image
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 6; col++)
            {
                int x = col * frameWidth;
                int y = row * frameHeight;
                animationFrames.Add(new Rectangle(x, y, frameWidth, frameHeight));
            }
        }
    }

    public Rectangle Rect => destinationRectangle;

    public void Update(GameTime gameTime, ILink Link)
    {
        if (animationDone) return;

        animationTimer += gameTime.ElapsedGameTime.TotalSeconds;
        if (animationTimer >= frameTime)
        {
            currentFrame++;
            animationTimer = 0;
            if (currentFrame >= animationFrames.Count)
            {
                animationDone = true;
                myGame.weaponItemsB = new NullSprite(_texture, myGame);
            }
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (animationDone) return;

        Rectangle source = animationFrames[Math.Min(currentFrame, animationFrames.Count - 1)];
        destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, source.Width * 3, source.Height * 3); // Scale 3x
        spriteBatch.Draw(_texture, destinationRectangle, source, Color.White);
    }
}
