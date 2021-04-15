using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float maxSpeed = 5.0f;
    private Rigidbody2D rigid;
    private Animator anim;
    bool isGround = true;
    public Vector3 playerPos;
    private float jumpPower = 15.0f;
    public Transform groundChecker;
    public float groundRaius = 0.2f;
    public LayerMask groundLayer;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapCircle(groundChecker.position, groundRaius, groundLayer);

        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Move()
    {
        /*
        float posX = Input.GetAxis("Horizontal");
        anim.SetBool("isMove", false);
        if (posX != 0)
        {
            anim.SetBool("isMove", true);
            if (posX >= 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            transform.Translate(Mathf.Abs(posX) * Vector3.right * maxSpeed * Time.deltaTime);
        }
        playerPos = this.gameObject.transform.position;
        Debug.Log(playerPos);
        */
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        anim.SetBool("isMove", false);

        if (rigid.velocity.x > maxSpeed)
        {
            anim.SetBool("isMove", true);
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if(rigid.velocity.x < maxSpeed * (-1))
        {
            anim.SetBool("isMove", true);
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }
    }

    void Jump()
    {
        anim.SetBool("isJump", false);
        if (Input.GetKeyDown(KeyCode.W) && isGround)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isGround = false;
            anim.SetBool("isJump", true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            collision.gameObject.SetActive(false);
        }
        else if(collision.gameObject.tag == "open")
        {
        //    Debug.Log("test");
        //    anim.SetBool("isOpen", true);
        }
    }
}
