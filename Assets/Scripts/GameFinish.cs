using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;public class GameFinish : MonoBehaviour
{

    public GameObject finishUI;

    void Update()
    {
        if (GoalChecker.goal == true)        {            finishUI.SetActive(true);        }
    }

    public void OnRetry()    {        SceneManager.LoadScene(SceneManager.GetActiveScene().name);    }
}
