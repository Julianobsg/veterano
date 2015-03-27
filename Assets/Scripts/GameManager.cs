using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    public const string GAME_MANAGER = "GameController";

    public int timeInSeconds = 60;
    public string ActualTime 
    { 
        get 
        {
            string time = string.Format("{0:D2}:{1:D2}",
                timeInSeconds / 60,
                timeInSeconds % 60);
            return time; 
        }
    }

    public void Die()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }
}
