using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            GameManager.Instance.FinishSequence();
        if(other.CompareTag("Enemy"))
            GameManager.Instance.LostSequence();
    }
}
