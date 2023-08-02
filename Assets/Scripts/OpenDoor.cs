using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    
    public Animator anim;

    private void Start()
    {   
        anim=GameObject.FindGameObjectWithTag("Door").GetComponentInParent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        anim.SetTrigger("Open");
    }

}
