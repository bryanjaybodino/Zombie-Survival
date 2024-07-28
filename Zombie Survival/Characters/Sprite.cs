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



        //THIS IS FOR CURRENT AMMO
        Bullets.Magazines.Rifle RifleMagazine = new Bullets.Magazines.Rifle();
        Bullets.Magazines.Pistol PistolMagazine = new Bullets.Magazines.Pistol();
        Bullets.Magazines.Shotgun ShotgunMagazine = new Bullets.Magazines.Shotgun();

        //DISPLAY CURRENT WEAPON
        Weapons.Sprite _weapon;

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
        private double _fireRifleCooldown = 100; // Cooldown time in milliseconds
        private double _lastFireTime = 0;
        public Sprite(Viewport viewport)
        {
            _weapon = new Weapons.Sprite(viewport);
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
            if (keyboardState.IsKeyDown(Keys.D1) && !isMoving && currentWeapon != Weapon.rifle.ToString()) // 1 = RIFLE
            {
                _lastFireTime = 100000; // PARA MAKA BARIL AGAD KAPAG NAKAPAG SWITCH WEAPON
                _currentFrame = 0;
                currentWeapon = Weapon.rifle.ToString();
                _frames = Rifle.frames;
            }
            else if (keyboardState.IsKeyDown(Keys.D2) && !isMoving && currentWeapon != Weapon.pistol.ToString()) // 2 = PISTOL
            {
                _lastFireTime = 100000;// PARA MAKA BARIL AGAD KAPAG NAKAPAG SWITCH WEAPON
                _currentFrame = 0;
                currentWeapon = Weapon.pistol.ToString();
                _frames = Pistol.frames;
            }
            else if (keyboardState.IsKeyDown(Keys.D3) && !isMoving && currentWeapon != Weapon.knife.ToString()) // 3 = KNIFE
            {
                _lastFireTime = 100000; // PARA MAKA BARIL AGAD KAPAG NAKAPAG SWITCH WEAPON
                _currentFrame = 0;
                currentWeapon = Weapon.knife.ToString();
                _frames = Knife.frames;
            }
            else if (keyboardState.IsKeyDown(Keys.D4) && !isMoving && currentWeapon != Weapon.shotgun.ToString()) // 4 = SHOTGUN
            {
                _lastFireTime = 100000;// PARA MAKA BARIL AGAD KAPAG NAKAPAG SWITCH WEAPON
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
                    _frames = RifleMagazine.Reload(currentWeapon.ToLower());
                }
                else if (currentWeapon.ToLower() == Weapon.pistol.ToString())
                {
                    _frames = PistolMagazine.Reload(currentWeapon.ToLower());

                }
                else if (currentWeapon.ToLower() == Weapon.shotgun.ToString())
                {
                    _frames = ShotgunMagazine.Reload(currentWeapon.ToLower());
                }
            }

            // Attack logic with cooldown check
            else if (mouseState.LeftButton == ButtonState.Pressed && !isMoving) // ATTACK
            {
                _currentFrame = 0;
                _elapsedTime = 0;

                if (currentWeapon.ToLower() == Weapon.rifle.ToString() && _lastFireTime >= _fireRifleCooldown)
                {
                    if (RifleMagazine.CurrentBullets > 0)
                    {
                        _lastFireTime = 0;
                        isMoving = true;
                        _frames = RifleAttack.frames;
                        shoot.Attack(Bullets.Textures.Bullets.Rifle.frames, RifleMagazine.Damage);
                        Sounds.SoundEffects.Rifle.Attack.audio.Play();

                        /// MINUS 1 BULLET
                        RifleMagazine.Shoot();
                    }
                }
                else if (currentWeapon.ToLower() == Weapon.pistol.ToString() && _lastFireTime >= _firePistolCooldown)
                {
                    if (PistolMagazine.CurrentBullets > 0)
                    {
                        _lastFireTime = 0;
                        isMoving = true;
                        _frames = PistolAttack.frames;
                        shoot.Attack(Bullets.Textures.Bullets.Pistol.frames, PistolMagazine.Damage);
                        Sounds.SoundEffects.Pistol.Attack.audio.Play();

                        /// MINUS 1 BULLET
                        PistolMagazine.Shoot();
                    }
                }
                else if (currentWeapon.ToLower() == Weapon.shotgun.ToString() && _lastFireTime >= _fireShotgunCooldown)
                {
                    if (ShotgunMagazine.CurrentBullets > 0)
                    {
                        _lastFireTime = 0;
                        isMoving = true;
                        _frames = ShotgunAttack.frames;
                        shoot.Attack(Bullets.Textures.Bullets.Shotgun.frames, ShotgunMagazine.Damage);
                        Sounds.SoundEffects.Shotgun.Attack.audio.Play();

                        /// MINUS 1 BULLET
                        ShotgunMagazine.Shoot();
                    }

                }
                else if (currentWeapon.ToLower() == Weapon.knife.ToString())
                {
                    _lastFireTime = 0;
                    isMoving = true;
                    _frames = KnifeAttack.frames;
                    _slash.Attack();
                    Sounds.SoundEffects.Knife.Attack.audio.Play();

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

            _weapon.Update(gameTime, currentWeapon);
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

            _weapon.Draw(_spriteBatch);
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
