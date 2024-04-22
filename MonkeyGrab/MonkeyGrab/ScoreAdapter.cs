using Android.Content;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace MonkeyGrab
{
    class ScoreAdapter : BaseAdapter<int>
    {
        List<HighScore> scores;
        readonly Context context;
        public int SelectedCount { get; set; }

        public ScoreAdapter(Context context, List<HighScore> scores)
        {
            this.context = context;
            this.scores = scores;
            this.SelectedCount = 0;
        }

        public List<HighScore> GetList()
        {
            return this.scores;
        }

        public void SetList(List<HighScore> list)
        {
            this.scores = list;
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override int this[int position]
        {
            get
            {
                return this.scores[position].hs;
            }
        }
        public HighScore RemoveItem(HighScore t)
        {
            this.scores.Remove(t); return t;
        } // datasetchange
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            LayoutInflater layoutInflater = ((HighScoreActivity)context).LayoutInflater;//when you use a custom view in a listview you must define the row layout
            View view = layoutInflater.Inflate(Resource.Layout.HighScores, parent, false);

            TextView score = view.FindViewById<TextView>(Resource.Id.HighScoresNum);
            HighScore temp = scores[position];

            if (temp != null)
                score.Text = temp.hs.ToString();

            return view;
        }

        public override int Count
        {
            get
            {
                return this.scores.Count;
            }
        }

    }
}