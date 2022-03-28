using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Game Related")]    
    [SerializeField] private Player player;
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject wall;
    [SerializeField] private Painter painter;
    [SerializeField] private Enemy[] enemies;

    private int paintedWalls = 0;
    private int totalWalls = 36;
    public void Awake()
    {
        Instance = this;
    }

    public void FinishSequence()
    {
        player.StopPlayer();
        player.enabled = false;
        MoveCameraToTheWall();
        PaintTheWall();
        UIManager.Instance.SetPercentageTextActive(true);
    }

    public void LostSequence()
    {
        player.enabled = false;
        foreach (var enemy in enemies)
        {
            enemy.enabled = false;
        }
        UIManager.Instance.GameLostSequence();
    }

    public void GameEndSequence()
    {
        UIManager.Instance.GameWonSequence();
    }

    private void MoveCameraToTheWall()
    {
        cameraFollow.enabled = false;
        var cameraTransform = mainCamera.transform;
        cameraTransform.position = new Vector3(0, wall.transform.position.y - 3, wall.transform.position.z - 11);
        cameraTransform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }
    
    private void PaintTheWall()
    {
        painter.enabled = true;
    }

    public void UpdatePaintedWalls()
    {
        paintedWalls += 1;
        if (paintedWalls == totalWalls)
            GameEndSequence();
        var rate = (int) Math.Round((double) 100 * paintedWalls / totalWalls);
        UIManager.Instance.UpdatePercentageText(rate);
    }
}
