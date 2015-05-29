using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCourseWork
{
    public class VacantDepartment:IEquatable<VacantDepartment>
    {
        public readonly int ID;
        public readonly string Name;
        public readonly List<VacantPosition> VacantPositions;
        public void AddToDepartment( VacantPosition position){
            VacantPositions.Add(position);
        }
        public void AddToDepartment(int positionID,Decimal maxSalary, string positionName,PositionState posistionState )
        {
            VacantPositions.Add(new VacantPosition(positionID,maxSalary, positionName, posistionState));
        }
        public VacantDepartment(int id, string name)
        {
            this.ID = id;
            this.Name = name;
            VacantPositions = new List<VacantPosition>();
        }
        private VacantDepartment() { }
        public override string ToString()
        {
            return Name;
        }


        public bool Equals(VacantDepartment other)
        {
            return Name.CompareTo(other.Name)==0;
        }
    }
}
