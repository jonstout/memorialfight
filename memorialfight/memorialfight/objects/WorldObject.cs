using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace memorialfight.objects
{
    class WorldObject : memorialfight.objects.GameObject
    {
        private Texture2D texture;
        public Rectangle leftBar;
        public Rectangle rightBar;
        public Rectangle topBar;
        public Rectangle bottomBar;

        public WorldObject(Vector2 pos, Rectangle rect, Texture2D texture) :
            base(pos, rect)
        {
            this.texture = texture;

            this.leftBar = new Rectangle((int)pos.X, (int)pos.Y, 20, rect.Height);
            this.rightBar = new Rectangle((int)pos.X + rect.Width - 20, (int)pos.Y, 20, rect.Height);
            this.topBar = new Rectangle((int)pos.X + 20, (int)pos.Y, rect.Width - 40, 20);
            this.bottomBar = new Rectangle((int)pos.X + 20, (int)pos.Y + rect.Height - 20, rect.Width - 40, 20);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.pos, Color.White);
        }

        public void Move(Vector2 velocity)
        {
            // Update this WorldObject's position
            this.pos.X += (int)velocity.X;
            this.pos.Y += (int)velocity.Y;
            // Update this WorldObject collision box's position
            this.rect.X += (int)velocity.X;
            this.rect.Y += (int)velocity.Y;
            this.leftBar.X += (int)velocity.X;
            this.leftBar.Y += (int)velocity.Y;
            this.rightBar.X += (int)velocity.X;
            this.rightBar.Y += (int)velocity.Y;
            this.topBar.X += (int)velocity.X;
            this.topBar.Y += (int)velocity.Y;
            this.bottomBar.X += (int)velocity.X;
            this.bottomBar.Y += (int)velocity.Y;
        }
    }
}
