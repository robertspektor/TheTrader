using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RandomWalk();

        FindBuildingObject();
        MoveToTarget();
        
        
    }

    void FindBuildingObject()
    {
        
        // find all objects with tag "InConstruction"
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("InConstruction");

        // check if there are any buildings
        if (buildings.Length > 0)
        {
            // set target to first building
            target = buildings[0];
        }
    }

    void MoveToTarget()
    {
        if (target != null)
        {
            // move towards target
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    void RandomWalk()
    {
        if (target == null)
        {
            // move in random direction
            transform.position += new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)) * speed * Time.deltaTime;
        }
        
    }

}
