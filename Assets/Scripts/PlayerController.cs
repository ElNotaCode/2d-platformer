using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//@Author: Eloi Marotrell Martin

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;
    //aqui referenciaremos al anumator que tiene player
    public Animator animator;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    public float fallMultiplayer;
    public float lowJumpMultiplier;

    public float torque;

    private void OnDrawGizmos()
    {
        //dibuja el ground check
        Gizmos.DrawWireSphere(groundCheck.transform.position, checkRadius);
    }

    private void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //Moverse
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        //chapuza para que salte la animaci�n de caminar, seguir viendo:
        //https://www.youtube.com/watch?v=hkaysu1Z-N8&t=232s
        animator.SetFloat("speed", Mathf.Abs(moveInput * speed));

    }

    private void Update()
    {
        //Saltar
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetButton("Jump") && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        //si estamos cayendo: v < 0
        //si estamos saltando v > 0
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplayer - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) //si pulsamos r�pido
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.forward * torque * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.forward * - torque * Time.deltaTime);
        }

    }
}
