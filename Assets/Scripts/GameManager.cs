using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private float _time = 0;
    private int _score = 0;

    private HUDManager _HUD;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _HUD = GetComponent<HUDManager>();
    }
    private void Update()
    {
        Timer();
    }
    string DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 1000;
        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliSeconds);
    }
    public void AddScore()
    {
        _score++;
        _HUD.SetScore(_score);
    }
    public void ChangeScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene, LoadSceneMode.Single);
    }
    void Timer()
    {
        _time += Time.deltaTime;
        _HUD.SetTimer(DisplayTime(_time));
    }
}
