
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace MonkeyGrab
{
    [Activity(Label = "Skinactivity")]
    public class Skinactivity : Activity, Android.Views.View.IOnClickListener
    {
        ImageButton greenChar, blueChar;
        Button defChar, Mainreturn;
        public static int charSel = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.skinlayout);
            // Create your application here
            greenChar = (ImageButton)FindViewById(Resource.Id.greenChar);
            blueChar = (ImageButton)FindViewById(Resource.Id.blueChar);
            defChar = (Button)FindViewById(Resource.Id.defChar);
            Mainreturn = (Button)FindViewById(Resource.Id.Mainreturn);
            greenChar.SetOnClickListener(this);
            blueChar.SetOnClickListener(this);
            defChar.SetOnClickListener(this);
            Mainreturn.SetOnClickListener(this);
        }
        public void OnClick(View v)
        {
            if (greenChar == v)
            {
                charSel = 1;
                Toast.MakeText(this, "You have chosen the green character", ToastLength.Short).Show();
            }
            if (blueChar == v)
            {
                charSel = 2;
                Toast.MakeText(this, "You have chosen the blue character", ToastLength.Short).Show();

            }
            if (v == defChar)
            {
                charSel = 0;
                Toast.MakeText(this, "You have chosen the red character", ToastLength.Short).Show();

            }
            if (v == Mainreturn)
            {
                Intent intentmain = new Intent(this, typeof(MainActivity));
                StartActivity(intentmain);
            }
        }
    }
}