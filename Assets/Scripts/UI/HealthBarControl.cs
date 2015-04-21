using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarControl : Manager {

	public Image frontImage;

    void Start ()
    {
        if (gm.stressBar == null)
        {
            gm.stressBar = this;
        }
        SetBarPercent(0);
    }

	public void SetBarPercent(float percent)
	{
		frontImage.fillAmount = percent;
	}
}
