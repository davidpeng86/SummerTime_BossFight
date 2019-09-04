using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ObstacleManager : MonoBehaviour
{
    ObstacleEmission[] emit;
    int bossHp;
    int hpCalc;

    public TextMeshProUGUI Obst;

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        emit = GetComponentsInChildren<ObstacleEmission>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        hpCalc = 0;
        for (int i = 0; i < emit.Length; i++){
            if(emit[i].isDead == false){
                hpCalc++;
            }
        }
    }

    void LateUpdate(){
        bossHp = hpCalc;
        print(bossHp);
        Obst.text = bossHp.ToString();
    }
}
