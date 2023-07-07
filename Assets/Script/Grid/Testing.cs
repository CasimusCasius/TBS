using BTS.Core;
using BTS.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private GridSystem gridSystem;
    private MouseToWorldPosition mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        gridSystem = new GridSystem(10, 10,2f);
        mousePosition =  FindObjectOfType<MouseToWorldPosition>();

        Debug.Log(new GridPosition(5, 7));

    }

    private void Update()
    {

        Debug.Log(gridSystem.GetGridPosition(mousePosition.GetMousePosition()));
    }


}
