using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRiseStraight : MonoBehaviour
{
    enum State { Idle, Overlap};

    public float maxHeight = 4.0f;
    public float riseSpeed = 1.0f;

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

        if (Input.GetMouseButton(0)) state = State.Overlap;
        else state = State.Idle;

        curHeight = transform.position.y - initHeight;
        
        if(state == State.Overlap && curHeight < maxHeight)
        {
            transform.position += transform.up * riseSpeed * Time.deltaTime;
        }
        else if(state == State.Idle && curHeight > 0)
        {
            transform.position -= transform.up * riseSpeed * Time.deltaTime;
        }
    }
}
