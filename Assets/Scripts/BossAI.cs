using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    enum State { Idle, GroundAttackStraight, GroundAttckCurve, Rolling };
    public int hp;
    public GameObject groundAttackCurve;
    public GameObject groundAttackStraight;

    private State state;
    private GameObject player;
    
    private Rigidbody rigid;
    private float stateCurTime;
    private float stateMaxTime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigid = GetComponent<Rigidbody>();
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
                GroundAttackStraight();
                break;
            case State.GroundAttckCurve:
                GroundAttackCurve();
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
        stateMaxTime = Random.Range(3, 3);
    }

    private void RandomState()
    {
        int rnd = Random.Range(2, 4);
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

    private void GroundAttackStraight()
    {
        //Debug.Log("Boss GroundAttackStraight");
    }

    private void GroundAttackCurve()
    {
        // Instantiate(groundAttackCurve, player.transform.position, new Quaternion());
        // Debig.Log("Boss GroundAttackCurve");
    }

    private void Rolling()
    {
        //Debug.Log("Boss Rolling");
    }
}
