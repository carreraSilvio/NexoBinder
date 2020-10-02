using UnityEngine;

namespace NexoBinder.Samples.ScoreSample
{
    public class PlayState : MonoBehaviour
    {
        public ScoreView scoreView;

        private int score = 0;
        //private float hp = 100;

        // Start is called before the first frame update
        void Start()
        {
           scoreView.score.Value = 10;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                scoreView.score.Value += 10;
            }

            //if (Input.GetKey(KeyCode.DownArrow))
            //{
            //    hp -= 1;
            //    hpView.OnChangeValue(hp);
            //}
            //else if (Input.GetKey(KeyCode.UpArrow))
            //{
            //    hp += 1;
            //    hpView.OnChangeValue(hp);
            //}


        }
    }
}