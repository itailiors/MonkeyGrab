using Android.App;
using Android.Content;
using Android.Media;
using System.Threading;

namespace MonkeyGrab
{
    [Service]
    class Mosica : IntentService
    {
        public MediaPlayer mediaPlayer;
        public Mosica()
        {

        }
        public void Run()
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.SetDataSource("https://www.mfiles.co.uk/mp3-downloads/kalinka.mp3");
            mediaPlayer.Looping = true;
            mediaPlayer.Prepare(); //sync
            mediaPlayer.Start();
            while (Board.musicTog)
            {
                Thread.Sleep(1000);
            }
            StopMusic();
        }

        protected override void OnHandleIntent(Intent intent)
        {
            ThreadStart ts = new ThreadStart(Run);
            Thread thread = new Thread(ts);
            thread.Start();
        }
        public override bool StopService(Intent name)
        {
            StopMusic();
            return base.StopService(name);
        }
        public void StopMusic()
        {
            mediaPlayer.Stop();
        }
    }
}