using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float rotationAngle;

    public GameObject mainCamera;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateCamera()
    {
        mainCamera.transform.Rotate(new Vector3(0, rotationAngle, 0));
    }
}
