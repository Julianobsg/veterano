using UnityEngine;
using System.Collections;

public class OpenDialogue : MonoBehaviour 
{
    public GameObject dialogue;

    void Awake ()
    {
        dialogue.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        dialogue.SetActive(true);
    }
}
