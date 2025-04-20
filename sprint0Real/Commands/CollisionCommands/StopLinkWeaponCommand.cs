using sprint0Real.Collisions;
using sprint0Real.Interfaces;
using sprint0Real;

public class StopLinkWeaponCommand : ICollisionCommand
{
    private Game1 game;

    public StopLinkWeaponCommand(Game1 game)
    {
        this.game = game;
    }

    public void Execute(IObject objA, IObject objB, CollisionDirections direction)
    {
        if (objA is ILinkSprite sword)
        {
            sword.Disable(); 
        }
        game.Link.SetCanAttack(true);
        game.Link.SetCanMove(true);
    }
}

