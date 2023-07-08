using BTS.Core;
using System;
using System.Collections;
using UnityEngine;

namespace BTS.Units
{
    public class UnitActionSystem : MonoBehaviour
    {
        public event EventHandler OnSelectedUnitChange;

        [SerializeField] private Unit selectedUnit;
        [SerializeField] private LayerMask unitLayerMask;

        private MouseToWorldPosition mousePosition;
        bool gameReady = false;
        private void Start()
        {
            mousePosition = FindObjectOfType<MouseToWorldPosition>();
            StartCoroutine(UpdateSelectUnit());
        }

        private IEnumerator UpdateSelectUnit()
        {
            yield return new WaitForSeconds(0.25f);
            selectedUnit = FindObjectOfType<Unit>();
            SetSelectedUnit(selectedUnit);
            gameReady = true;

        }

        void Update()
        {

            if (gameReady && Input.GetMouseButtonDown(0))
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