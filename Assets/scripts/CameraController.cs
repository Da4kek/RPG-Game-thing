using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Vector3 offset;
    private float currentZoom = 10f;
    public float pitch =2f;
    public float Zoomspeed = 4f;
    public float maxzoom = 15f;
    public float minzoom = 5f;
    public float speeD = 100f;
    private float inpuT = 0f;

    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * Zoomspeed;
        currentZoom = Mathf.Clamp(currentZoom, minzoom, maxzoom);

        inpuT -= Input.GetAxis("Horizontal") * speeD * Time.deltaTime;
    }

    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
        transform.RotateAround(target.position, Vector3.up, inpuT);
    }
}
