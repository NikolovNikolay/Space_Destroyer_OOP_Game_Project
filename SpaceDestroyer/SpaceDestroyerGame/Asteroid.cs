using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDestroyerGame
{
    public class Asteroid : CosmicObject
    {
        public Asteroid(Position position, char[,] body) : base(position, body)
        {           
        }

        public override void Collide(GameObject obj)
        {
            this.isDestroyed = true;
        }
    }
}
