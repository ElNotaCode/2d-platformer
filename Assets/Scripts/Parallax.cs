using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//@Author: Eloi Martorell Martin

public class Parallax : MonoBehaviour
{
    //https://www.youtube.com/watch?v=zit45k6CUMk&t=199s
    private float lenght;
    private float startPos;
    public GameObject camara;
    public float parallaxEffect;

    private float distance;
    private float temp;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        temp = (camara.transform.position.x * (1 - parallaxEffect));
        distance = (camara.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if(temp > startPos + lenght)
        {
            startPos += lenght;
        }else if(temp < startPos - lenght)
        {
            startPos -= lenght;
        }

    }
}
