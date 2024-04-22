using Android.Graphics;

namespace MonkeyGrab
{
    class ClimbPoint : Shape
    {
        public float BallRadius { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public Color color { get; set; }

        public ClimbPoint(float radius, Point center, Color color) : base(center.X, center.Y, color)
        {
            BallRadius = radius;
            this.color = color;
            x = center.X;
            y = center.Y;
        }


        public override void Draw(Canvas canvas)
        {
            Paint p1 = new Paint();
            p1.Color = color;
            canvas.DrawCircle(x, y, BallRadius, p1);
        }
    }
}