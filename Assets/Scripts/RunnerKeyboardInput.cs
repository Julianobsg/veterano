using UnityEngine;
using System.Collections;

public class RunnerKeyboardInput : MonoBehaviour
{
    RunnerCharacter2D rc;

    void Start()
    {
        rc = GetComponent<RunnerCharacter2D>();
    }

    void Update ()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rc.Move(rc.direction, true);
        }
        if (rc.direction < 0 && Input.GetAxis("Horizontal") > 0)
        {
            rc.direction *= -1;
        }
        else if (rc.direction > 0 && Input.GetAxis("Horizontal") < 0)
        {
            rc.direction *= -1;
        }
    }


}
