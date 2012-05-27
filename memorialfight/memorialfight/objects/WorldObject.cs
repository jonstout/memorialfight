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

            this.leftBar = new Rectangle(rect.X, rect.Y, 20, rect.Height);
            this.rightBar = new Rectangle(rect.Width - 20, rect.Y, 20, rect.Height);
            this.topBar = new Rectangle(rect.X + 20, rect.Y, rect.Width - 40, 20);
            this.bottomBar = new Rectangle(rect.X + 20, rect.Height - 20, rect.Width - 40, 20);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.pos, Color.White);
        }

        public void Move(Vector2 pos)
        {
            // Update this WorldObject's position
            this.pos.X += pos.X;
            this.pos.Y += pos.Y;
            // Update this WorldObject collision box's position
            this.rect.X += (int)pos.X;
            this.rect.Y += (int)pos.Y;
            this.leftBar.X += (int)pos.X;
            this.leftBar.Y += (int)pos.Y;
            this.rightBar.X += (int)pos.X;
            this.rightBar.Y += (int)pos.Y;
            this.topBar.X += (int)pos.X;
            this.topBar.Y += (int)pos.Y;
            this.bottomBar.X += (int)pos.X;
            this.bottomBar.Y += (int)pos.Y;
        }
    }
}
