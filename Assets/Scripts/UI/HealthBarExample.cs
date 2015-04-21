using UnityEngine;
using System.Collections;

public class HealthBarExample : MonoBehaviour {

	public HealthBarControl healthBarControl;

	float currentHealth = 1f;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine(DecreaseHealth());
	}
	
	IEnumerator DecreaseHealth()
	{
		yield return new WaitForSeconds(1);
		currentHealth -= 0.01f;

		healthBarControl.SetBarPercent(currentHealth);

		if(currentHealth >= 0)
			StartCoroutine(DecreaseHealth());
	}
}
