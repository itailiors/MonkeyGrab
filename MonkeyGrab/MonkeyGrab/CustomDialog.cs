
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace MonkeyGrab
{
    class CustomDialog : Dialog
    {
        //Opens Dialog if battery is lower than 30
        public bool want;
        public CustomDialog(Activity activity) : base(activity)
        {
            want = false;
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature((int)WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.CustomDialog);

            Button accept = FindViewById<Button>(Resource.Id.btacc);

            accept.Click += (e, a) =>
            {
                want = true;
                Dismiss();
            };
        }
    }
}