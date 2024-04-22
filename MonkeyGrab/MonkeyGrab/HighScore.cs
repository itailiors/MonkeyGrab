using SQLite;

namespace MonkeyGrab
{
    [Table("Scores")]
    class HighScore
    {
        [PrimaryKey, AutoIncrement]
        int id { get; set; }
        public int hs { get; set; }
        public HighScore(int hs)
        {
            this.hs = hs;
        }
        public HighScore()
        {

        }
    }
}