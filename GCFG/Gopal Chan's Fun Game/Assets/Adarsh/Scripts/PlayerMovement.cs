using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float tilt = 5.0f;
    public float mouseSensitivity = 5f;
    private Vector3 moveDirection = Vector3.zero;
    void Start()
    {
    }
    void Update()
    {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, -Input.GetAxis("Vertical"));
            moveDirection *= speed;
        // moveDirection.y -= gravity * Time.deltaTime;
            var rot = Input.GetAxis("Mouse X");
            transform.eulerAngles += (Vector3.up * rot * mouseSensitivity * Time.deltaTime);
			transform.Translate(moveDirection  * Time.deltaTime);
            
	}
}
