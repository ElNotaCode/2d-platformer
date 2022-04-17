using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    private float moveInput;

    double boost;
    float boostFloat;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boost = 0;

    }

    private void FixedUpdate()
    {
        //sacamos que botón se está pulsando
        moveInput = Input.GetAxisRaw("Horizontal");
        //Vector2 y le decímos que actue sobre la y

        //TO DO: Arreglar codigo boosting movement

        if (moveInput != 0)
        {

            if (boost != 3)
            {
                boost = boost + 0.1;
                boostFloat = ToSingle(boost);

                rb.velocity = new Vector2(moveInput * (speed + boostFloat), rb.velocity.y);
                Debug.Log(speed + boostFloat);
            }
            else
            {
                rb.velocity = new Vector2(moveInput * (speed + 3), rb.velocity.y);
                Debug.Log("MaxSpeed!");
            }


        }
        else
        {
            boost = 0;
        }

    }
    public static float ToSingle(double value)
    {
        return (float)value;
    }
}
