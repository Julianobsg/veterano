using UnityEngine;
using System.Collections;

public class OnTriggerChangeScene : MonoBehaviour 
{
	public string sceneName
		;
	void OnTriggerEnter2D(Collider2D other) 
	{
		Application.LoadLevel(sceneName);
	}
}
