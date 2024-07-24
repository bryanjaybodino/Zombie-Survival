using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Zombie_Survival.Globals;

namespace Zombie_Survival.Characters
{
    public class Sprite
    {
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

            // Load each frame of the GIF
            _frames = new Texture2D[]
            {
                content.Load<Texture2D>("Characters/Pistol/1"),
                content.Load<Texture2D>("Characters/Pistol/2"),
                content.Load<Texture2D>("Characters/Pistol/3"),
                content.Load<Texture2D>("Characters/Pistol/4"),
                content.Load<Texture2D>("Characters/Pistol/5"),
                content.Load<Texture2D>("Characters/Pistol/6"),
                content.Load<Texture2D>("Characters/Pistol/7"),
                content.Load<Texture2D>("Characters/Pistol/8"),
                content.Load<Texture2D>("Characters/Pistol/9"),
                content.Load<Texture2D>("Characters/Pistol/10"),
                content.Load<Texture2D>("Characters/Pistol/11"),
                // Add more frames as needed
            };

            // Initialize position to the center of the viewport
            Movements.Position = new Vector2(_viewport.Width / 2, _viewport.Height / 2);
        }

        public static void Update(GameTime gameTime)
        {
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
            Camera.Initialize(new Rectangle(0, 0, Maps.Sprite._frames[0].Width, Maps.Sprite._frames[0].Height));
            Movements.Update(gameTime, _frames[_currentFrame]);

      
            Globals.Camera.Update(Movements.Position, _viewport);
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
