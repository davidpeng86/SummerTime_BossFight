using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotate : MonoBehaviour
{
    public GameObject center;
    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;
    public int step = 9;
    public float speed = 0.01f;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Rolling()
    {
        Vector3 target = player.transform.position;
        Vector3 direction = target - center.transform.position;
        
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.z))
        {
            if (direction.x > 0) StartCoroutine("moveRight");
            if (direction.x < 0) StartCoroutine("moveLeft");
        }
        else
        {
            if (direction.z > 0) StartCoroutine("moveUp");
            if (direction.z < 0) StartCoroutine("moveDown");
        }
    }

    IEnumerator moveUp()
    {
        for (int i = 0; i < (90 / step); ++i)
        {
            transform.RotateAround(up.transform.position, Vector3.right, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = transform.position;
    }

    IEnumerator moveDown()
    {
        for (int i = 0; i < (90 / step); ++i)
        {
            transform.RotateAround(down.transform.position, Vector3.left, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = transform.position;
    }

    IEnumerator moveLeft()
    {
        for (int i = 0; i < (90 / step); ++i)
        {
            transform.RotateAround(left.transform.position, Vector3.forward, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = transform.position;
    }

    IEnumerator moveRight()
    {
        for (int i = 0; i < (90 / step); ++i)
        {
            transform.RotateAround(right.transform.position, Vector3.back, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = transform.position;
    }
}
