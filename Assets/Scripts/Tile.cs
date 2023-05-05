using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private List<Transform> _points = new List<Transform>();
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _bomb;
    public float speed;

    void Start()
    {
        int randomCoinNumber = Random.Range(0, _points.Count);
        print(randomCoinNumber);
        if (Time.time < 5)
        {
            GameObject newCoint = Instantiate(_coin, _points[randomCoinNumber].position, _coin.transform.rotation);
            newCoint.transform.SetParent(transform);
        }
        else if (Time.time >= 5)
        {
            if (Random.Range(0, 3) != 2)
            {
                GameObject newCoint = Instantiate(_coin, _points[randomCoinNumber].position, _coin.transform.rotation);
                newCoint.transform.SetParent(transform);
            }
            else
            {
                GameObject newBom = Instantiate(_bomb, _points[randomCoinNumber].position, _bomb.transform.rotation);
                newBom.transform.SetParent(transform);
            }
        }

    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.back * Time.fixedDeltaTime * speed);
    }
}
