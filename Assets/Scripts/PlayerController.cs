using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;using UnityStandardAssets.Characters.ThirdPerson;public class PlayerController : MonoBehaviour
{
    public static bool lose;
    public GameObject gameOverUI;
    public Text gameOverText;
    public AudioSource badSE;
    public float moveSpeed = 10f;

    private float inputHorizontal;
    private float inputVertical;
    private Rigidbody rb;
    private PlayerController script;
    private ThirdPersonUserControl third;
    private Vector3 velocity;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lose = false;
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()    {        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);        if (moveForward != Vector3.zero)        {            transform.rotation = Quaternion.LookRotation(moveForward);        }    }

    private void OnCollisionEnter(Collision collision)    {        if (collision.gameObject.tag == "Enemy")        {            lose = true;            transform.LookAt(Camera.main.transform.right);            GetComponent<Animator>().SetTrigger("Lose");            rb.velocity = Vector3.zero;            rb.isKinematic = true;            script = this.GetComponent<PlayerController>();            script.enabled = false;            third = this.GetComponent<ThirdPersonUserControl>();            third.enabled = false;            gameOverUI.SetActive(true);            gameOverText.text = "ゲームオーバー";            badSE.Play();        }    }
}
