using Microsoft.Xna.Framework;
using sprint0Real.LinkStuff;
using static Link;

namespace sprint0Real.Interfaces
{
    public interface ILink : IGameObject
    {
        public void MoveInDirection(Direction dir);

        public Rectangle GetLocation();

        public void SetLocation(Rectangle location);

        public void ApplyMomentum();

        public void StopMomentumInDirection(Direction dir);

        public bool CanMove();

        public bool CanAttack();

        public void SetCanMove(bool move);

        public Direction GetFacing();

        public void SetFacing(Direction facing);

        public void SetCanAttack(bool canAttack);
        public void DrawWeaponSprite();

        public void DrawFireball();
        public void DrawItemSprite();
        public Color GetLinkColor();

        public bool IsDamaged();

        public bool IsPhaseActive();

        public void SetIsDamaged(bool toDamage);

        public void SetLinkColor(Color color);

        public Inventory GetInventory();

        public int GetCurrentHealth();
        public void OffsetCurrentHealth(int amount);

        public int GetMaxHealth();

        public void SetMaxHealth(int amount);

        public void SwitchPhaseActive();
        public void RestoreAllHealth();
    }
}
