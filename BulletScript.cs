using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, .4f);
        GameObject col = collision.gameObject;

        if (col.tag == "Ennemi")
        {
            EnnemiScript ennemiScript = col.GetComponent<EnnemiScript>();
            ennemiScript.SetHealth(20);
            int ennemiHealth = ennemiScript.GetHealth();

            if(ennemiHealth <= 0)
            {
                Destroy(col);
            }
        }
    }
}
