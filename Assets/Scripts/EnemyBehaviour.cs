using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float _speed = 2.0f;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.MovePosition(Vector2.zero);

    }

    private void FixedUpdate()
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, Vector2.zero, Time.deltaTime * _speed);
        _rb2d.MovePosition(newPosition);
    }
}
