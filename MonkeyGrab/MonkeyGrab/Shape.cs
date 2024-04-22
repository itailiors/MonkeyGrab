using Android.Content;
using Android.Graphics;

namespace MonkeyGrab
{
    public abstract class Shape
    {
        public float X { get; set; }
        public float Y { get; set; }

        protected int ScreenWidth;
        protected int ScreenHight;

        protected Paint ShapePaint;
        protected Color ShapeColor;
        private Context context;

        public Shape(float x, float y, Color color)
        {
            X = x;
            Y = y;
            ShapeColor = color;
            ShapePaint = new Paint();
            ShapePaint.Color = color;
        }

        protected Shape(Context context)
        {
            this.context = context;
        }

        public abstract void Draw(Canvas canvas);

    }
}
