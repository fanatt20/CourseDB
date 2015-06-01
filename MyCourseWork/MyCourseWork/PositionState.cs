using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCourseWork
{
    public class PositionState : IEquatable<PositionState>
    {
        public readonly int ID;
        public readonly string State;
        public List<PositionState> GetPossibleStates()
        {

            var result = new List<PositionState> { new PositionState(1, "Полставки") };
            if (ID != 1)
                result.Add(new PositionState(2, "Ставка"));
            return result;
        }
        public PositionState(int id, string state)
        {
            ID = id;
            State = state;
        }

        public bool Equals(PositionState other)
        {
            return ID == other.ID;
        }
        public override string ToString()
        {
            return State;
        }

    }
}
