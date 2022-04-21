using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameStart;

    public GameObject player;
    public GameObject bombObject;
    public GameObject[] spawnPoint;

    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'instance de 'GameManager' dans la scène");
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameStart = true;
        StartGame();
    }

    public void StartGame()
    {
        StartCoroutine(SpawnBomb());
    }

    IEnumerator SpawnBomb()
    {
        int index;
        while (!player.GetComponent<PlayerController>().isDie)
        {
            index = Random.Range(0, 4);

            Instantiate(bombObject, spawnPoint[index].transform.position, spawnPoint[index].transform.rotation);

            yield return new WaitForSeconds(5f);
        }
    }
}
