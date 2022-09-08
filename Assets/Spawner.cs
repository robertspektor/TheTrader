using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    
    public float timeToSpawn = 1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SpawnObject(Vector2 position)
    {
        Debug.Log("Spawning Object");
        GameObject newObject = Instantiate(objectToSpawn, position, Quaternion.identity);
        
        // set name of new object
        newObject.name = "Building";

        // create tag Building and InConstruction and add to new object
        newObject.tag = "InConstruction";
        


        // add BuildingController to new object
        newObject.AddComponent<BuildingController>();


    }

}
