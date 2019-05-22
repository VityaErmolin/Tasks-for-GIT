namespace Net2_2_new
{
    public class Window
    {
        public string Title { get; set; }
        public int? Top { get; set; }
        public int? Left { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }

        public Window(int? top, int? left, int? width, int? height, string title)
        {
            Title = title;
            Top = top;
            Left = left;
            Width = width;
            Height = height;
        }

        public void Fix()
        {
            if (Height == null)
            {
                Height = 150;
            }

            if (Width == null)
            {
                Width = 400;
            }

            if (Left == null)
            {
                Left = 0;
            }

            if (Top == null)
            {
                Top = 0;
            }
        }

        public override string ToString()
        {
            return $"  {Title}({(Top != null ? Top.ToString() : "?")}," +
                   $" {(Left != null ? Left.ToString() : "?")}, " +
                   $"{(Width != null ? Width.ToString() : "?")}, " +
                   $"{(Height != null ? Height.ToString() : "?")})";
        }
    }
}