using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCourseWork
{
    public class Position:IEquatable<Position>
    {
        public readonly Int32 ID;
        public readonly String Name;
        public PositionState State;
        public readonly Decimal MaxSalary;
        public Position(Int32 id,Decimal maxSalary ,String name, PositionState state)
        {
            ID = id;
            Name = name;
            State = state;
            MaxSalary = maxSalary;
        }
        public override String ToString()
        {
            return Name;
        }

        public bool Equals(Position other)
        {
            return (Name.CompareTo(other.Name)==0)&&(ID==other.ID) &&(State==other.State);
        }
    }
}
