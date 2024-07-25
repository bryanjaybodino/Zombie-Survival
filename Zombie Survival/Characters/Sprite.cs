using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Zombie_Survival.Globals;
using static Zombie_Survival.Characters.Textures;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Zombie_Survival.Characters
{
    public class Sprite
    {




        Bullets.Shoot shoot = new Bullets.Shoot();



        private Texture2D[] _frames;
        private int _currentFrame;
        private double _frameTime;
        private double _elapsedTime;
        private Viewport _viewport;
        private string currentWeapon = "knife";
        private Texture2D _size;
        private bool isMoving = false; private enum Weapon
        {
            pistol,
            rifle,
            knife,
            shotgun
        }


        public Sprite(Viewport viewport)
        {
            _viewport = viewport;
            _currentFrame = 0;
            _frameTime = 50; // Time per frame in milliseconds
            _frames = Knife.frames;
            _size = Knife.frames[0];


            // Initialize position to the center of the viewport
            Movements.Position = new Vector2(_viewport.Width / 2, _viewport.Height / 2);
        }

        public void Update(GameTime gameTime)
        {

            KeyboardState keyboardState = Keyboard.GetState();
            ////////////////CHANGE WEAPON//////////////////////////////////
            if (keyboardState.IsKeyDown(Keys.D1) && !isMoving) // 1 = RIFLE
            {
                _currentFrame = 0;
                currentWeapon = Weapon.rifle.ToString();
                _frames = Rifle.frames;
            }
            else if (keyboardState.IsKeyDown(Keys.D2) && !isMoving) // 2 = PISTOL
            {
                _currentFrame = 0;
                currentWeapon = Weapon.pistol.ToString();
                _frames = Pistol.frames;
            }
            else if (keyboardState.IsKeyDown(Keys.D3) && !isMoving) // 3 = KNIFE
            {
                _currentFrame = 0;
                currentWeapon = Weapon.knife.ToString();
                _frames = Knife.frames;
            }
            else if (keyboardState.IsKeyDown(Keys.D4) && !isMoving) // 4 = SHOTGUN
            {
                _currentFrame = 0;
                currentWeapon = Weapon.shotgun.ToString();
                _frames = Shotgun.frames;
            }






            //////////////////////RELOAD/////////////////////////////////////
            else if (keyboardState.IsKeyDown(Keys.R) && !isMoving) // RELOAD
            {
                isMoving = true;
                _currentFrame = 0;

                if (currentWeapon.ToLower() == Weapon.rifle.ToString())
                {
                    _frames = RifleReload.frames;
                }
                else if (currentWeapon.ToLower() == Weapon.pistol.ToString())
                {
                    _frames = PistolReload.frames;
                }
                else if (currentWeapon.ToLower() == Weapon.shotgun.ToString())
                {
                    _frames = ShotgunReload.frames;
                }

            }




            ////////////////////ATTACK//////////////////////////////////////
            else if (keyboardState.IsKeyDown(Keys.Enter) && !isMoving) // ATTACK
            {
                isMoving = true;
                _currentFrame = 0;

                if (currentWeapon.ToLower() == Weapon.rifle.ToString())
                {
                    _frames = RifleAttack.frames;
                }
                else if (currentWeapon.ToLower() == Weapon.pistol.ToString())
                {
                    _frames = PistolAttack.frames;
                    shoot.Attack();
                }
                else if (currentWeapon.ToLower() == Weapon.knife.ToString())
                {
                    _frames = KnifeAttack.frames;
                }
                else if (currentWeapon.ToLower() == Weapon.shotgun.ToString())
                {
                    _frames = ShotgunAttack.frames;
                }
            }


            // Update animation frame
            _elapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (_elapsedTime >= _frameTime)
            {
                _elapsedTime -= _frameTime;
                _currentFrame++;
                if (_currentFrame >= _frames.Length)
                {
                    isMoving = false;
                    _currentFrame = 0; // Loop back to the first frame

                    /// RESET FRAME IN THE CURRENT WEAPON
                    if (currentWeapon.ToLower() == Weapon.rifle.ToString())
                    {
                        _frames = Rifle.frames;
                    }
                    else if (currentWeapon.ToLower() == Weapon.pistol.ToString())
                    {
                        _frames = Pistol.frames;

                    }
                    else if (currentWeapon.ToLower() == Weapon.knife.ToString())
                    {
                        _frames = Knife.frames;
                    }
                    else if (currentWeapon.ToLower() == Weapon.shotgun.ToString())
                    {
                        _frames = Shotgun.frames;
                    }
                }
            }

            Movements.Update(gameTime, _size);
            var gameArea = new Rectangle(0, 0, Maps.Textures.Covid19.frames[0].Width, Maps.Textures.Covid19.frames[0].Height);
            Camera.Update(gameArea, Movements.Position, _viewport);
            shoot.Update(gameTime);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {

            shoot.Draw(_spriteBatch);
            // Draw the current frame with rotation
            _spriteBatch.Draw(
                _frames[_currentFrame],
                Movements.Position,
                null,
                Color.White,
                Movements.Rotation, // Rotation angle
                new Vector2(_size.Width / 2, _size.Height / 2), // Origin set to center
                .5f, // Scale
                SpriteEffects.None,
                0f
            );

     


        }
    }
}
