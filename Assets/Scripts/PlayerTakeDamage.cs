using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    public float backVelocity = 15.0f;
    public float riseVelocity = 12.0f;
    public float flickTime = 5.0f;
    public float delay = 0.3f;

    private bool flick;
    private float flickDuration;
    private float flickCurTime = 0;
    private bool takeDamge;
    private GameObject boss;
    private Rigidbody rigid;
    private Material material;
    private Color originColor;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("boss");
        material = GameObject.Find("ghost").GetComponent<Renderer>().sharedMaterial;
        originColor = material.color;
        

        rigid = GetComponent<Rigidbody>();
        rigid.freezeRotation = true;
        flick = true;
        flickDuration = 0.0f;
    }

    void Update()
    {
        if (takeDamge)
        {
            if (flick)
            {
                material.SetColor("_Color", Color.red);
            }
            else
            {
                material.SetColor("_Color", originColor);
            }
            if(flickDuration > delay)
            {
                flickDuration = 0;
                flick = (flick ? false : true);
            }
            if(flickCurTime > flickTime)
            {
                flickDuration = 0;
                flickCurTime = 0;
                flick = true;
                takeDamge = false;
            }
            flickDuration += Time.deltaTime;
        }
        else
        {
            material.SetColor("_Color", originColor);
        }
        flickCurTime += Time.deltaTime;
    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 direction = (-transform.forward).normalized;
        if(collision.gameObject == boss)
        {
            rigid.velocity = direction * backVelocity;
            takeDamge = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            takeDamge = true;
            rigid.velocity = transform.up * riseVelocity;
        }
    }
}
