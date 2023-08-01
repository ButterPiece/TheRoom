using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationStart : MonoBehaviour
{
    private float x;
    private float y;
    public float yRotation;
    public float xRotation;
    public float sensitivity;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        x=Input.GetAxis("Mouse X")*Time.deltaTime*sensitivity;
        y=Input.GetAxis("Mouse Y")*Time.deltaTime*sensitivity;
        yRotation+=x;
        xRotation-=y;
        xRotation=Mathf.Clamp(xRotation,-20f,30f);
        if(yRotation<=50f&&yRotation>=-50f)
        {
            transform.rotation=Quaternion.Euler(xRotation,yRotation,0);

        }
        
    }
}
