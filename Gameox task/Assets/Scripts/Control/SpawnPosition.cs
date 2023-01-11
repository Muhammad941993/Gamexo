using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    [SerializeField] Instantiate Fishbool;

    private void Awake()
    {
        Fishbool = Instantiate(Fishbool);
    }
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("GetFish", 1, .7f);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void GetFish()
    {
        var g = Fishbool.GetRandomPrefabFromTheBool();
        if (g == null) return;
        g.transform.position = new Vector3(20, 0, 0);
        g.transform.RotateAround(transform.position, Vector3.forward, Random.Range(0, 360));
        g.transform.Rotate(Vector3.forward, Random.Range(-15, 15));
        g.SetActive(true);
    }
}
