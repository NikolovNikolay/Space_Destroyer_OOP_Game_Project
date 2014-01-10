namespace SpaceDestroyerGame.GameObjects.CosmicObjects
{
    using SpaceDestroyerGame.Misc;
    using System;
    using System.Linq;

    public class MeteorRightAttack : Meteor
    {
        public MeteorRightAttack(Position position)
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
            this.position.Col--;
        }
    }
}
