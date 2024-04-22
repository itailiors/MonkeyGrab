
using Android.App;
using Android.Content;

namespace MonkeyGrab
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { Intent.ActionBatteryChanged })]
    class BroadcastBattery : BroadcastReceiver
    {
        //opens a dialog
        CustomDialog cd;
        public BroadcastBattery(CustomDialog cd)
        {
            this.cd = cd;
        }
        public BroadcastBattery() { } //constructor

        public override void OnReceive(Context context, Intent intent)
        {
            int battery = intent.GetIntExtra("level", 0);
            if (battery < 30)
            {
                cd.Show();
            }
        }
    }
}