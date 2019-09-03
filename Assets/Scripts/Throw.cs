using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public Rigidbody skull;
    public Transform holder;
    public float force;
    public Transform shootDir;
    bool isShoot = false;
    bool returnBall = false;
    float time = 0f;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(!isShoot){
                skull.transform.parent = null;
                skull.transform.GetComponent<TrailRenderer>().enabled = true;
                skull.isKinematic = false;
                skull.AddRelativeForce(shootDir.forward * force, ForceMode.Impulse);
                print(skull.transform.rotation);
                isShoot = true;
                skull.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            }
            else{
                returnBall = true;
                skull.collisionDetectionMode = CollisionDetectionMode.Discrete;
                time = Time.time;
            }
        }
        if(returnBall){
            skull.isKinematic = true;
                if(Vector3.Distance(skull.position,holder.position)>0.1f){
                    skull.transform.position = Vector3.Lerp(skull.position,
                                                holder.position, (Time.time - time) / 1);
                }
                else
                {
                    skull.transform.GetComponent<TrailRenderer>().enabled = false;
                    skull.transform.parent = holder;
                    isShoot = false;
                    returnBall = false;
                }
            }
    }

}
