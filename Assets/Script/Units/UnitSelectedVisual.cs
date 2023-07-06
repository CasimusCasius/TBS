using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTS.Units
{

    public class UnitSelectedVisual : MonoBehaviour
    {
        [SerializeField] private Unit unit;

        private UnitActionSystem actionSystem;
        private MeshRenderer meshRenderer;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Start()
        {
            actionSystem = FindObjectOfType<UnitActionSystem>();
            meshRenderer.enabled = false;
            actionSystem.OnSelectedUnitChange += ActionSystem_OnSelectedUnitChange;
        }

        private void ActionSystem_OnSelectedUnitChange(object sender, System.EventArgs e)
        {
            Debug.Log("Event action");
            if (actionSystem.GetSelectedUnit() == unit)
            {
                Debug.Log("Event action");
                meshRenderer.enabled = true;
            }
            else
            {
                meshRenderer.enabled = false;
            }
        }

        private void OnDisable()
        {
            actionSystem.OnSelectedUnitChange -= ActionSystem_OnSelectedUnitChange;
        }

    } 
}
