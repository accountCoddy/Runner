using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private Animator _playerAnim;
    private int _coinsCount;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void AddCoin()
    {
        _coinsCount++;
        _coinsText.text = _coinsCount.ToString();
    }

    public void Lose()
    {
        
        _playerAnim.SetTrigger("death");
        FindObjectOfType<Player>().enabled = false;
        FindObjectOfType<TileGenerator>().enabled = false;

        Tile[] allTile = FindObjectsOfType<Tile>();
        foreach (Tile tile in allTile)
        {
            tile.speed = 0;
        }

        PlayerPrefs.SetInt("best", _coinsCount);
        PlayerPrefs.Save();
        
    }
}
