using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public Transform hand;
    public GameObject throwObj;
    public int throwPow = 3;
    Rigidbody objRb;
    // Start is called before the first frame update
    void Start()
    {
        objRb = throwObj.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ToThrow(){
        objRb. isKinematic = false;
        objRb.transform.parent = null;
        objRb.AddForce(transform.forward * throwPow, ForceMode.Impulse);
    }
}
