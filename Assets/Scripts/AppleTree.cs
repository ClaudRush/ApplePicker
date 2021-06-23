using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private ApplePicker _applePicker;
    [SerializeField] private GameObject _applePrefab;
    [SerializeField] private float _speed;
    [SerializeField] private float _leftAndRightEdge;
    [SerializeField] private float _chanceToChangeDirections;
    [SerializeField] private float _secondsBetweenAppleDrops;

    private void Start()
    {
        Invoke(nameof(DropApple), 2f);
    }

    private void Update()
    {
        Move();
    }
    private void FixedUpdate()
    {
        if (Random.value < _chanceToChangeDirections)
        {
            _speed *= -1f;
        }
    }

    private void Move()
    {
        Vector3 pos = transform.position;
        pos.x += _speed * Time.deltaTime;
        transform.position = pos;
        if (pos.x < -_leftAndRightEdge)
        {
            _speed = Mathf.Abs(_speed);
        }
        else if (pos.x > _leftAndRightEdge)
        {
            _speed = -Mathf.Abs(_speed);
        }
    }

    void DropApple()
    {
        GameObject appleGO = Instantiate(_applePrefab);
        appleGO.transform.position = transform.position;
        appleGO.GetComponent<Apple>().ApplePicker = _applePicker;
        Invoke(nameof(DropApple), _secondsBetweenAppleDrops);
    }
}
