using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival.Weapons
{
    public class Sprite
    {

        private UI_Elements.Sprite ui_elements;


        private Texture2D[] _frames;
        private int _currentFrame;
        private double _frameTime;
        private double _elapsedTime;
        private Viewport _viewport;
        private string _currentWeapon;

        public Sprite(Viewport viewport)
        {
            _currentFrame = 0;
            _frameTime = 100; // Time per frame in milliseconds
            _viewport = viewport;
            ui_elements = new UI_Elements.Sprite(viewport);
        }

        public void Update(GameTime gameTime, string currentWeapon)
        {
            _currentWeapon = currentWeapon;
            // Update animation frame
            _elapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (_elapsedTime >= _frameTime)
            {
                _elapsedTime -= _frameTime;
                _currentFrame++;
                if (_currentFrame >= _frames.Length)
                {
                    _currentFrame = 0; // Loop back to the first frame
                }
            }

            if (currentWeapon == "knife")
            {
                _frames = Textures.Knife.frames;
            }
            else if (currentWeapon == "rifle")
            {
                _frames = Textures.Rifle.frames;
            }
            else if (currentWeapon == "pistol")
            {
                _frames = Textures.Pistol.frames;
            }
            else if (currentWeapon == "shotgun")
            {
                _frames = Textures.Shotgun.frames;
            }

            ui_elements.Update(gameTime);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            if (_frames != null)
            {

                ///THIS CODE IS FOR POSITION OF WEAPON ON THE SCREEN
                var frameHeight = _frames[_currentFrame].Height;
                var frameWidth = _frames[_currentFrame].Width;
                var x = Globals.Camera.cameraPosition.X + 50;
                var y = (Globals.Camera.cameraPosition.Y + (_viewport.Height - (frameHeight / 2))) - 10;
                Vector2 CurrentWeaponPosition = new Vector2(x, y);



                Globals.CircleTexture.Draw(_spriteBatch, 60, Color.Gray * 0.8f, CurrentWeaponPosition);
                Vector2 CurrentWeaponPosition1 = new Vector2(x + 5, y + 5);
                Globals.CircleTexture.Draw(_spriteBatch, 55, Color.LightGray, CurrentWeaponPosition1);




                Vector2 origin = new Vector2(frameWidth / 2, frameHeight / 2);
                _spriteBatch.Draw(
                    _frames[_currentFrame],
                    new Vector2(CurrentWeaponPosition.X + 70, CurrentWeaponPosition.Y + 60),
                    null,
                    Color.White,
                    0f,
                    origin, // Use the center of the frame as the origin
                    0.5f,
                    SpriteEffects.None,
                    0f
                );




                //WHITE LONG BOX
                Vector2 WhiteBoxPosition = new Vector2(x + (frameWidth / 2), y + 40);
                Globals.BoxTexture.Draw(_spriteBatch, (65 * 4) + 5, 70, Color.Gray * 0.8f, WhiteBoxPosition);


                for (int i = 1; i <= 4; i++)
                {
                    int padding = 5;

                    int WeaponBoxWidth = 60;
                    int WeaponBoxHeight = 60;

                    // Calculate the X position dynamically based on the index i
                    var WeaponBoxX = x + padding + (i - 1) * (WeaponBoxWidth + padding);
                    var WeaponBoxY = y + 40 + padding;

                    Vector2 WeaponBoxPosition = new Vector2((frameWidth / 2) + WeaponBoxX, WeaponBoxY);
                    Globals.BoxTexture.Draw(_spriteBatch, WeaponBoxWidth, WeaponBoxHeight, Color.White, WeaponBoxPosition);



                    var weaponX = WeaponBoxPosition.X + 5;
                    var weaponY = WeaponBoxPosition.Y + 2;
                    if (i == 1) // RIFLE
                    {
                        _spriteBatch.Draw(Textures.Rifle.frames[0], new Rectangle((int)weaponX, (int)weaponY, 60, 60), Color.White);
                        Globals.FontTexture.Draw(_spriteBatch, "1", new Vector2(weaponX, weaponY), Color.Black, true);
                    }
                    else if (i == 2)//PISTOL
                    {
                        _spriteBatch.Draw(Textures.Pistol.frames[0], new Rectangle((int)weaponX, (int)weaponY, 60, 60), Color.White);
                        Globals.FontTexture.Draw(_spriteBatch, "2", new Vector2(weaponX, weaponY), Color.Black, true);
                    }
                    else if (i == 3)//KNIFE
                    {
                        _spriteBatch.Draw(Textures.Knife.frames[0], new Rectangle((int)weaponX, (int)weaponY, 60, 60), Color.White);
                        Globals.FontTexture.Draw(_spriteBatch, "3", new Vector2(weaponX, weaponY), Color.Black, true);
                    }
                    else if (i == 4)//SHOTGUN
                    {
                        _spriteBatch.Draw(Textures.Shotgun.frames[0], new Rectangle((int)weaponX, (int)weaponY, 60, 60), Color.White);
                        Globals.FontTexture.Draw(_spriteBatch, "4", new Vector2(weaponX, weaponY), Color.Black, true);
                    }
                }








                ///OTHER UI ELEMENTS 


                ui_elements.Draw(_spriteBatch, _currentWeapon);
            }

        }
    }
}
