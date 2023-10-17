using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10f;

    void Update() 
    {
        Rotate();
        if(transform.position.y <= FindObjectOfType<BallController>().transform.position.y -10)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    void Rotate()
    {
        transform.Rotate(new Vector3(0f, 0f, rotationSpeed * Time.deltaTime));
    }

}
