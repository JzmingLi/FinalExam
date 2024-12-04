using System.Collections;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public GameObject[] objects;

    public void Start()
    {
        objects = new GameObject[10];
        objects = new GameObject[10];
        for (int i = 0; i < objects.Length; i++)
        {
            GameObject newObject = Instantiate(prefab);
            newObject.SetActive(false);
            objects[i] = newObject;
        }
    }

    public void SpawnObject()
    {
        foreach (GameObject obj in objects)
        {
            if (obj.activeInHierarchy == false)
            {
                obj.SetActive(true);
            }
        }
    }
}
