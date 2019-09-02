using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    Quaternion origin = Quaternion.Euler(new Vector3(0,45,0));
    float mouseX;
    float mouseY;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = origin;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.mousePosition.x/Screen.width - 0.5f;
        mouseY = Input.mousePosition.y/Screen.height;
        transform.localRotation = Quaternion.Euler(new Vector3(-60*mouseY,45+180*mouseX,0));
    }
}
