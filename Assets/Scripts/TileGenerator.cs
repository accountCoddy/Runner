using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Transform _tileHolder;
    [SerializeField] private List<Tile> _tiles = new List<Tile>();
    [SerializeField] private float _speed;
    [SerializeField] private float _maxCount;
    private float _timer;
    void Start()
    {
        _tiles[0].speed = _speed;
        for (int i = 0; i < _maxCount; i++)
        {
            GenerateTile();
        }
    }

    void Update()
    {
        if(_tiles.Count < _maxCount)
        {
            GenerateTile();
        }

        _timer += Time.deltaTime;
        if (_timer >= 10)
        {
           _timer = 0;
           UpSpeed(5);
        }

    }

    private void GenerateTile()
    {
        GameObject newTileObject = Instantiate(_tilePrefab, _tiles.Last().transform.position + Vector3.forward * 5, Quaternion.identity);
        Tile newTile = newTileObject.GetComponent<Tile>();
        newTile.speed = _speed;
        _tiles.Add(newTile);
        newTile.transform.SetParent(_tileHolder);
    }
    private void OnTriggerEnter(Collider other)
    {
        _tiles.Remove(other.GetComponent<Tile>());
        Destroy(other.gameObject);
    }

    public void UpSpeed(float newSpeed)
    {
        _speed += newSpeed;
        foreach (Tile tile in _tiles)
        {
            tile.speed += newSpeed;
        }
    }
}
