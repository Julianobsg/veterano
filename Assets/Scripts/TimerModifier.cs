using UnityEngine;
using System.Collections;

public class TimerModifier : Manager 
{
    public int timeAdded;

    public void OnTriggerEnter2D(Collider2D other)
    {
        gm.timeInSeconds += timeAdded;
    }
}
