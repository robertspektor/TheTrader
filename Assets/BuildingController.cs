using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public bool isInConstruction = true;
    private int currentWorkers = 0;

    // Update is called once per frame
    void Update()
    {
        UpdateColor();
        Contruct();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Worker")
        {
            currentWorkers++;
        }
    }

    void Contruct()
    {
        // check if building is in construction
        if (isInConstruction)
        {
            // check if currentWorkers is greater than 0
            if (currentWorkers > 0)
            {
               isInConstruction = false;
               // remove tag InConstruction
                gameObject.tag = "Building";
            }
        }
    }

    void UpdateColor()
    {
        // check if building is in construction
        if (isInConstruction)
        {
            // set color of the mesh to red
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            // set color to green
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
}
