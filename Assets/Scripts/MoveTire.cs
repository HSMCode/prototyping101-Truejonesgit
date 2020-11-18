using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTire : MonoBehaviour
{

    public float lifetime = 10f;
    public GameObject tire;


    void Start()
    {
        Invoke("destroyTire", lifetime);
    }



    void Update()
    {
        transform.Translate(Vector3.forward * 5f * Time.deltaTime);

        transform.Rotate(Vector3.left * 50f * Time.deltaTime);
    }

    void destroyTire()
    {
        Destroy(tire);
    }
}
