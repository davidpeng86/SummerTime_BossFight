using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float scrollSpeed = 10.0f;
    public float theta = 180.0f;
    public float fi = 45.0f;
    public float d = 5.0f;
    
    GameObject boss;
    Material bossMaterial;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("boss");
        bossMaterial = boss.GetComponent<Renderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = target.transform.position;
        Vector3 direction;

        updateInfo();

        direction = Quaternion.Euler(0, theta, 0) * new Vector3(1.0f, 0.8f, 0).normalized;
        transform.position = position + direction * d;
        transform.forward = -direction;
        
        bool hit;
        RaycastHit raycastHit;
        hit = Physics.Raycast(transform.position, transform.forward, out raycastHit);
        Color color = bossMaterial.color;
        if (hit && raycastHit.collider.gameObject == boss)
        {
            color.a = 0.5f;
            bossMaterial.SetColor( "_Color", color);
        }
        else
        {
            color.a = 1.0f;
            bossMaterial.SetColor("_Color", color);
        }
        
    }

    void updateInfo()
    {
        Vector2 mousePosition = Input.mousePosition;

        //theta = mousePosition.x / Screen.width * 220;
        //fi = mousePosition.y / Screen.height * 60;

        d -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
    }
}