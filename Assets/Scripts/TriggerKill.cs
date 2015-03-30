using UnityEngine;


public class TriggerKill : Manager
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            gm.Die();
    }
}
