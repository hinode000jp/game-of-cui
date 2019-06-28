using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;public class GoalChecker : MonoBehaviour
{
    public static bool goal;
    public AudioSource gameBGM;
    public AudioSource goalBGM;
    public AudioSource goalSE;
    public GameObject player;
    private ThirdPersonUserControl third;    private PlayerController script;
    Rigidbody rb;
    private GameObject mainCam;
    private GameObject subCam;


    void Start()
    {
        goal = false;
        mainCam = GameObject.Find("Main Camera");
        subCam = GameObject.Find("SubCamera");
        subCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)    {        if (other.gameObject.tag == "Player")        {            mainCam.SetActive(false);            subCam.SetActive(true);            player.GetComponent<Animator>().SetTrigger("Goal");            gameBGM.Stop();            goalBGM.Play();            goalSE.Play();            goal = true;            rb = player.GetComponent<Rigidbody>();            rb.velocity = Vector3.zero;            rb.isKinematic = true;            script = player.GetComponent<PlayerController>();            script.enabled = false;            third = player.GetComponent<ThirdPersonUserControl>();            third.enabled = false;        }    }
}
