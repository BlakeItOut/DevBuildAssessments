using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomNameGeneratorLibrary;

namespace _3._1_2WelcomeToTheTeamMyPeeps
{
    class Program
    {
        static List<Person> _people = new List<Person>();
        static Random random = new Random();
        static PersonNameGenerator personNameGenerator = new PersonNameGenerator();
        static PlaceNameGenerator placeNameGenerator = new PlaceNameGenerator(); 
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine($"Welcome to the Team, My Peeps!\n    1.List people\n    2.Add person\n    3.Add team member\n    4.Add a random person\n    5.Add random team member\n    6.Quit");
                switch (Validator.promptUser("What would you like to do? ", (num => num == "1" || num == "2" || num == "3" || num == "4" || num == "5" || num == "6")))
                {
                    case "1":
                        _listPeople();
                        break;
                    case "2":
                        _addPerson(_makePerson());
                        break;
                    case "3":
                        _addPerson(_makeTeamMember());
                        break;
                    case "4":
                        _addRandomPerson();
                        break;
                    case "5":
                        _addRandomTeamMember();
                        break;
                    case "6":
                        Console.WriteLine("Have a great day!");
                        Console.ReadKey();
                        return;
                    default:
                        break;
                }
                Console.Write("Press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void _addRandomPerson()
        {
            var randomFirstName = personNameGenerator.GenerateRandomFirstName();
            var randomLastName = personNameGenerator.GenerateRandomLastName();
            _addPerson(randomFirstName, randomLastName, random.Next(19, 120), $"{randomFirstName}{randomLastName}@gmail.com");
        }

        static void _addRandomTeamMember()
        {
            var randomFirstName = personNameGenerator.GenerateRandomFirstName();
            var randomLastName = personNameGenerator.GenerateRandomLastName();
            _addTeamMember(randomFirstName, randomLastName, random.Next(19, 120), $"{randomFirstName}{randomLastName}@quickenloans.com", random.NextDouble()* 100000.0);
            ((TeamMember)(object)_people[_people.Count - 1]).Address = placeNameGenerator.GenerateRandomPlaceName();
        }

        static void _listPeople ()
        {
            _people.ForEach(person => Console.WriteLine(person.ToString()));
        }
        static void _addPerson(string firstName, string lastName, int age, string emailAddress) => _addPerson(new Person(firstName, lastName, age, emailAddress));
        static void _addTeamMember(string firstName, string lastName, int age, string emailAddress, double salary) => _addPerson(new TeamMember(firstName, lastName, age, emailAddress, salary));
        static void _addPerson (Person person)
        {
            if(person.Over18())
            {
                _people.Add(person);
            }
            else
            {
                Console.WriteLine("This person is not over 18 and cannot be added.");
            }
        }
        static Person _makePerson ()
        {
            string firstName = Validator.promptUser("What would you like for their first name? ", (str => !String.IsNullOrWhiteSpace(str)));
            string lastName = Validator.promptUser("What would you like for their last name? ", (str => true));
            int age = int.Parse(Validator.promptUser("What would you like for their age? ", (num => int.TryParse(num, out age) && age >= 0)));
            string emailAddress = Validator.promptUser("What would you like for their email? ", (str => Person.IsValidEmail(str).Result));
            return new Person(firstName, lastName, age, emailAddress);
                
        }
        static TeamMember _makeTeamMember()
        {
            Person person = _makePerson();
            double salary = double.Parse(Validator.promptUser("How much does the team member make?? ", (num => double.TryParse(num, out salary) && salary >= 0)));
            TeamMember teamMember = new TeamMember(person.FirstName, person.LastName, person.Age, person.EmailAddress, salary);
            teamMember.Address = Validator.promptUser("Where is the team member? ", (str => !String.IsNullOrWhiteSpace(str)));
            return teamMember;
        }
    }
}
