using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRiseCurve : MonoBehaviour
{
    enum State { Prepare, Up, Down };

    public float maxHeight = 4.0f;
    public float riseSpeed = 1.0f;
    public float curveRate = 1.0f;
    public float maxTime = 3;
    public float delayTime = 1.75f;

    private float r = 0;
    private float initHeight;
    private float curHeight;
    private float curTime;
    private State state;
    // Start is called before the first frame update
    void Start()
    {
        initHeight = transform.position.y;
        state = State.Prepare;
        curTime = 0f;
        r = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        updateState();
        curHeight = transform.position.y - initHeight;

        if (state == State.Up && curHeight <= maxHeight - (r * curveRate))
        {
            transform.position += transform.up * riseSpeed * Time.deltaTime;
        }
        else if (state == State.Down && curHeight >= 0)
        {
            transform.position -= transform.up * riseSpeed * Time.deltaTime;
        }
    }

    private void updateState()
    {
        curTime += Time.deltaTime;
        if(curTime >= maxTime + delayTime)
        {
            Destroy(this.transform.parent.gameObject);
        }
        else if (curTime >= maxTime / 2 + delayTime)
        {
            state = State.Down;
        }else if(curTime >= delayTime)
        {
            state = State.Up;
        }
    }
}
