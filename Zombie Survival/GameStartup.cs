using Microsoft.Xna.Framework;
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

            for (int i = 0; i < 6; i++)
            {
                Zombies.Respawn.Start(_zombies);
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

            _maps.Update(gameTime);


            _characters.Update(gameTime, _zombies);

            for (int i = 0; i < _zombies.Count; i++)
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
