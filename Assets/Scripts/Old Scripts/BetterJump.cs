using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    //multiplicador de gravedad cuando nuestro personaje cae
    public float fallMultiplayer = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody2D rb;

    private void Awake()
    {
        Debug.Log("Jump.Awake() was called");
        //Guardamos en rb el rigidbody del objeto
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //si estamos cayendo: v < 0
        //si estamos saltando v > 0
        if (rb.velocity.y < 0)
        {
            //queremos aumentar nuestra gravedad
            //rb.velocity afecta a los dos vectores x y (x y z en caso que sea 3d)
            //como solo queremos afectar a uno usamos Vector2.up para afectar solo
            //al vertical, en cuanto al fallMultiplayer - 1 es porque unity ya aplica
            // 1 de gravedad y si queremos 2.5 hay que restarle uno que ya está aplicado
            //multiplicamos por deltaTime ya que queremos solo una fracción del segundo
            //del frame

            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplayer - 1) * Time.deltaTime;

        } else if(rb.velocity.y > 0 && !Input.GetButton("Jump")) //si pulsamos rápido
            {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
