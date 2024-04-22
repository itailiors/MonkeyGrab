
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace MonkeyGrab
{
    [Activity(Label = "About")]
    public class About : Activity, Android.Views.View.IOnClickListener
    {
        ImageButton btMs;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Aboutx);
            btMs = (ImageButton)FindViewById(Resource.Id.ibtMs);
            btMs.SetOnClickListener(this);

            // Create your application here
        }

        public void OnClick(View v)
        {
            if (v == btMs)
            {
                Intent intentMs = new Intent(this, typeof(MainActivity));
                StartActivity(intentMs);
            }
        }
    }
}