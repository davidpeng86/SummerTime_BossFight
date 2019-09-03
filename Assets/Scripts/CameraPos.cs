using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    public int rotSpeed;
    bool turnable = true;
    Vector3 pos,dir;
    bool rotLeft = false,rotRight = false;
    void Awake(){
        pos = transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(turnable){
            if(Input.GetKeyDown(KeyCode.Q)){
                turnable = false;
                rotLeft = true;
                dir = transform.right;
            }
            if(Input.GetKeyDown(KeyCode.E)){
                rotRight = true;
                turnable = false;
                dir = -transform.right;
            }
        }
        if(rotLeft){
            if(transform.rotation != Quaternion.Euler(dir)){
                Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, rotSpeed*Time.deltaTime, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDir);
                if(Vector3.Distance(transform.forward, dir) <= 0.0003f){  
                    turnable = true;
                    rotLeft = false;
                }
            }
            
        }
        if(rotRight){
            if(transform.rotation != Quaternion.Euler(dir)){
                Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, rotSpeed*Time.deltaTime, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDir);
                if(Vector3.Distance(transform.forward, dir) <= 0.0003f){
                    turnable = true;
                    rotRight = false;
                }
            }
        }
    }
    void LateUpdate(){
        transform.position = pos;
    }

    void FaceDir( Vector3 dir){
        if(transform.rotation != Quaternion.Euler(dir)){
            Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, rotSpeed*Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }
}
