using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CamSpin : MonoBehaviour
{
    public GameObject player_object;
    public PlayerScript player_script;

    void Start()
    {
        player_object = GameObject.Find("Player");
        player_script = player_object.GetComponent<PlayerScript>();
    }

    void Update()
    {
        transform.RotateAround(player_object.transform.position, Vector3.up, Input.GetAxisRaw("Mouse X") * 1000 * Time.deltaTime);
    }
}