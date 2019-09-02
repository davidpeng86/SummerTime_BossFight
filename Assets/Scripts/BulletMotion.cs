using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMotion : MonoBehaviour
{
    Rigidbody rb;
    public int force = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        print("Collision");
        ContactPoint contactPoint = other.GetContact(0);
        Vector3 curDir = Vector3.forward;
        Vector3 newDir = Vector3.Reflect(curDir, contactPoint.normal);
        // transform.rotation = Quaternion.FromToRotation(curDir, newDir);
        // print(rb.GetPointVelocity(transform.position));
        rb.AddForce(contactPoint.normal * force/2, ForceMode.Impulse);
    }
}
