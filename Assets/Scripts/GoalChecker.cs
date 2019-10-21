using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;using UnityStandardAssets.Characters.ThirdPerson;public class GoalChecker : MonoBehaviour
{
    public static bool goal;
    public AudioSource gameBGM;
    public AudioSource goalBGM;
    public AudioSource goalSE;
    public GameObject player;
    public GameObject goalUI;

    private ThirdPersonUserControl controll;    private GameObject mainCam;
    private GameObject subCam;

    void Start()
    {        goal = false;        mainCam = GameObject.Find("Main Camera");        subCam = GameObject.Find("SubCamera");        subCam.SetActive(false);        controll = player.GetComponent<ThirdPersonUserControl>();    }

    private void OnTriggerEnter(Collider other)    {        if (other.gameObject.tag == "Player")        {            mainCam.SetActive(false);            subCam.SetActive(true);            player.GetComponent<Animator>().SetTrigger("Goal");            gameBGM.Stop();            goalBGM.Play();            goalSE.Play();            goal = true;            controll.enabled = false;            goalUI.SetActive(true);        }    }   public void OnRetry()    {        SceneManager.LoadScene(SceneManager.GetActiveScene().name);    }}
