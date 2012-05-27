using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using memorialfight.objects;
using memorialfight.objects.actor;

namespace memorialfight.objects.special
{
    class Level
    {
        private LinkedList<EnvironmentObject> envObjects;

        public Level(LinkedList<Player> players, LinkedList<Texture2D> tileSet, String tileId, String tileType)
        {
            this.envObjects = this.CreateEnvironment(tileId, tileType, tileSet);
        }

        private LinkedList<EnvironmentObject> CreateEnvironment(String tileId, String tileType, LinkedList<Texture2D> tileSet)
        {
            LinkedList<EnvironmentObject> result = new LinkedList<EnvironmentObject>();
            Vector2 pos = new Vector2(0f);
            for (int i = 0; i < tileId.Length; i++)
            {
                Char tileRef = tileId.ElementAt(i);

                switch(tileRef)
                {
                    case '0':
                        EnvironmentObject tmp = new EnvironmentObject(pos, new Rectangle((int)pos.X, (int)pos.Y, 120, 120), tileSet.ElementAt(0));
                        result.AddLast(tmp);
                        break;
                    default:
                        Console.WriteLine("Nothing added");
                        break;
                }
            }
            return result;
        }
    }
}
