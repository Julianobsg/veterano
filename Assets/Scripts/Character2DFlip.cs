using UnityEngine;
using System.Collections;

public class Character2DFlip : MonoBehaviour {
    private bool facingRight = true; // For determining which way the player is currently facing.
    private Transform myTransform;

    // Use this for initialization
    void Start()
    {
        myTransform = transform;
    }
    public void CheckFlip(float move)
    {
            // If the input is moving the player right and the player is facing left...
        if (move > 0 && !facingRight)
            // ... flip the player.
            Flip();
            // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && facingRight)
            // ... flip the player.
            Flip();
    }


    private void Flip()
    {
        facingRight = !facingRight;
        if (facingRight)
        {
            transform.localEulerAngles = new Vector3(0, 90, 0);
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 270, 0);
        }
    }
}
