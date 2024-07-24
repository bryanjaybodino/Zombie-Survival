using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Zombie_Survival.Globals;
using static Zombie_Survival.Characters.Textures;

namespace Zombie_Survival.Characters
{
    public class Sprite
    {

        //PISTOL
        static Textures.Pistol pistol = new Textures.Pistol();
        static Textures.PistolAttack pistol_attack = new Textures.PistolAttack();
        static Textures.PistolReload pistol_reload = new Textures.PistolReload();

        //RIFLE
        static Textures.Rifle rifle = new Textures.Rifle();
        static Textures.RifleReload rifle_reload = new Textures.RifleReload();
        static Textures.RifleAttack rifle_attack = new Textures.RifleAttack();

        //KNIFE
        static Textures.Knife knife = new Textures.Knife();
        static Textures.KnifeAttack knife_attack = new Textures.KnifeAttack();

        //SHOTGUN
        static Textures.Shotgun shotgun = new Textures.Shotgun();
        static Textures.ShotgunReload shotgun_reload = new Textures.ShotgunReload();
        static Textures.ShotgunAttack shotgun_attack = new Textures.ShotgunAttack();



        private static Texture2D[] _frames;
        private static int _currentFrame;
        private static double _frameTime;
        private static double _elapsedTime;
        private static SpriteBatch _spriteBatch;
        private static Viewport _viewport;
        static string currentWeapone = "pistol";
        private static Texture2D _size;
        static bool isMoving = false; private enum Weapon
        {
            pistol,
            rifle,
            knife,
            shotgun
        }

        public static void LoadContent(ContentManager content, SpriteBatch spriteBatch, Viewport viewport)
        {
            _viewport = viewport;
            _spriteBatch = spriteBatch;
            _currentFrame = 0;
            _frameTime = 100; // Time per frame in milliseconds

            //RIFLE
            rifle.LoadContent(content);
            rifle_reload.LoadContent(content);
            rifle_attack.LoadContent(content);

            //PISTOL
            pistol.LoadContent(content);
            pistol_attack.LoadContent(content);
            pistol_reload.LoadContent(content);

            //KNIFE
            knife.LoadContent(content);
            knife_attack.LoadContent(content);

            //SHOTGUN
            shotgun.LoadContent(content);
            shotgun_reload.LoadContent(content);
            shotgun_attack.LoadContent(content);


            _size = knife._frames[0];
            _frames = pistol._frames;
            // Initialize position to the center of the viewport
            Movements.Position = new Vector2(_viewport.Width / 2, _viewport.Height / 2);
        }



        public static void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            ////////////////CHANGE WEAPON//////////////////////////////////
            if (keyboardState.IsKeyDown(Keys.D1) && !isMoving) // 1 = RIFLE
            {
                _currentFrame = 0;
                currentWeapone = Weapon.rifle.ToString();
                _frames = rifle._frames;
            }
            else if (keyboardState.IsKeyDown(Keys.D2) && !isMoving) // 2 = PISTOL
            {
                _currentFrame = 0;
                currentWeapone = Weapon.pistol.ToString();
                _frames = pistol._frames;
            }
            else if (keyboardState.IsKeyDown(Keys.D3) && !isMoving) // 3 = KNIFE
            {
                _currentFrame = 0;
                currentWeapone = Weapon.knife.ToString();
                _frames = knife._frames;
            }
            else if (keyboardState.IsKeyDown(Keys.D4) && !isMoving) // 4 = SHOTGUN
            {
                _currentFrame = 0;
                currentWeapone = Weapon.shotgun.ToString();
                _frames = shotgun._frames;
            }






            //////////////////////RELOAD/////////////////////////////////////
            else if (keyboardState.IsKeyDown(Keys.R) && !isMoving) // RELOAD
            {
                isMoving = true;
                _currentFrame = 0;

                if (currentWeapone.ToLower() == Weapon.rifle.ToString())
                {
                    _frames = rifle_reload._frames;
                }
                else if (currentWeapone.ToLower() == Weapon.pistol.ToString())
                {
                    _frames = pistol_reload._frames;
                }
                else if (currentWeapone.ToLower() == Weapon.shotgun.ToString())
                {
                    _frames = shotgun_reload._frames;
                }

            }



            ////////////////////ATTACK//////////////////////////////////////
            else if (keyboardState.IsKeyDown(Keys.Enter) && !isMoving) // ATTACK
            {
                isMoving = true;
                _currentFrame = 0;

                if (currentWeapone.ToLower() == Weapon.rifle.ToString())
                {
                    _frames = rifle_attack._frames;
                }
                else if (currentWeapone.ToLower() == Weapon.pistol.ToString())
                {
                    _frames = pistol_attack._frames;
                }
                else if (currentWeapone.ToLower() == Weapon.knife.ToString())
                {
                    _frames = knife_attack._frames;
                }
                else if (currentWeapone.ToLower() == Weapon.shotgun.ToString())
                {
                    _frames = shotgun_attack._frames;
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
                    if (currentWeapone.ToLower() == Weapon.rifle.ToString())
                    {
                        _frames = rifle._frames;
                    }
                    else if (currentWeapone.ToLower() == Weapon.pistol.ToString())
                    {
                        _frames = pistol._frames;
                    }
                    else if (currentWeapone.ToLower() == Weapon.knife.ToString())
                    {
                        _frames = knife._frames;
                    }
                    else if (currentWeapone.ToLower() == Weapon.shotgun.ToString())
                    {
                        _frames = shotgun._frames;
                    }
                }
            }

            Movements.Update(gameTime, _size);

            var gameArea = new Rectangle(0, 0, Maps.Sprite._frames[0].Width, Maps.Sprite._frames[0].Height);
            Camera.Update(gameArea, Movements.Position, _viewport);
        }

        public static void Draw()
        {
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
