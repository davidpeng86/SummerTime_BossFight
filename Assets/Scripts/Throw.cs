using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public Rigidbody skull;
    public Transform holder;
    public float force;
    
    bool isShoot = false;
    bool returnBall = false;
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {

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
                skull.AddForce(transform.forward * force, ForceMode.Impulse);
                isShoot = true;
            }
            else{
                returnBall = true;
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
