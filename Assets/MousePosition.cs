using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // on mouse click spawn object
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Clicked");
            SpawnObjectOnMousePosition();
        }
        
    }

    void SpawnObjectOnMousePosition()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // call spawner script
        Spawner spawner = GameObject.Find("Spawner").GetComponent<Spawner>();

        spawner.SpawnObject(mousePosition);
    }
}
