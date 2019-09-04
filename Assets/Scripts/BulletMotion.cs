using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BulletMotion : MonoBehaviour
{
    Rigidbody rb;
    public int force = 0;
    public float shakeAmount = 0.5f;
    public Transform cubeOrigin;
    Vector3 cubeReturnPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cubeReturnPoint = cubeOrigin.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        ContactPoint contactPoint = other.GetContact(0);
        if(other.gameObject.tag != "Player"){
            Vector3 curDir = Vector3.forward;
            Vector3 newDir = Vector3.Reflect(curDir, contactPoint.normal);
            Vector3 shakeDir = Vector3.Normalize(transform.position - contactPoint.point);
            Transform shakee;
            Vector3 returnPos;
            if(other.transform.parent!= null && other.transform.parent.tag == "boss"){
                shakee = other.transform.parent;
                returnPos = cubeReturnPoint;
                shakeAmount = 2f;
            }
            else{
                shakee = other.transform;
                returnPos = shakee.position;
                shakeAmount = 4f;
                shakee.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            }

            if(shakee.gameObject.GetComponent<ObstacleEmission>()!= null){
                if(!shakee.gameObject.GetComponent<ObstacleEmission>().isDead){
                    shakee.DOMove(shakee.position-shakeDir*shakeAmount,0.25f).OnComplete(() =>
                                    shakee.DOMove(returnPos,0.1f).OnComplete(() =>
                                    shakee.gameObject.GetComponent<ObstacleEmission>().Bling()));
                }
                else{
                    shakee.DOMove(shakee.position-shakeDir*shakeAmount*0.6f,0.15f).OnComplete(() =>
                                    shakee.DOMove(returnPos,0.07f).OnComplete(() =>
                                    shakee.gameObject.GetComponent<ObstacleEmission>().Bling()));
                }
            }
            else{
                shakee.DOMove(shakee.position-shakeDir*shakeAmount,0.25f).OnComplete(() =>
                                shakee.DOMove(returnPos,0.1f).OnComplete(() =>
                                shakee.gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION")));
            }
        }
            rb.AddForce(contactPoint.normal * force, ForceMode.Impulse);
    }
    
}
