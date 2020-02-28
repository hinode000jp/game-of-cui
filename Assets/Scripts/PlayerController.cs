using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;

    private float inputHorizontal;
    private float inputVertical;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()    {        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);        if (moveForward != Vector3.zero)        {            transform.rotation = Quaternion.LookRotation(moveForward);        }    }

    private void OnTriggerEnter(Collider other)    {        if (other.CompareTag("Crystal"))        {            Destroy(other.gameObject);        }
    }
}
