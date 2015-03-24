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
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = myTransform.localScale;
        theScale.x *= -1;
        myTransform.localScale = theScale;
    }
}
