using UnityEngine;
using System.Collections;

public class UIMenuScripts : MonoBehaviour {

	public GameObject creditsCanvas;
	public GameObject levelSelectionCanvas;
	public GameObject[] levels;

	void Start()
	{
		creditsCanvas.SetActive(false);
		ActivatePlayableLevels();
		levelSelectionCanvas.SetActive(false);
	}

	void ActivatePlayableLevels()
	{
		for (int i = 1; i < levels.Length; i++)
		{
			levels[i].SetActive(PlayableLevel(i));
		}
	}

	public void LoadThisScene(string thisSceneName)
	{
		Application.LoadLevel(thisSceneName);
	}

	public void CreditsToggle()
	{
		creditsCanvas.SetActive(!creditsCanvas.activeSelf);
	}

	public void LevelSelectToggle()
	{
		levelSelectionCanvas.SetActive(!levelSelectionCanvas.activeSelf);
	}

	public bool PlayableLevel(int number)
	{
		if(PlayerPrefs.GetInt("level" + number.ToString(), 0) == 1)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}