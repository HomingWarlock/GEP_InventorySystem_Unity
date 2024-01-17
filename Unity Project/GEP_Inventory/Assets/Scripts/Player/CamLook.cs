using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLook : MonoBehaviour
{
    private PlayerScript player_script;
    public Transform player_body;
    private float sensitivity;
    private float x_rotation;

    private void Awake()
    {
        player_script = GameObject.Find("Player").GetComponent<PlayerScript>();
        player_body = GameObject.Find("Player").GetComponent<Transform>();
        sensitivity = 3000;
        x_rotation = 0;
    }

    private void Update()
    {
        if (!player_script.movement_locked)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            x_rotation -= mouseY;
            x_rotation = Mathf.Clamp(x_rotation, -90, 90);

            transform.localRotation = Quaternion.Euler(x_rotation, 0, 0);
            player_body.Rotate(Vector3.up * mouseX);
        }
    }
}