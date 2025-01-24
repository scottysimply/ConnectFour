using Microsoft.Xna.Framework;

namespace ConnectFour
{
    public class Cell
    {
        public Rectangle Bounds;
        public Cell(int x, int y, int width, int height)
        {
            Bounds = new Rectangle(x, y, width, height);
            State = 0;
        }
        public int State { get; set; }
    }
}
