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

namespace memorialfight.objects
{
    class GameObject
    {
        public Vector2 pos;
        public Rectangle rect;

        /* GameObject is the base class for anthing in the game.
         *  
         * Params:
         *  xPos: Position on the X-axis
         *  yPos: Position on the Y-axis
         *  hitBox: Rectangle representing the active area of this GameObject
         */
        public GameObject(Vector2 pos, Rectangle rect)
        {
            this.pos = pos;
            this.rect = rect;
        }

        /* Intersects
         * 
         * Params:
         *  rect: Rectangle to check for collisions
         * 
         * Returns:
         *  Boolean: True if rect intersect with this GameObject
         */
        public Boolean Intersects(Rectangle rect)
        {
            if (this.rect.Intersects(rect))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
