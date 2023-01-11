using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireWeapon : MonoBehaviour
{

    [SerializeField] Instantiate MyBulletBool;
   
    

    public UnityEvent OnFire;
    private void Awake()
    {
     
     // MyBulletBool =  gameObject.GetComponent<Instantiate>();
    }
    // Start is called before the first frame update
    void Start()
    {
        OnFire.AddListener(() => Fire());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            OnFire.Invoke();
        }
    }


    void Fire()
    {
        var bullet = MyBulletBool.GetPrefabFromTheBool();
        if (bullet == null) return;
        bullet.SetActive(true);
        bullet.transform.rotation = gameObject.transform.rotation;
        bullet.transform.position = gameObject.transform.position;
        print(transform.name);
    }
  

}
