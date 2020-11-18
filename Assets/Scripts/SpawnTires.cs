using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTires : MonoBehaviour
{
    public GameObject tire;
 

    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    
    

   
    void Start()
    {
        
        InvokeRepeating("spawnTire", startDelay, spawnInterval);

        
    }

    

    void spawnTire()
    {
       

        Instantiate(tire, this.transform.position, tire.transform.rotation);
        
    }

   

}
