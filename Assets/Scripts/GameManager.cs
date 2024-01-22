using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
   

    public GameStates gameStates = GameStates.Gameplay;
    [SerializeField]
    private int _coreInitialHealthPoints = 3;
    private int _coreCurrentHealthPoints = 0;

    private float _time = 0;
    
    private int _scoreInitial = 0;
    private int _scoreCurrent = 0;
    public float TimeGameplay { get => _time; set => _time = value; }

    private HUDManager _HUD;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Encontrado más de un GameManager de persistencia de datos, destruyendo el más nuevo");
            Destroy(this.gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        gameStates = GameStates.Gameplay;
        _coreCurrentHealthPoints = _coreInitialHealthPoints;
        _scoreCurrent = _scoreInitial;
        _HUD = GameObject.FindGameObjectWithTag("UIManager").GetComponent<HUDManager>();
    }
    private void Update()
    {
       switch (gameStates)
        {
            case GameStates.Gameplay:
                Timer();
                break;
            case GameStates.Pause:
                break;
            case GameStates.MainMenu:
                break;
            case GameStates.GameOver:
                break;
        }
    }
    public void AddScore()
    {
        _scoreCurrent++;
        _HUD.SetScore(_scoreCurrent);
    }



    #region HealthPoints Methods
    public void TakeHealthPoints()
    {
        _coreCurrentHealthPoints--;
    }
    public void AddHealthPoints()
    {
        _coreCurrentHealthPoints++;
    }
    #endregion

    #region Timer Methods
    public string DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 1000;
        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliSeconds);
    }
     public void Timer()
    {
        _time += Time.deltaTime;
    }
    #endregion

    public void PlayTheGame()
    {
        gameStates = GameStates.Gameplay;
    }

    public void ResetTheGame()
    {
        _time = 0;
        _coreCurrentHealthPoints = _coreInitialHealthPoints;
        _scoreCurrent = _scoreInitial;
        _HUD.ResetHUD();
        ChangeScene("SampleScene");
        ResumeGame();
    }
    public void PauseGame()
    {
        SoundManager.Instance.PlaySfxAudioSource();
        Time.timeScale = 0;
        gameStates = GameStates.Pause;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameStates = GameStates.Gameplay;
    }

    public void ChangeScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

public enum GameStates
{
    MainMenu,
    Gameplay,
    Pause,
    GameOver
}
