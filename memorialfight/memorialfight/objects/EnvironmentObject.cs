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
    class EnvironmentObject : WorldObject
    {
        private Texture2D texture;

        public EnvironmentObject(Vector2 pos, Rectangle rect, Texture2D texture) :
            base(pos, rect, texture)
        {
            this.texture = texture;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(this.texture, this.rect, Color.White);
        }
    }
}
