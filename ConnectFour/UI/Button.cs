using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ConnectFour.UI
{
    public class Button
    {
        public Point Position;

        public Point Size;

        public int LabelHeight;

        public bool Enabled { get; set; }
        
        public string Label = "";
        public Button(Point position, Point size, string label)
        {
            Label = label;
            Position = position;
            Size = size;
            Enabled = false;
            LabelHeight = size.Y;
        }
        public virtual void OnClick() { }
        public virtual void Draw(SpriteBatch spriteBatch) { }

    }

    public class ResetButton : Button
    {
        /// <summary>
        /// Relative to window
        /// </summary>
        public Point GamePosition = new(0, 0);
        public Rectangle Bounds
        {
            get
            {
                return new(GamePosition, Size);
            }
        }
        public ResetButton(GameEndForm parent, Point position_on_parent, Point size, string label) : base(position_on_parent, size, label)
        {
            Label = label;
            Position = position_on_parent;
            GamePosition = parent.Bounds.Location + position_on_parent;
            Size = size;
        }
        public override void OnClick()
        {
            ConnectFourGame.ResetGame();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Enabled) return;
            // Draw base.
            spriteBatch.Draw(ConnectFourGame.BlankSquare, Bounds, new Color(.13f, .16f, .56f));

            // Draw Text
            Vector2 drawPos = Bounds.Center.ToVector2();
            drawPos -= 0.5f * ConnectFourGame.Trebuchet.MeasureString(Label);
            spriteBatch.DrawString(ConnectFourGame.Trebuchet, Label, drawPos, Color.White);
        }
    }
}
