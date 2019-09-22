using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject ennemi;
    private int spawnNumber = 5;
    private float spawnOffset = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for(int i = 0; i < spawnNumber; i++)
        {
            Vector3 spawnPos = transform.position;

            if (transform.position.x != 0)
            {
                spawnPos.y = Random.Range(-spawnOffset, spawnOffset);
            }
            else if(transform.position.y != 0)
            {
                spawnPos.x = Random.Range(-spawnOffset, spawnOffset);
            }

            Instantiate(ennemi, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }
    }
}
