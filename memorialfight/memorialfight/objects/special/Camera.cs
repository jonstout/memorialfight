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
    class Camera
    {
        // Where on the screen we draw the environment
        Rectangle screenRect;
        // What part of the gameworld we actually draw
        Rectangle worldRect;
        Vector2 worldOffset;

        public Camera(Rectangle screenRect, Vector2 actorPosition)
        {
            this.screenRect = screenRect;
            
            this.worldRect = screenRect;
            this.UpdateWorldRect(actorPosition);
        }

        public void Update(Vector2 actorPosition)
        {
            this.UpdateWorldRect(actorPosition);

            this.worldOffset = new Vector2(this.worldRect.X - this.screenRect.X, this.worldRect.Y - this.screenRect.Y);
        }

        public void UpdateWorldRect(Vector2 actorPosition)
        {
            this.worldRect.X = (int)actorPosition.X - (this.worldRect.Width / 2);
            this.worldRect.Y = (int)actorPosition.Y - (this.worldRect.Height / 2);
        }

        public void Draw(Texture2D texture, Vector2 position, Color color)
        {

        }

        public Vector2 DrawPosition(Vector2 objPosition)
        {
            return new Vector2(objPosition.X - this.worldOffset.X, objPosition.Y - this.worldOffset.Y);
        }
    }
}
