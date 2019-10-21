using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;using UnityEngine.UI;using UnityStandardAssets.Characters.ThirdPerson;[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(ThirdPersonCharacter))]

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverUI;    public Text gameOverText;    public AudioSource badSE;

    private Transform target;    private bool isActive = false;
    private NavMeshAgent agent;
    private ThirdPersonCharacter character;
    private static bool lose;
    private PlayerController script;
    private ThirdPersonUserControl controll;

    void Start()
    {
        target = player.transform;
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
        script = player.GetComponent<PlayerController>();
        controll = player.GetComponent<ThirdPersonUserControl>();

        agent.updateRotation = false;
        agent.updatePosition = true;

        isActive = true;
        lose = false;
    }


    void Update()
    {
        if (GoalChecker.goal == true || lose == true)        {            isActive = false;            character.Move(Vector3.zero, false, false);            agent.ResetPath();        }

        if (isActive)        {            if (target != null)            {                agent.SetDestination(target.position);            }            if (agent.remainingDistance > agent.stoppingDistance)            {                character.Move(agent.desiredVelocity, false, false);            }            else            {                character.Move(Vector3.zero, false, false);            }        }
        else        {            return;        }
    }

    public void SetTarget(Transform target)    {        this.target = target;    }

    private void OnCollisionEnter(Collision other)    {        if (other.gameObject.tag == "Player")        {            player.GetComponent<Animator>().SetTrigger("Lose");            player.transform.LookAt(Camera.main.transform.right);            gameOverUI.SetActive(true);            gameOverText.text = "ゲームオーバー";            badSE.Play();            lose = true;            script.enabled = false;            controll.enabled = false;        }    }
}
