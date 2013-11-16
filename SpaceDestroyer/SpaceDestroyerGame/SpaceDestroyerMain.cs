using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDestroyerGame
{
    class SpaceDestroyerMain
    {
        static void Main(string[] args)
        {           
            Console.BufferWidth = Console.WindowWidth = 80;
            Console.BufferHeight = Console.WindowHeight = 50;

            IUserInterface keyboard = new KeyboardInterface();
            IRenderer renderer = new Renderer(Console.BufferHeight-10, Console.BufferWidth-1);

            Engine engine = new Engine(renderer, keyboard, 100);

            SpaceCraft craft = new PlayerSpaceCraft(new Position(Console.BufferHeight - 14, Console.BufferWidth / 2));            
            engine.AddCruiser(craft);

            HandlePlayerControls(keyboard, engine);

            engine.Run();
        }

        private static void HandlePlayerControls(IUserInterface keyboard, Engine engine)
        {
            keyboard.OnUpPressed += (sender, eventInfo) =>
            {
                engine.MoveCruiserUp();
            };

            keyboard.OnDownPressed += (sender, eventInfo) =>
            {
                engine.MoveCruiserDown();
            };

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                engine.MoveCruiserLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                engine.MoveCruiserRight();
            };

            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                engine.CruiserShoot();
            };
        }
    }
}
