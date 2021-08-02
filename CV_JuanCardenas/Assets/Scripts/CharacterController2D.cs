using UnityEngine;
using UnityEngine.Events;
public class CharacterController2D : MonoBehaviour
{
    [SerializeField] float jumpForce = 400f;                          // Amount of force added when the player jumps.
    [Range(0, .3f)] [SerializeField] float movementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] bool airControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] LayerMask whatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] Transform groundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] Transform ceilingCheck;                          // A position marking where to check for ceilings

    const float groundedRadius = 0.2f; // Radius of the overlap circle to determine if grounded
    bool grounded;            // Whether or not the player is grounded.
    const float ceilingRadius = 0.2f; // Radius of the overlap circle to determine if the player can stand up
    Rigidbody2D rb2D;
    bool facingRight = true;  // For determining which way the player is currently facing.
    Vector3 velocity = Vector3.zero;

    [Header("Events")]
    [Space]
    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();

        //Crear evento de aterrizaje (nos ayudará a la hora de sincronizar la animación)
        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    private void FixedUpdate()
    {
        //bool wasGrounded = grounded;
        //grounded = false;

        ////CORREGIR POR POSIBLE ESFUERZO EXTRA
        //Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        //for (int i = 0; i < colliders.Length; i++)
        //{
        //    if (colliders[i].gameObject != gameObject)
        //    {
        //        grounded = true;
        //        if (!wasGrounded)
        //            OnLandEvent.Invoke();
        //    }
        //}
        bool left = Physics2D.Raycast(new Vector2(groundCheck.position.x-0.2f,groundCheck.position.y), -Vector2.up, 0.2f, whatIsGround);
        bool center = Physics2D.Raycast(groundCheck.position, -Vector2.up, 0.2f, whatIsGround);
        bool right = Physics2D.Raycast(new Vector2(groundCheck.position.x + 0.2f, groundCheck.position.y), -Vector2.up, 0.2f, whatIsGround);
        if (left||center||right)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }


    public void Move(float move, bool jump)
    {
     
        //only control the player if grounded or airControl is turned on
        if (grounded || airControl)
        {
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, rb2D.velocity.y);
            // And then smoothing it out and applying it to the character
            rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, targetVelocity, ref velocity, movementSmoothing);

            //Flip Player
            if (move > 0 && !facingRight)
            {
                Flip();
            }
            else if (move < 0 && facingRight)
            {
                
                Flip();
            }
        }
        // If the player should jump...
        if (grounded && jump)
        {
            // Add a vertical force to the player.
            grounded = false;
            rb2D.AddForce(new Vector2(0f, jumpForce));
        }
    }


    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
