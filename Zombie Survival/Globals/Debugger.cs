using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival.Globals
{
    public class Debugger
    {
        public static void Draw(SpriteBatch spriteBatch, Rectangle boundingBox)
        {
            // Draw the bounding box for debugging
            Texture2D whiteTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            whiteTexture.SetData(new[] { Color.White });
            spriteBatch.Draw(whiteTexture, boundingBox, Color.Red * 0.5f);
        }


        public static Rectangle BoundingBox(Texture2D frame, Vector2 position, Vector2 scale, float scaleFactor)
        {
            if(frame != null)
            {

                int width = (int)(frame.Width * scale.X * scaleFactor);
                int height = (int)(frame.Height * scale.Y * scaleFactor);
                int x = (int)(position.X - (width / 2));
                int y = (int)(position.Y - (height / 2));
                return new Rectangle(x, y, width, height);
            }
            else
            {
                return new Rectangle(0, 0, 0, 0);
            }

        }
    }
}
