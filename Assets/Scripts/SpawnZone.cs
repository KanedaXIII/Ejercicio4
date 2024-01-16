using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SpawnZone : MonoBehaviour
{
    private BoxCollider2D _BoxCollider;
    private float _boundMaxY, _boundMinY, _boundMaxX, _boundMinX;

    // Start is called before the first frame update
    void Start()
    {
        _BoxCollider = GetComponent<BoxCollider2D>();
        _boundMaxX = _BoxCollider.bounds.max.x; 
        _boundMaxY = _BoxCollider.bounds.max.y;
        _boundMinX = _BoxCollider.bounds.min.x;
        _boundMinY = _BoxCollider.bounds.min.y;
    }

    private Vector2 GetSpawnPosition()
    {
        float spawnX = Random.Range(_boundMinX , _boundMaxX);
        float spawnY = Random.Range(_boundMinY , _boundMaxY);

        return new Vector2(spawnX, spawnY);
    }

    public void SpawnEnemy(GameObject enemyGameObjet)
    {
        Vector2 spawnPosition = GetSpawnPosition();
        Instantiate(enemyGameObjet, spawnPosition, Quaternion.identity);
    }
}
