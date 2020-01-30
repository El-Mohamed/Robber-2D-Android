using Android.OS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Robber_2D;
using System;
using System.Collections.Generic;

namespace Robber_2D
{
    class EndScreen : GameState
    {

        SpriteFont textFont, scoreFont;
        Texture2D resultImage;
        private int leftMarginGameOver;
        string EndScore;
        private const string startMessage = "PRESS ANYWHERE TO RESTART THE GAME";
        bool canRestart;
        GameResult gameResult;

        public EndScreen(ContentManager contentManager, GraphicsDevice graphicsDevice, Robber2D game, GameResult gameResult) : base(contentManager, graphicsDevice, game)
        {
            this.gameResult = gameResult;
        }

        public override void Initialize()
        {

        }
        public override void LoadContent()
        {
            // Sound Effect

            if (gameResult == GameResult.Lost)
            {
                GameSounds.PlayGameOverSound();
            }

            // Result Image

            if (gameResult == GameResult.Won)
            {
                resultImage = ContentManager.Load<Texture2D>("YouWin");
            }
            else
            {
                resultImage = ContentManager.Load<Texture2D>("GameOver");
            }

            textFont = ContentManager.Load<SpriteFont>("DefaultTextFont");

            leftMarginGameOver = (Robber2D.ScreenWidth - resultImage.Width) / 2;

            // Text

            scoreFont = ContentManager.Load<SpriteFont>("DefaultFont");
            CalculateScore();

            // Restart

            canRestart = false;

            new Handler().PostDelayed(delegate
            {
                canRestart = true;
            }, 2500);
        }

        private void CalculateScore()
        {
            int DiamondsScore = InGame.player.Inventory.MyDiamonds * 200;
            int CoinsScore = InGame.player.Inventory.AllCoins.Count * 100;
            EndScore = "TOTAL SCORE: " + Convert.ToString(DiamondsScore + CoinsScore);
        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (TouchController.isPressed() && canRestart)
            {
                MenuSounds.PlaySelectSound();
                StartNewGame();
            }
        }

        private void DrawResultImage(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(resultImage, new Vector2(leftMarginGameOver, 200), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 1);
        }

        private void DrawScore(SpriteBatch spriteBatch)
        {
            var x = ((Robber2D.ScreenWidth / 2)) - (textFont.MeasureString(EndScore).X / 2);
            var y = ((Robber2D.ScreenHeight / 2)) - (textFont.MeasureString(EndScore).Y / 2);
            spriteBatch.DrawString(textFont, EndScore, new Vector2(x, y), Color.Red);
        }

        private void DrawTextMessage(SpriteBatch spriteBatch)
        {
            var x = ((Robber2D.ScreenWidth / 2)) - (textFont.MeasureString(startMessage).X / 2) ;
            var y = ((Robber2D.ScreenHeight / 2)) - (textFont.MeasureString(startMessage).Y / 2) + 200;
            spriteBatch.DrawString(textFont, startMessage, new Vector2(x, y), Color.White);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            DrawResultImage(spriteBatch);
            DrawScore(spriteBatch);
            DrawTextMessage(spriteBatch);

            spriteBatch.End();
        }


        private void StartNewGame()
        {
            GameStateManager.Instance.SetCurrentState(new InGame(ContentManager, GraphicsDevice, Game));
        }
    }
}
