using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;

namespace Zombie_Survival.Zombies
{
    public class Sprite
    {
        private Texture2D[] _frames { get; set; }
        private int _currentFrame;
        private double _frameTime;
        private double _elapsedTime;
        private Vector2 _scale;
        private float _movementSpeed = 150f; // Initialize movement speed (pixels per second)
        private float _minDistance = 100f; // Minimum distance to maintain from other sprites

        public Vector2 Position { get;  set; }
        public float Rotation { get; private set; } = 0f;
        public int ZombieHealth { get; set; } = 100;
        public int ZombieDamage { get; set; } = 5;
        public bool isReceivedDamage { get; set; } = false;

        private int MaxHealth ;
        public Rectangle BoundingBox
        {
            get
            {

                return Globals.Debugger.BoundingBox(Textures.Macho.frames[0], Position, _scale, 0.5f);
            }
        }


        public Sprite(Vector2 position)
        {
            Position = position;
            _currentFrame = 0;
            _frameTime = 50; // Time per frame in milliseconds
            _scale = new Vector2(.5f, .5f); // Initialize scale to 0.5     

            MaxHealth = ZombieHealth;
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
                if (_currentFrame == (_frames.Length / 2))/// Middle of the Frame Sound Triggered
                {
                    Sounds.SoundEffects.Zombie.Attack.audio.Play();
                    Characters.Movements.HealhtBar -= ZombieDamage;
                }
            }
        }


        private bool FollowCharacter(GameTime gameTime)
        {
            Vector2 characterPosition = Characters.Movements.Position;
            Vector2 direction = characterPosition - Position;
            float distance = direction.Length();

            direction.Normalize(); // Get the direction as a unit vector
            Position += direction * _movementSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Calculate rotation angle
            Rotation = (float)Math.Atan2(direction.Y, direction.X);

            if (distance > (_minDistance - 20f))
            { 
                _frameTime = 50;
                return true; // IF FOLLOWING
            }
            else
            {
                _frameTime = 80;
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
                if(_frames != null)
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



                    ////
                    if (isReceivedDamage)
                    {
                        Rectangle HealthBar = new Rectangle((int)Position.X, (int)Position.Y, 20, ZombieHealth);
                        Rectangle MaxHealthBar = new Rectangle((int)Position.X, (int)Position.Y, 20, MaxHealth);
                        Texture2D whiteTexture = new Texture2D(_spriteBatch.GraphicsDevice, 1, 1);
                        whiteTexture.SetData(new[] { Color.White });
                        origin = new Vector2(HealthBar.Width / 2, HealthBar.Height / 2);

                        Color HealthBarColor = Color.White;
                        if (ZombieHealth >= 80)
                        {
                            HealthBarColor = Color.LimeGreen;
                        }
                        else if (ZombieHealth >= 50 && ZombieHealth < 80)
                        {
                            HealthBarColor = Color.Orange;
                        }
                        else
                        {
                            HealthBarColor = Color.Red;
                        }

                        // Use the center of the frame as the origin
                        _spriteBatch.Draw(whiteTexture, Position, MaxHealthBar, Color.Black, Rotation, origin, _scale, SpriteEffects.None, 0f);
                        _spriteBatch.Draw(whiteTexture, Position, HealthBar, HealthBarColor, Rotation, origin, _scale, SpriteEffects.None, 0f);





                    }
                }
               

                // Draw the bounding box for debugging
                //Globals.Debugger.Draw(_spriteBatch, BoundingBox);
            }
            catch { }
        }
    }
}
