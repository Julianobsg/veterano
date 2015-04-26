using UnityEngine;
using System.Collections;

public class SetPanelActiveStatus : MonoBehaviour
{
    public GameObject panel;
    public bool status;

    public void SetStatus()
    {
        panel.SetActive(status);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        SetStatus();
    }
}
