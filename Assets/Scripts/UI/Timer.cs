using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : Manager {
    private Text text;

    void Start () 
    {
        if (gm.timer == null)
        {
            gm.timer = this;
        }
        text = GetComponent<Text>();
        Text = gm.ActualTime;
        Pause = false;
	}

    IEnumerator Countdown () 
    {
        yield return new WaitForSeconds(1);

        gm.TimeInSeconds--;
        Text = gm.ActualTime;
        if (gm.TimeInSeconds > 0)
        {
            StartCoroutine(Countdown());
        }
        else
        {
            gm.Die();
        }
    }

    public string Text { set { text.text = value;} }
    private bool pause;

    public bool Pause
    {
        get { return pause; }
        set 
        { 
            pause = value;
            if (pause)
            {
                StopAllCoroutines();
            }
            else
            {
                StartCoroutine(Countdown());
            }
        }
    }
}
