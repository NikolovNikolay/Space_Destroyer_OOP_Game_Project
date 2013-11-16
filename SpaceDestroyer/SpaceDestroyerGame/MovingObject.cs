using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDestroyerGame
{
    public class MovingObject : GameObject
    {
        public MovingObject(Position position, char[,] body) : base(position,body)
        {
        }

        public override void Move()
        {
        }
    }
}
