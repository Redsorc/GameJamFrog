using System.Collections.Generic;
using TurnBasedStrategyFramework.Common.Cells;
using UnityEngine;

namespace TurnBasedStrategyFramework.Unity.Cells
{
    /// <summary>
    /// Unity-specific implementation of a square cell.
    /// </summary>
    public class Square : Cell
    {
        private Vector3 _cellDimensions = new Vector3(1f, 1f, 1f);
        public override Vector3 CellDimensions { get => _cellDimensions; protected set => _cellDimensions = value; }
        public override CellShape CellShape { get; protected set; } = CellShape.Square;

        public override int GetDistance(ICell otherCell)
        {
            return SquareHelper.GetDistance(this, otherCell);
        }

        public override IEnumerable<ICell> GetNeighbours(ICellManager cellManager)
        {
            return SquareHelper.GetNeighbours(this, cellManager);
        }
    }
}