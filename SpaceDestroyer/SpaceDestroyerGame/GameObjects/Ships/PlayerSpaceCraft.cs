namespace SpaceDestroyerGame.Ships
{
    using SpaceDestroyerGame.Misc;
    using SpaceDestroyerGame.GameObjects;
    using System;
    using System.Linq;

    public class PlayerSpaceCraft : SpaceCraft
    {
        public PlayerSpaceCraft(Position position)
            : base(position, new char[,]
             {
             {' ',' ','/','|','\\',' ',' '},
             {'/','_',']','|','[','_','\\'},
             {' ','_','I','|','I','_',' '},
             {' ','/','^','^','^','\\',' '}
             })
        {
            this.HitPoints = 4;
        }

        public void MoveUp()
        {
            if (this.position.Row > Console.BufferHeight - (Console.BufferHeight - 3))
            {
                this.position.Row--;
            }
        }

        public void MoveDown()
        {
            if (this.position.Row < Console.BufferHeight - 14)
            {
                this.position.Row++;
            }
        }

        public void MoveLeft()
        {
            if (this.position.Col > 1)
            {
                this.position.Col--;
            }
        }

        public void MoveRight()
        {
            if (this.position.Col < Console.BufferWidth - 8)
            {
                this.position.Col++;
            }
        }

        public Bullet Shoot()
        {
            Position bulletPos = this.GetPosition;
            bulletPos.Row--;
            bulletPos.Col += 3;
            return new PlayerBullet(bulletPos);
        }

        public override void Collide(GameObject obj)
        {
            if (obj is LifeGift)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (this.HitPoints < 4)
                {
                    this.HitPoints++;
                }
            }
            else
            {
                this.HitPoints--;
                Console.ForegroundColor = ConsoleColor.Red;
                if (this.HitPoints <= 0)
                {
                    this.IsDestroyed = true;
                    this.position = new Position(0, 0);
                }
            }
        }

        public override void Move()
        {
        }
    }
}
