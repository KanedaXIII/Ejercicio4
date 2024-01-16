using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject,4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObjectColl = collision.gameObject;
        if (gameObjectColl.tag == "Enemy")
        {
            GameManager.Instance.AddScore();
            Destroy(gameObjectColl.transform.parent.gameObject);
            Destroy(this.gameObject);
        }
    }
}
