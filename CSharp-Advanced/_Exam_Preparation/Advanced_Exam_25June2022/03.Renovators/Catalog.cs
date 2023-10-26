using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {

        private readonly List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            renovators = new List<Renovator>();
        }

        public string Name { get; set; }

        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count => renovators.Count;
        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            if (NeededRenovators <= renovators.Count)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";

        }

        public bool RemoveRenovator(string name)
        {
            return renovators.Remove(renovators.FirstOrDefault(r => r.Name == name));
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            var list = renovators.FindAll(r => r.Type == type);

            foreach (var item in list)
            {
                renovators.Remove(item);
            }

            return list.Count;
        }

        public Renovator HireRenovator(string name)
        {
            var item = renovators.FirstOrDefault(r => r.Name == name);  
            if (item == null)
            {
                return null;
            }
            item.Hired = true;
            return item;
        }

        public List<Renovator> PayRenovators(int days)
        {
            return  renovators.FindAll(r => r.Days >= days);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");
            foreach (var item in renovators.FindAll(r => r.Hired == false))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
