using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDestroyerGame
{
    public abstract class Gift : MovingObject
    {
        public Gift(Position position, char[,] body) : base(position, body)
        {
           
        }

        
    }
}
