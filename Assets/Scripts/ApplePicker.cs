using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private int _numBaskets;
    [SerializeField] private float _basketBottomY;
    [SerializeField] private float _basketSpacingY;
    [SerializeField] private GameObject _basketPrefab;
    [SerializeField] private List<GameObject> _basketList;

    void Start()
    {
        _basketList = new List<GameObject>();
        for (int i = 0; i < _numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate(_basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = _basketBottomY + (_basketSpacingY * i);
            tBasketGO.transform.position = pos;
            _basketList.Add(tBasketGO);
        }
    }

    public void AppleDestroyed()
    {
        Apple[] tAppleArray = FindObjectsOfType<Apple>();

        foreach (var tApple in tAppleArray)
        {
            Destroy(tApple.gameObject);
        }
    }

    public void BasketDestoyed()
    {
        int basketIndex = _basketList.Count - 1;

        GameObject tBasketGO = _basketList[basketIndex];
        _basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        if (_basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }
}
