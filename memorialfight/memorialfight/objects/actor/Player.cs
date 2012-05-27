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

namespace memorialfight.objects.actor
{
    class Player : Actor
    {
        protected int id;

        public Player(Vector2 pos, Rectangle rect, Texture2D texture, int id) :
            base(pos, rect, texture)
        {
            this.id = id;
        }

        public void MovePlayer(KeyboardState keystate)
        {
            if (keystate.IsKeyDown(Keys.A))
            {
                this.MoveLeft();
            }
            if (keystate.IsKeyDown(Keys.D))
            {
                this.MoveRight();
            }
            if (!keystate.IsKeyDown(Keys.A) && !keystate.IsKeyDown(Keys.D))
            {
                this.Pause();
            }
            if (keystate.IsKeyDown(Keys.Space))
            {
                this.Jump();
            }
        }
    }
}
