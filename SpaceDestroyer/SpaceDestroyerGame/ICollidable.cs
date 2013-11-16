using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDestroyerGame
{
    public interface ICollidable
    {
        void Collide(GameObject obj);
    }
}
