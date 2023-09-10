using System;

namespace Runer
{
    public class MatchModel : IModel
    {
        private int score;
        private DefeatData? defeatData;

        public int Score
        {
            get => score;
            set
            {
                if (value == score)
                {
                    return;
                }

                score = value;
                PropertyChanged?.Invoke(nameof(Score), score);
            }
        }
        public DefeatData? DefeatData
        {
            get => defeatData;
            set
            {
                if (value == defeatData)
                {
                    return;
                }

                defeatData = value;
                PropertyChanged?.Invoke(nameof(Score), score);
            }
        } 

        public event Action<string, object> PropertyChanged;
    }
}