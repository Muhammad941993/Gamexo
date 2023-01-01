using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FireWeapon : MonoBehaviourPunCallbacks
{
    [SerializeField] AudioSource Shout;
    [SerializeField] AudioClip clip;
    [SerializeField] Instantiate bulletPool;

    private void Awake()
    {
       
        bulletPool = Instantiate(bulletPool);
      
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine) return;

        if (Input.GetMouseButtonUp(0))
        {
           var bullet = bulletPool.Get();
            if (bullet == null) return;
            bullet.SetActive(true);
            Shout.PlayOneShot(clip);
            bullet.transform.rotation = gameObject.transform.rotation;
            bullet.transform.position = gameObject.transform.position;
        }
    }


    void MakeBullets()
    {

    }

}
