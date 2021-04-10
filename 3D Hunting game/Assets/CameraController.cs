using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotSpeed = 200f;
    private float camRotX;
    private float camRotY;

    Vector3 offset;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        camRotX = Camera.main.transform.eulerAngles.x;
        camRotY = Camera.main.transform.eulerAngles.y;
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;

        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        camRotX += h * rotSpeed * Time.deltaTime;
        camRotY += v * rotSpeed * Time.deltaTime;
        // x, y, z

        camRotY = Mathf.Clamp(camRotY, -45, 45);
        camRotX = Mathf.Clamp(camRotX, -45, 45);
            
        transform.eulerAngles = new Vector3(-camRotY, camRotX, 0);
    }
}
