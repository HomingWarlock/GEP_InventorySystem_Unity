using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    private float move_speed;
    private Vector3 back_dir;
    private Vector3 right_dir;
    private Vector3 true_dir;

    public bool movement_locked;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        move_speed = 500;

        movement_locked = false;
    }

    private void Update()
    {
        back_dir = Input.GetAxisRaw("Vertical") * transform.forward;
        right_dir = Input.GetAxisRaw("Horizontal") * transform.right;
        true_dir = back_dir + right_dir;
    }

    private void FixedUpdate()
    {
        if (!movement_locked)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                rb.velocity = new Vector3(true_dir.x * move_speed * Time.deltaTime, rb.velocity.y, true_dir.z * move_speed * Time.deltaTime);
            }
            else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
            }
        }
    }
}