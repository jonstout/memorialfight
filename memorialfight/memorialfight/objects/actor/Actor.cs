using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    class Actor : memorialfight.objects.WorldObject
    {
        protected float velocityY;
        protected float velocityX;
        protected float accelerationY;
        protected float accelerationX;
        protected Boolean jumping;
        protected float maxAccelerationX;
        protected float maxAccelerationY;

        public Actor(Vector2 pos, Rectangle rect, Texture2D texture) :
            base(pos, rect, texture)
        {
            this.maxAccelerationX = 5.4f;
            this.maxAccelerationY = 1.3f;
            this.accelerationY = 6.5f;
            this.accelerationX = .3f;
            this.jumping = true;
        }

        public void SetMaxAccelerationX(float maxAcceleration)
        {
            this.maxAccelerationX = maxAcceleration;
        }

        public Boolean StandingOn(Rectangle r_rect)
        {
            Console.WriteLine(this.bottomBar.Intersects(r_rect).ToString() + r_rect.ToString() + this.bottomBar.ToString());
            if (this.bottomBar.Intersects(r_rect))
            {
                this.jumping = false;
                this.velocityY = 0f;
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual void Update()
        {
            if (this.velocityY < this.maxAccelerationY)
            {
                this.velocityY += this.accelerationY;
            }
            this.Move(new Vector2(0f, this.velocityY));
        }

        public void MoveLeft()
        {
            if (this.velocityX > -this.maxAccelerationX)
            {
                this.velocityX -= this.accelerationX;
            }
            this.Move(new Vector2(this.velocityX, 0f));
        }

        public void MoveRight()
        {
            if (this.velocityX < this.maxAccelerationX)
            {
                this.velocityX += this.accelerationX;
            }
            this.Move(new Vector2(this.velocityX, 0f));
        }

        public void Pause()
        {
            if (Math.Abs(this.velocityX) < .2f)
            {
                this.velocityX = 0.0f;
            }
            else if (this.velocityX > 0f)
            {
                this.velocityX -= this.accelerationX;
            }
            else if (this.velocityX < 0f)
            {
                this.velocityX += this.accelerationX;
            }
            this.Move(new Vector2(this.velocityX, 0f));
        }

        public void Jump()
        {
            if (!this.jumping)
            {
                this.velocityY = -35f;
                this.Move(new Vector2(0f, this.velocityY));
                this.jumping = true;
            }
        }

        public void Fire()
        {
            // TODO: Make an object to fire at shit.
        }
    }
}
