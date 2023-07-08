

using UnityEngine;

namespace BTS.Grid
{
    public class GridSystem
    {
        private int width, height;
        private float cellSize;
        private GridObject[,] gridObjectsArray;


        public GridSystem(int width, int height, float cellSize)
        {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;
            
            gridObjectsArray = new GridObject[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    
                    gridObjectsArray[x,z]= new GridObject(new GridPosition(x,z));

                }
            }

        }
        public Vector3 GetWorldPosition(GridPosition gridPosition)
        {
            return new Vector3(gridPosition.x, 0, gridPosition.z) * cellSize;
        }

        public GridPosition GetGridPosition(Vector3 worldPosition)
        {
            return new GridPosition(
                Mathf.RoundToInt(worldPosition.x / cellSize),
                Mathf.RoundToInt(worldPosition.z / cellSize));

        }

        public void CreateDebugObjects(Transform debugPrefab)
        {
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    GridPosition gridPosition = new GridPosition(x,z);
                    var debugTransform =  GameObject.Instantiate(debugPrefab, GetWorldPosition(gridPosition),Quaternion.identity);
                    var gridDebugObject =  debugTransform.GetComponent<GridDebugObject>();
                    gridDebugObject.SetGridObject(GetGridObject(gridPosition));
                }
            }

        }

        public GridObject GetGridObject(GridPosition gridPosition)
        {
            return gridObjectsArray[gridPosition.x, gridPosition.z];
        }

    }

}