using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ConnectFour.UI
{
    /// <summary>
    /// This class covers the rendering of text. This class has the following abilities:<br/>
    /// <list type="bullet">
    ///     <item>
    ///         <description>Resizing text based on the parent container.</description>
    ///     </item>
    ///     <item>
    ///         <description>Aligning text horizontally and vertically.</description>
    ///     </item>
    ///     <item>
    ///         <description>Scaling and resizing text.</description>
    ///     </item>
    /// </list>
    /// This is mostly a note for myself, but DO NOT try to make an object through initializers. This should only be created through a constructor.
    /// </summary>
    public class WrappedText
    {
        /// <summary>
        /// Backing field for <see cref="Text"/>.
        /// </summary>
        private string _text;
        /// <summary>
        /// The input text of this string. This is inaccessible since this should never be accessed.
        /// </summary>
        public string Text { set => _text = value; }
        /// <summary>
        /// The max width of each line of text. Set this to the width of the container to ensure that the the text fits in the container.
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// The height of each line of text.
        /// </summary>
        public int Height { get; set; }

    }
}
