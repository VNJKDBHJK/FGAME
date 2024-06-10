using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadow_pool : MonoBehaviour
{
    public static shadow_pool instance;

    public GameObject shadowPrefab;

    public int shadowCount;

    private Queue<GameObject> avaliableObjects = new Queue<GameObject>();//ÃÌº”∂”¡–
    private void Awake()
    {
        instance = this;
        FillPool();
    }
    public void FillPool()
    {
        for(int i = 0; i < shadowCount; i++)
        {
            var newShadow = Instantiate(shadowPrefab);
            newShadow.transform.SetParent(transform);

            ReturnPool(newShadow);
        }
    }
    public void ReturnPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        avaliableObjects.Enqueue(gameObject);
    }

    public GameObject GetFormPool()
    {
        if(avaliableObjects.Count == 0)
        {
            FillPool();
        }
        var outshadow = avaliableObjects.Dequeue();
        outshadow.SetActive(true);

        return outshadow;
    }
}
