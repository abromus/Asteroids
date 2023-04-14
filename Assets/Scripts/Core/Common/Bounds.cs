namespace Asteroids.Core
{
    public readonly struct Bounds
    {
        public Float3 Left { get; }

        public Float3 Right { get; }

        public Float3 Top { get; }

        public Float3 Bottom { get; }

        public float Width { get; }

        public float Height { get; }

        public Bounds(Float3 left, Float3 right, Float3 top, Float3 bottom)
        {
            Left = left;
            Right = right;
            Top = top;
            Bottom = bottom;

            Width = right.X - left.X;
            Height = top.Y - bottom.Y;
        }
    }
}
