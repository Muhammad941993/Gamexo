using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject explosionprefab;
    [SerializeField] float speed = 1;
    bool stopMove;
    private void Start()
    {
        stopMove = false;
        explosionprefab.SetActive(false);
    }
    void Update()
    {
        if (stopMove) return;

        transform.Translate(speed * Time.deltaTime * Vector3.up);
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("Projectile")) return;
        if (collision.CompareTag("Fish"))
        {
            collision.GetComponent<Fish>().DecreaseHelath();
            StartCoroutine(HandelExplosion());
        }
    }

    IEnumerator HandelExplosion()
    {
        stopMove = true;
        explosionprefab.SetActive(true);
        yield return new WaitForSeconds(.3f);
        explosionprefab.SetActive(false);
        gameObject.SetActive(false);
        stopMove = false;
    }
}
