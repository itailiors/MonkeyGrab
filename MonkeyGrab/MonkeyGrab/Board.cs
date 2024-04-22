using Android.Content;
using Android.Graphics;
using Android.Views;
using System;
using System.Threading;

namespace MonkeyGrab
{
    class Board : SurfaceView
    {


        private bool play = true;
        public static bool musicTog = true; // music toggle 
        private Thread gameThread;
        private ThreadStart ts;
        private GameWall gameWall;
        private Hand RightHand, LeftHand;
        private ClimbPoint[] cpArr;
        private Point sRight, eRight, sLeft, eLeft;
        private int placeMentR = -1, placeMentL = -1;
        private int timer;
        private int checkLeft = 0, checkRight = 0;
        public static int score;
        private bool aLeft = false, aRight = false, start = false;

        public Board(Context context, int screenWidth, int screenHeight) : base(context)
        {
            int sNumber = (Skinactivity.charSel);

            Paint pHand = new Paint
            {

                Color = Color.Red,
                StrokeWidth = 25
            };
            if (sNumber == 1)
            {
                pHand.Color = Color.GreenYellow;
            }
            if (sNumber == 0)
            {
                pHand.Color = Color.Red;
            }
            if (sNumber == 2)
            {
                pHand.Color = Color.Blue;
            }
            Color col = Color.Green;
            sRight = new Point((screenWidth / 10) * 7, screenHeight - screenHeight / 4);
            eRight = new Point((screenWidth / 10) * 7, (screenHeight / 3) * 2);
            sLeft = new Point((screenWidth / 10) * 3, screenHeight - screenHeight / 4);
            eLeft = new Point((screenWidth / 10) * 3, (screenHeight / 3) * 2);

            RightHand = new Hand(sRight, eRight, pHand);
            LeftHand = new Hand(sLeft, eLeft, pHand);
            cpArr = new ClimbPoint[24];
            gameWall = new GameWall(screenWidth, screenHeight, col, cpArr);
            ts = new ThreadStart(Run);
            gameThread = new Thread(ts);
            gameThread.Start();
        }
        public void Run()
        {
            Bitmap b = null;
            int sNum = (Skinactivity.charSel);
            if (sNum == null)
            {
                sNum = 0;

            }
            musicTog = true;
            Canvas canvas = null;
            while (play)
            {
                if (Holder.Surface.IsValid)
                {
                    try
                    {


                        canvas = Holder.LockCanvas();
                        if (b == null) // chooses with character
                        {
                            if (sNum == 0)
                            {
                                b = Bitmap.CreateScaledBitmap(BitmapFactory.DecodeResource(Resources, Resource.Drawable.extendaarmsname), (canvas.Width / 10) * 4, canvas.Height / 4, false);
                            }
                            if (sNum == 1)
                            {
                                b = Bitmap.CreateScaledBitmap(BitmapFactory.DecodeResource(Resources, Resource.Drawable.extendagreen), (canvas.Width / 10) * 4, canvas.Height / 4, false);
                            }
                            if (sNum == 2)
                            {
                                b = Bitmap.CreateScaledBitmap(BitmapFactory.DecodeResource(Resources, Resource.Drawable.extendablue), (canvas.Width / 10) * 4, canvas.Height / 4, false);
                            }

                        }

                        canvas.DrawColor(Color.White);
                        gameWall.Draw(canvas);
                        gameWall.checkSpeed(score); // checks the score to update the speed of the wall going down
                        LeftHand.Draw(canvas);
                        RightHand.Draw(canvas);
                        if (start) // score
                        {
                            timer++;
                        }
                        canvas.DrawText("The score is : " + timer / 50, (canvas.Width / 3) * 1, canvas.Height / 10, new Paint { Color = Color.Blue, TextSize = 30 });
                        score = timer / 50;

                        canvas.DrawBitmap(b, canvas.Width / 2 - b.Width / 2, canvas.Height - (canvas.Height / 40) * 11, null);



                        if (placeMentR != -1) // if the right hand allready has a value of a climbpoint then keep grabbing it 
                        {
                            start = true;
                            eRight.X = gameWall.ReturnPosX(placeMentR);
                            eRight.Y = gameWall.ReturnPosY(placeMentR);
                        }
                        else if (RightHand.HandHit(RightHand, cpArr) != -1) // if it doesnt have then check if its touching a climbpoint
                        {
                            placeMentR = RightHand.HandHit(RightHand, cpArr);
                            eRight.X = gameWall.ReturnPosX(placeMentR);
                            eRight.Y = gameWall.ReturnPosY(placeMentR);
                            eLeft.X = (canvas.Width / 10) * 3;//value of start
                            eLeft.Y = (canvas.Height / 3) * 2 + canvas.Height / 20;
                            aRight = true;
                            aLeft = false;
                            placeMentL = -1;
                        }
                        if (placeMentL != -1) // if the left hand allready has a value of a climbpoint then keep grabbing it 
                        {
                            start = true;
                            eLeft.X = gameWall.ReturnPosX(placeMentL);
                            eLeft.Y = gameWall.ReturnPosY(placeMentL);
                        }
                        else if (LeftHand.HandHit(LeftHand, cpArr) != -1) // if it doesnt have then check if its touching a climbpoint
                        {
                            placeMentL = LeftHand.HandHit(LeftHand, cpArr);
                            eLeft.X = gameWall.ReturnPosX(placeMentL);
                            eLeft.Y = gameWall.ReturnPosY(placeMentL);

                            eRight.X = ((canvas.Width / 10) * 7);//value of start
                            eRight.Y = ((canvas.Height / 3) * 2) + canvas.Height / 20;
                            aRight = false;
                            aLeft = true;
                            placeMentR = -1;
                        }
                        if (aRight) // if its the right hand touching a climb point then do you function
                        {
                            checkLeft = 0;
                            checkRight++;
                            if (eRight.Y > canvas.Height)
                            {
                                score = timer / 50;
                                musicTog = false;
                                play = false;
                            }
                        }
                        if (aLeft)  // if its the left hand touching a climb point then do you function
                        {
                            checkRight = 0;
                            checkLeft++;
                            if (eLeft.Y > canvas.Height)
                            {
                                score = timer / 50;
                                musicTog = false;
                                play = false;
                            }
                        }




                    }
                    catch (System.Exception e)
                    {
                        Android.Util.Log.Debug("Err:", e.Message);
                    }
                    finally
                    {

                        if (canvas != null)
                            Holder.UnlockCanvasAndPost(canvas);

                    }
                }



            }

            Intent intent = new Intent();
            ((GameShow)this.Context).Finish();
        }


        public override bool OnTouchEvent(MotionEvent e)
        {
            if (e.GetX() - eLeft.X < 10 && e.GetY() - eLeft.Y < 10) // the touchevent needs to be in that distance from the arm 
            {
                if (Math.Sqrt(Math.Pow((e.GetX() - sLeft.X), 2) + Math.Pow((e.GetY() - sLeft.Y), 2)) < sLeft.X && !aLeft) // this makes it so the arm doesnt go longer than it should
                {
                    if (e.Action == MotionEventActions.Move)
                    {
                        eLeft.X = (int)e.GetX();
                        eLeft.Y = (int)e.GetY();


                    }
                }
            }
            else if (e.GetX() - eRight.X < 10 && e.GetY() - eRight.Y < 10) // the touchevent needs to be in that distance from the arm 
            {
                if (Math.Sqrt(Math.Pow((e.GetX() - sRight.X), 2) + Math.Pow((e.GetY() - sRight.Y), 2)) < sLeft.X && !aRight) // this makes it so the arm doesnt go longer than it should
                {
                    if (e.Action == MotionEventActions.Move)
                    {
                        eRight.X = (int)e.GetX();
                        eRight.Y = (int)e.GetY();

                    }
                }

            }
            return true;
        }


    }
}