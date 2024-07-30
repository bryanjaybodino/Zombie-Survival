using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival.Helicopter
{
    public class Sprite
    {
        private Texture2D[] _frames;
        private int _currentFrame;
        private double _frameTime;
        private double _elapsedTime;
        private float _rotation;
        private float _scale;
        private Vector2 _imagePosition;
        private Rectangle _rectangle;
        public Sprite(Viewport viewport)
        {
            _imagePosition = new Vector2(0, 0); // Set initial position of the image
            _currentFrame = 0;
            _frameTime = 100; // Time per frame in milliseconds
            _frames = Textures.HealthKit.frames;
            _rotation = 0f;
            _scale = .1f;
        }

        public void Update(GameTime gameTime)
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


            if (UI_Elements.Sprite.isSupplyArrive == true)
            {
                var CharacterRectangle = Globals.Debugger.BoundingBox(Characters.Textures.Rifle.frames[0], Characters.Movements.Position, new Vector2(0.3f, 0.3f), 0.5f);
                if (_rectangle.Intersects(CharacterRectangle))
                {
                    UI_Elements.Sprite.SupplyReceived();
                    if(UI_Elements.Sprite.DropType.Medic == UI_Elements.Sprite.dropType)
                    {
                        Characters.Movements.ResetHealth();
                    }
                    else
                    {
                        Characters.Sprite.RifleMagazine.ResetAmmo();
                        Characters.Sprite.ShotgunMagazine.ResetAmmo();
                        Characters.Sprite.PistolMagazine.ResetAmmo();
                    }
                }

            }

        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            if (UI_Elements.Sprite.isSupplyArrive == true)
            {
                if (UI_Elements.Sprite.DropType.Medic == UI_Elements.Sprite.dropType)
                {
                    _rectangle = Globals.RectangleImage.Draw(_spriteBatch, Helicopter.Textures.HealthKit.frames, 50f, 50f, UI_Elements.Sprite.supX, UI_Elements.Sprite.supY, false);
                }
                else
                {
                    _rectangle = Globals.RectangleImage.Draw(_spriteBatch, Helicopter.Textures.BulletKit.frames, 50f, 50f, UI_Elements.Sprite.supX, UI_Elements.Sprite.supY, false);
                }    
            }
        }
    }
}
