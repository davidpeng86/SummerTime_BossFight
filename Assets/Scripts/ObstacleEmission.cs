using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEmission : MonoBehaviour
{
    Renderer thisRen;
    public bool isDead;
    public bool emit;
    // Start is called before the first frame update
    void Start()
    {
        thisRen = GetComponent<Renderer>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bling(){
        if(isDead){
            NoLight();
            // EmitLight();
            // isDead = false;
        }
        else{
            NoLight();
            isDead = true;
        }

    }

    public void EmitLight(){
        thisRen.material.EnableKeyword("_EMISSION");
    }

    public void NoLight(){
        thisRen.material.DisableKeyword("_EMISSION");
    }

}
