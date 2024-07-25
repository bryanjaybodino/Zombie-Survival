using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival.Bullets
{
    internal class Shoot
    {
        List<Sprite> bullets = new List<Sprite>();
        public void Attack()
        {
            Vector2 target = new Vector2(Characters.Movements.Rotation);
            Vector2 direction = target - Characters.Movements.Position;
            direction.Normalize();
            bullets.Add(new Sprite(Textures.Bullets.Pistol._frames,Characters.Movements.Position, direction, 1000f));
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
