using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    [HideInInspector]
    public int sheepSaved;
    [HideInInspector]
    public int sheepDropped;

    public int sheepDroppedBeforeGameOver;
    public SheepSpawner sheepSpawner;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }
    private void GameOver()
    {
        UIManager.Instance.ShowGameOverWindow();
        sheepSpawner.canSpawn = false;
        sheepSpawner.DestroyAllSheep();
    }
    public void DroppedSheep()
    {
        sheepDropped++;
        UIManager.Instance.UptadeSheepDropped();
        if (sheepDropped == sheepDroppedBeforeGameOver)
        {
            GameOver();
        }
    }
    public void SavedSheep()
    {
        sheepSaved++;
        UIManager.Instance.UpdateSheepSaved();
    }

}
