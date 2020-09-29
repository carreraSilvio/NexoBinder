using UnityEngine;

public class PlayState : MonoBehaviour
{
    public TextView view;

    private int health = 0;

    // Start is called before the first frame update
    void Start()
    {
        view.OnTextChange(health.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            health -= 1;
            view.OnTextChange(health.ToString());
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            health += 1;
            view.OnTextChange(health.ToString());
        }


    }
}
