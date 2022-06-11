using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{

    //Velocidad de la camara
    public int cameraSpeed;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //moverse
        rb.velocity = new Vector2(1 * cameraSpeed, rb.velocity.y);
    }
}
