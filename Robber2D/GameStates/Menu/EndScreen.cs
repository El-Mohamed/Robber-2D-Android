using Android.OS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Robber2D;
using System;
using System.Collections.Generic;

namespace Robber2D
{
    class EndScreen : GameState
    {

        SpriteFont buttonFont;
        Texture2D GameOverImage;
        private int leftMarginGameOver;
        string EndScore;
        private const string startMessage = "PRESS ANYWHERE TO RESTART THE GAME";
        bool canRestart;

        public EndScreen(ContentManager contentManager, GraphicsDevice graphicsDevice, Game1 game) : base(contentManager, graphicsDevice, game)
        {

        }

        public override void Initialize()
        {

        }
        public override void LoadContent()
        {
            buttonFont = contentManager.Load<SpriteFont>("DefaultTextFont");
            GameOverImage = contentManager.Load<Texture2D>("GameOver");

            GetScore();

            // Game Over Image
            leftMarginGameOver = (Game1.ScreenWidth - GameOverImage.Width) / 2;
            GameSounds.PlayGameOverSound();

            canRestart = false;

            new Handler().PostDelayed(delegate
            {
                canRestart = true;
            }, 2500);
        }

        private void GetScore()
        {
            int DiamondsScore = InGame.player.Inventory.MyDiamonds * 200;
            int CoinsScore = InGame.player.Inventory.MyCoins.Count * 100;
            EndScore = "TOTAL SCORE: " + Convert.ToString(DiamondsScore + CoinsScore);
        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (Controller.isPressed() && canRestart)
            {
                StartNewGame();
            }
        }

        private void DrawGameOverText(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(GameOverImage, new Vector2(leftMarginGameOver, 200), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
        }

        private void DrawScore(SpriteBatch spriteBatch)
        {
            var x = ((Game1.ScreenWidth / 2)) - (buttonFont.MeasureString(EndScore).X / 2);
            var y = ((Game1.ScreenHeight / 2)) - (buttonFont.MeasureString(EndScore).Y / 2);
            spriteBatch.DrawString(buttonFont, EndScore, new Vector2(x, y), Color.Red);
        }

        private void DrawTextMessage(SpriteBatch spriteBatch)
        {
            var x = ((Game1.ScreenWidth / 2)) - (buttonFont.MeasureString(startMessage).X / 2) ;
            var y = ((Game1.ScreenHeight / 2)) - (buttonFont.MeasureString(startMessage).Y / 2) + 200;
            spriteBatch.DrawString(buttonFont, startMessage, new Vector2(x, y), Color.White);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            DrawGameOverText(spriteBatch);
            DrawScore(spriteBatch);
            DrawTextMessage(spriteBatch);

            spriteBatch.End();
        }


        private void StartNewGame()
        {
            GameStateManager.Instance.SetCurrentState(new InGame(contentManager, graphicsDevice, game));
        }
    }
}
