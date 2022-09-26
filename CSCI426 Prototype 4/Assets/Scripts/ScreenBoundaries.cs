using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundaries : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -4.5f)
        {
            transform.position = new Vector3(transform.position.x, -4.5f, 0);
        }
        else if(transform.position.y >= 4.5)
        {
            transform.position = new Vector3(transform.position.x, 4.5f, 0);
        }

        if (transform.position.x >= 8.3f)
        {
            transform.position = new Vector3(8.3f, transform.position.y, 0);
        }
        else if(transform.position.x <= -8.3f)
        {
            transform.position = new Vector3(-8.3f, transform.position.y, 0);
        }

        transform.Translate(Vector3.right * Time.deltaTime * speed * Input.GetAxis("Horizontal"));
        transform.Translate(Vector3.up * Time.deltaTime * speed * Input.GetAxis("Vertical"));
    }
}
