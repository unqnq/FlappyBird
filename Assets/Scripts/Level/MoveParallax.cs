using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParallax : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
        if (transform.position.x < -7)
        {
            transform.position = new Vector3(7.6f, transform.position.y, transform.position.z);
        }
    }
}
