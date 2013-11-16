using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDestroyerGame
{
    public class EnemySpaceCraftProtoOne : EnemySpaceCraft
    {
        public EnemySpaceCraftProtoOne(Position position): base(position)
        {
            this.color = color;
            this.body = new char[,] { 
                { '\\',' ', '/' },
                { '_', 'V', '_' },
                { '-', '|', '-' },
                { ' ', 'V', ' ' }
            };
            this.hitPoints = 0;
        }

        public override void Move()
        {
            this.position.Row++;
            //if(this.position.Row > Console.BufferHeight)
            //{
            //    this.isDestroyed = true;
            //}
        }

        public override void Collide(GameObject obj)
        {
            this.hitPoints--;
            if (this.hitPoints <= 0)
            {
                this.isDestroyed = true;
            }
        }
    }
}
