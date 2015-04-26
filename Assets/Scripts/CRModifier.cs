using UnityEngine;
using System.Collections;

public class CRModifier : Manager 
{
    public float crAdded;

    public void OnTriggerEnter2D(Collider2D other)
    {
        gm.CR += crAdded;
    }
}
