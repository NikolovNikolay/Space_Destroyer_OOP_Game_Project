namespace SpaceDestroyerGame.GameObjects.CosmicObjects
{
    using SpaceDestroyerGame.Misc;
    using System;
    using System.Linq;

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
                this.IsDestroyed = true;
            }
        }
    }
}
