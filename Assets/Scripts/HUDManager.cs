using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    

    [Header("HUD")]
    [SerializeField]
    private GameObject _HUDContainer;
    [SerializeField]
    private TMP_Text _TimerText;
    [SerializeField]
    private TMP_Text _ScoreText;
    [Header("Pause")]
    [SerializeField]
    private GameObject _PauseMenuContainer;
    [SerializeField]
    private Button _ResumePauseMenuButton;
    [SerializeField]
    private Button _RetryPauseMenuButton;
    [SerializeField]
    private Button _QuitPauseMenuButton;
    [Header("GameOver")]
    [SerializeField]
    private GameObject _GameOverMenuContainer;
    [SerializeField]
    private Button _RetryGameOverMenuButton;
    [SerializeField]
    private Button _QuitGameOverMenuButton;
    [Header("MainMenu")]
    [SerializeField]
    private GameObject _MainMenuContainer;
    [SerializeField]
    private Button _PlayMainMenuButton;
    [SerializeField]
    private Button _QuitMainMenuButton;

    private List<GameObject> _UIList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        _UIList.Add(_HUDContainer);
        _UIList.Add(_PauseMenuContainer);
        _UIList.Add(_GameOverMenuContainer);
        _UIList.Add(_MainMenuContainer);

        //Pause
        _ResumePauseMenuButton.onClick.AddListener(GameManager.Instance.ResumeGame);
        _RetryPauseMenuButton.onClick.AddListener(GameManager.Instance.ResetTheGame);
        _QuitPauseMenuButton.onClick.AddListener(GameManager.Instance.ExitGame);
        //GameOver
        _QuitGameOverMenuButton.onClick.AddListener(GameManager.Instance.ExitGame);
        _RetryGameOverMenuButton.onClick.AddListener(GameManager.Instance.ResetTheGame);
        //MainMenu
        _QuitMainMenuButton.onClick.AddListener(GameManager.Instance.ExitGame);
        _PlayMainMenuButton.onClick.AddListener(GameManager.Instance.PlayTheGame);
    }

    private void Update()
    {
        switch (GameManager.Instance.gameStates)
        {
            case GameStates.Gameplay:
                SetActiveUI(_HUDContainer.name);
                SetTimer(GameManager.Instance.DisplayTime(GameManager.Instance.TimeGameplay));
                break;
            case GameStates.Pause:
                SetActiveUI(_PauseMenuContainer.name);
                break;
            case GameStates.MainMenu:
                SetActiveUI(_MainMenuContainer.name);
                break;
            case GameStates.GameOver:
                SetActiveUI(_GameOverMenuContainer.name);
                break;
        }
    }

    public void ResetHUD()
    {
        ResetTimer();
        ResetScore();
    }



    private void SetActiveUI(string nameUI)
    {
        foreach (GameObject UIobject in _UIList)
        {
            if(UIobject.name == nameUI)
            {
                UIobject.SetActive(true);
            }
            else
            {
                UIobject.SetActive(false);
            }
        }
    }

    public void SetTimer(string t)
    {
        _TimerText.text = "Timer: "+t;
    }

    public void SetScore(int score)
    {
        _ScoreText.text = "Score: "+score.ToString();
    }
    private void ResetTimer()
    {
        _TimerText.text = "Timer: 00:00:00";
    }

    private void ResetScore()
    {
        _ScoreText.text = "Score: 0";
    }
}
