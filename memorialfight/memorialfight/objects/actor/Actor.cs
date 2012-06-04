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
        public Boolean jumping;
        protected float maxAccelerationX;
        protected float maxAccelerationY;

        public Actor(Vector2 pos, Rectangle rect, Texture2D texture) :
            base(pos, rect, texture)
        {
            this.maxAccelerationX = 5.4f;
            this.maxAccelerationY = 16f;
            this.accelerationY = 5f;
            this.accelerationX = .3f;
            this.jumping = true;
        }

        public void SetMaxAccelerationX(float maxAcceleration)
        {
            this.maxAccelerationX = maxAcceleration;
        }

        private Boolean StandingOn(Rectangle r_rect)
        {
            if (this.bottomBar.Intersects(r_rect))
            {
                // If depth is too low the character keeps falling just enough to
                // snap back to the correct position. This makes things work poorly.
                float depth = (this.bottomBar.Y + this.bottomBar.Height) - r_rect.Y;
                if (depth > 4)
                {
                    this.Position(new Vector2(this.pos.X, r_rect.Y - this.rect.Height));
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean GroundCollision(LinkedList<EnvironmentObject> objects)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                if (this.StandingOn(objects.ElementAt(i).rect))
                {
                    this.Position(new Vector2(this.pos.X, objects.ElementAt(i).rect.Top - this.rect.Height));
                    this.jumping = false;
                    return true;
                }
            }
            this.jumping = true;
            return false;
        }

        private Boolean UpAgainst(EnvironmentObject obj)
        {
            if (this.rightBar.Intersects(obj.leftBar))
            {
                float depth = (this.rightBar.X + this.bottomBar.Width) - obj.rect.X;
                if (depth > 5)
                {
                    this.Position(new Vector2((obj.rect.X - this.rect.Width), this.pos.Y));
                }
                return true;
            }
            else if (this.leftBar.Intersects(obj.rightBar))
            {
                float depth = (obj.rect.Y + obj.rect.Width) - this.leftBar.X;
                if (depth > 5)
                {
                    this.Position(new Vector2(obj.rect.X + obj.rect.Width, this.pos.Y));
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean WallCollision(LinkedList<EnvironmentObject> objects)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                if (this.UpAgainst(objects.ElementAt(i)))
                {
                    return true;
                }
            }
            return false;
        }

        public virtual void Update(LinkedList<EnvironmentObject> objects)
        {
            // Do ground collisions with environment
            if (!this.GroundCollision(objects))
            {
                if (this.velocityY < this.maxAccelerationY)
                {
                    this.velocityY += this.accelerationY;
                }
            }
            // Check wall collisions with environment
            if (this.WallCollision(objects))
            {
                this.velocityX = 0f;
            }
            
            //Console.WriteLine(this.velocityX.ToString() + " " + this.velocityY.ToString());
            this.Move(new Vector2(this.velocityX, this.velocityY));
        }

        public void MoveLeft()
        {
            if (this.velocityX > -this.maxAccelerationX)
            {
                this.velocityX -= this.accelerationX;
            }
        }

        public void MoveRight()
        {
            if (this.velocityX < this.maxAccelerationX)
            {
                this.velocityX += this.accelerationX;
            }
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
        }

        public void Jump()
        {
            if (!this.jumping)
            {
                this.velocityY = -70f;
                this.jumping = true;
            }
        }

        public void Fire()
        {
            // TODO: Make an object to fire at shit.
        }
    }
}
