using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{

    [SerializeField] List<PoolItem> PrefabToInstantiate = new();
    [SerializeField] List<GameObject> InstantiatedPrefabList = new();
  
    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine(InstantiatePool());

    }

    // Update is called once per frame


    IEnumerator InstantiatePool()
    {

        foreach (PoolItem item in PrefabToInstantiate)
        {
            for (int i = 0; i < item.PrefabNumber; i++)
            {
                GameObject obj = Instantiate(item.Prefab, transform);
                obj.SetActive(false);
                InstantiatedPrefabList.Add(obj);
                yield return null;
            }
        }

    }

    public GameObject GetPrefabFromTheBool()
    {
        foreach (GameObject obj in InstantiatedPrefabList)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }
        return null;
    }

    public GameObject GetRandomPrefabFromTheBool()
    {

        int x = Random.Range(0, InstantiatedPrefabList.Count);
        if (!InstantiatedPrefabList[x].activeInHierarchy)
        {

            return InstantiatedPrefabList[x];
        }
        else
        {
            return GetPrefabFromTheBool();
        }

    }

}



[System.Serializable]
public class PoolItem
{
    public GameObject Prefab;
    public int PrefabNumber;
}
