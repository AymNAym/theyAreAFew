using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    private float bulletSpeed = 20f;
    private bool canShoot = true;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("FirePlayer1") > .2f && canShoot == true)
        {
            Shoot();
            StartCoroutine(WaitForShooting());
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }

    IEnumerator WaitForShooting()
    {
        canShoot = false;
        yield return new WaitForSeconds(.1f);
        canShoot = true;
    }
}
