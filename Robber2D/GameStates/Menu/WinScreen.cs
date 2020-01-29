using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.OS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Robber_2D
{
    class WinScreen : GameState
    {
        private Texture2D YouWinImage;
        private int leftMarginLogo, topMarginLogo, leftMarginText, topMarginText;
        private SpriteFont spriteFont;
        private const string startMessage = "PRESS ANYWHERE TO RETURN";
        bool canReturn;

        public WinScreen(ContentManager contentManager, GraphicsDevice graphicsDevice, Game1 game) : base(contentManager, graphicsDevice, game)
        {

        }

        public override void Initialize()
        {

        }
        public override void LoadContent()
        {
            YouWinImage = contentManager.Load<Texture2D>("YouWin");
            leftMarginLogo = ((Game1.ScreenWidth - YouWinImage.Width) / 2);
            topMarginLogo = ((Game1.ScreenHeight - YouWinImage.Height) / 2) - 100;
            spriteFont = contentManager.Load<SpriteFont>("DefaultTextFont");
            leftMarginText = (Game1.ScreenWidth - (int)spriteFont.MeasureString(startMessage).X) / 2;
            topMarginText = ((Game1.ScreenHeight - (int)spriteFont.MeasureString(startMessage).Y) / 2) + 300;

            new Handler().PostDelayed(delegate
            {
                canReturn = true;
            }, 2500);
        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (Controller.isPressed() && canReturn)
            {
                ReturnToMenu();
            }
        }

        private void DrawGameOverText(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(YouWinImage, new Vector2(leftMarginLogo, 200), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
        }

        private void DrawWinImage(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(YouWinImage, new Vector2(leftMarginLogo, topMarginLogo), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
        }
        private void DrawTextMessage(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, startMessage, new Vector2(leftMarginText, topMarginText), Color.White);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            DrawWinImage(spriteBatch);
            DrawTextMessage(spriteBatch);

            spriteBatch.End();
        }



        private void ReturnToMenu()
        {
            GameStateManager.Instance.SetCurrentState(new StartScreen(contentManager, graphicsDevice, game));
        }
    }
}
