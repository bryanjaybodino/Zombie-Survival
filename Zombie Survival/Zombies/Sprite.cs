﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;

namespace Zombie_Survival.Zombies
{
    public class Sprite
    {
        private Texture2D[] _frames;
        private int _currentFrame;
        private double _frameTime;
        private double _elapsedTime;
        private Vector2 _scale;
        private float _movementSpeed = 140f; // Initialize movement speed (pixels per second)
        private float _minDistance = 100f; // Minimum distance to maintain from other sprites

        public Vector2 Position { get; private set; }
        public float Rotation { get; private set; } = 0f;

        public Rectangle BoundingBox
        {
            get
            {
                float scaleFactor = 0.5f; // Adjust this factor as needed
                int width = (int)(_frames[0].Width * _scale.X * scaleFactor);
                int height = (int)(_frames[0].Height * _scale.Y * scaleFactor);
                int x = (int)(Position.X - (width / 2));
                int y = (int)(Position.Y - (height / 2));
                return new Rectangle(x, y, width, height);
            }
        }


        public Sprite(Viewport viewport, Vector2 position)
        {
            Position = position;
            _currentFrame = 0;
            _frameTime = 50; // Time per frame in milliseconds
            _scale = new Vector2(.5f, .5f); // Initialize scale to 0.5     
        }

        public void Update(GameTime gameTime, List<Sprite> sprites)
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
    

            // Follow character and avoid overlapping with other sprites
            bool isFollowing = FollowCharacter(gameTime);

            // Ensure no overlapping with other sprites
            AvoidOverlapping(sprites);

            if (isFollowing)
            {
                _frames = Textures.Macho.frames;
            }
            else // ATTACKING
            {
                _frames = Textures.MachoAttack.frames;
            }
        }

        private bool FollowCharacter(GameTime gameTime)
        {
            Vector2 characterPosition = Characters.Movements.Position;
            Vector2 direction = characterPosition - Position;
            float distance = direction.Length();

            if (distance > (_minDistance-40f))
            {
                direction.Normalize(); // Get the direction as a unit vector
                Position += direction * _movementSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                // Calculate rotation angle
                Rotation = (float)Math.Atan2(direction.Y, direction.X);
                _frameTime = 50;
                return true; // IF FOLLOWING
            }
            else
            {
                _frameTime = 100;
                return false; // ATTACK ANIMATION
            }
        }

        private void AvoidOverlapping(List<Sprite> sprites)
        {
            foreach (var sprite in sprites)
            {
                if (sprite != this)
                {
                    float distance = Vector2.Distance(Position, sprite.Position);
                    if (distance < _minDistance)
                    {
                        // Move away to avoid overlapping
                        Vector2 moveAway = Position - sprite.Position;
                        moveAway.Normalize();
                        Position += moveAway * (_minDistance - distance);
                    }
                }
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            try
            {
                if (_currentFrame >= _frames.Length)
                {
                    _currentFrame = 0;
                }


                Vector2 origin = new Vector2(_frames[_currentFrame].Width / 2, _frames[_currentFrame].Height / 2);

                _spriteBatch.Draw(
                    _frames[_currentFrame],
                    Position,
                    null,
                    Color.White,
                    Rotation,
                    origin, // Use the center of the frame as the origin
                    _scale,
                    SpriteEffects.None,
                    0f
                );



          
                // Draw the bounding box for debugging
                Rectangle boundingBox = BoundingBox;
                Texture2D whiteTexture = new Texture2D(_spriteBatch.GraphicsDevice, 1, 1);
                whiteTexture.SetData(new[] { Color.White });
                _spriteBatch.Draw(whiteTexture, boundingBox, Color.Red * 0.5f);
            }
            catch { }
        }
    }
}
