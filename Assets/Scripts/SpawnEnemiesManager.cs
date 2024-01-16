using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesManager : MonoBehaviour
{

    [SerializeField]
    private float _offset;
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private List<GameObject> _enemyList = new List<GameObject>();
    [SerializeField]
    private GameObject[] _zoneSpawnList;

    private GameObject _zoneSpawnCurrent;
    private Camera _camera;

    

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        float orthographicSize = _camera.orthographicSize + 1;
        float aspectRatio = _camera.aspect + 1;

        InvokeRepeating("Spawwwwwwwwww", 4f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawwwwwwwwww()
    {
        _zoneSpawnCurrent = GetSpawnZone();
        SpawnEnemies();
    }

    private GameObject GetSpawnZone()
    {
        int nSpawnZone = Random.Range(0,_zoneSpawnList.Length);
        _zoneSpawnCurrent = _zoneSpawnList[nSpawnZone];
        return _zoneSpawnCurrent;
    }

    private void SpawnEnemies()
    {
        _zoneSpawnCurrent.GetComponent<SpawnZone>().SpawnEnemy(_enemy);
    }
}
