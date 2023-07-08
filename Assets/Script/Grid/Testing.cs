
using BTS.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] Unit unit;
    void Start()
    {
       

       

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            unit.GetMoveAction().GetValidActionGridPositionList();
        }
        
    }


}
