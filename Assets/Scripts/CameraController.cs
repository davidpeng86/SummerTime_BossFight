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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = target.transform.position;
        Vector3 direction;

        updateInfo();
        
        direction = Quaternion.Euler(fi, theta, 0) * new Vector3(1, 1, 0);
        transform.position = position + direction * d;
        transform.forward = -direction;
        
    }

    void updateInfo()
    {
        Vector2 mousePosition = Input.mousePosition;

        theta = mousePosition.x / Screen.width * 360;
        fi = mousePosition.y / Screen.height * 90;
        
        d -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
    }
}
