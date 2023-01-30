using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float HorizontalMove = 0f;
    private bool FacingRight = true;

    [Header("Player Movement Speed")]
    [Range(0, 10f)] public float speed = 1f;
    [Range(0, 16f)] public float jumpForce = 8f;

    [Header("Player Animation Settings")]
    public Animator animator;

    [Space]
    [Header("Ground Checker Settings")]
    public bool isGrounded = false;
    [Range(-5f, 5f)] public float checkGroundOffsetY = -1.8f;
    [Range(0, 5f)] public float checkGroundRadius = 0.3f;
    void Start()
    {
        // Take rigitbodty of Player 
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        HorizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("HorizontalMove", Mathf.Abs(HorizontalMove));

        if (isGrounded == false)
        {
            animator.SetBool("Jumping", true);
        }
        else
        {
            animator.SetBool("Jumping", false);
        }

        if (HorizontalMove < 0 && FacingRight)
        {
            Flip();
        }
        else if(HorizontalMove > 0 && !FacingRight)
        {
            Flip();
        }
    }

    
    private void FixedUpdate()
    {
        // velocity = direction * speed
        Vector2 targetVelocity = new Vector2(HorizontalMove * 10f, rb.velocity.y);
        rb.velocity = targetVelocity;

        CheckGround();
    }

    private void Flip()
    {
        FacingRight = !FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void CheckGround()
    {
        // Get a list of all Colliders that fall within a circular area.
        Collider2D[] colliders = Physics2D.OverlapCircleAll
            (new Vector2(transform.position.x, transform.position.y +
            checkGroundOffsetY), checkGroundRadius);
        if(colliders.Length > 1)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

}
