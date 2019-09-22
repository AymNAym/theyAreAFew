using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> players = new List<GameObject>();
    [SerializeField] GameObject player1;
    //[SerializeField] GameObject player2;

    private void Start()
    {
        GameObject firstPlayer = Instantiate(player1, transform.GetChild(0));
        //GameObject secondPlayer = Instantiate(player2, transform.GetChild(1));

        players.Add(firstPlayer);
    }
}
