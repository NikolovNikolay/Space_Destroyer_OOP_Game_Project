﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDestroyerGame
{
    public class CosmicObject : MovingObject
    {
        public CosmicObject(Position position, char[,] body): base(position, body)
        {
        }

        public override void Move()
        {
        }
    }
}
