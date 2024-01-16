using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _TimerText;
    [SerializeField]
    private TMP_Text _ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ResetHUD()
    {
        ResetTimer();
        ResetScore();
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
