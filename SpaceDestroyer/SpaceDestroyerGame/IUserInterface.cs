using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDestroyerGame
{
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
