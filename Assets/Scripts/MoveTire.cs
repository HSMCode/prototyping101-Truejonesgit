using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTire : MonoBehaviour
{

  

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 5f * Time.deltaTime);

        transform.Rotate(Vector3.left * 50f * Time.deltaTime);
    }
}
