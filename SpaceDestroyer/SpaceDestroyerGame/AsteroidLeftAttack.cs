using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDestroyerGame
{
    public class AsteroidLeftAttack : Asteroid
    {
        public AsteroidLeftAttack(Position position) : base(position, new char[,] {{'@'}})
        {
        }

        public override void Move()
        {
            this.position.Row++;
            this.position.Col++;
        }
    }
}
