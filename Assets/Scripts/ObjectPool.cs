using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    private static ObjectPool instance;

    static Dictionary<int, Queue<GameObject>> pool = new Dictionary<int, Queue<GameObject>>();

    static Dictionary<int, GameObject> fillPool = new Dictionary<int, GameObject>();

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public static void PreLoad(GameObject Prefab, int amount)
    {
        int id = Prefab.GetInstanceID();

        GameObject category = new GameObject();

        category.name = Prefab.name + "Pool";

        fillPool.Add(id, category);

        pool.Add(id, new Queue<GameObject>());

        for (int i = 0; i < amount; i++)
        {
            CreateObject(Prefab);
        }            
    }

    static void CreateObject(GameObject Prefab)
    {
        int id = Prefab.GetInstanceID();
        GameObject prefabCopy = Instantiate(Prefab) as GameObject;

        //prefabCopy.transform.SetParent(Getparent(id).transform);
        prefabCopy.SetActive(false);
        pool[id].Enqueue(prefabCopy);
    }




    
}
