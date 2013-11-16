using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceDestroyerGame
{
    public class Engine
    {
        IRenderer renderer;
        IUserInterface userInterface;
        List<GameObject> allObjects;
        List<MovingObject> movingObjects;
        List<EnemySpaceCraft> protoOneEnemies;
        List<Bullet> bullets;
        PlayerSpaceCraft cruiser;
        int sleep;
        private int accidentalDropCounter;
        long score;

        public Engine(IRenderer renderer, IUserInterface userInterface, int speed)
        {
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.sleep = speed;
            this.allObjects = new List<GameObject>();
            this.movingObjects = new List<MovingObject>();
            this.protoOneEnemies = new List<EnemySpaceCraft>();
            this.bullets = new List<Bullet>();
            this.accidentalDropCounter = 0;
            this.score = 0;
        }


        public virtual void AddObject(GameObject obj)
        {
           if(obj is EnemySpaceCraftProtoOne || obj is Asteroid || obj is Meteor)
           {
               this.movingObjects.Add(obj as MovingObject);
           }
           else if(obj is Bullet)
           {
               this.bullets.Add(obj as Bullet);
           }
           
           this.allObjects.Add(obj);
        }

        public void AddCruiser(GameObject obj)
        {
            this.cruiser = obj as PlayerSpaceCraft;
            this.allObjects.Add(obj);
        }

        public void Run()
        {
            bool endLoop = false;
            BorderDraw();
            while (true)
            {                
                accidentalDropCounter++;
                this.userInterface.ProcessInput();
                Thread.Sleep(this.sleep);
                Random rand = new Random();

                if(accidentalDropCounter % 10 == 0 && this.protoOneEnemies.Count < 10)
                {
                    this.AddObject(new EnemySpaceCraftProtoOne(new Position(0, rand.Next(1, Console.BufferWidth-1))));
                }

                 if (accidentalDropCounter % 2 == 0)
                {
                    this.AddObject(new Star(new Position(0, rand.Next(1, Console.BufferWidth + 1)), new char[,] { { '.' } }));
                }

                if(accidentalDropCounter % 24 == 0)
                {
                    this.AddObject(new AsteroidLeftAttack(new Position(rand.Next(1, Console.BufferWidth + 1),(Console.BufferHeight - Console.BufferHeight))));
                }

                if (accidentalDropCounter % 29 == 0)
                {
                    this.AddObject(new AsteroidRightAttack(new Position(rand.Next(0, Console.BufferHeight + 1), Console.BufferWidth+5)));
                }

                if (accidentalDropCounter % 70 == 0)
                {
                    this.AddObject(new MeteorRightAttack(new Position(rand.Next(0, Console.BufferHeight + 1), Console.BufferWidth + 5)));
                }

                if (accidentalDropCounter % 60 == 0)
                {
                    this.AddObject(new MeteorLeftAttack(new Position(rand.Next(0, Console.BufferWidth + 1), (Console.BufferHeight - Console.BufferHeight))));
                }

                for (int i = 0; i < this.allObjects.Count; i++)
                {
                    this.renderer.EnqueObject(allObjects[i]);
                }

                for (int i = 0; i < this.bullets.Count; i++)
                {
                    if(this.bullets[i].GetPosition.Row == 0)
                    {
                        this.bullets[i].Move();
                        this.bullets[i].isDestroyed = true;
                        this.bullets.RemoveAt(i);
                    }
                }

                for (int i = 0; i < this.allObjects.Count; i++)
                {
                    this.allObjects[i].Move();
                    
                    this.score = CollisionHandler.CollisionCheck(this.movingObjects, this.bullets, this.cruiser, this.score);
                    
                    this.allObjects.RemoveAll(x => x.isDestroyed == true);
                    this.movingObjects.RemoveAll(x => x.isDestroyed == true);
                    this.bullets.RemoveAll(x => x.isDestroyed == true);
                    this.protoOneEnemies.RemoveAll(x => x.isDestroyed = true);

                    if(this.cruiser.hitPoints <= 0)
                    {
                        GameOver.PrintGameOver();                        
                    }
                }
               
               
                this.renderer.Render();
                Console.ForegroundColor = ConsoleColor.White;
                Lives();
                ScorePrinter();
                this.renderer.ClearObjectMatrix();                
            }
        }

        private void ScorePrinter()
        {
            Console.SetCursorPosition(28, Console.BufferHeight - 8);
            Console.Write(new string(' ', 20));
            Console.SetCursorPosition(28, Console.BufferHeight - 8);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("SCORE: {0}", this.score);
            Console.ResetColor();
        }

        private static void BorderDraw()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(0, Console.BufferHeight - 10);
            Console.Write(new string('=', Console.BufferWidth));
        }

        private void Lives()
        {
            Console.SetCursorPosition(5, Console.BufferHeight - 8);
            Console.Write( new string(' ', 19));
            Console.SetCursorPosition(5, Console.BufferHeight - 8);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("HITS TO DEATH: {0}", new string('\u2665', this.cruiser.hitPoints));
            Console.ResetColor();
        }

        public virtual void MoveCruiserRight()
        {
            this.cruiser.MoveRight();
        }

        public virtual void MoveCruiserLeft()
        {
            this.cruiser.MoveLeft();
        }

        public virtual void MoveCruiserUp()
        {
            this.cruiser.MoveUp();
        }

        public virtual void MoveCruiserDown()
        {
            this.cruiser.MoveDown();
        }

        public virtual void CruiserShoot()
        {
            this.AddObject(this.cruiser.Shoot());
        }
    }
}