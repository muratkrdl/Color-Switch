using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    [SerializeField] GameObject circlePrefab;
    [SerializeField] Transform player;

    Vector3 target;

    void Start() 
    {
        target = new Vector3(0f, 0, 0);    
    }

    void Update() 
    {
        if(player.position.y > target.y-10)
        {
            target.y +=10;
            var circle = Instantiate(circlePrefab);

            circle.transform.position = target;
        }
    }

}
