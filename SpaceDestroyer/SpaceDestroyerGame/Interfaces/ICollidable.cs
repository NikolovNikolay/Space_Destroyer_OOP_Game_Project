namespace SpaceDestroyerGame.Interfaces
{
    using SpaceDestroyerGame.GameObjects;
    using System;
    using System.Linq;

    public interface ICollidable
    {
        void Collide(GameObject obj);
    }
}
