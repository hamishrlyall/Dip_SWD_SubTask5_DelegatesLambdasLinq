using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ObjectLibrary;


namespace FileParserNetStandard
{

    public class PersonHandler
    {
        public List<Person> People;

        /// <summary>
        /// Converts List of list of strings into Person objects for People attribute.
        /// </summary>
        /// <param name="people"></param>
        public PersonHandler(List<List<string>> people)
        {
            People = new List<Person>();

            foreach (List<string> row in people.Skip(1))
            {
                People.Add(new Person(int.Parse(row[0]), row[1], row[2], new DateTime(long.Parse(row[3]))));
            }

        }

        /// <summary>
        /// Gets oldest people
        /// </summary>
        /// <returns></returns>
        public List<Person> GetOldest()
        {
            DateTime oldest = People.Select(x => x.Dob).Min();

            return People.Where(x => x.Dob == oldest).ToList();
        }

        /// <summary>
        /// Gets string (from ToString) of Person from given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetString(int id)
        {
            return People.Find(x => x.Id == id).ToString();
        }

        public List<Person> GetOrderBySurname()
        {
            return People.OrderBy(x => x.Surname).ToList();
        }

        /// <summary>
        /// Returns number of people with surname starting with a given string.  Allows case-sensitive and case-insensitive searches
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public int GetNumSurnameBegins(string searchTerm, bool caseSensitive)
        {

            return People.Select(x => x.Surname).Where(y => y.StartsWith(searchTerm, !caseSensitive, null)).Count();
        }
        
        /// <summary>
        /// Returns a string with date and number of people with that date of birth.  Two values seperated by a tab.  Results ordered by date.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAmountBornOnEachDate()
        {
            List<string> result = new List<string>();

            return result;  //-- return result here
        }
    }
}