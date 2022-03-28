using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintRed : MonoBehaviour
{
    [SerializeField] private Renderer pieceRenderer;

    private bool isPainted;
    
    //Checks if is painted and paints it red
    //Than updates UI
    private void OnTriggerEnter(Collider other)
    {
        if (!isPainted && other.CompareTag("Painter"))
        {
            isPainted = true;
            pieceRenderer.material.color = Color.red;
            GameManager.Instance.UpdatePaintedWalls();
        }
    }
}
