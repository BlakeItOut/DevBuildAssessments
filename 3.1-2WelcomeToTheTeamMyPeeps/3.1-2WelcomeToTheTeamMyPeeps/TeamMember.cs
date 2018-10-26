using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1_2WelcomeToTheTeamMyPeeps
{
    class TeamMember : Person
    {
        public double Salary { get; set; }
        public string Address { get; set; }
        public TeamMember(string firstName, string lastName, int age, string emailAddress, double salary) : base(firstName, lastName, age, emailAddress)
        {
            Salary = salary;
        }
        public override string ToString() => $"{base.ToString()}, Salary: {Salary:C}, Location: {Address}";
    }
}
