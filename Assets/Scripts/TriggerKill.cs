using UnityEngine;


public class TriggerKiller : Manager
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            gm.Die();
    }
}
