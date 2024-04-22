using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;

namespace MonkeyGrab
{
    [Activity(Label = "GameShow")]
    public class GameShow : Activity
    {
        private Intent mosic;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            Point screenSize = new Point();
            WindowManager.DefaultDisplay.GetSize(screenSize);
            Board board = new Board(this, screenSize.X, screenSize.Y);
            mosic = new Intent(this, typeof(Mosica));
            SetContentView(board);
        }
        protected override void OnResume()
        {
            StartService(mosic);
            base.OnResume();

        }
        protected override void OnPause()
        {

            StopService(mosic);
            base.OnPause();
        }

    }
}