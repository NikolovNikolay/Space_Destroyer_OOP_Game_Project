using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDestroyerGame
{
    public class Meteor : CosmicObject
    {
        private int hitPoints;
        public Meteor(Position position, char[,] body) : base(position, body)
        {
            this.hitPoints = 0;
        }

        public int HitPoints
        {
            get { return this.hitPoints; }
        }

        public override void Collide(GameObject obj)
        {
            this.hitPoints--;
            if(this.hitPoints <= 0)
            {
                this.isDestroyed = true;
            }
        }
    }
}
