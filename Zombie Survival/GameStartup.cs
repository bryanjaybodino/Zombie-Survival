﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Zombie_Survival.Globals;


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


        private Characters.Sprite _characters;
        private Maps.Sprite _maps;
        private List<Zombies.Sprite> _zombies = new List<Zombies.Sprite>();
        private Crosshairs.Sprite _crosshairs;
        protected override void Initialize()
        {
            base.Initialize();

            _characters = new Characters.Sprite(GraphicsDevice.Viewport);
            _maps = new Maps.Sprite(GraphicsDevice.Viewport);

            _crosshairs = new Crosshairs.Sprite(GraphicsDevice.Viewport);





            // Example: Create 10 sprites and position them in a grid
            int rows = 2;
            int columns = 2;
            int spacing = 100; // Adjust spacing as needed

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Vector2 position = new Vector2(j * spacing, i * spacing);
                    _zombies.Add(new Zombies.Sprite(GraphicsDevice.Viewport, position));
                }
            }


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

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);

            _maps.Update(gameTime);
            _characters.Update(gameTime);
           


            for(int i = 0; i < _zombies.Count; i++)
            {
                _zombies[i].Update(gameTime, _zombies);
            }


            _crosshairs.Update(gameTime);



            // PARA ACCURATE PARIN YUNG MOUSE POSITION
            Globals.MouseInput.Update(Camera.Transform);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, Camera.Transform); // para soft lang yung lakad ng character pag sunod sa camera

            //MAP
            _maps.Draw(_spriteBatch);


            //CHARACTER
            _characters.Draw(_spriteBatch);


            //ZOMBIE

            for (int i = 0; i < _zombies.Count; i++)
            {
                _zombies[i].Draw(_spriteBatch);
            }


           

            //CROSSHAIR
            _crosshairs.Draw(_spriteBatch);


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
