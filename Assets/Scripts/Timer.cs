using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : Manager {
    private Text text;

    void Start () 
    {
        StartCoroutine(Countdown());
        text = GetComponent<Text>();
        text.text = gm.ActualTime;
	}

    IEnumerator Countdown () 
    {
        yield return new WaitForSeconds(1);
        gm.timeInSeconds--;
        text.text = gm.ActualTime;
        if (gm.timeInSeconds > 0)
        {
            StartCoroutine(Countdown());
        }
        else
        {
            gm.Die();
        }
    }
}
