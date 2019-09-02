using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRiseStraight : MonoBehaviour
{
    enum State { Idle, Overlap};

    public float maxHeight = 4.0f;
    public float riseSpeed = 1.0f;
    public float maxTime = 3;

    private float initHeight;
    private float curHeight;
    private float curTime;
    private State state;
    // Start is called before the first frame update
    void Start()
    {
        initHeight = transform.position.y;
        state = State.Overlap;
    }

    // Update is called once per frame
    void Update()
    {
        updateState();
        
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

    private void updateState()
    {
        curTime += Time.deltaTime;
        if (curTime >= maxTime)
        {
            Destroy(this.transform.parent.gameObject);
        }
        else if (curTime >= maxTime / 2)
        {
            state = State.Idle;
        }
    }
}
