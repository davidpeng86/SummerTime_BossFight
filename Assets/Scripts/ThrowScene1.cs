using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowScene1 : MonoBehaviour
{
    public Rigidbody skull;
    public Transform holder;
    public float force;

    Animator animator;
    Vector3 shootDir;
    bool isShoot = false;
    bool returnBall = false;
    float time = 0f;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isShoot)
            {
                Vector2 mousePosition = Input.mousePosition;

                animator.Play("Throw_new");
                skull.transform.parent = null;
                skull.transform.GetComponent<TrailRenderer>().enabled = true;
                skull.isKinematic = false;
                skull.AddForce(transform.forward * force, ForceMode.Impulse);
                isShoot = true;
                skull.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            }
            else
            {
                returnBall = true;
                skull.collisionDetectionMode = CollisionDetectionMode.Discrete;
                time = Time.time;
            }
        }
        if (returnBall)
        {
            skull.isKinematic = true;
            if (Vector3.Distance(skull.position, holder.position) > 0.1f)
            {
                animator.Play("Get_new");
                skull.transform.position = Vector3.Lerp(skull.position,
                                            holder.position, (Time.time - time) / 1);
            }
            else
            {
                skull.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                skull.transform.GetComponent<TrailRenderer>().enabled = false;
                skull.transform.parent = holder;
                isShoot = false;
                returnBall = false;
            }
        }
    }

}
