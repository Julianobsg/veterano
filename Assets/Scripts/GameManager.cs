using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    public const string GAME_MANAGER = "GameController";
    public Timer timer;
    public HealthBarControl stressBar;

    [SerializeField]
    private float stress = 0;

    [SerializeField]
    private int timeInSeconds = 60;

    public int TimeInSeconds
    {
        get { return timeInSeconds; }
        set
        {
            timeInSeconds = value;
            timer.Text = ActualTime; 
        }
    }
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


    public float Stress
    {
        get { return stress; }
        set 
        {
            stress = value; 
            stressBar.SetBarPercent(stress);
        }
    }


    public void Die()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }
}
