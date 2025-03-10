using sprint0Real.Collisions;

namespace sprint0Real.Interfaces
{
    public interface ICollisionCommand2
    {
        void Execute(IObject objA, IObject objB, CollisionDirections direction);
    }
}
