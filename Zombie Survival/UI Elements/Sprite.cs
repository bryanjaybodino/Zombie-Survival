using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Zombie_Survival.UI_Elements
{
    public class Sprite
    {
        private static Viewport _viewport;
        private int TotalHealthBar;
        private Timer _myTimer;
        private double _totalPlayTime;
        private bool _isGameActive;

        private string playTimeText;
        public Sprite(Viewport viewport)
        {
            _viewport = viewport;
            TotalHealthBar = Characters.Movements.HealhtBar;
            _totalPlayTime = 0.0;
            _isGameActive = true;
            _myTimer = new Timer(1); // Timer for 5 seconds
            _myTimer.Elapsed += _myTimer_Elapsed; ;
            _myTimer.Start();
        }

        private void _myTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _totalPlayTime += 1;
            playTimeText = $"Play Time: {TimeSpan.FromSeconds(_totalPlayTime):hh\\:mm\\:ss}";
        }

        public void Draw(SpriteBatch _spriteBatch, string currentWeapon)
        {
            //HEART
            var heartPosition = Globals.RectangleImage.Draw(_spriteBatch, Textures.Heart.frames, 30f, 30f, 30, 30);
            Globals.FontTexture.Draw(_spriteBatch, "Health : ", new Vector2(heartPosition.X + 35, heartPosition.Y), Color.WhiteSmoke, false, 1.5f);


            ///HEALTH BAR
            Globals.BoxTexture.Draw(_spriteBatch, TotalHealthBar, 15, Color.Black, new Vector2(heartPosition.X + 115, heartPosition.Y + 5));

            int healthBarGreen = (TotalHealthBar * 3) / 4;
            int healthBarOrange = TotalHealthBar / 2;

            // Ensure that Characters.Movements.HealthBar is correctly initialized
            int currentHealth = Characters.Movements.HealhtBar;

            // Determine color based on health value
            Color healthColor;
            if (currentHealth >= healthBarGreen)
            {
                healthColor = Color.LimeGreen;
            }
            else if (currentHealth >= healthBarOrange)
            {
                healthColor = Color.Orange;
            }
            else
            {
                healthColor = Color.Red;
            }

            // Draw the health bar
            Globals.BoxTexture.Draw(_spriteBatch, currentHealth, 15, healthColor, new Vector2(heartPosition.X + 115, heartPosition.Y+5));


            //BULLETS
            var bulletPosition = Globals.RectangleImage.Draw(_spriteBatch, Textures.Bullet.frames, 30f, 30f, 30, 60);
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
            Globals.FontTexture.Draw(_spriteBatch, "Ammo : " + currentBullets, new Vector2(bulletPosition.X + 35, bulletPosition.Y+5), Color.WhiteSmoke, false, 1.5f);



            //SKULLS
            var skullPosition = Globals.RectangleImage.Draw(_spriteBatch, Textures.Skull.frames, 30f, 30f, _viewport.Width - 300, 30);
            Globals.FontTexture.Draw(_spriteBatch, "Kills : " + Zombies.Respawn.TotalKills().ToString("N0"), new Vector2(skullPosition.X + 35, skullPosition.Y), Color.WhiteSmoke, false, 1.5f);

            //PLAYTIME
            Globals.FontTexture.Draw(_spriteBatch, playTimeText, new Vector2(skullPosition.X + 35, skullPosition.Y+35), Color.WhiteSmoke, false, 1.5f);
        }

    }
}