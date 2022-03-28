using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private Transform rotatingObject;
    [SerializeField] private bool isHorizontal;
    [SerializeField] private bool isStatic;
    void Start()
    {
        //Using tweens on simple movements that dont require force
       if(isHorizontal)
            rotatingObject.DORotate(new Vector3(0, 180, 0), 3f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
       else
           rotatingObject.DORotate(new Vector3(180, 0, 0), 3f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
       
       //Moving on platform rather than rotating around itself
       if (!isStatic)
           rotatingObject.DOMoveX(-1, 1f, false).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
    
    

}
