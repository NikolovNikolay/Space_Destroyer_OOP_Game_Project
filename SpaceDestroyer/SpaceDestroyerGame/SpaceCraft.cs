using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDestroyerGame
{
    public abstract class SpaceCraft : MovingObject
    {
        public int hitPoints { get; set; }
        public SpaceCraft(Position position, char[,] body): base(position,body)
        {
        }       
                
        public override void Move()
        {
        }
    }
}
