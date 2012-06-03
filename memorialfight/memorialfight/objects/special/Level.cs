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
        private LinkedList<Player> players;

        private Camera camera;

        public Level(Camera camera, LinkedList<Player> players, LinkedList<Texture2D> tileSet, Vector2 levelPosition, String tileReference, String tileType)
        {
            this.players = players;
            this.envObjects = this.CreateEnvironment(tileSet, levelPosition, tileReference, tileType);

            this.camera = camera;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 tmp = new Vector2();
            // Players
            for (int i = 0; i < players.Count; i++)
            {
                tmp = this.players.ElementAt(i).pos;
                this.players.ElementAt(i).Position(this.camera.DrawPosition(this.players.ElementAt(i).pos));
                this.players.ElementAt(i).Draw(spriteBatch);
                this.players.ElementAt(i).Position(tmp);
            }
            
            // EnvironmentObjects
            for (int i = 0; i < envObjects.Count; i++)
            {
                tmp = this.envObjects.ElementAt(i).pos;
                this.envObjects.ElementAt(i).Position(this.camera.DrawPosition(this.envObjects.ElementAt(i).pos));
                this.envObjects.ElementAt(i).Draw(spriteBatch);
                this.envObjects.ElementAt(i).Position(tmp);
            }
        }

        public void MovePlayer1(KeyboardState keyState)
        {
            this.players.ElementAt(0).MovePlayer(keyState);

            this.camera.Update(this.players.ElementAt(0).pos);
        }

        public void Update()
        {
            for (int i = 0; i < players.Count; i++)
            {
                this.players.ElementAt(i).Update(envObjects);
            }
        }

        private LinkedList<EnvironmentObject> CreateEnvironment(LinkedList<Texture2D> tileSet, Vector2 levelPosition, String tileReference, String tileType)
        {
            LinkedList<EnvironmentObject> result = new LinkedList<EnvironmentObject>();
            Vector2 pos = levelPosition;
            for (int i = 0; i < tileReference.Length; i++)
            {
                Char tileRef = tileReference.ElementAt(i);

                switch(tileRef)
                {
                    case '0':
                        pos.X += 120;
                        break;
                    case '1':
                        EnvironmentObject tmp = new EnvironmentObject(pos, new Rectangle((int)pos.X, (int)pos.Y, 120, 120), tileSet.ElementAt(0));
                        result.AddLast(tmp);
                        pos.X += 120;
                        break;
                    case '2':
                        EnvironmentObject tmp1 = new EnvironmentObject(pos, new Rectangle((int)pos.X, (int)pos.Y, 120, 120), tileSet.ElementAt(1));
                        result.AddLast(tmp1);
                        pos.X += 120;
                        break;
                    case '\n':
                        pos.X = levelPosition.X;
                        pos.Y += 120;
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
