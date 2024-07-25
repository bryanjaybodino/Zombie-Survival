using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Zombie_Survival.Bullets.Textures;

namespace Zombie_Survival.Bullets
{
    internal class Shoot
    {
        List<Sprite> bullets = new List<Sprite>();
        public void Attack()
        {
            Vector2 position = Characters.Movements.Position;
            float rotation = Characters.Movements.Rotation;

            // Gun offset relative to the character's position (adjust as needed)
            Vector2 gunOffset = new Vector2(25, 15);

            // Rotate the offset based on the character's rotation
            Vector2 rotatedOffset = Vector2.Transform(gunOffset, Matrix.CreateRotationZ(rotation));

            // Calculate the bullet's initial position
            Vector2 bulletStartPosition = position + rotatedOffset;

            // Calculate the direction based on the rotation
            Vector2 direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            direction.Normalize();

            bullets.Add(new Sprite(Textures.Bullets.Pistol.frames, bulletStartPosition, direction, 1000f, rotation));
        }

        public void Update(GameTime gameTime)
        {
            foreach (var bullet in bullets)
            {
                bullet.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            // Draw bullets
            foreach (var bullet in bullets)
            {
                bullet.Draw(_spriteBatch);
            }
        }
    }
}
