
using BTS.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTS.Grid
{
	public class GridObject
	{
		//private GridSystem gridSystem;
		private GridPosition gridPosition;
        private List<Unit> units;

        public GridObject(GridPosition gridPosition) //public GridObject(GridSystem gridSystem, GridPosition gridPosition)
        {
            //this.gridSystem = gridSystem;
            this.gridPosition = gridPosition;   
            units = new List<Unit>();
        }

        public override string ToString()
        {
            string unitString = "";
            foreach (var unit in units)
            {
                unitString += unit.ToString() + "\n";
            }


            return gridPosition.ToString() + "\n" + unitString;
        }

        public void AddUnit(Unit unit)
        {
            units.Add(unit);
        }

        public void RemoveUnit(Unit unit)
        {
            units.Remove(unit);
        }

        public List<Unit> GetUnitList() => units;

        public bool HasAnyUnit() => units.Count > 0;
        
        

    } 
}
