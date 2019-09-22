using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiScript : MonoBehaviour
{
    private int health = 100;

    public void SetHealth(int damages)
    {
        health -= damages;
    }

    public int GetHealth()
    {
        return health;
    }
}
