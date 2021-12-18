using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    public float speed;
    private bool flip, walkingLeft, walkingRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if(!PorkchopPanel.PorkPanelActive && !SkrejalPanel.SkrejalPanelActive)
        {
            if(walkingRight)
            {
                rb.MovePosition(rb.position + Vector2.right * speed);
            }
            if(walkingLeft)
            {
                rb.MovePosition(rb.position + Vector2.left * speed);
            }
        }
    }

    public void WalkLeft()
    {
        walkingLeft = true;

        sprite.flipX = true;
        animator.SetBool("IsMove", true);
    }

    public void WalkRight()
    {
        walkingRight = true;

        sprite.flipX = false;
        animator.SetBool("IsMove", true);
    }

    public void NoWalk()
    {
        walkingLeft = false;
        walkingRight = false;

        animator.SetBool("IsMove", false);
    }
}
