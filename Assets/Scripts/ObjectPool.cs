using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;
    
    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialized(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawnedObject = Instantiate(prefab, _container);
            spawnedObject.SetActive(false);

            _pool.Add(spawnedObject);
        }
    }

    protected void Initialized(GameObject[] prefabs)
    {
        for (int i = 0; i < _capacity; i++)
        {
            int randomObject = Random.Range(0, prefabs.Length);
            GameObject spawnedObject = Instantiate(prefabs[randomObject], _container);
            spawnedObject.SetActive(false);
            
            _pool.Add(spawnedObject);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }
}
