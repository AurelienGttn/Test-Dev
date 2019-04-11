using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cube : MonoBehaviour
{
    private CubeManager cubeManager;
    
    void Start()
    {
        cubeManager = FindObjectOfType<CubeManager>();
    }
    
    private void OnMouseDown()
    {
        // Make sure the panel isn't active
        if (!EventSystem.current.IsPointerOverGameObject())
            // Check if this is the right cube
            cubeManager.CheckCube(CubeManager.chosenOne == this);
    }
}
