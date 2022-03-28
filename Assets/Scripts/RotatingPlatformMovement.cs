using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatformMovement : MonoBehaviour
{
    [SerializeField] private bool isStatic;
    void Start()
    {
        
        transform.DORotate(new Vector3(0, 0, 180), 2f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        
    }
}
