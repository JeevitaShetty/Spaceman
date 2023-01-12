using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipScript : MonoBehaviour
{
    [SerializeField] float shipSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpawnRate = 5;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * shipSpeed * Time.deltaTime);


        if (timer < bulletSpawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            bulletDelay();
            timer = 0;
        }

    }

    private void bulletDelay()
    {
 
        GameObject bulletSpawn = Instantiate(bullet, transform.position , Quaternion.identity);
        //here cuz of above line the ships will be chosen randomly among the 3 ships.
        //Quaternion.identity is used to make rotation value 0,0,0

        
    }

}
