using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    [SerializeField] private Text _scoreGT;

    private void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        _scoreGT = scoreGO.GetComponent<Text>();
        _scoreGT.text = "0";
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 mousePos2D = Input.mousePosition;

        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = transform.position;
        pos.x = mousePos3D.x;
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);

            int score = int.Parse(_scoreGT.text);
            score += 100;
            _scoreGT.text = score.ToString();

            if (score > HighScore._score)
            {
                HighScore._score = score;
            }
        }
    }
}
