using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDestroyerGame
{

    public abstract class EnemySpaceCraft : SpaceCraft
    {
        public EnemySpaceCraft(Position position)
            : base(position, new char[,] { {' '} })
           
        {
          
        }
    }
}
