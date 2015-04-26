using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    public void Load(string thisSceneName)
    {
        Application.LoadLevel(thisSceneName);
    }

    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
