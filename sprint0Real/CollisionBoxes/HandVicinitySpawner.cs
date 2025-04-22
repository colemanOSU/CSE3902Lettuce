using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.EnemyStuff.HandStuff;
using sprint0Real.Interfaces;
using sprint0Real.Levels;

namespace sprint0Real.CollisionBoxes
{
    public class HandVicinitySpawner : ICollisionBoxes, IUpdates
    {
        public Rectangle Rect { get; }
        private bool Top;
        private Random random = new Random();

        private bool spawnFlag = false;
        private float spawnTimer = 0f;
        private float spawnDelay = 0.5f;

        public HandVicinitySpawner(Rectangle destinationRectangle)
        {
            Rect = destinationRectangle;
            if (Rect.Top < Game1.SCREENHEIGHT / 2)
            {
                Top = true;
            }
        }
        private void SpawnHand()
        {
            spawnDelay = (float)random.NextDouble() * 2 + 2;
            float spawnLocation = (float)random.NextDouble() * Rect.Width + Rect.Left;
            if (Top)
            {
                CurrentMap.Instance.Stage(new Hand(new Vector2(spawnLocation, 138)));
            }
            else
            {
                CurrentMap.Instance.Stage(new Hand(new Vector2(spawnLocation, Game1.SCREENHEIGHT)));
            }
        }

        public void SpawnCheck()
        {
            if (spawnTimer >= spawnDelay)
            {
                spawnTimer = 0f;
                SpawnHand();
            }
        }

        public void AdvanceTimer()
        {
            spawnFlag = true;
        }

        public void Update(GameTime time)
        {
            if (spawnFlag)
            {
                spawnTimer += (float)time.ElapsedGameTime.TotalSeconds;
            }
            SpawnCheck();
            spawnFlag = false;
        }
    }
}
