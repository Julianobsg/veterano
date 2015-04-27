using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    public int levelID = 0;
    private const string TIME_DEATH = "Você acordou atrasado, perdeu a prova e reprovou!";
    private const string DEATH = "Você acordou atrasado, perdeu a prova e reprovou!";
    private const string LOW_CR_DEATH = "Sua nota está baixa, você reprovou.";
    public const string GAME_MANAGER = "GameController";
    public Timer timer;
    public HealthBarControl stressBar;
    public CRUi crUi;

    [SerializeField]
    private float stress = 0;

    [SerializeField]
    private int timeInSeconds = 60;

    [SerializeField]
    private float actualCR = 2.0f;

    [SerializeField]
    private DeathFeedBack deathPanel;

    [SerializeField]
    private GameObject winPanel;

    void Start ()
    {
        if (crUi == null)
        {
            crUi = GameObject.FindGameObjectWithTag("CR").GetComponent<CRUi>();
        }
        crUi.CR = actualCR;
    }

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

    public void LevelCompleted ()
    {
        if (actualCR < 1)
        {
            DeathFeedback(LOW_CR_DEATH);
        }
        else
        {
            WinFeedback();
        }
    }

    private void WinFeedback()
    {
        PlayerPrefs.SetInt("level" + levelID.ToString(), 1);
        Pause = true;
        winPanel.SetActive(true);
    }

    public void Die()
    {
        if (timeInSeconds <= 0)
        {
            DeathFeedback(TIME_DEATH);
        }
        else
        {
            DeathFeedback(DEATH);
        }
    }

    private void DeathFeedback(string feedback)
    {
        Pause = true;
        deathPanel.gameObject.SetActive(true);
        deathPanel.feedback = feedback;
    }

    public float CR 
    {
        get 
        {
            return actualCR;
        }
        set 
        {
            actualCR = value;
            if (actualCR > 4)
            {
                actualCR = 4;
            }
            if (actualCR < 0)
            {
                actualCR = 0;
            }
            crUi.CR = actualCR;
        } 
    }

    public bool Pause
    {
        set 
        {
            timer.Pause = value;
        }
    }
}
