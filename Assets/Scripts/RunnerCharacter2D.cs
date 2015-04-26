using UnityEngine;

[RequireComponent(typeof(Character2DFlip))]
public class RunnerCharacter2D : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 10f; // The fastest the player can travel in the x axis.
    [SerializeField] 
    private float jumpForce = 400f; // Amount of force added when the player jumps.	

    [SerializeField] 
    private bool airControl = false; // Whether or not a player can steer while jumping;
    [SerializeField] 
    private LayerMask whatIsGround; // A mask determining what is ground to the character

    [SerializeField]
    private Transform groundCheck; // A position marking where to check if the player is grounded.
    [SerializeField] 
    private float groundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool grounded = false; // Whether or not the player is grounded.
    private Animator anim; // Reference to the player's animator component.
    private Rigidbody2D myRigidbody2D;
    private Character2DFlip characterFlip;
    public float direction;

    private void Awake()
    {
        // Setting up references.
        anim = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        characterFlip = GetComponent<Character2DFlip>();
        direction = 1.0f;
    }


    private void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
        anim.SetBool("Ground", grounded);

        anim.SetFloat("vSpeed", myRigidbody2D.velocity.y);
        Move(direction, false);
    }

    public void Move(float move, bool jump)
    {


        //only control the player if grounded or airControl is turned on
        if (grounded || airControl)
        {

            // The Speed animator parameter is set to the absolute value of the horizontal input.
            anim.SetFloat("Speed", Mathf.Abs(move));

            // Move the character
            myRigidbody2D.velocity = new Vector2(move * maxSpeed, myRigidbody2D.velocity.y);

            characterFlip.CheckFlip(move);
        }
        // If the player should jump...
        if (grounded && jump && anim.GetBool("Ground"))
        {
            // Add a vertical force to the player.
            grounded = false;
            anim.SetBool("Ground", false);
            myRigidbody2D.AddForce(new Vector2(0f, jumpForce));
        }
    }

    public float MaxSpeed
    {
        get { return maxSpeed; }
        set { maxSpeed = value; }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheck.position, groundedRadius);
    }
}
