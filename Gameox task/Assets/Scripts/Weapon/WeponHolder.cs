using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponHolder : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    AudioSource Shout;

    List<GameObject> WeaponList = new();
    Weapon CurrentWeapon;
    // Start is called before the first frame update
    private void Awake()
    {
        var weaponList = GameObject.FindGameObjectsWithTag("Weapon");
        // Convert And Hide The Weapons
        ConvertArrayToList(weaponList, WeaponList);

        Shout = GetComponent<AudioSource>();

    }

    private void Start()
    {
        // Shwo The First Weapon
        EnableWeapon(0);
    }

    void ConvertArrayToList(GameObject[] gameObjects , List<GameObject> objectsList)
    {
        foreach(GameObject @object in gameObjects)
        {
            @object.GetComponent<Weapon>().GetWeaponFire().OnFire.AddListener(() => PlaySound());
            @object.SetActive(false);
            objectsList.Add(@object);
        }
    }
    
    void EnableWeapon(int weaponNumber)
    {
        WeaponList[weaponNumber].SetActive(true);
        CurrentWeapon = GetActiveWeapon().GetComponent<Weapon>();
      //  CurrentWeapon.GetWeaponFire().OnFire.AddListener(() => PlaySound());
    }


    void DisableWeapon(int weaponNumber)
    {
        WeaponList[weaponNumber].SetActive(false);
    }
    // called from UI Button
    public void ShowNextWeapon()
    {
        for (int i = 0 , x = WeaponList.Count; i < x; i++)
        {
            if (WeaponList[i].activeSelf)
            {
                if (i + 1 == x) return;

                DisableWeapon(i);

                EnableWeapon(i+1);
                break;
            }

        }
    }

    // called from UI Button
    public void ShowLastWeapon()
    {
        for (int i = 0, x = WeaponList.Count; i < x; i++)
        {
            if (WeaponList[i].activeSelf)
            {
                if (i == 0) return;

                DisableWeapon(i);

                EnableWeapon(i - 1);
                break;
            }

        }
    }


    GameObject GetActiveWeapon()
    {
        int weaponNum = -1;
        for (int i = 0, x = WeaponList.Count; i < x; i++)
        {
            if (!WeaponList[i].activeSelf) continue;

            weaponNum = i;
        }
        return WeaponList[weaponNum];
    }


    void PlaySound()
    {
      Shout.PlayOneShot(clip);
        print("Sound");
    }
}
