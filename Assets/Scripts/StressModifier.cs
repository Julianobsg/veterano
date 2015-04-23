using UnityEngine;
using System.Collections;

public class StressModifier : Manager 
{
    public int stressAdded;

    public void OnTriggerEnter2D(Collider2D other)
    {
        gm.Stress += stressAdded;
    }
}
