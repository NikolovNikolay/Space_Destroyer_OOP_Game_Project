using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDestroyerGame
{
    public class PlayerBullet : Bullet
    {
        public PlayerBullet(Position position)
            : base(position)
        {
            this.body = new char[,] { { '|' } };
        }

        public override void Move()
        {
            this.position.Row--;
        }
    }
}
