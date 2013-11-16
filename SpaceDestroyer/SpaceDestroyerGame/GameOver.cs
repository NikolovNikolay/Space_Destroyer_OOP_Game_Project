using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDestroyerGame
{
    public abstract class GameOver
    {
       public static void PrintGameOver()
       {
           Console.SetCursorPosition(Console.BufferWidth / 2 - 10, Console.BufferHeight - 5);
           Console.ForegroundColor = ConsoleColor.Red;
           Console.WriteLine("G A M E   O V E R");
       }
    }
}
