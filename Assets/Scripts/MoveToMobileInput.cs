using UnityEngine;
using System.Collections;
using TouchScript;

public class MoveToMobileInput : MonoBehaviour {

    MoveToCharacter2D mc;

	void Start () 
    {
        mc = GetComponent<MoveToCharacter2D>();
	}



    private void OnEnable()
    {
        if (TouchManager.Instance != null)
        {
            TouchManager.Instance.TouchesBegan += TouchStart;
        }
    }
    private void OnDisable()
    {
        if (TouchManager.Instance != null)
        {
            TouchManager.Instance.TouchesBegan -= TouchStart;
        }
    }


    private void TouchStart(object sender, TouchEventArgs e)
    {
        mc.MoveTo(e.Touches[0].Position);
    }

}
