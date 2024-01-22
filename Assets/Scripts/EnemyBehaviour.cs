using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float _speed = 2.0f;
    private bool _dead = false;
    [Header("Audio source")]
    [SerializeField]
    private AudioSource _enemyAudioSource;
    [SerializeField]
    private AudioClip _destroyAudio;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        //_rb2d.MovePosition(Vector2.zero);
        _enemyAudioSource.clip = _destroyAudio;
        
    }

    private void FixedUpdate()
    {
        if (!_dead)
        {
            Vector2 newPosition = Vector2.MoveTowards(transform.position, Vector2.zero, Time.deltaTime * _speed);
            _rb2d.MovePosition(newPosition);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Core")
        {
            GameManager.Instance.TakeHealthPoints();
            Destroy(this.gameObject);
        }
    }

    public void Dead()
    {
        _dead = true;
        _enemyAudioSource.Play();
        Destroy(this.gameObject, 1.2f);
    }
}
