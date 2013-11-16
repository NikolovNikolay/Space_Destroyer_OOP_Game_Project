using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDestroyerGame
{
    public class KeyboardInterface : IUserInterface
    {
        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey(true);
                
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if(keyInfo.Key.Equals(ConsoleKey.LeftArrow))
                {
                    if(this.OnLeftPressed != null)
                    {
                        this.OnLeftPressed(this, new EventArgs());
                    }
                }

                if(keyInfo.Key.Equals(ConsoleKey.RightArrow))
                {
                    if(this.OnRightPressed != null)
                    {
                        this.OnRightPressed(this, new EventArgs());
                    }
                }

                if(keyInfo.Key.Equals(ConsoleKey.UpArrow))
                {
                    if(this.OnUpPressed != null)
                    {
                        this.OnUpPressed( this, new EventArgs());
                    }
                }

                if(keyInfo.Key.Equals(ConsoleKey.DownArrow))
                {
                    if(this.OnDownPressed != null)
                    {
                        this.OnDownPressed(this, new EventArgs());
                    }
                }

                if(keyInfo.Key.Equals(ConsoleKey.Spacebar))
                {
                    if(this.OnActionPressed != null)
                    {
                        this.OnActionPressed(this, new EventArgs());
                    }
                }
            }
        }

        public event EventHandler OnLeftPressed;

        public event EventHandler OnRightPressed;

        public event EventHandler OnUpPressed;

        public event EventHandler OnDownPressed;

        public event EventHandler OnActionPressed;


        
    }
}
