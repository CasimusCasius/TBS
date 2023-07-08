using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BTS.Grid
{
    public class GridDebugObject : MonoBehaviour
    {
        [SerializeField] TextMeshPro textDebugObject;

        GridObject gridObject;

        private void Update()
        {
            textDebugObject.text = gridObject.ToString();
        }

        public void SetGridObject(GridObject gridObject)
        {
            this.gridObject = gridObject;
        }

    } 
}
