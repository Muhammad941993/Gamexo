using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{

    [SerializeField] List<PoolItem> Enemy;
    [SerializeField] List<GameObject> EnemyList = new();
  
    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine(InstantiatePool());

    }

    // Update is called once per frame


    IEnumerator InstantiatePool()
    {

        foreach (PoolItem item in Enemy)
        {
            for (int i = 0; i < item.PrefabNumber; i++)
            {
                GameObject E = Instantiate(item.EnemyPrefab, transform);
                E.SetActive(false);
                EnemyList.Add(E);
                yield return null;
            }
        }

    }

    public GameObject Get()
    {
        foreach (GameObject g in EnemyList)
        {
            if (!g.activeInHierarchy)
                return g;
        }
        return null;
    }

    public GameObject GetRandoum()
    {

        int x = Random.Range(0, EnemyList.Count);
        if (!EnemyList[x].activeInHierarchy)
        {

            return EnemyList[x];
        }
        else
        {
            return Get();
        }

    }

}



[System.Serializable]
public class PoolItem
{
    public GameObject EnemyPrefab;
    public int PrefabNumber;
}
