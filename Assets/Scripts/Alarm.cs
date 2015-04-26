using UnityEngine;
using System.Collections;

public class Alarm : Manager
{

    public void OnTriggerEnter2D(Collider2D other)
    {
        gm.LevelCompleted();
    }
}
