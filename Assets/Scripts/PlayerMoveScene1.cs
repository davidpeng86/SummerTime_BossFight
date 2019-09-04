using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScene1 : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(transform.up, -rotateSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(transform.up, rotateSpeed);
        }
    }
}
