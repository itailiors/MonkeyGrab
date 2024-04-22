using Android.Graphics;

namespace MonkeyGrab
{
    class GameWall : Shape
    {


        int screenWidth, screenHeight;
        public ClimbPoint[] cpArr = new ClimbPoint[24];
        int counter = 0;
        Point c;
        int goUp = 2;
        int[] Temp1 = new int[24]; // the x array
        int[] Temp2 = new int[24]; // the y array
        public static int[] yArr = new int[24];

        public GameWall(int screenWidth, int screenHeight, Color color, ClimbPoint[] cpArr) : base(screenWidth, screenHeight, color)
        {
            this.screenHeight = screenHeight;
            this.screenWidth = screenWidth;
            this.cpArr = cpArr; // climb point arr
            CreatebaseArr();

        }

        public override void Draw(Canvas canvas)
        {

            int br = canvas.Width / 30;
            for (int i = 0; i < cpArr.Length; i++)
            {
                cpArr[i].Draw(canvas);
            }
            UpdateBallsPosition();
        }
        public void CreatebaseArr()
        {
            int xBall, yBall;
            int ballRad = this.screenWidth / 30;
            int dxball = this.screenWidth / 6;
            int dyball = this.screenHeight / 6;
            for (int i = 1; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {

                    xBall = ballRad * i + dxball * i;
                    if (j != 0) // sets height
                    {
                        yBall = screenHeight / 6 * j;

                    }
                    else
                    {
                        yBall = 0;
                    }
                    c = new Point(xBall, yBall);
                    Color color = Color.Green;
                    cpArr[counter] = new ClimbPoint(ballRad, c, color);
                    cpArr[counter].y = yBall;
                    counter++;
                }
            }
        }
        public void checkSpeed(int score)
        {
            goUp = score / 5;
            if (goUp == 0)
            {
                goUp = 1;
            }
        }
        public void UpdateBallsPosition()
        {
            int ballRad = this.screenWidth / 30;
            int dyball = this.screenHeight / 6;
            for (int i = 0; i < 24; i++)
            {
                if (cpArr[i].y >= screenHeight + ballRad)
                {
                    cpArr[i].y = 0 - ballRad;
                }
            }
            for (int i = 0; i < cpArr.Length; i++)
            {
                cpArr[i].y += goUp;
                yArr[i] = (int)cpArr[i].y;
                Temp1[i] = (int)cpArr[i].y;
                Temp2[i] = (int)cpArr[i].x;
            }
        }
        public int ReturnPosY(int a)
        {
            return Temp1[a];
        }
        public int ReturnPosX(int a)
        {
            return Temp2[a];
        }
    }
}
