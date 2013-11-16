using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDestroyerGame
{
    public class Bullet : MovingObject
    {
        public Bullet(Position position) : base(position, new char[,] {{'|'}})
        {
        }
        
        public override void Move()
        {
            this.position.Row--;
        }

        public override void Collide(GameObject obj)
        {
            this.isDestroyed = true;
        }
    }
}
