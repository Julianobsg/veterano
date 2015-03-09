using UnityEngine;
using System.Collections;
using TouchScript;
public class RunnerMobileInput : MonoBehaviour 
{
    public float direction = 1;
    public float minimumThreshold = 1;
    RunnerCharacter2D rc;

    private Vector3 touchStartPosition;

    private void OnEnable()
    {
        if (TouchManager.Instance != null)
        {
            TouchManager.Instance.TouchesBegan += TouchStart;
            TouchManager.Instance.TouchesEnded += TouchEnded;
        }
    }



    private void OnDisable()
    {
        if (TouchManager.Instance != null)
        {
            TouchManager.Instance.TouchesBegan -= TouchStart;
            TouchManager.Instance.TouchesEnded -= TouchEnded;
        }
    }

    private void TouchStart(object sender, TouchEventArgs e)
    {
        touchStartPosition = e.Touches[0].Position;
    }

    private void TouchEnded(object sender, TouchEventArgs e)
    {
        //Debug.Log(Vector3.Distance(touchStartPosition, e.Touches[0].Position));
        if (Vector3.Distance(touchStartPosition, e.Touches[0].Position) > minimumThreshold)
        {
            direction *= -1;
        }
        else
        {
            rc.Move(direction, true);
        }

    }

    void Start()
    {
        rc = GetComponent<RunnerCharacter2D>();
    }

    void FixedUpdate()
    {
        rc.Move(direction, false);
    }
}
