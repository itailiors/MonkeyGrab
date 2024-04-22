using Android.App;
using Android.Graphics;
using Android.OS;

namespace MonkeyGrab
{
    [Activity(Label = "GameScreen")]
    public class GameScreen : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //SupportActionBar.Hide();
            Point screenSize = new Point();
            WindowManager.DefaultDisplay.GetSize(screenSize);
            Board board = new Board(this, screenSize.X, screenSize.Y);
            SetContentView(board);
        }

    }
}