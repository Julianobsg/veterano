using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour 
{
    protected GameManager gm;

    void Awake ()
    {
        gm = GameObject.FindGameObjectWithTag(GameManager.GAME_MANAGER).GetComponent<GameManager>();
    }
}
