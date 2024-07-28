using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival.UI_Elements
{
    public class Sprite
    {
        private Viewport _viewport;
        public Sprite(Viewport viewport)
        {
            _viewport = viewport;
        }

        public void Draw(SpriteBatch _spriteBatch, string currentWeapon)
        {
            //HEART
            DisplayImage(_spriteBatch, Textures.Heart.frames, 0.1f, 10, 10);

            //BULLETS
            var bulletPosition = DisplayImage(_spriteBatch, Textures.Bullet.frames, 0.1f, 10, 35);
            string currentBullets = "";

            //GET THE BULLET FROM CHARACTERS
            if (currentWeapon == "knife")
            {
                currentBullets = "0/0";
            }
            else if (currentWeapon == "rifle")
            {
                currentBullets = Characters.Sprite.RifleMagazine.CurrentBullets + "/" + Characters.Sprite.RifleMagazine.TotalBullets;
            }
            else if (currentWeapon == "pistol")
            {
                currentBullets = Characters.Sprite.PistolMagazine.CurrentBullets + "/" + Characters.Sprite.PistolMagazine.TotalBullets;
            }
            else if (currentWeapon == "shotgun")
            {
                currentBullets = Characters.Sprite.ShotgunMagazine.CurrentBullets + "/" + Characters.Sprite.ShotgunMagazine.TotalBullets;
            }


            Globals.FontTexture.Draw(_spriteBatch, "Ammo : " + currentBullets, new Vector2(bulletPosition.X + 30, bulletPosition.Y+5), Color.WhiteSmoke, true);
        }



        private Vector2 DisplayImage(SpriteBatch _spriteBatch, Texture2D[] _frames, float size, float X = 0, float Y = 0)
        {
            var frameHeight = _frames[0].Height * size;
            var frameWidth = _frames[0].Width * size;
            var x = Globals.Camera.cameraPosition.X;
            var y = Globals.Camera.cameraPosition.Y;
            Vector2 CurrentPosition = new Vector2(x + X, y + Y);

            Vector2 origin = new Vector2(frameWidth / 2, frameHeight / 2);
            _spriteBatch.Draw(
                _frames[0],
                new Vector2(CurrentPosition.X, CurrentPosition.Y),
                null,
                Color.White,
                0f,
                origin, // Use the center of the frame as the origin
                size,
                SpriteEffects.None,
                0f
            );

            return CurrentPosition;
        }
    }
}
