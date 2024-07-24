using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival.Maps
{
    public class Sprite
    {
        public static Texture2D[] _frames;
        private static int _currentFrame;
        private static double _frameTime;
        private static double _elapsedTime;
        private static Vector2 _imagePosition;

        private static SpriteBatch _spriteBatch;
        public static void LoadContent(ContentManager content, SpriteBatch spriteBatch, Viewport viewport)
        {
            _spriteBatch = spriteBatch;
            _imagePosition = new Vector2(0, 0); // Set initial position of the image
            _currentFrame = 0;
            _frameTime = 100; // Time per frame in milliseconds

            // Load each frame of the GIF
            _frames = new Texture2D[]
            {
                content.Load<Texture2D>("Maps/Covid19"),
                // Add more frames as needed
            }; 
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
        }
        public static void Draw()
        {
            _spriteBatch.Draw(_frames[_currentFrame], _imagePosition, Color.White);
        }
    }
}
