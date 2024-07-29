using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival.Globals
{
    public class FontTexture
    {
        static SpriteFont messageFont;

        public static void LoadContent(ContentManager content)
        {
            messageFont = content.Load<SpriteFont>("Text");
        }

        public static void Draw(SpriteBatch _spriteBatch, string message, Vector2 position, Color color, bool isBold = false, float scale = 1f, float rotation = 0f)
        {
            Vector2 origin = Vector2.Zero; // Adjust origin as needed for centering, etc.

            if (isBold)
            {
                // Simulate bold by drawing the text multiple times with slight offsets
                Vector2[] offsets = new Vector2[]
                {
                        new Vector2(-1, 0),
                        new Vector2(1, 0),
                        new Vector2(0, -1),
                        new Vector2(0, 1)
                };

                foreach (var offset in offsets)
                {
                    _spriteBatch.DrawString(messageFont, message, position + offset, Color.Black, rotation, origin, scale, SpriteEffects.None, 0f);
                }
            }

            // Draw the main text
            _spriteBatch.DrawString(messageFont, message, position, color, rotation, origin, scale, SpriteEffects.None, 0f);
        }
    }
}
