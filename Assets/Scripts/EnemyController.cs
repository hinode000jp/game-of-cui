using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;using UnityStandardAssets.Characters.ThirdPerson;[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof(ThirdPersonCharacter))]

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    Transform target;

    bool isActive = false;
    NavMeshAgent agent;
    ThirdPersonCharacter character;

    private EnemyController script;
    private ThirdPersonUserControl third;

    Rigidbody rb;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();

        agent.updateRotation = false;
        agent.updatePosition = true;

        isActive = true;
    }


    void Update()
    {
        if (GoalChecker.goal == true || PlayerController.lose == true)        {            isActive = false;            character.Move(Vector3.zero, false, false);            agent.ResetPath();        }

        if (isActive)        {            if (target != null)            {                agent.SetDestination(target.position);            }            if (agent.remainingDistance > agent.stoppingDistance)            {                character.Move(agent.desiredVelocity, false, false);            }            else            {                character.Move(Vector3.zero, false, false);            }        }
        else        {            return;        }
    }

    public void SetTarget(Transform target)    {        this.target = target;    }

    private void OnCollisionEnter(Collision other)    {        if (other.gameObject.tag == "Player")        {            Debug.Log("GameOver!");            isActive = false;        }    }
}
