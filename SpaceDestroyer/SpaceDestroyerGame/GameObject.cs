using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDestroyerGame
{
    public abstract class GameObject : IRenderable, ICollidable
    {
        protected ConsoleColor color;
        protected Position position;
        protected char[,] body;
        protected bool destroyed = false;

        public GameObject(Position initialPosition, char[,] objectBody, ConsoleColor color = ConsoleColor.DarkGray)
        {
            this.position = initialPosition;
            this.body = this.CopyMatrixBody(objectBody);
        }

        public Position GetPosition
        {
            get
            {
                return new Position(position.Row, position.Col);
            }

            protected set
            {
                this.position = new Position(value.Row, value.Col);
            }
        }

        public bool isDestroyed
        {
            get
            {
                return this.destroyed;
            }

            set
            {
                this.destroyed = value;
            }
        }

        private char[,] CopyMatrixBody(char[,] matrixToCopy)
        {
            int rows = matrixToCopy.GetLength(0);
            int cols = matrixToCopy.GetLength(1);
            char[,] copiedMatrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    copiedMatrix[i, j] = matrixToCopy[i, j];
                }
            }

            return copiedMatrix;
        }

        public char[,] GetImage()
        {
            return CopyMatrixBody(body);
        }

        public abstract void Move();

        public virtual void Collide(GameObject obj)
        {
            this.isDestroyed = true;
        }
    }
}
