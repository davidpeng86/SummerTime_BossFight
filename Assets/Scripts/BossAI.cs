using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    enum State { Idle, GroundAttackStraight, GroundAttckCurve, Rolling };
    public int hp = 50;
    public float rotateDelay = 0.5f;
    public GameObject groundAttackCurve;
    public GameObject groundAttackStraight;

    private State state;
    private GameObject player;
    private BossRotate bossRotate;

    private Rigidbody rigid;
    private float rotateTime;
    private float stateCurTime;
    private float stateMaxTime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigid = GetComponent<Rigidbody>();
        bossRotate = gameObject.GetComponent<BossRotate>();
        state = State.Idle;
        stateCurTime = 0;
        RandomStateMaxTime();
    }

    // Update is called once per frame
    void Update()
    {
        updateStateTime();
        updateState();
    }

    private void updateStateTime()
    {
        stateCurTime += Time.deltaTime;

        if(stateCurTime >= stateMaxTime)
        {
            Debug.Log("----------Boss Switch State----------");
            stateCurTime = 0;
            RandomStateMaxTime();
            RandomState();
        }

    }

    private void updateState()
    {
        switch (state)
        {
            case State.Idle:
                Idle();
                break;
            case State.GroundAttackStraight:
                break;
            case State.GroundAttckCurve:
                break;
            case State.Rolling:
                Rolling();
                break;
            default:
                break;
        }
    }
    
    private void RandomStateMaxTime()
    {
        stateMaxTime = Random.Range(4, 6);
    }

    private void RandomState()
    {
        int rnd = Random.Range(1, 5);
        switch (rnd)
        {
            case 1:
                state = State.Idle;
                Debug.Log("Boss Idle");
                break;
            case 2:
                state = State.GroundAttackStraight;
                Instantiate(groundAttackStraight, player.transform.position, new Quaternion());
                Debug.Log("Boss GroundAttackStraight");
                break;
            case 3:
                state = State.GroundAttckCurve;
                Instantiate(groundAttackCurve, player.transform.position, new Quaternion());
                Debug.Log("Boss GroundAttackCurve");
                break;
            case 4:
                state = State.Rolling;
                rotateTime = 0;
                Debug.Log("Boss Rolling");
                break;
            default:
                break;
        }
    }

    private void Idle()
    {
        //Debug.Log("Boss Idle");
    }

    private void Rolling()
    {
        rotateTime += Time.deltaTime;
        if (rotateTime > rotateDelay)
        {
            rotateTime = 0;
            bossRotate.Rolling();
        }
    }
    
}
