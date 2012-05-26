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

        public void Move(KeyboardState keystate)
        {
            if (keystate.IsKeyDown(Keys.A) && this.velocityX > -5.4f)
            {
                this.velocityX -= this.accelerationX;
            }
            if (keystate.IsKeyDown(Keys.D) && this.velocityX < 5.4f)
            {
                this.velocityX += this.accelerationX;
            }
            if (!keystate.IsKeyDown(Keys.A) && !keystate.IsKeyDown(Keys.D))
            {
                if (Math.Abs(this.velocityX) < .2f)
                {
                    this.velocityX = 0.0f;
                }
                else if (this.velocityX >= 0f)
                {
                    this.velocityX -= this.accelerationX;
                }
                else if (this.velocityX <= 0f)
                {
                    this.velocityX += this.accelerationX;
                }
            }
            if (keystate.IsKeyDown(Keys.Space))
            {
                this.velocityY = -15f;
                this.Update();
                Console.WriteLine("Pushed Spacebar");
            }
            this.pos.X += this.velocityX;
            this.rect.X = (int)this.pos.X;
        }
    }
}
