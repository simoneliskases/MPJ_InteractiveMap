using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{

    public Terrain terrain;

    [Header("Coins")]
    public GameObject coinPrefab;
    public Vector3 coinSpawnCenter;
    public Vector3 coinSpawnSize;
    public float coinYPositionOffset;
    [Tooltip("How long it takes at least to spawn a coin")]
    public float coinSpawnMinTime;
    [Tooltip("How long it takes at max to spawn a coin")]
    public float coinSpawnMaxTime;
    [Tooltip("How fast the coins rotate")]
    public float coinRotateSpeed;
    [Tooltip("The maximal possible number of coins allowed in the scene at once")]
    public int maxCoinNumber;

    private float coinStartTime;
    private List<GameObject> coinList = new List<GameObject>();


    private void Start()
    {
        coinStartTime = Random.Range(coinSpawnMinTime, coinSpawnMaxTime);
    }

    private void Update()
    {
        foreach (var _coin in coinList.ToArray())
        {
            if(_coin != null)
            {
                _coin.transform.Rotate(0, coinRotateSpeed, 0);
            }
            else
            {
                coinList.Remove(_coin);
                coinStartTime = Random.Range(coinSpawnMinTime, coinSpawnMaxTime);
            }
        }

        if (coinStartTime > 0)
        {
            coinStartTime -= Time.deltaTime;
        }
        else if(coinList.Count < maxCoinNumber)
        {
            SpawnCoin();
            coinStartTime = Random.Range(coinSpawnMinTime, coinSpawnMaxTime);
        }

    }

    private void SpawnCoin()
    {
        Vector3 _pos = coinSpawnCenter + new Vector3(Random.Range(-coinSpawnSize.x / 2, coinSpawnSize.x / 2), 0f, Random.Range(-coinSpawnSize.z / 2, coinSpawnSize.z /2));
        _pos.y = terrain.SampleHeight(_pos) - coinYPositionOffset;

        GameObject _coin = Instantiate(coinPrefab, _pos, Quaternion.identity);
        coinList.Add(_coin);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(coinSpawnCenter, coinSpawnSize);
    }
}
