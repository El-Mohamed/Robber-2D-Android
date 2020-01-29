using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Robber_2D;
using System;
using System.Collections.Generic;

namespace Robber_2D
{
    class StartScreen : GameState
    {
        #region Fields

        private Texture2D logo;
        private int leftMarginLogo, topMarginLogo, leftMarginText, topMarginText;
        private SpriteFont spriteFont;
        private const string startMessage = "PRESS ANYWHERE TO START THE GAME";

        #endregion
        public StartScreen(ContentManager contentManager, GraphicsDevice graphicsDevice, Game1 game) : base(contentManager, graphicsDevice, game)
        {

        }

        public override void Initialize()
        {

        }

        public override void LoadContent()
        {
            logo = contentManager.Load<Texture2D>("Logo");
            leftMarginLogo = ((Game1.ScreenWidth - logo.Width) / 2);
            topMarginLogo = ((Game1.ScreenHeight - logo.Height) / 2) - 100;
            spriteFont = contentManager.Load<SpriteFont>("DefaultTextFont");
            leftMarginText = (Game1.ScreenWidth - (int)spriteFont.MeasureString(startMessage).X) / 2;
            topMarginText = ((Game1.ScreenHeight - (int)spriteFont.MeasureString(startMessage).Y) / 2) + 300;

        }

        private void StartGame()
        {
            GameStateManager.Instance.SetCurrentState(new InGame(contentManager, graphicsDevice, game));
        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (Controller.isPressed())
            {
                StartGame();
            }
        }

        private void DrawLogo(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(logo, new Vector2(leftMarginLogo, topMarginLogo), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
        }
        private void DrawTextMessage(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, startMessage, new Vector2(leftMarginText, topMarginText), Color.White);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            DrawLogo(spriteBatch);
            DrawTextMessage(spriteBatch);

            spriteBatch.End();
        }
    }
}
