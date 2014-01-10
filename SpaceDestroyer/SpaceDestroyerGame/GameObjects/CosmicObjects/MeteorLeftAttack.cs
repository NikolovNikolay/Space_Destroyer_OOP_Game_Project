namespace SpaceDestroyerGame.GameObjects.CosmicObjects
{
    using SpaceDestroyerGame.Misc;
    using System;
    using System.Linq;

    public class MeteorLeftAttack : Meteor
    {
        public MeteorLeftAttack(Position position)
            : base(position, new char[,]
            {
            { '\\','|','/' },
            { '-','*','-'},
            { '/','|', '\\'}
            })
        {
        }

        public override void Move()
        {
            this.position.Row++;
            this.position.Col++;
        }
    }
}
