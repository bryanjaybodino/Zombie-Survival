using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival.Globals
{
    public class RectangleImage
    {
        public static Rectangle Draw(SpriteBatch _spriteBatch, Texture2D[] _frames, float width, float height, float X = 0, float Y = 0)
        {
            // Calculate the position of the image
            var x = Globals.Camera.cameraPosition.X;
            var y = Globals.Camera.cameraPosition.Y;
            Vector2 CurrentPosition = new Vector2(x + X, y + Y);

            // Create a destination rectangle using the specified width and height
            Rectangle destinationRectangle = new Rectangle(
                (int)(CurrentPosition.X - width / 2),  // x position - half of the width for centering
                (int)(CurrentPosition.Y - height / 2), // y position - half of the height for centering
                (int)width,   // width of the rectangle
                (int)height   // height of the rectangle
            );

            // Draw the texture to the specified rectangle
            _spriteBatch.Draw(
                _frames[0],        // Texture to draw
                destinationRectangle, // Destination rectangle defining size and position
                null,              // Source rectangle (null to use the entire texture)
                Color.White,       // Color tint
                0f,                // Rotation angle
                Vector2.Zero,      // Origin (center of the texture)
                SpriteEffects.None,// Sprite effects (e.g., flipping)
                0f                 // Layer depth
            );

            return destinationRectangle;
        }
    }
}
