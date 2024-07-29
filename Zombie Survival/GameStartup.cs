﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Zombie_Survival.Globals;
using static Zombie_Survival.GameScreen;


namespace Zombie_Survival
{
    public class GameStartup : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public GameStartup()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 800;


            // Set fullscreen mode
            //_graphics.IsFullScreen = true;
            //_graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //_graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _graphics.ApplyChanges();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }


        public static GameScreen.GameOver _gameover;
        public static GameScreen.Playing _playing;


        protected override void Initialize()
        {
            base.Initialize();
            _playing = new GameScreen.Playing(GraphicsDevice.Viewport);
            _gameover = new GameScreen.GameOver(GraphicsDevice.Viewport);


        }



        protected override void LoadContent()
        {

            //MAP
            Maps.Textures.Covid19.LoadContent(Content);


            //RIFLE
            Characters.Textures.Rifle.LoadContent(Content);
            Characters.Textures.RifleReload.LoadContent(Content);
            Characters.Textures.RifleAttack.LoadContent(Content);

            //KNIFE
            Characters.Textures.Knife.LoadContent(Content);
            Characters.Textures.KnifeAttack.LoadContent(Content);

            //KNIFE SLASH
            Knife_Slash.Textures.Slash.LoadContent(Content);

            //PISTOL
            Characters.Textures.Pistol.LoadContent(Content);
            Characters.Textures.PistolReload.LoadContent(Content);
            Characters.Textures.PistolAttack.LoadContent(Content);

            //SHOTGUN
            Characters.Textures.Shotgun.LoadContent(Content);
            Characters.Textures.ShotgunReload.LoadContent(Content);
            Characters.Textures.ShotgunAttack.LoadContent(Content);


            //BULLETS
            Bullets.Textures.Bullets.Pistol.LoadContent(Content);
            Bullets.Textures.Bullets.Rifle.LoadContent(Content);
            Bullets.Textures.Bullets.Shotgun.LoadContent(Content);

            //CROSSHAIR
            Crosshairs.Textures.Green.LoadContent(Content);

            //ZOMBIES
            Zombies.Textures.Macho.LoadContent(Content);
            Zombies.Textures.MachoAttack.LoadContent(Content);

            //BLOOD EFFECTS
            Blood_Effects.Textures.KillZombie.LoadContent(Content);


            //WEAPONS
            Weapons.Textures.Pistol.LoadContent(Content);
            Weapons.Textures.Rifle.LoadContent(Content);
            Weapons.Textures.Shotgun.LoadContent(Content);
            Weapons.Textures.Knife.LoadContent(Content);

            //OTHER UI ELEMENTS
            UI_Elements.Textures.Skull.LoadContent(Content);
            UI_Elements.Textures.Heart.LoadContent(Content);
            UI_Elements.Textures.Cash.LoadContent(Content);
            UI_Elements.Textures.Bullet.LoadContent(Content);
            UI_Elements.Textures.MouseCursor.LoadContent(Content);
            UI_Elements.Textures.GameOver.Screen.LoadContent(Content);
            UI_Elements.Textures.GameOver.Back.LoadContent(Content);
            UI_Elements.Textures.GameOver.PlayAgain.LoadContent(Content);


            //GLOBAL
            Globals.FontTexture.LoadContent(Content);


            //SOUNDS
            Sounds.SoundEffects.Rifle.Attack.LoadContent(Content);
            Sounds.SoundEffects.Pistol.Attack.LoadContent(Content);
            Sounds.SoundEffects.Shotgun.Attack.LoadContent(Content);
            Sounds.SoundEffects.Knife.Attack.LoadContent(Content);

            Sounds.SoundEffects.Rifle.Reload.LoadContent(Content);
            Sounds.SoundEffects.Pistol.Reload.LoadContent(Content);
            Sounds.SoundEffects.Shotgun.Reload.LoadContent(Content);

            Sounds.SoundEffects.Zombie.LoadContent(Content);
            Sounds.SoundEffects.Zombie.Attack.LoadContent(Content);

            Sounds.SoundEffects.Zombie.audio.Play();
        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);



            if (_gameover.status)
            {
                _gameover.Update(gameTime);
            }
            else
            {
               _playing.Update(gameTime);

            }            
            
            // PARA ACCURATE PARIN YUNG MOUSE POSITION
            Globals.MouseInput.Update(Camera.Transform);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, Camera.Transform); // para soft lang yung lakad ng character pag sunod sa camera


            if (_gameover.status)
            {
                _gameover.Draw(_spriteBatch);
            }
            else
            {

                _playing.Draw(_spriteBatch);
            }



            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
