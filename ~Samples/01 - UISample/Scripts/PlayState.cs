using UnityEngine;

public class PlayState : MonoBehaviour
{
    public StringView view;
    public FloatView hpView;

    private int score = 0;
    private float hp = 100;

    // Start is called before the first frame update
    void Start()
    {
        view.OnSet(score.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            score += 100;
            view.OnSet(score.ToString("000000"));
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            hp -= 1;
            hpView.OnSet(hp);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            hp += 1;
            hpView.OnSet(hp);
        }


    }
}
