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
    private GameObject cam_point;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        move_speed = 500;
        cam_point = GameObject.Find("CamPoint");
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKey(KeyCode.X))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        back_dir = Input.GetAxisRaw("Vertical") * cam_point.transform.forward;
        right_dir = Input.GetAxisRaw("Horizontal") * cam_point.transform.right;
        true_dir = back_dir + right_dir;
    }

    private void FixedUpdate()
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