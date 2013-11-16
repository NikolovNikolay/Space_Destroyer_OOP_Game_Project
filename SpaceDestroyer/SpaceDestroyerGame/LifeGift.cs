using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDestroyerGame
{
    public class LifeGift: Gift
    {
        public LifeGift(Position position)
            : base(position, new char[,] { { '\u2665' } })
        {
            //this.body = new char[,] {{'\u2665'}};
        }

        public override void Move()
        {
            this.position.Row++;
        }

        public override void Collide(GameObject obj)
        {
            this.isDestroyed = true;
        }
    }
}
