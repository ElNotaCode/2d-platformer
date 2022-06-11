using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//@Author: Eloi Martorell Martin

public class PlayerController : MonoBehaviour
{
    //Velocidad y capacidad de salto.
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;
    //Aqui referenciaremos al animator que tiene player.
    public Animator animator;

    //Para mirar si est� en el suelo.
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //Saltos extras.
    private int extraJumps;
    public int extraJumpsValue;

    //Modificadores de gravedad.
    public float fallMultiplayer;
    public float lowJumpMultiplier;

    public float torque;

    //Sonidos.
    public AudioSource walkSoundEffect;
    public AudioSource firstJumpSoundEffect;
    public AudioSource secondJumpSoundEffect;

    //Particulas.
    public ParticleSystem dust;

    private void OnDrawGizmos()
    {
        //Dibuja el ground check, gracias Raul.
        Gizmos.DrawWireSphere(groundCheck.transform.position, checkRadius);
    }

    private void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Ground check.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //Moverse.
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(moveInput));

        //Rotar el sprite depndiendo de la direccion.
        //TODO: Cambiar esto a la forma correcta https://www.youtube.com/watch?v=Cr-j7EoM8bg
        if (moveInput > 0)
        {
            gameObject.transform.localScale = new Vector3(1,1,1);
        }
        
        if(moveInput < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        if(moveInput != 0 && isGrounded)
        {
            if (!walkSoundEffect.isPlaying)
            {
                walkSoundEffect.Play();
            }

            dust.Play();

        }
        else
        {
            dust.Stop();
        }

    }

    private void Update()
    {
        //Debug.Log("Estado animator: " + animator.GetBool("isJumping"));
        //Detectar si est� en el suelo.
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
            animator.SetBool("isJumping", false);
        }
        else
        {
            if (animator.GetBool("isJumping") == false)
            {
                //Solo lo va a pasar a true una vez.
                animator.SetBool("isJumping", true);
            }
            
        }

        //Saltar y dar saltos extras.
        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            firstJumpSoundEffect.Play();
            
        }
        else if (Input.GetButton("Jump") && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            secondJumpSoundEffect.Play();
        }

        //MODIF Gravedad
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

        //Rotar.
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
