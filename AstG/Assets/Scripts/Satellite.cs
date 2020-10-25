using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour
{

    void Update()
    {
        transform.RotateAround(new Vector3(0,-1,0), Vector3.forward, 20 * Time.deltaTime);
    }
}
