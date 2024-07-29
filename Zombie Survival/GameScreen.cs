using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zombie_Survival.Globals;
using static Zombie_Survival.UI_Elements.Textures;
using static Zombie_Survival.UI_Elements.Textures.GameOver;

namespace Zombie_Survival
{
    public class GameScreen
    {
        public class GameOver
        {
            Viewport _viewport;
            private Rectangle _playAgain;
            private Rectangle _back;
            private Rectangle _mouseCursor;

            public GameOver(Viewport viewport)
            {
                _viewport = viewport;
            }
            public bool status
            {
                get
                {
                    if (Characters.Movements.HealhtBar <= 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            public void Draw(SpriteBatch _spriteBatch)
            {
                var viewPortH = _viewport.Height;
                var viewPortW = _viewport.Width;

                var centerHViewport = _viewport.Height / 2;
                var centerWViewport = _viewport.Width / 2;
                Globals.RectangleImage.Draw(_spriteBatch, UI_Elements.Textures.GameOver.Screen.frames, viewPortW, viewPortH, centerWViewport, centerHViewport);


                var playAgainWidth = UI_Elements.Textures.GameOver.PlayAgain.frames[0].Width;
                var playAgainHeight = UI_Elements.Textures.GameOver.PlayAgain.frames[0].Height;
                _playAgain = Globals.RectangleImage.Draw(_spriteBatch, UI_Elements.Textures.GameOver.PlayAgain.frames, playAgainWidth, playAgainHeight, centerWViewport, centerHViewport + 200);


                var backWidth = UI_Elements.Textures.GameOver.Back.frames[0].Width;
                var backHeight = UI_Elements.Textures.GameOver.Back.frames[0].Height;
                _back = Globals.RectangleImage.Draw(_spriteBatch, UI_Elements.Textures.GameOver.Back.frames, backWidth, backHeight, centerWViewport, centerHViewport + 250);


                var cursorWidth = UI_Elements.Textures.MouseCursor.frames[0].Width;
                var cursorHeight = UI_Elements.Textures.MouseCursor.frames[0].Height;



                //MOUSE COURSOR
                _mouseCursor = new Rectangle((int)Globals.MouseInput.transformedMousePosition.X, (int)Globals.MouseInput.transformedMousePosition.Y, 10, 10);//FOR POINTER
                Globals.RectangleImage.Draw(_spriteBatch, UI_Elements.Textures.MouseCursor.frames, cursorWidth, cursorHeight, Globals.MouseInput.actualMousePosition.X+30, Globals.MouseInput.actualMousePosition.Y+30); //DESIGN ONLY
            }
            public void Update(GameTime gameTime)
            {

                var mouseInput = Mouse.GetState();
                if (_mouseCursor.Intersects(_playAgain))
                {

                    if (mouseInput.LeftButton == ButtonState.Pressed)
                    {
                        Characters.Movements.HealhtBar = 200;
                    }

                }
                else if (_mouseCursor.Intersects(_back))
                {

                }

            }
        }

    }
}
