namespace SpaceDestroyerGame.Interfaces
{
    using SpaceDestroyerGame.GameObjects;
    using System;
    using System.Linq;

    public interface IRenderer
    {
        void EnqueObject(GameObject obj);

        void Render();

        void ClearObjectMatrix();
    }
}
