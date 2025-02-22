using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private float _heightRange = 0.45f;
    [SerializeField] private float _terrainOffset = 1f;
    [SerializeField] private float _terrainOffTime = 6f;
    [SerializeField] private GameObject _terrain;

    private float _timer;

    private void Start()
    {
        SpawnTerrain();
    }

    private void Update()
    {
        if (_timer > _maxTime)
        {
            SpawnTerrain();
            _timer = 0;
        }   

        _timer += Time.deltaTime;
    }

    private void SpawnTerrain()
    {
        Vector3 spawnPos = transform.position + new Vector3(_terrainOffset, Random.Range(-_heightRange, _heightRange));
        GameObject terrain = Instantiate(_terrain, spawnPos, Quaternion.identity);

        Destroy(terrain, _terrainOffTime);
    }
}
