using UnityEngine;
using System.Collections;

public class SetPlayerRunning : Manager 
{
    [SerializeField]
    private bool setRunning = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        RunnerCharacter2D rc2D = other.GetComponent<RunnerCharacter2D>();
        if (rc2D != null)
        {
            gm.Pause = !setRunning;
            rc2D.IsRunning = setRunning;
        }
    }
}
