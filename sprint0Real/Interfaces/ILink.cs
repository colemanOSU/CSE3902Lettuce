using Microsoft.Xna.Framework;
using static Link;

namespace sprint0Real.Interfaces
{
    public interface ILink
    {
        Rectangle Rect { get; }
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
        public void SetItem(int num,Game1 game);
        public void DrawWeaponSprite();
        public void NextItem();
        public void LastItem();

        public Color GetLinkColor();

        public void DamageLink();

        public bool IsDamaged();

        public void SetIsDamaged(bool toDamage);

        public void SetLinkColor(Color color);
    }
}
