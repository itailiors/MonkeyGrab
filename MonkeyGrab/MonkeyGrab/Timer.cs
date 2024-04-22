using Android.Graphics;
using System.Threading;

namespace MonkeyGrab
{
    class Timer
    {
        private int Time { get; set; }
        private int x { get; set; }
        private int y { get; set; }
        private Paint paint { get; set; }
        public Timer(int t, int x, int y, Paint paint)
        {
            this.Time = t;
            this.x = x;
            this.y = y;
            this.paint = paint;
        }

        public Timer(int v1, int v2, Paint pTimer)
        {
        }

        public void Draw(Canvas canvas)
        {
            canvas.DrawText("The score is : " + Time, x, y, paint);
            Thread.Sleep(100);
            Time = +1;
        }
    }
}