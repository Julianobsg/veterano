using UnityEngine;
using System.Collections;

public class SetPlayerRunning : MonoBehaviour 
{
    [SerializeField]
    private bool setRunning = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        RunnerCharacter2D rc2D = other.GetComponent<RunnerCharacter2D>();
        if (rc2D != null)
        {
            rc2D.IsRunning = setRunning;
        }
    }
}
