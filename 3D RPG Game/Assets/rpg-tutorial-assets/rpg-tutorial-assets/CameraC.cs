using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraC : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private float pitch = 1f; // ≈∏∞Ÿ¿« Ω≈¿Â

    private float currentZoom = 10f;

    public float zoomSpeed = 4f;
    public float mimZoom = 5f;
    public float maxZoom = 15f;

    private float currentYaw = 0f;
    private float yawSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, mimZoom, maxZoom);

        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
