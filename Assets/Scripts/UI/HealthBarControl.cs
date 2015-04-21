using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarControl : MonoBehaviour {

	public Image frontImage;

	public void SetBarPercent(float percent)
	{
		frontImage.fillAmount = percent;
	}
}
