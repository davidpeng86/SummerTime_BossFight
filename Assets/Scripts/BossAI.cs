using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    enum State { Idle, GroundAttack, GroundAttackStraight, GroundAttckCurve, Rolling };
    public int hp = 20;
    public float rotateDelay = 0.5f;
    public float jumpVelocity = 10.0f;
    public GameObject groundAttackCurve;
    public GameObject groundAttackStraight;
    public GameObject groundAttack;
    public int attackNum = 5;
    public int attackRange = 1000;

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
        rigid.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp == 0) bossDie();
        updateStateTime();
        updateState();
        
    }

    private void updateStateTime()
    {
        stateCurTime += Time.deltaTime;

        if(stateCurTime >= stateMaxTime)
        {
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
            case State.Rolling:
                Rolling();
                break;
            default:
                break;
        }
    }
    
    private void RandomStateMaxTime()
    {
        stateMaxTime = Random.Range(2, 3);
    }

    private void RandomState()
    {
        int rnd = Random.Range(1, 5);
        bool label = true;
        while (label)
        {
            label = false;
            switch (rnd)
            {
                case 1:
                    state = State.GroundAttackStraight;
                    rigid.velocity = new Vector3(0, jumpVelocity, 0);
                    RandomAttackPosition(groundAttack);
                    break;
                case 2:
                    state = State.GroundAttackStraight;
                    rigid.velocity = new Vector3(0, jumpVelocity, 0);
                    RandomAttackPosition(groundAttackStraight);
                    break;
                case 3:
                    state = State.GroundAttckCurve;
                    rigid.velocity = new Vector3(0, jumpVelocity, 0);
                    RandomAttackPosition(groundAttackCurve);
                    break;
                case 4:
                    state = State.Rolling;
                    if (Mathf.Abs(transform.position.x) > 10 || Mathf.Abs(transform.position.z) > 10)
                    {
                        label = true;
                    }
                    rotateTime = 0;
                    break;
                default:
                    break;
            }
        }
    }

    private void RandomAttackPosition(GameObject ground)
    {
        Vector3 playerPosition = player.transform.position;
        Instantiate(ground, new Vector3(playerPosition.x, 0, playerPosition.z), new Quaternion());
        for(int i = 0; i < attackNum - 1; ++i)
        {
            Vector3 rndV = new Vector3(Random.Range(-attackRange, attackRange), 0, Random.Range(-attackRange, attackRange));
            while(Vector3.Distance(rndV, playerPosition) < 4)
            {
                rndV = new Vector3(Random.Range(-attackRange, attackRange), 0, Random.Range(-attackRange, attackRange));
            }
            Quaternion rndQ = new Quaternion(0, Random.Range(0, 180), 0, 0);
            Instantiate(ground, rndV + playerPosition, rndQ);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "bullet")
        {
            hp--;
            Debug.Log(hp);
        }
       
    }
    
    private void bossDie()
    {
        // 
    }
}
