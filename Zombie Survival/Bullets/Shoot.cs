﻿using Microsoft.Xna.Framework;
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




        private void Pistol(Texture2D frames)
        {
            float scale = 0.02f;
            Vector2 position = Characters.Movements.Position;
            float rotation = Characters.Movements.Rotation;
            Vector2 gunOffset = new Vector2(35, 22);

            // Rotate the offset based on the character's rotation
            Vector2 rotatedOffset = Vector2.Transform(gunOffset, Matrix.CreateRotationZ(rotation));

            // Calculate the bullet's initial position
            Vector2 bulletStartPosition = position + rotatedOffset;

            // Calculate the direction based on the rotation
            Vector2 direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            direction.Normalize();

            bullets.Add(new Sprite(frames, bulletStartPosition, direction, 2500f, rotation, scale, 10000f));
        }


        private void Rifle(Texture2D frames)
        {
            float scale = 0.05f;
            Vector2 position = Characters.Movements.Position;
            float rotation = Characters.Movements.Rotation;
            Vector2 gunOffset = new Vector2(40, 10);// PARA SUMAKTO YUNG BALA SA BARIL

            // Rotate the offset based on the character's rotation
            Vector2 rotatedOffset = Vector2.Transform(gunOffset, Matrix.CreateRotationZ(rotation));

            // Calculate the bullet's initial position
            Vector2 bulletStartPosition = position + rotatedOffset;

            // Calculate the direction based on the rotation
            Vector2 direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            direction.Normalize();

            bullets.Add(new Sprite(frames, bulletStartPosition, direction, 2500f, rotation, scale, 10000f));
        }


        private void Shotgun(Texture2D frames)
        {
            float scale = 0.05f;
            Vector2 position = Characters.Movements.Position;
            float rotation = Characters.Movements.Rotation;
            Vector2 gunOffset = new Vector2(65, 10); // Adjust as needed

            // Define the maximum distance for shotgun bullets
            float maxDistance = 300f; // Adjust this value to shorten or lengthen the range

            // Shoot three bullets with slightly different angles
            for (int i = -1; i <= 1; i++)
            {
                float spreadAngle = 0.1f * i; // Adjust the spread angle as needed
                float bulletRotation = rotation + spreadAngle;

                // Rotate the offset based on the character's rotation
                Vector2 rotatedOffset = Vector2.Transform(gunOffset, Matrix.CreateRotationZ(bulletRotation));

                // Calculate the bullet's initial position
                Vector2 bulletStartPosition = position + rotatedOffset;

                // Calculate the direction based on the rotation
                Vector2 direction = new Vector2((float)Math.Cos(bulletRotation), (float)Math.Sin(bulletRotation));
                direction.Normalize();

                bullets.Add(new Sprite(frames, bulletStartPosition, direction, 2500f, bulletRotation, scale, maxDistance));
            }
        }





        public void Attack(Texture2D frames)
        {
            if (frames.Name == "Characters/Pistol/Bullet")
            {
                Pistol(frames);
            }
            else if (frames.Name == "Characters/Rifle/Bullet")
            {
                Rifle(frames);
            }
            else if (frames.Name == "Characters/Shotgun/Bullet")
            {
                Shotgun(frames);
            }


        }

        public void Update(GameTime gameTime, List<Zombies.Sprite> zombies)
        {
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                bullets[i].Update(gameTime);

                bool bulletHit = false;

                for (int j = zombies.Count - 1; j >= 0; j--)
                {
                    if (bullets[i].BoundingBox.Intersects((Rectangle)zombies[j].BoundingBox))
                    {
                        // Bullet hits the zombie
                        bulletHit = true;
                        zombies.RemoveAt(j);



                        Random random = new Random();
                        float newX = random.Next(Maps.Textures.Covid19.frames[0].Width);
                        float newY = random.Next(Maps.Textures.Covid19.frames[0].Height);


                        Vector2 NewPosition = new Vector2(newX, newY);
                        zombies.Add(new Zombies.Sprite(NewPosition));
                        break;
                    }
                }

                // If the bullet hit a zombie, remove it
                if (bulletHit)
                {
                    bullets.RemoveAt(i);
                }
                else if (!bullets[i].IsActive)
                {
                    bullets.RemoveAt(i);
                }
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
