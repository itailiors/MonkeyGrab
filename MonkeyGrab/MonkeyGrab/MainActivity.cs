using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace MonkeyGrab
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, Android.Views.View.IOnClickListener
    {
        ImageButton btHS, btSkin, btAb;
        BroadcastBattery broadcastBattery;
        ImageButton btPlay;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SupportActionBar.Hide();
            SetContentView(Resource.Layout.activity_main);
            btPlay = (ImageButton)FindViewById(Resource.Id.ibtPlay);
            btPlay.SetOnClickListener(this);
            btHS = (ImageButton)FindViewById(Resource.Id.ibtHS);
            btHS.SetOnClickListener(this);
            broadcastBattery = new BroadcastBattery();
            btSkin = (ImageButton)FindViewById(Resource.Id.ibtSkin);
            btSkin.SetOnClickListener(this);
            btAb = (ImageButton)FindViewById(Resource.Id.ibtAb);
            btAb.SetOnClickListener(this);
            this.broadcastBattery = new BroadcastBattery(new CustomDialog(this));
            RegisterReceiver(this.broadcastBattery, new IntentFilter(Intent.ActionBatteryChanged));
        }
        protected override void OnResume()
        {
            base.OnResume();
            RegisterReceiver(broadcastBattery, new IntentFilter(Intent.ActionBatteryChanged));
        }
        protected override void OnPause()
        {
            UnregisterReceiver(broadcastBattery);
            base.OnPause();
        }
        public void OnClick(View v)
        {
            if (btPlay == v)
            {
                Intent intent = new Intent(this, typeof(GameShow));
                StartActivity(intent);
            }
            if (btHS == v)
            {
                Intent intent1 = new Intent(this, typeof(HighScoreActivity));
                StartActivity(intent1);
            }
            if (btSkin == v)
            {
                Intent intentSk = new Intent(this, typeof(Skinactivity));
                StartActivity(intentSk);
            }
            if (btAb == v)
            {
                Intent intentAb = new Intent(this, typeof(About));
                StartActivity(intentAb);
            }
        }
    }
}