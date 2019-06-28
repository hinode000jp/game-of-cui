using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject targetObject;
    Vector3 targetPos;

    float scrollPos;

    void Start()
    {
        targetObject = GameObject.Find("Player");
        targetPos = targetObject.transform.position;
    }

    void Update()
    {
        transform.position += targetObject.transform.position - targetPos;
        targetPos = targetObject.transform.position;

        if (Input.GetMouseButton(0))        {            float mouseInputX = Input.GetAxis("Mouse X");            float mouseInputY = Input.GetAxis("Mouse Y");            transform.RotateAround(targetPos, Vector3.down, mouseInputX * Time.deltaTime * -200f);            transform.RotateAround(targetPos, transform.right, mouseInputY * Time.deltaTime * -200f);        }

        scrollPos = Input.GetAxis("Mouse ScrollWheel");
        transform.position += transform.forward * scrollPos;
    }
}
