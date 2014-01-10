namespace SpaceDestroyerGame.Interfaces
{
    using System;
    using System.Linq;

    public interface IUserInterface
    {
        event EventHandler OnLeftPressed;

        event EventHandler OnRightPressed;

        event EventHandler OnUpPressed;

        event EventHandler OnDownPressed;

        event EventHandler OnActionPressed;

        void ProcessInput();
    }
}
