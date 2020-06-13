using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float mvSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Wall.gameOver)
        {
            rb.velocity = Vector3.zero;
            animator.SetBool("Walking", false);
            return;
        }
        var x = (int)Input.GetAxisRaw("Horizontal");
        var y = (int)Input.GetAxisRaw("Vertical");
        rb.velocity = Quaternion.Euler(0, playerCamera.eulerAngles.y, 0) * new Vector3(x, 0, y) * mvSpeed;
        playerCamera.position = transform.position;

        if(x==0 && y == 0) 
        {
            animator.SetBool("Walking", false);
        }
        else 
        {
            animator.SetBool("Walking", true);
            transform.forward = rb.velocity;
        }
    }
}
