namespace SpaceDestroyerGame.Misc
{
    using System;
    using System.Linq;

    public abstract class GameOver
    {
       public static void PrintGameOver()
       {
           Console.SetCursorPosition((Console.BufferWidth / 2) - 10, Console.BufferHeight - 5);
           Console.ForegroundColor = ConsoleColor.Red;
           Console.WriteLine("G A M E   O V E R");
       }
    }
}
