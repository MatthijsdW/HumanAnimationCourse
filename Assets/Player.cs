using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 inputVector;
    private Animator animator;
    private bool grounded;
    [SerializeField]
    private LayerMask groundLayer;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        animator.SetFloat("Turn", -inputVector.x);
        animator.SetFloat("Speed", inputVector.z);

        grounded = Physics.Raycast(transform.position + Vector3.up, Vector3.down, 1.1f, groundLayer);
        if (Input.GetButtonDown("Fire1") && grounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        animator.SetTrigger("Jump");
    }
}
