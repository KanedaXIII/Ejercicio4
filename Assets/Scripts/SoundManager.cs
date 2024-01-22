using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField]
    private AudioSource _sFXAudioSource;
    [SerializeField]
    private AudioSource _musicAudioSource;
    [Header("Menu SoundFx")]
    [SerializeField]
    private AudioClip _pauseSFX;
    [SerializeField]
    private AudioClip _playSFX;
    [SerializeField]
    private AudioClip _resumeSFX;
    [SerializeField]
    private AudioClip _clickSFX;
    [Header("Gameplay SoundFx")]
    [SerializeField]
    private AudioClip _shootSfx;
    [Header("GameOver SoundFx")]
    [SerializeField]
    private AudioClip _gameOverSFX;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayMusicAudioSource(AudioClip _musicClip) 
    { 
        _musicAudioSource.Play(); 
    }
    public void PlaySfxAudioSource()
    {
        //_SFXAudioSource.clip = _sfxClip;
        _sFXAudioSource.clip = _pauseSFX;
        _sFXAudioSource.Play();
    }

}
