using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject coinPrefab;
    public Vector3 coinSpawnCenter;
    public Vector3 coinSpawnSize;
    public float coinYPositionOffset;
    public float coinSpawnMinTime;
    public float coinSpawnMaxTime;
    public float coinRotateSpeed;
    public float xResolution;
    public float zResolution;
    public float coinMaxDistance;
    public float carMaxDistance;
    public int maxCoinNumber;

    private float _coinStartTime;
    private float _spawnHeight = 15f;
    private GameObject _car;
    private List<GameObject> _coinList = new List<GameObject>();
    private List<Vector3> _allSpawnPoints = new List<Vector3>();
    private List<Vector3> _currentSpawnPoints = new List<Vector3>();

    private void OnEnable()
    {
        Vector3 _leftTopCorner = new Vector3(coinSpawnCenter.x - (coinSpawnSize.x / 2), _spawnHeight, coinSpawnCenter.z + (coinSpawnSize.z / 2));
        Vector3 _leftBottomCorner = new Vector3(coinSpawnCenter.x - (coinSpawnSize.x / 2), _spawnHeight, coinSpawnCenter.z - (coinSpawnSize.z / 2));
        Vector3 _rightTopCorner = new Vector3(coinSpawnCenter.x + (coinSpawnSize.x / 2), _spawnHeight, coinSpawnCenter.z + (coinSpawnSize.z / 2));
        Vector3 _rightBottomCorner = new Vector3(coinSpawnCenter.x + (coinSpawnSize.x / 2), _spawnHeight, coinSpawnCenter.z - (coinSpawnSize.z / 2));

        List<float> _xCoordinates = new List<float>();
        List<float> _zCoordinates = new List<float>();

        float _xSummand = (_rightTopCorner.x - _leftTopCorner.x) / xResolution;
        float _zSummand = (_rightBottomCorner.z - _rightTopCorner.z) / zResolution;

        for (int i = 0; i <= xResolution; i++)
        {
            _xCoordinates.Add(_leftTopCorner.x + (_xSummand * i));
        }

        for (int i = 0; i <= zResolution; i++)
        {
            _zCoordinates.Add(_leftTopCorner.z + (_zSummand * i));
        }

        foreach (var _x in _xCoordinates)
        {
            foreach (var _z in _zCoordinates)
            {
                _allSpawnPoints.Add(new Vector3(_x, _spawnHeight, _z));
            }
        }

        List<Vector3> _unspawnableArea = new List<Vector3>();
        foreach (var _spawnPoint in _allSpawnPoints)
        {
            RaycastHit _hit;

            if (Physics.Raycast(_spawnPoint, Vector3.down, out _hit) && _hit.transform.gameObject.tag != "Ground" && _hit.transform.gameObject.tag != "Car")
            {
                _unspawnableArea.Add(_spawnPoint);
            }
        }

        foreach(var _spawnPoint in _unspawnableArea)
        {
            _allSpawnPoints.Remove(_spawnPoint);
        }
    }

    private void Start()
    {
        _car = GameManager.currentCar;
        _coinStartTime = Random.Range(coinSpawnMinTime, coinSpawnMaxTime);

        SpawnCoin();
    }

    private void Update()
    {
        foreach (var _coin in _coinList.ToArray())
        {
            if(_coin != null)
            {
                _coin.transform.Rotate(coinRotateSpeed, coinRotateSpeed, coinRotateSpeed);
            }
            else
            {
                _coinList.Remove(_coin);
                _coinStartTime = Random.Range(coinSpawnMinTime, coinSpawnMaxTime);
            }
        }

        if (_coinStartTime > 0)
        {
            _coinStartTime -= Time.deltaTime;
        }
        else if (_coinList.Count < maxCoinNumber)
        {
            SpawnCoin();
            _coinStartTime = Random.Range(coinSpawnMinTime, coinSpawnMaxTime);
        }
    }

    private void SpawnCoin()
    {
        RecalculateCurrentSpawnPoints();

        Vector3 _spawnPoint = _currentSpawnPoints[Mathf.RoundToInt(Random.Range(0, _currentSpawnPoints.Count))];
        _spawnPoint.y = YPosition(_spawnPoint.x, _spawnPoint.z);

        GameObject _coin = Instantiate(coinPrefab, _spawnPoint, Quaternion.identity);
        _coinList.Add(_coin);

        RecalculateAllSpawnPoints(_spawnPoint);
    }

    private float YPosition(float _xPosition, float _zPosition)
    {
        Vector3 _tempPosition = new Vector3(_xPosition, _spawnHeight, _zPosition);

        RaycastHit _hit;
        Physics.Raycast(_tempPosition, Vector3.down, out _hit);

        return _spawnHeight - _hit.distance + coinYPositionOffset;
    }

    private void RecalculateCurrentSpawnPoints()
    {
        _currentSpawnPoints = _allSpawnPoints;
        List<Vector3> _nearCar = new List<Vector3>();

        foreach(var _spawnPoint in _currentSpawnPoints)
        {
            float _distance = Distance(_car.transform.position, _spawnPoint);
            if(_distance < carMaxDistance)
            {
                _nearCar.Add(_spawnPoint);
            }
        }

        foreach(var _spawnPoint in _nearCar)
        {
            _currentSpawnPoints.Remove(_spawnPoint);
        }
    }

    private void RecalculateAllSpawnPoints(Vector3 _lastSpawnPoint)
    {
        _allSpawnPoints.Remove(_lastSpawnPoint);
        List<Vector3> _nearCoin = new List<Vector3>();

        foreach (var _spawnPoint in _allSpawnPoints)
        {
            float _distance = Distance(_lastSpawnPoint, _spawnPoint);
            if(_distance < coinMaxDistance)
            {
                _nearCoin.Add(_spawnPoint);
            }
        }

        foreach(var _spawnPoint in _nearCoin)
        {
            _allSpawnPoints.Remove(_spawnPoint);
        }
    }

    private float Distance(Vector3 _startPoint, Vector3 _endPoint)
    {
        float _xDistance = _endPoint.x - _startPoint.x;
        float _zDistance = _endPoint.z - _startPoint.z;

        return Mathf.Sqrt((_xDistance * _xDistance) + (_zDistance * _zDistance));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(coinSpawnCenter, coinSpawnSize);
    }
}