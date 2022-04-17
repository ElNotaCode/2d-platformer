using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody2D rb;

    public float speed;
    private float moveInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        //sacamos que bot�n se est� pulsando
        moveInput = Input.GetAxisRaw("Horizontal");
        //Vector2 y le dec�mos que actue sobre la y

        rb.velocity = new Vector2(moveInput * speed , rb.velocity.y);


    }

}
