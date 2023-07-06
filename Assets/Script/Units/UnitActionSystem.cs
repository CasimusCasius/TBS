using BTS.Core;
using System;
using UnityEngine;

namespace BTS.Units
{
    public class UnitActionSystem : MonoBehaviour
    {
        public event EventHandler OnSelectedUnitChange;

        [SerializeField] private Unit selectedUnit;
        [SerializeField] private LayerMask unitLayerMask;

        private MouseToWorldPosition mousePosition;

        private void Start()
        {
            mousePosition = FindObjectOfType<MouseToWorldPosition>();
            selectedUnit = FindAnyObjectByType<Unit>();
            SetSelectedUnit(selectedUnit);
        }

        void Update()
        {

            if (Input.GetMouseButtonDown(0))
            {
                if (TryHandleUnitSelection()) return;
                selectedUnit.SetMoveTarget(mousePosition.GetMousePosition());
            }
        }

        public Unit GetSelectedUnit() => selectedUnit;

        private bool TryHandleUnitSelection()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, unitLayerMask))
            {
                Debug.Log("Changing unit");
                if (hit.transform.TryGetComponent(out Unit unit))
                {
                    SetSelectedUnit(unit);
                    return true;
                }

            }
            return false;
        }

        private void SetSelectedUnit(Unit unit)
        {
            selectedUnit = unit;

            OnSelectedUnitChange?.Invoke(this, EventArgs.Empty);
        }



    }
}