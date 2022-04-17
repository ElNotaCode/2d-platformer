using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    //para tener un selector en el jumpVelocity, es bastante útil
    [Range(1, 10)]
    public float JumpVelocity;

    private Rigidbody2D rb;

    //variables para detectar si está en el suelo
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    //sobre los nombres del botón:
    //You can see the definitions, and define your own, by using the Input Manager.
    //You can get to it from the main menu using Edit->Project Settings->Input.

    private void Start()
    {
        //Guardamos en rb el rigidbody del objeto
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * JumpVelocity;
        }

    }

}
