using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Zombie_Survival.Globals;
using static Zombie_Survival.Characters.Textures;
using static Zombie_Survival.Knife_Slash.Textures;

namespace Zombie_Survival.Characters
{
    public class Sprite
    {
        Bullets.Shoot shoot = new Bullets.Shoot();
        public Knife_Slash.Sprite _slash;

        private Texture2D[] _frames;
        private int _currentFrame;
        private double _frameTime;
        private double _elapsedTime;
        private Viewport _viewport;
        private string currentWeapon = "knife";
        private Texture2D _size;
        private bool isMoving = false;

        public Rectangle BoundingBox
        {
            get
            {
                return Globals.Debugger.BoundingBox(_size, Movements.Position, new Vector2(0.5f, 0.6f), 0.5f);
            }
        }
        private enum Weapon
        {
            pistol,
            rifle,
            knife,
            shotgun
        }

        // Cooldown related variables
        private double _firePistolCooldown = 400; // Cooldown time in milliseconds
        private double _fireShotgunCooldown = 1800; // Cooldown time in milliseconds
        private double _fireRifleCooldown = 300; // Cooldown time in milliseconds
        private double _fireKnifeCooldown = 1200; // Cooldown time in milliseconds
        private double _lastFireTime = 0;
        public Sprite(Viewport viewport)
        {

            _slash = new Knife_Slash.Sprite(viewport);
            _viewport = viewport;
            _currentFrame = 0;
            _frameTime = 50; // Time per frame in milliseconds
            _frames = Knife.frames;
            _size = Knife.frames[0];

            // Initialize position to the center of the viewport
            Movements.Position = new Vector2(_viewport.Width / 2, _viewport.Height / 2);
        }

        public void Update(GameTime gameTime, List<Zombies.Sprite> zombies)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();

            // Update the cooldown timer
            _lastFireTime += gameTime.ElapsedGameTime.TotalMilliseconds;

            // Change weapon logic
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

            // Reload logic
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

            // Attack logic with cooldown check
            else if (mouseState.LeftButton == ButtonState.Pressed && !isMoving) // ATTACK
            {
                _currentFrame = 0;
                _elapsedTime = 0;

                if (currentWeapon.ToLower() == Weapon.rifle.ToString() && _lastFireTime >= _fireRifleCooldown)
                {
                    _lastFireTime = 0;
                    isMoving = true;
                    _frames = RifleAttack.frames;
                    shoot.Attack(Bullets.Textures.Bullets.Rifle.frames);
                    Sounds.SoundEffects.RifleAttack.audio.Play();
                }
                else if (currentWeapon.ToLower() == Weapon.pistol.ToString() && _lastFireTime >= _firePistolCooldown)
                {
                    _lastFireTime = 0;
                    isMoving = true;
                    _frames = PistolAttack.frames;
                    shoot.Attack(Bullets.Textures.Bullets.Pistol.frames);
                    Sounds.SoundEffects.PistolAttack.audio.Play();
                }
                else if (currentWeapon.ToLower() == Weapon.shotgun.ToString() && _lastFireTime >= _fireShotgunCooldown)
                {
                    _lastFireTime = 0;
                    isMoving = true;
                    _frames = ShotgunAttack.frames;
                    shoot.Attack(Bullets.Textures.Bullets.Shotgun.frames);
                    Sounds.SoundEffects.ShotgunAttack.audio.Play();
                }
                else if (currentWeapon.ToLower() == Weapon.knife.ToString())
                {
                    _lastFireTime = 0;
                    isMoving = true;
                    _frames = KnifeAttack.frames;
                    _slash.Attack();
                    Sounds.SoundEffects.KnifeAttack.audio.Play();

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
                    _currentFrame = 0; // Loop back to the first frame

                    // Reset frame to the current weapon's idle frame
                    if (currentWeapon.ToLower() == Weapon.rifle.ToString())
                    {
                        isMoving = false;
                        _frames = Rifle.frames;
                    }
                    else if (currentWeapon.ToLower() == Weapon.pistol.ToString())
                    {
                        isMoving = false;
                        _frames = Pistol.frames;
                    }
                    else if (currentWeapon.ToLower() == Weapon.knife.ToString())
                    {
                        _frames = Knife.frames;
                        isMoving = false;
                        _slash.Hide(); ;
                    }
                    else if (currentWeapon.ToLower() == Weapon.shotgun.ToString())
                    {
                        _frames = Shotgun.frames;
                        isMoving = false;
                    }
                }
            }
            _slash.Update(gameTime, zombies);
            Movements.Update(gameTime, _size, Camera.Transform);
            AvoidOverlapping(zombies);
            var gameArea = new Rectangle(0, 0, Maps.Textures.Covid19.frames[0].Width, Maps.Textures.Covid19.frames[0].Height);
            Camera.Update(gameArea, Movements.Position, _viewport);
            shoot.Update(gameTime, zombies);
        }
        private void AvoidOverlapping(List<Zombies.Sprite> zombies)
        {
            foreach (var sprite in zombies)
            {
                float distance = Vector2.Distance(Movements.Position, sprite.Position);
                if (distance < 50f)
                {
                    // Move away to avoid overlapping
                    Vector2 moveAway = Movements.Position - sprite.Position;
                    moveAway.Normalize();
                    Movements.Position += moveAway * (50f - distance);
                }
            }
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _slash.Draw(_spriteBatch);
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

            // Draw the bounding box for debugging
            //Globals.Debugger.Draw(_spriteBatch, BoundingBox);



        }
    }
}
