using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public int speed;
    float rotateSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.W)){
            FaceDir(Vector3.forward);
            rb.velocity = Vector3.forward*speed;
        }
        if(Input.GetKey(KeyCode.S)){
            FaceDir(-Vector3.forward);
            rb.velocity = -Vector3.forward*speed;
        }
        if(Input.GetKey(KeyCode.A)){
            FaceDir(Vector3.left);
            rb.velocity = transform.forward*speed;
        }
        if(Input.GetKey(KeyCode.D)){
            FaceDir(Vector3.right);
            rb.velocity = transform.forward*speed;
        }
    }

    void FaceDir( Vector3 dir){
        if(transform.rotation != Quaternion.Euler(dir)){
            Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, rotateSpeed*Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }
}
