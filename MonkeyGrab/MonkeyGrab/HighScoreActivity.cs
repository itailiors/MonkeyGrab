using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using SQLite;
using System.Collections.Generic;

namespace MonkeyGrab
{
    [Activity(Label = "itemShop")]
    public class HighScoreActivity : Activity
    {
        ScoreAdapter it;
        ListView lv;
        ImageButton btnHome;
        List<HighScore> ScoreList = new List<HighScore>();
        int index;
        private void CreateList(List<HighScore> ls) // creats a list and puts all scores to 0
        {
            while (ls.Count < 10)
            {
                ls.Add(new HighScore(0));
            }
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ListViewScores);
            GetScores();
            lv = FindViewById<ListView>(Resource.Id.lv);
            it = new ScoreAdapter(this, ScoreList);
            lv.Adapter = it;
            btnHome = FindViewById<ImageButton>(Resource.Id.btnHome);
            btnHome.Click += ButtonHome_Click;
            if (ScoreList.Count > 0)
            {
                int scoreInt = (Board.score);

                for (int i = 0; i < 10; i++)
                {
                    if (ScoreList[i] == null) // if the score is not existstent then its 0
                    {
                        ScoreList[i].hs = 0;
                    }
                }

                if (scoreInt > ScoreList[9].hs)
                {

                    for (int i = 0; i < 10; i++)
                    {
                        if (scoreInt > ScoreList[i].hs) // makes it so the score goes in the right place
                        {
                            index = i;
                            break;
                        }
                        else if (scoreInt == ScoreList[i].hs) // if its equal to score then put 1 place under
                        {
                            index = i - 1;
                        }
                    }
                }

                SQLiteConnection dbConnection = new SQLiteConnection(SQLhelper.Path());
                HighScore cur = new HighScore(scoreInt);
                ScoreList.Insert(index, cur);

                dbConnection.CreateTable<HighScore>();
                if (cur.hs > 0 && cur.hs != -100) dbConnection.Insert(cur); // if its valid in the scorelist then insert it
                dbConnection.Close();

                it.NotifyDataSetChanged(); //notify the data adapter for it to change the high score list in the high score activity
            }
        }
        public void GetScores() // gets the list of scores in descending order
        {
            SQLiteConnection dbConnection = new SQLiteConnection(SQLhelper.Path());
            dbConnection.CreateTable<HighScore>();

            string strSql = string.Format("SELECT * FROM Scores ORDER BY hs DESC");

            List<HighScore> dbScores = dbConnection.Query<HighScore>(strSql);
            dbConnection.Close();
            if (dbScores.Count > 0)
            {
                ScoreList = dbScores;
            }

            CreateList(ScoreList);

        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
        }
        private void ButtonHome_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivityForResult(intent, Constants.GAME_REUEST);
        }
    }
}