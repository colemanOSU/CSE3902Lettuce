using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using sprint0Real.EnemyStuff.BatStuff;
using sprint0Real.EnemyStuff.DeathSprites;
using sprint0Real.EnemyStuff.DragonStuff;
using sprint0Real.EnemyStuff.HandStuff;
using sprint0Real.Interfaces;
using sprint0Real.Levels;
using sprint0Real.TreasureItemStuff;
using System;

namespace sprint0Real.EnemyStuff.SkeletonStuff
{
    public class SkeletonStateMachine : IStateMachine
    {
        private enum SkeletonStates {Left, Right, Up, Down}
        private SkeletonStates currentState = SkeletonStates.Right;
        private Skeleton mySkeleton;
        private Random random = new Random();
        private SoundEffect EnemyDie;
        private bool DieSoundPlayed = false;
        private Death death;
        public SkeletonStateMachine(Skeleton Skeleton)
        {
            mySkeleton = Skeleton;
            EnemyDie = SoundEffectFactory.Instance.getEnemyDie();
        }

        public void TakeDamage(int damage)
        {
            mySkeleton.Health -= damage;
            if (mySkeleton.Health <= 0)
            {
                if (!DieSoundPlayed)
                {
                    EnemyDie.Play();
                    DieSoundPlayed = true;
                }
                DropManager.Instance.OnDeath(mySkeleton.location);
                CurrentMap.Instance.DeStage(mySkeleton);
                death = new Death(mySkeleton.location);
                CurrentMap.Instance.Stage(death);
            }
        }

        public void ChangeDirection()
        {
            int nextDirection = random.Next(0, 4);
            switch (nextDirection)
            {
                case 0:
                    currentState = SkeletonStates.Right;
                    break;
                case 1:
                    currentState = SkeletonStates.Left;
                    break;
                case 2:
                    currentState = SkeletonStates.Up;
                    break;
                case 3:
                    currentState = SkeletonStates.Down;
                    break;
            }
        }

        public void hitWall()
        {
            switch (currentState)
            {
                case SkeletonStates.Right:
                    mySkeleton.location = new Vector2(mySkeleton.location.X - mySkeleton.speed, mySkeleton.location.Y);
                    break;
                case SkeletonStates.Left:
                    mySkeleton.location = new Vector2(mySkeleton.location.X + mySkeleton.speed, mySkeleton.location.Y);
                    break;
                case SkeletonStates.Up:
                    mySkeleton.location = new Vector2(mySkeleton.location.X, mySkeleton.location.Y - mySkeleton.speed);
                    break;
                case SkeletonStates.Down:
                    mySkeleton.location = new Vector2(mySkeleton.location.X, mySkeleton.location.Y + mySkeleton.speed);
                    break;
            }
        }
        public void Update()
        {
            switch (currentState)
            {
                case SkeletonStates.Right:
                    mySkeleton.location = new Vector2(mySkeleton.location.X - mySkeleton.speed, mySkeleton.location.Y);
                    break;
                case SkeletonStates.Left:
                    mySkeleton.location = new Vector2(mySkeleton.location.X + mySkeleton.speed, mySkeleton.location.Y);
                    break;
                case SkeletonStates.Up:
                    mySkeleton.location = new Vector2(mySkeleton.location.X, mySkeleton.location.Y - mySkeleton.speed);
                    break;
                case SkeletonStates.Down:
                    mySkeleton.location = new Vector2(mySkeleton.location.X, mySkeleton.location.Y + mySkeleton.speed);
                    break;
            }
        }
    }
}