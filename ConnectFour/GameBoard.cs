using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ConnectFour
{
    public class GameBoard
    {
        /// <summary>
        /// This is the state of the game. 0's indicate empty cells, 1's indicate Yellow (player 1)'s pieces, and 2 represents red's pieces.
        /// </summary>
        public Cell[,] GameState { get; set; }
        /// <summary>
        /// Padding given to each element in the game board, in pixels.
        /// </summary>
        public const int PADDING = 4;
        /// <summary>
        /// Margins surrounding the game board, in pixels.
        /// </summary>
        public const int MARGINS = 16;
        
        public int Cell_Size { get; set; }

        /// <summary>
        /// The dimensions of this element.
        /// </summary>
        public Rectangle Bounds;
        
        /// <summary>
        /// Constructs a game board, auto-fit to the window dimensions.
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="rows"></param>
        /// <param name="window_dimensions"></param>
        /// <param name="cell_size">Out: </param>
        public GameBoard(int columns, int rows, Point window_dimensions, out int cell_size)
        {
            GameState = new Cell[columns, rows];
            bool landscape = window_dimensions.X >= window_dimensions.Y;
            if (landscape)
            {
                cell_size = (window_dimensions.Y - 2 * (MARGINS + rows * PADDING)) / rows;
            }
            else
            {
                cell_size = (window_dimensions.Y - 2 * (MARGINS + columns * PADDING)) / columns;
            }
            int width = 2 * PADDING * columns + columns * cell_size;
            int height = 2 * PADDING * rows + rows * cell_size;
            Cell_Size = cell_size;

            Bounds = new Rectangle(MARGINS, MARGINS, width, height);
            for (int y = 0; y < GameState.GetLength(1); y++)
            {
                for (int x = 0; x < GameState.GetLength(0); x++)
                {
                    GameState[x, y] = new Cell(MARGINS + PADDING + (x * cell_size) + (x * 2 * PADDING), MARGINS + PADDING + (y * cell_size) + (y * 2 * PADDING), cell_size, cell_size);

                }
            }
            
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Cell cell in GameState)
            {
                Texture2D texture = (cell.State) switch
                {
                    1 => ConnectFourGame.YellowToken,
                    2 => ConnectFourGame.RedToken,
                    _ => ConnectFourGame.EmptySpace,
                };
                spriteBatch.Draw(texture, cell.Bounds, Color.White);
            }
        }


        /// <summary>
        /// Converts indices (in terms of columns and rows) into a <see cref="Point"/> that represents the top left or center of the cell.
        /// </summary>
        /// <param name="column">The column index. Starts at 0.</param>
        /// <param name="row">The row index. Starts at 0.</param>
        /// <param name="center">If true, returns the center of the cell instead of the top left. Defaults to false.</param>
        /// <returns>The top left (or alternatively the center) of the cell.</returns>
        public Point ConvertIndicesToPoint(int column, int row, bool center = false)
        {
            // This gives top left coordinate
            int X = MARGINS + PADDING + column * (Cell_Size + 2 * PADDING);
            int Y = MARGINS + PADDING + row * (Cell_Size + 2 * PADDING);
            
            // If center, convert to center:
            if (center)
            {
                X += Cell_Size / 2;
                Y += Cell_Size / 2;
            }

            // Return point.
            return new Point(X, Y);
        }
    }
}
