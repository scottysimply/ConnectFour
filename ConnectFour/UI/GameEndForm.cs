using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ConnectFour.UI
{
    public enum GameStateSettings
    {
        Ongoing,
        YellowWin,
        RedWin,
        Draw,
    }
    public class GameEndForm
    {
        public GameStateSettings CurrentState { get; set; }
        public Rectangle Bounds;
        public string Label { get; set; }
        public ResetButton ResetButton;
        public bool Enabled;
        const int PADDING = 12;
        public GameEndForm(Point center, Point size)
        {
            Bounds = new Rectangle(center - (size.ToVector2() * 0.5f).ToPoint(), size);
            int button_height = (int)(Bounds.Height * .33f);
            ResetButton = new ResetButton(this, new(PADDING, size.Y - button_height - PADDING), new(size.X - 2 * PADDING, button_height), "Reset");
            Enabled = false;
        }
        /// <summary>
        /// Repeatedly checks to see if the form should be updated.
        /// </summary>
        /// <returns>Whether the form is visible.</returns>
        public void Update()
        {
            if (CurrentState == GameStateSettings.Ongoing)
            {
                Enabled = false;
                ResetButton.Enabled = false;
                return;
            }

            // If the game is no longer ongoing:
            Enabled = true;
            ResetButton.Enabled = true;
            switch (CurrentState)
            {
                case GameStateSettings.YellowWin:
                    Label = "Yellow won!\nPress the button below to restart.";
                    break;

                case GameStateSettings.RedWin:
                    Label = "Red won!\nPress the button below to restart.";
                    break;

                case GameStateSettings.Draw:
                    Label = "The game has ended in a draw.\nPress the button below to restart.";
                    break;

                default:
                    return;

            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Enabled) return;
            // Draw base.
            spriteBatch.Draw(ConnectFourGame.BlankSquare, Bounds, new Color(.20f, .24f, .7f));

            // Calculate text position
            Vector2 drawPos = Bounds.Center.ToVector2();
            Vector2 textSize = ConnectFourGame.Trebuchet.MeasureString(Label);
            drawPos -= 0.5f * textSize;

            float scale = textSize.Y / (textSize.Y - 2 * PADDING);

            spriteBatch.DrawString(ConnectFourGame.Trebuchet, Label, drawPos, Color.White, 0f, textSize * 0.5f, scale, SpriteEffects.None, 0);

            // Draw button
            ResetButton.Draw(spriteBatch);
        }

    }
}
