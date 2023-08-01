using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    
    public Animator anim;

    private void Start()
    {
        anim=GetComponentInParent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Close");
        anim.SetTrigger("Close");
    }

}
