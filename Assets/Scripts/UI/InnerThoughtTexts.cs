using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InnerThoughtTexts : Manager
{
    public List<string> texts;
    private Text uiText;
    private int actualText;
    
	void Start () 
    {
        uiText = GetComponent<Text>();
        ThoughtText = texts[0];
	}
	
	void Update () 
    {
        if (Input.anyKeyDown)
        {
            actualText++;
            if (actualText < texts.Count)
            {
                ThoughtText = texts[actualText];
            }
            else
            {
                GameObject.FindGameObjectWithTag("Player").
                    GetComponent<RunnerCharacter2D>().IsRunning = true;
                gameObject.transform.parent.gameObject.SetActive(false);
                gm.Pause = false;
            }
        }
	}

    public string ThoughtText { get { return uiText.text; } set { uiText.text = value; } }
}
