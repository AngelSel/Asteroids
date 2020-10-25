using UnityEngine;

public class CameraMovements : MonoBehaviour
{

    public Transform target;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, target.position.y+3, transform.position.z);
    }
}
