using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Character2DFlip))]
public class MoveToCharacter2D : MonoBehaviour 
{
    private bool moving = false;
    [SerializeField]
    private float maxSpeed = 10f; // The fastest the player can travel in the x axis.

    private Vector2 target;
    private Animator anim; // Reference to the player's animator component.
    private Transform myTransform;

    private Camera mainCamera;

    private Character2DFlip characterFlip;

    private Vector3 lastPosition;
	void Start () 
    {
        anim = GetComponent<Animator>();
        myTransform = transform;
        anim.SetBool("Ground", true);
        mainCamera = Camera.main;
        characterFlip = GetComponent<Character2DFlip>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (moving)
        {
            float move = MoveDirection();

            //Debug.Log("direction: " + direction + " target: " + target + " " + move);
            anim.SetFloat("Speed", Mathf.Abs(move));

            // Move the character
            rigidbody2D.velocity = new Vector2(move * maxSpeed, 0);
            if (Vector2.Distance(myTransform.position, target) <= 0.3 || move == 0 || lastPosition == myTransform.position)
            {
                moving = false;
            }
            lastPosition = myTransform.position;
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            anim.SetFloat("Speed", 0);
        }
	}

    private float MoveDirection()
    {
        float move = 0;

        if (target.x > myTransform.position.x)
        {
            move = 1;
        }
        else if (target.x < myTransform.position.x)
        {
            move = -1;
        }

        characterFlip.CheckFlip(move);

        return move;

    }

    public void MoveTo(Vector2 targetPosition)
    {
        lastPosition = Vector3.zero;
        moving = true;
        targetPosition = mainCamera.ScreenToWorldPoint(targetPosition);
        target = new Vector2(targetPosition.x, myTransform.position.y);
    }

    public bool IsMoving { get { return moving; } }
}
