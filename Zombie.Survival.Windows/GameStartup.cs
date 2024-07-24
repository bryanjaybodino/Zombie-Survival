using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Zombie.Survival.Windows.Maps;
using Zombie.Survival.Windows.Objects;
using Zombie.Survival.Windows.Objects.Maps;
using Zombie.Survival.Windows.Objects.YourCharcter;


namespace Zombie.Survival.Windows
{
    public class GameStartup : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player _defaultCharacter;
        private Covid19 _covid19;
        public static Camera _camera = new Camera();
        Message message;
        public GameStartup()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            

            // Set fullscreen mode
            //_graphics.IsFullScreen = true;

            // Optional: Set the preferred back buffer size
            //_graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //_graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            // Apply the changes to the graphics settings
            // _graphics.ApplyChanges();
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _defaultCharacter = new Player(_spriteBatch,GraphicsDevice.Viewport);
            _defaultCharacter.LoadContent(Content);

            message = new Message(_spriteBatch, _defaultCharacter);
            message.LoadContent(Content);


            _covid19 = new Covid19(_spriteBatch);
            _covid19.LoadContent(Content);
       

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
       
            _defaultCharacter.Update(gameTime);
            _covid19.Update(gameTime);

 
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

  
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, _camera.transform); // para soft lang yung lakad ng character pag sunod sa camera
            _covid19.Draw(gameTime);
            _defaultCharacter.Draw(gameTime);
            message.Draw(gameTime);



            _spriteBatch.End();
 
        }
    }
}
