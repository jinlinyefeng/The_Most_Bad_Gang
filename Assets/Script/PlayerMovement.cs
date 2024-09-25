using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private LayerMask jumpableGround;

    [SerializeField]
    [Tooltip("跳跃力大小")]
    public float jumpForce = 7f;
    [Tooltip("重力大小")]
    public float gravityForce = -2f;
    [Tooltip("移动速度")]
    public float moveSpeed = 7f;
    private float dirX = 0f;

    private Rigidbody2D rb; //玩家的刚体组件
    private SpriteRenderer sprite; //人物画布，用于反转画布
    private Animator animator; //当前动画变量
    private BoxCollider2D coll;

    [Header("音效")]
    [Tooltip("跳跃音效")] public AudioClip jumpSound;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        //获取组件
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); 
        coll = GetComponent<BoxCollider2D>();
        jumpSoundEffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    /// <summary>
    /// 跳跃
    /// </summary>
    public void Jump()
    {

        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            Debug.Log("跳起来了");
            jumpSoundEffect.clip = jumpSound;
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    /// <summary>
    /// 移动
    /// </summary>
    public void Movement()
    {
        Debug.Log("开始移动了");
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        UpdateAnimationState();
    }

    /// <summary>
    /// 更新动画
    /// </summary>
    public void UpdateAnimationState()
    {
        MovementState state;
        Debug.Log(dirX);
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false; //是否反转人物画布
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f) 
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);
    }

    /// <summary>
    /// 判断是否着地
    /// </summary>
    /// <returns></returns>
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}