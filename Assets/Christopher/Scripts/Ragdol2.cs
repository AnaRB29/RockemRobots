using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdol2 : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private Rigidbody[] rigidbodies;

    void Start()
    {
        rigidbodies = transform.GetComponentsInChildren<Rigidbody>();
        //SetEnabled(false);
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetEnabled(true);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SetEnabled(false);
        }
    }

    void SetEnabled(bool enabled)
    {
        bool isKinematic = !enabled;
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = isKinematic;
        }

        animator.enabled = !enabled;
    }

    void Update()
    {
       
    }
}



