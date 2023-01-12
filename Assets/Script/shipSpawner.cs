using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] spaceShips;
    [SerializeField] float spawnRate = 5;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        shipDelay();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            shipDelay();
            timer = 0;
        }

    }

    private void shipDelay()
    {
        int rand = Random.Range(0, 3);
        float heightRange = Random.Range(-7.4f, 7.4f);
        GameObject shipSpawn = Instantiate(spaceShips[rand], new Vector2(44f, heightRange), Quaternion.identity);
        //here cuz of above line the ships will be chosen randomly among the 3 ships.
        //Quaternion.identity is used to make rotation value 0,0,0

        
        
    }
}

