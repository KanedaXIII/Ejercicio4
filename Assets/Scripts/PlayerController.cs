using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb2d;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private float _speed = 2.0f;
    [SerializeField]
    public float _projectileForce = 20.0f;
    [SerializeField]
    private GameObject _aimObject;
    [SerializeField]
    private GameObject _projectileObject;
    [SerializeField]
    private AudioClip _shootClip;

    [Header("Audio Source")]
    [SerializeField]
    private AudioSource _playerAudioSource;

    private float _rotZ;

    private Vector2 _movementInput;
    private Vector2 _mousePos;
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        if (_rb2d.velocity.magnitude != 0f)
        {
            _animator.SetBool("IsWalking", true);
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }
    }

    private void FixedUpdate()
    {
        
        _rb2d.velocity = _movementInput.normalized * _speed;

        Vector2 rotation = _mousePos - new Vector2(_aimObject.transform.position.x, _aimObject.transform.position.y);

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90f;

        _rotZ = rotZ;

        _aimObject.transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    private void OnMove(InputValue value)
    {
        _movementInput = value.Get<Vector2>();
    }

    private void OnAim(InputValue value)
    {
        _mousePos = _camera.ScreenToWorldPoint(value.Get<Vector2>());
    }

    private void OnShoot()
    {
        if (GameManager.Instance.gameStates == GameStates.Gameplay)
        {
            _playerAudioSource.clip = _shootClip;
            GameObject projectileInstance = Instantiate(_projectileObject, _aimObject.transform.GetChild(0).position, Quaternion.Euler(0,0, _rotZ +90f));
            _playerAudioSource.Play();
            Rigidbody2D projectileRbd2d = projectileInstance.GetComponent<Rigidbody2D>();
            projectileRbd2d.AddForce(_aimObject.transform.up * _projectileForce, ForceMode2D.Impulse);
        }
    }
        

    private void OnPause()
    {
        if (GameManager.Instance.gameStates == GameStates.Gameplay)
        {
            GameManager.Instance.PauseGame();
        }
        else
        {
            GameManager.Instance.ResumeGame();
        }
    }
}
