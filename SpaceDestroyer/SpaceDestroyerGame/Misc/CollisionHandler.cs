namespace SpaceDestroyerGame.Misc
{
    using SpaceDestroyerGame.GameObjects;
    using SpaceDestroyerGame.GameObjects.CosmicObjects;
    using SpaceDestroyerGame.Ships;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class CollisionHandler
    {
        public static long[] CollisionCheck(List<MovingObject> movingObjects, List<Bullet> bullets, PlayerSpaceCraft craft, long[] data)
        {
            //for (int i = 0; i < movingObjects.Count; i++)
            //{
            //    var objType = movingObjects[i].GetType().Name;
            //    var obj = movingObjects[i];

            //    switch (objType)
            //    {
            //        case "EnemySpaceCraftProtoOne":
            //            if (obj.GetPosition.Row == craft.GetPosition.Row - 2 && 
            //                (obj.GetPosition.Col + 2 >= craft.GetPosition.Col && obj.GetPosition.Col + 1 <= craft.GetPosition.Col + 7))
            //            {
            //                obj.Collide(craft);
            //                craft.Collide(obj);
            //            }
            //            break;
            //        case "Meteor":
            //            if ((obj.GetPosition.Row + 1 >= craft.GetPosition.Row && obj.GetPosition.Row + 1 <= craft.GetPosition.Row + 3) &&
            //                (obj.GetPosition.Col + 2 >= craft.GetPosition.Col && obj.GetPosition.Col + 1 <= craft.GetPosition.Col + 7))
            //            {
            //                obj.Collide(craft);
            //                craft.Collide(obj);
            //            }
            //            break;
            //        case "Asteroid":
            //            if ((obj.GetPosition.Row >= craft.GetPosition.Row && obj.GetPosition.Row <= craft.GetPosition.Row + 3) && (obj.GetPosition.Col >= craft.GetPosition.Col &&
            //                            obj.GetPosition.Col <= craft.GetPosition.Col + 7))
            //            {
            //                obj.Collide(craft);
            //                craft.Collide(obj);
            //            }
            //            break;
            //        case "Gift":
            //            if (obj.GetPosition.Row == craft.GetPosition.Row && (obj.GetPosition.Col >= craft.GetPosition.Col && obj.GetPosition.Col <= craft.GetPosition.Col + 8))
            //            {
            //                obj.Collide(craft);
            //                craft.Collide(obj);
            //            }
            //            break;
            //        default:
            //            break;
            //    }

            //    for (int j = 0; j < bullets.Count; j++)
            //    {
            //        var bullet = bullets[j];
            //        switch (objType)
            //        {
            //            case "EnemySpaceCraftProtoOne":
            //                if (bullet.GetPosition.Row == obj.GetPosition.Row + 3 && (bullet.GetPosition.Col >= obj.GetPosition.Col &&
            //                            bullet.GetPosition.Col <= obj.GetPosition.Col + 3))
            //                {
            //                    bullet.Collide(obj);
            //                    obj.Collide(bullet);
            //                    Console.ForegroundColor = ConsoleColor.Green;
            //                    data[0] += 50;
            //                    data[1] += 1;
            //                }
            //                break;
            //            case "Asteroid":
            //                if (bullet.GetPosition.Row == obj.GetPosition.Row && bullet.GetPosition.Col == obj.GetPosition.Col)
            //                {
            //                    bullet.Collide(obj);
            //                    obj.Collide(bullet);
            //                    Console.ForegroundColor = ConsoleColor.Green;
            //                    data[0] += 60;
            //                    data[2] += 1;
            //                }
            //                break;
            //            case "Meteor":
            //                if (bullet.GetPosition.Row == obj.GetPosition.Row + 2 && 
            //                    (bullet.GetPosition.Col >= obj.GetPosition.Col && bullet.GetPosition.Col <= obj.GetPosition.Col + 2))
            //                {
            //                    bullet.Collide(obj);
            //                    obj.Collide(bullet);
            //                    Console.ForegroundColor = ConsoleColor.Green;
            //                    data[0] += 75;
            //                    data[3] += 1;
            //                }
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //}
            foreach (var obj in movingObjects)
            {
                if (obj is EnemySpaceCraftProtoOne)
                {
                    if (obj.GetPosition.Row == craft.GetPosition.Row - 2 && (obj.GetPosition.Col + 2 >= craft.GetPosition.Col &&
                                        obj.GetPosition.Col + 1 <= craft.GetPosition.Col + 7))
                    {
                        obj.Collide(craft);
                        craft.Collide(obj);
                    }
                }
                else if (obj is Meteor)
                {
                    if ((obj.GetPosition.Row + 1 >= craft.GetPosition.Row && obj.GetPosition.Row + 1 <= craft.GetPosition.Row + 3) && (obj.GetPosition.Col + 2 >= craft.GetPosition.Col &&
                                        obj.GetPosition.Col + 1 <= craft.GetPosition.Col + 7))
                    {
                        obj.Collide(craft);
                        craft.Collide(obj);
                    }
                }
                else if (obj is Asteroid)
                {
                    if ((obj.GetPosition.Row >= craft.GetPosition.Row && obj.GetPosition.Row <= craft.GetPosition.Row + 3) && (obj.GetPosition.Col >= craft.GetPosition.Col &&
                                        obj.GetPosition.Col <= craft.GetPosition.Col + 7))
                    {
                        obj.Collide(craft);
                        craft.Collide(obj);
                    }
                }
                else if (obj is Gift)
                {
                    if (obj.GetPosition.Row == craft.GetPosition.Row && (obj.GetPosition.Col >= craft.GetPosition.Col && obj.GetPosition.Col <= craft.GetPosition.Col + 8))
                    {
                        obj.Collide(craft);
                        craft.Collide(obj);
                    }
                }

                foreach (var bullet in bullets)
                {
                    if (obj is EnemySpaceCraftProtoOne)
                    {
                        if (bullet.GetPosition.Row == obj.GetPosition.Row + 3 && (bullet.GetPosition.Col >= obj.GetPosition.Col &&
                                        bullet.GetPosition.Col <= obj.GetPosition.Col + 3))
                        {
                            bullet.Collide(obj);
                            obj.Collide(bullet);
                            Console.ForegroundColor = ConsoleColor.Green;
                            data[0] += 50;
                            data[1] += 1;
                        }
                    }
                    else if (obj is Asteroid)
                    {
                        if (bullet.GetPosition.Row == obj.GetPosition.Row && bullet.GetPosition.Col == obj.GetPosition.Col)
                        {
                            bullet.Collide(obj);
                            obj.Collide(bullet);
                            Console.ForegroundColor = ConsoleColor.Green;
                            data[0] += 60;
                            data[2] += 1;
                        }
                    }
                    else if (obj is Meteor)
                    {
                        if (bullet.GetPosition.Row == obj.GetPosition.Row + 2 && (bullet.GetPosition.Col >= obj.GetPosition.Col &&
                                        bullet.GetPosition.Col <= obj.GetPosition.Col + 2))
                        {
                            bullet.Collide(obj);
                            obj.Collide(bullet);
                            Console.ForegroundColor = ConsoleColor.Green;
                            data[0] += 75;
                            data[3] += 1;
                        }
                    }
                }
            }

            return data;
        }
    }
}
