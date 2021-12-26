using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private AllahFightCollider allahCollider;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    public float speed;
    private bool flip, walkingLeft, walkingRight;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        PlayerData.LoadData();
    }

    void FixedUpdate()
    {
        if(!PorkchopPanel.PorkPanelActive && !SkrejalPanel.SkrejalPanelActive && !allahCollider.Collided)
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

    public void NoRight()
    {
        walkingRight = false;

        animator.SetBool("IsMove", false);
    }

    public void NoLeft()
    {
        walkingLeft = false;

        animator.SetBool("IsMove", false);
    }
}
