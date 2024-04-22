using Android.Graphics;
using System;

namespace MonkeyGrab
{
    class Hand
    {
        // h- hand
        private Point sHand { get; set; }
        private Point eHand { get; set; }
        private Paint pHand { get; set; }
        public Hand(Point sHand, Point eHand, Paint pHand)
        {
            this.sHand = sHand;
            this.eHand = eHand;
            this.pHand = pHand;
        }

        public Hand()
        {

        }
        public int HandHit(Hand h, ClimbPoint[] cpA)
        {

            for (int counter = 0; counter < cpA.Length; counter++)
            {
                if (Math.Sqrt(Math.Pow((h.eHand.X - cpA[counter].X), 2) + Math.Pow((h.eHand.Y - GameWall.yArr[counter]), 2)) < 10) // checks the distance between end of arm to climb point
                {

                    return counter;
                }

            }
            return -1;


        }
        public void Draw(Canvas canvas)
        {
            Paint cHand = new Paint
            {

                Color = Color.Pink,
                StrokeWidth = 25
            };
            canvas.DrawLine(sHand.X, sHand.Y, eHand.X, eHand.Y, pHand);
            canvas.DrawCircle(eHand.X, eHand.Y, 10, cHand);
        }


    }
}