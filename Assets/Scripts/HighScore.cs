using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int _score;
    [SerializeField] private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
        if (PlayerPrefs.HasKey("HighScore"))
        {
            _score = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", _score);
    }
    void Update()
    {
        _text.text = "High Score: " + _score;
        if (_score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", _score);
        }
    }
}
