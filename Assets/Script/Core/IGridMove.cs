using BTS.Grid;
using BTS.Units;
using System.Collections.Generic;

namespace BTS.Core
{
    public interface IGridMove
    {
        public void AddUnitAtGridPosition(GridPosition gridPosition, Unit unit);
        public List<Unit> GetUnitListAtGridPosition(GridPosition gridPosition);
        public void RemoveUnitAtGridPosition(GridPosition gridPosition, Unit unit);
    }
}
