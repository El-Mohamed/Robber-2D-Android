using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Robber_2D;
using System;
using System.Collections.Generic;

namespace Robber_2D
{
    class StartScreen : GameState
    {

        private Texture2D logo;
        private int leftMarginLogo, topMarginLogo, leftMarginText, topMarginText;
        private SpriteFont spriteFont;
        private const string startMessage = "PRESS ANYWHERE TO START THE GAME";

        public StartScreen(ContentManager contentManager, GraphicsDevice graphicsDevice, Robber2D game) : base(contentManager, graphicsDevice, game)
        {

        }

        public override void Initialize()
        {

        }

        public override void LoadContent()
        {
            // Logo

            logo = ContentManager.Load<Texture2D>("Logo");
            leftMarginLogo = ((Robber2D.ScreenWidth - logo.Width) / 2);
            topMarginLogo = ((Robber2D.ScreenHeight - logo.Height) / 2) - 100;

            // Text

            spriteFont = ContentManager.Load<SpriteFont>("DefaultTextFont");
            leftMarginText = (Robber2D.ScreenWidth - (int)spriteFont.MeasureString(startMessage).X) / 2;
            topMarginText = ((Robber2D.ScreenHeight - (int)spriteFont.MeasureString(startMessage).Y) / 2) + 300;

            // SoundEffect

            MenuSounds.SelectSound = ContentManager.Load<SoundEffect>("SelectSound");
        }

        private void StartGame()
        {
            GameStateManager.Instance.SetCurrentState(new InGame(ContentManager, GraphicsDevice, Game));
        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (TouchController.isPressed())
            {
                MenuSounds.PlaySelectSound();
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
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            DrawLogo(spriteBatch);
            DrawTextMessage(spriteBatch);

            spriteBatch.End();
        }
    }
}
