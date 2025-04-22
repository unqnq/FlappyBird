using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float pipeSpeed;
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * pipeSpeed;
        if (transform.position.x < -4)
        {
            Destroy(gameObject);
        }
    }
}
