using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDestroyerGame
{
    class Star : CosmicObject
    {
        public Star(Position position, char[,] body) : base(position,body)
        {
        }

        public override void Move()
        {
            this.position.Row++;
        }

    }
}
