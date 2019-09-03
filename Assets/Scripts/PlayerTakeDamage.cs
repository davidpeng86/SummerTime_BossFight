using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    public float backVelocity = 15.0f;
    public float riseVelocity = 12.0f;
    private GameObject boss;
    private Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("boss");
        rigid = GetComponent<Rigidbody>();
        rigid.freezeRotation = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 direction = (-transform.forward).normalized;
        if(collision.gameObject == boss)
        {
            rigid.velocity = direction * backVelocity;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            rigid.velocity = transform.up * riseVelocity;
        }
    }
}
