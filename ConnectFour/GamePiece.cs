using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ConnectFour
{
    public class GamePiece
    {
        private Point _position;
        public Point Position
        {
            get => _position;
            set
            {
                _position = value;
                _bounds.Location = value;
            }
        }
        private int _width;
        public int Width
        {
            get => _width;
            set
            {
                _width = value;
                _bounds.Width = value;
            }
        }
        private int _height;
        public int Height
        {
            get => _height;
            set
            {
                _height = value;
                _bounds.Height = value;
            }
        }
        // public Team Team { get; set; }
        private Rectangle _bounds;
        public Rectangle Bounds
        {
            get => _bounds;
            set
            {
                _bounds = value;
                _position = value.Location;
                _width = value.Width;
                _height = value.Height;
            }
        }
        private Color _color;
        public bool IsYellow { get; set; }




        public GamePiece(int width, int height, Point position, bool isYellow)
        {
            _width = width;
            _height = height;
            _position = position;
            _bounds = new Rectangle(position.X, position.Y, width, height);
            IsYellow = isYellow;
        }
        public void Update()
        {
            // Update color when team changes color
            /*switch (Team)
            {
                case Team.Red:
                    _color = new Color(215, 20, 12);
                    break;
                case Team.Yellow:
                    _color = new Color(189, 212, 4);
                    break;
                default:
                    break;
            }*/

            if (IsYellow)
            {
                _color = new Color(189, 212, 4);
            }
            else
            {
                _color = new Color(215, 20, 12);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ConnectFourGame.PlayerToken, _bounds, _color);
        }


    }
}
