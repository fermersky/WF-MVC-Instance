using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Helpers;

namespace WindowsFormsApp1.Models
{
    public class Model : ObservableObject, IModel
    {
        List<Person> persons;
        public List<Person> Persons
        {
            get { return persons; }
            set
            {
                persons = value;
                OnPropertyChanged("Persons");
            }
        }

        public Model()
        {
            Persons = new List<Person>();
        }

        public void Add(Person person)
        {
            Persons.Add(person);
        }

        public void Load()
        {
            Persons.Add(new Person { Name = "John", Surname = "Doe", Age = 22 });
            Persons.Add(new Person { Name = "Egor", Surname = "Fermersky", Age = 24 });
            Persons.Add(new Person { Name = "Sergey", Surname = "Sarnitsky", Age = 25 });
        }

        public void Edit(Person pers, int index)
        {
            if (index != -1)
                persons[index] = pers;
        }
    }
}
