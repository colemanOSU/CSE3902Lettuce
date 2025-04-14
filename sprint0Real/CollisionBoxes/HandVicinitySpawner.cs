using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using sprint0Real.Interfaces;

namespace sprint0Real.CollisionBoxes
{
    public class HandVicinitySpawner : ICollisionBoxes
    {
        public Rectangle Rect { get; }
        private int quadrant;

        public HandVicinitySpawner(Rectangle destinationRectangle)
        {
            Rect = destinationRectangle;
        }
        private void SpawnHand()
        {
            // Add a method that, depending on the quadrant, spawns hands from the wall
        }

        public void StartSpawning()
        {
            // Add a timer that occassionally spawns hands
        }
    }
}
