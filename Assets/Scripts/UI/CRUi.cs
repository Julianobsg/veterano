using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CRUi : MonoBehaviour 
{
    private Text crUiText;

    void Awake ()
    {
        crUiText = GetComponent<Text>();
    }

    public float CR
    {
        set { crUiText.text = "CR: " + value.ToString(); }
    }
}
