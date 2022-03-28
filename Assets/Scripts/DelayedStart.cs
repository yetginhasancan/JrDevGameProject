using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedStart : MonoBehaviour
{
    
    public GameObject Player;
    void Start()
    {
        StartCoroutine ("StartDelay");
    }

    //Delay for game to start properly

    IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        Player.SetActive(true);
        Time.timeScale = 1;
    }
}
