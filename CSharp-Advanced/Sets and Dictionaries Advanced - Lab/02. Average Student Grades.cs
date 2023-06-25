namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());

            var grades = new Dictionary<string, List<decimal>>();


            for (int i = 0; i < countOfStudents; i++)
            {
                string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string studentName = line[0];
                decimal studentGrade = decimal.Parse(line[1]);  

                if (grades.ContainsKey(studentName) == false)
                {
                    grades.Add(studentName, new List<decimal>());   
                }

                grades[studentName].Add(studentGrade);
            }

            // това е по-хитро
            foreach (var (studentName, studentGrades) in grades)
            {
                Console.WriteLine($"{studentName} -> " + string.Join(" ", studentGrades.Select(x => x.ToString("F2"))) + $" (avg: {studentGrades.Average():F2})");

            }

            // George -> 6.00 5.50 6.00 (avg: 5.83)


            // това е по-разписано
            //foreach (string studentName in grades.Keys)
            //{
            //    Console.Write($"{studentName} -> ");

            //    foreach (decimal studentGrades in grades[studentName])
            //    {
            //        Console.Write($"{studentGrades:F2} ");
            //    }

            //    Console.WriteLine($"(avg: {grades[studentName].Average():F2})");
            //}


        }
    }
}