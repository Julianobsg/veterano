using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathFeedBack : MonoBehaviour 
{
    [SerializeField]
    private Text feedbackText;

    public string feedback
    {
        set { feedbackText.text = value; }
    }
    
}
