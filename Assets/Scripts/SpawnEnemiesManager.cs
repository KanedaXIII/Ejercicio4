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
    private float _countdown=10f;
    [SerializeField]
    private GameObject[] _zoneSpawnList;

    private GameObject _zoneSpawnCurrent;
    
    private float _countdownTime;
    

    // Start is called before the first frame update
    void Start()
    {   
 
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameStates == GameStates.Gameplay)
        {
            _countdown -= Time.deltaTime;
            if (_countdown<=0)
            {
                _countdown=10f;
                StartCoroutine(SpawnEnemiesWave());
            }
        }
    }

    private IEnumerator SpawnEnemiesWave()
    {
        _zoneSpawnCurrent = GetSpawnZone();
        _zoneSpawnCurrent.GetComponent<SpawnZone>().SpawnEnemy(_enemy);
        yield return new WaitForSeconds(.1f);
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
