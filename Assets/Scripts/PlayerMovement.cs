using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public int speed;
    float rotateSpeed = 15f;
    public Transform moveDirRef;
    Transform movePivot;
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
            if(moveDirRef != null){
                rb.velocity = moveDirRef.forward*speed;
            }
            else{ 
                rb.velocity = transform.forward*speed;
            }
            
        }
        if(Input.GetKey(KeyCode.S)){
            FaceDir(-Vector3.forward);
            if(moveDirRef != null){
                rb.velocity = -moveDirRef.forward*speed;
            }
            else{ 
                rb.velocity = transform.forward*speed;
            }
        }
        if(Input.GetKey(KeyCode.A)){
            FaceDir(Vector3.left);
            if(moveDirRef != null){
                rb.velocity = -moveDirRef.right*speed;
            }
            else{ 
                rb.velocity = transform.forward*speed;
            }
        }
        if(Input.GetKey(KeyCode.D)){
            FaceDir(Vector3.right);
            if(moveDirRef != null){
                rb.velocity = moveDirRef.right*speed;
            }
            else{ 
                rb.velocity = transform.forward*speed;
            }
        }
    }

    void FaceDir( Vector3 dir){
        if(transform.rotation != Quaternion.Euler(dir)){
            Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, rotateSpeed*Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }
}
