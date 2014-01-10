namespace SpaceDestroyerGame.Misc
{
    using SpaceDestroyerGame.GameObjects;
    using SpaceDestroyerGame.GameObjects.CosmicObjects;
    using SpaceDestroyerGame.Interfaces;
    using SpaceDestroyerGame.Ships;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

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
        long[] score;

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
            this.score = new long[4];
        }

        public virtual void AddObject(GameObject obj)
        {
            if (obj is EnemySpaceCraftProtoOne || obj is Asteroid || obj is Meteor || obj is Gift)
            {
                this.movingObjects.Add(obj as MovingObject);
            }
            else if (obj is Bullet)
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
            bool dead = false;
            BorderDraw();

            {
                new Thread(() =>
                {
                    while (true)
                    {
                        accidentalDropCounter++;
                        if (!dead)
                        {
                            this.score[0]++;
                        }

                        this.userInterface.ProcessInput();
                        Thread.Sleep(this.sleep);
                        Random rand = new Random();

                        if (accidentalDropCounter % 4 == 0 && this.protoOneEnemies.Count < 10)
                        {
                            this.AddObject(new EnemySpaceCraftProtoOne(new Position(0, rand.Next(1, Console.BufferWidth - 1))));
                        }

                        if (accidentalDropCounter % 2 == 0)
                        {
                            this.AddObject(new Star(new Position(0, rand.Next(1, Console.BufferWidth + 1)), new char[,] { { '.' } }));
                        }

                        if (accidentalDropCounter % 21 == 0)
                        {
                            this.AddObject(new AsteroidLeftAttack(new Position(rand.Next(1, (Console.BufferWidth / 3) + 1), -3)));
                        }

                        if (accidentalDropCounter % 23 == 0)
                        {
                            this.AddObject(new AsteroidRightAttack(new Position(rand.Next(0, (Console.BufferHeight / 3) + 1), Console.BufferWidth + 3)));
                        }

                        if (accidentalDropCounter % 50 == 0)
                        {
                            this.AddObject(new MeteorRightAttack(new Position(rand.Next(0, (Console.BufferHeight / 3) + 1), Console.BufferWidth + 3)));
                        }

                        if (accidentalDropCounter % 60 == 0)
                        {
                            this.AddObject(new MeteorLeftAttack(new Position(rand.Next(0, (Console.BufferWidth / 3) + 1), -3)));
                        }

                        if (accidentalDropCounter % 16 == 0)
                        {
                            this.AddObject(new LifeGift(new Position(0, rand.Next(1, Console.BufferWidth - 1))));
                        }

                        for (int i = 0; i < this.allObjects.Count; i++)
                        {
                            this.renderer.EnqueObject(allObjects[i]);
                        }

                        for (int i = 0; i < this.bullets.Count; i++)
                        {
                            if (this.bullets[i].GetPosition.Row == 0)
                            {
                                this.bullets[i].Move();
                                this.bullets[i].IsDestroyed = true;
                                this.bullets.RemoveAt(i);
                            }
                        }

                        for (int i = 0; i < this.allObjects.Count; i++)
                        {
                            this.allObjects[i].Move();

                            this.score = CollisionHandler.CollisionCheck(this.movingObjects, this.bullets, this.cruiser, this.score);

                            this.allObjects.RemoveAll(x => x.IsDestroyed == true);
                            this.movingObjects.RemoveAll(x => x.IsDestroyed == true);
                            this.bullets.RemoveAll(x => x.IsDestroyed == true);
                            this.protoOneEnemies.RemoveAll(x => x.IsDestroyed = true);

                            if (this.cruiser.HitPoints <= 0)
                            {
                                dead = true;
                                GameOver.PrintGameOver();
                            }
                        }

                        this.renderer.Render();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(0, Console.BufferHeight - 8);
                        Console.Write(new string(' ', Console.BufferWidth));
                        Lives();
                        ScoreDataPrinter();
                        this.renderer.ClearObjectMatrix();
                    }
                }).Start();
            }
        }

        private static void BorderDraw()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(0, Console.BufferHeight - 10);
            Console.Write(new string('=', Console.BufferWidth));
        }

        private void ScoreDataPrinter()
        {
            Console.SetCursorPosition(15, Console.BufferHeight - 8);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("SCORE: {0}", this.score[0]);
            Console.SetCursorPosition(35, Console.BufferHeight - 8);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("ENEMIES: {0}", this.score[1]);
            Console.SetCursorPosition(49, Console.BufferHeight - 8);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("ASTEROIDS: {0}", this.score[2]);
            Console.SetCursorPosition(65, Console.BufferHeight - 8);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("METEORS: {0}", this.score[3]);
            Console.ResetColor();
        }

        private void Lives()
        {
            Console.SetCursorPosition(5, Console.BufferHeight - 8);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("HITS {0}", new string('\u2665', this.cruiser.HitPoints));
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