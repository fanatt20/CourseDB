using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCourseWork
{
    public class PositionState:IEquatable<PositionState>
    {
        public readonly int ID;
        public readonly string Name;
        public List<PositionState> GetPossibleStates()
        {
            var result = new List<PositionState> { new PositionState(3, "Требуется полставки") };
            if (ID == 0)
                result.Add(new PositionState(0, "Вакантная позиция"));
            return result;


        }
        public PositionState(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }

        public bool Equals(PositionState other)
        {
            return ID == other.ID;
        }
    }
}
