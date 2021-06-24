using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField] private float _bottomY = -20f;
    [SerializeField] private ApplePicker _applePicker;

    public ApplePicker ApplePicker { get => _applePicker; set => _applePicker = value; }

    void Update()
    {
        if (transform.position.y < _bottomY)
        {
            Destroy(gameObject);
            _applePicker.AppleDestroyed();
            _applePicker.BasketDestoyed();
        }
    }
}
