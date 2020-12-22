using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
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
        CalculatePosition();
        coinStartTime = Random.Range(coinSpawnMinTime, coinSpawnMaxTime);
    }

    private void Update()
    {
        foreach (var _coin in coinList.ToArray())
        {
            if(_coin != null)
            {
                _coin.transform.Rotate(coinRotateSpeed, coinRotateSpeed, coinRotateSpeed);
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
            CalculatePosition();
            coinStartTime = Random.Range(coinSpawnMinTime, coinSpawnMaxTime);
        }
    }

    private void CalculatePosition()
    {
        float _xPosition = XPosition();
        float _zPosition = ZPosition();

        Vector3 _tempPosition = new Vector3(_xPosition, 15, _zPosition);

        RaycastHit _hit;
        if (Physics.Raycast(_tempPosition, Vector3.down, out _hit) && _hit.transform.gameObject.tag == "Ground")
        {
            InstantiateCoin(new Vector3(_xPosition, 15 - _hit.distance + coinYPositionOffset, _zPosition));
        }
        else
        {
            CalculatePosition();
        }
    }

    private float XPosition()
    {
        return coinSpawnCenter.x + Random.Range(-coinSpawnSize.x / 2, coinSpawnSize.x / 2);
    }

    private float ZPosition()
    {
        return coinSpawnCenter.z + Random.Range(-coinSpawnSize.z / 2, coinSpawnSize.z / 2);
    }

    private void InstantiateCoin(Vector3 _position)
    {
        GameObject _coin = Instantiate(coinPrefab, _position, Quaternion.identity);
        coinList.Add(_coin);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(coinSpawnCenter, coinSpawnSize);
    }
}
