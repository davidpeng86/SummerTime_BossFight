using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRiseCurve : MonoBehaviour
{
    enum State { Idle, Overlap };

    public float maxHeight = 4.0f;
    public float riseSpeed = 1.0f;
    public float curveRate = 0.01f;

    private float r = 0;
    private float initHeight;
    private float curHeight;
    private State state;
    // Start is called before the first frame update
    void Start()
    {
        initHeight = transform.position.y;
        state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        curHeight = transform.position.y - initHeight;
        r = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position);

        if (state == State.Overlap && curHeight <= maxHeight - (r * curveRate))
        {
            transform.position += transform.up * riseSpeed * Time.deltaTime;
        }
        else if (state == State.Idle && curHeight >= 0)
        {
            transform.position -= transform.up * riseSpeed * Time.deltaTime;
        }
    }

    public void Attack()
    {

    }
}
