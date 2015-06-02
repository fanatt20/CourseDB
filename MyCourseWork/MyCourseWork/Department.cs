using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCourseWork
{
    public class Department:IEquatable<Department>
    {
        public readonly int ID;
        public readonly string Name;
        public readonly List<Position> VacantPositions;
        public void AddToDepartment( Position position){
            VacantPositions.Add(position);
        }
        public void AddToDepartment(int positionID,Decimal maxSalary, string positionName,PositionState posistionState )
        {
            VacantPositions.Add(new Position(positionID,maxSalary, positionName, posistionState));
        }
        public Department(int id, string name)
        {
            this.ID = id;
            this.Name = name;
            VacantPositions = new List<Position>();
        }
        private Department() { }
        public override string ToString()
        {
            return Name;
        }


        public bool Equals(Department other)
        {
            return Name.CompareTo(other.Name)==0;
        }
    }
}
