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
        static Textures.pistol pistol = new Textures.pistol();
        static Textures.pistol_attack pistol_attack = new Textures.pistol_attack();


        private static Texture2D[] _frames;
        private static int _currentFrame;
        private static double _frameTime;
        private static double _elapsedTime;
        private static SpriteBatch _spriteBatch;
        private static Viewport _viewport;

        public static void LoadContent(ContentManager content, SpriteBatch spriteBatch, Viewport viewport)
        {
            _viewport = viewport;
            _spriteBatch = spriteBatch;
            _currentFrame = 0;
            _frameTime = 100; // Time per frame in milliseconds

            pistol.LoadContent(content);
            pistol_attack.LoadContent(content);

            _frames = pistol._frames;
            // Initialize position to the center of the viewport
            Movements.Position = new Vector2(_viewport.Width / 2, _viewport.Height / 2);
        }

        private enum Weapon
        {
            pistol,
            rifle,
            knife
        }
        static string currentWeapone = "pistol";
        static bool isAttacking = false;
        public static void Update(GameTime gameTime)
        {


            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Enter) && !isAttacking)
            {
                isAttacking = true;
                _currentFrame = 0;
                _frames = pistol_attack._frames;
            }



            // Update animation frame
            _elapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (_elapsedTime >= _frameTime)
            {
                _elapsedTime -= _frameTime;
                _currentFrame++;
                if (_currentFrame >= _frames.Length)
                {
                    _currentFrame = 0; // Loop back to the first frame
                    if (currentWeapone.ToLower() == Weapon.pistol.ToString())
                    {
                        _frames = pistol._frames;
                    } 
                }
            }
            if (keyboardState.IsKeyUp(Keys.Enter))
            {
                isAttacking = false;
            }

            Movements.Update(gameTime, _frames[_currentFrame]);

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
                new Vector2(_frames[_currentFrame].Width / 2, _frames[_currentFrame].Height / 2), // Origin set to center
                .5f, // Scale
                SpriteEffects.None,
                0f
            );
        }
    }
}
