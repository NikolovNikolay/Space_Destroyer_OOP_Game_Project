namespace SpaceDestroyerGame.Ships
{
    using SpaceDestroyerGame.Misc;
    using System;
    using System.Linq;

    public abstract class EnemySpaceCraft : SpaceCraft
    {
        public EnemySpaceCraft(Position position)
            : base(position, new char[,] { { ' ' } })
        {
        }
    }
}
