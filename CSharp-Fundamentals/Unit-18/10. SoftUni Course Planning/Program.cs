using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> scheduleLessons = Console.ReadLine()
                .Split(", ")
                .ToList();
            string manipulation = Console.ReadLine();

            while (manipulation != "course start")
            {
                string[] operation = manipulation.Split(":");
                string command = operation[0];
                string lessonTitle1 = "", lessonTitle2 = "", temp = "", exercise = "";
                string tempLesson = "", tempExercise = "";
                int index = -1, index1 = -1, index2 = -1, index3 = -1, index4 = -1;
                switch (command)
                {
                    case "Add":
                        lessonTitle1 = operation[1];
                        if (!scheduleLessons.Any(x => x == lessonTitle1))
                        {
                            scheduleLessons.Add(lessonTitle1);
                        }
                        break;
                    case "Insert":
                        lessonTitle1 = operation[1];
                        index = int.Parse(operation[2]);
                        if (!scheduleLessons.Any(x => x == lessonTitle1))
                        {
                            scheduleLessons.Insert(index, lessonTitle1);
                        }
                        break;
                    case "Remove":
                        lessonTitle1 = operation[1];
                        exercise = lessonTitle1 + "-Exercise";
                        index1 = scheduleLessons.FindIndex(x => x == lessonTitle1);
                        index2 = scheduleLessons.FindIndex(x => x == exercise);
                        if (index1 >= 0 && index2 >= 0)
                        {
                            scheduleLessons.RemoveAt(index1);
                            scheduleLessons.RemoveAt(index2);
                        }
                        else if (index1 >= 0)
                        {
                            scheduleLessons.RemoveAt(index1);
                        }
                        break;
                    case "Swap":
                        lessonTitle1 = operation[1];
                        lessonTitle2 = operation[2];
                        index1 = scheduleLessons.FindIndex(x => x == lessonTitle1);
                        index2 = scheduleLessons.FindIndex(x => x == lessonTitle2);
                        index3 = scheduleLessons.FindIndex(x => x == (lessonTitle1 + "-Exercise"));
                        index4 = scheduleLessons.FindIndex(x => x == (lessonTitle2 + "-Exercise"));
                        if (index1 >= 0 && index2 >= 0)
                        {
                            if ((index3 > 0) && (index4 > 0))
                            { // има 2 урока и 2 упражнения
                                tempLesson = scheduleLessons[index1];
                                tempExercise = scheduleLessons[index3];
                                scheduleLessons[index1] = scheduleLessons[index2];
                                scheduleLessons[index3] = scheduleLessons[index4];
                                scheduleLessons[index2] = tempLesson;
                                scheduleLessons[index4] = tempExercise;

                            }
                            else if (index3 > 0)
                            {// само на 1(първи) урок има упражнение
                                tempLesson = scheduleLessons[index1];
                                tempExercise = scheduleLessons[index3];
                                scheduleLessons[index1] = scheduleLessons[index2];
                                scheduleLessons[index2] = tempLesson;
                                scheduleLessons.Insert(index2+1, tempExercise);
                                scheduleLessons.RemoveAt(index3);
                            }
                            else if (index4 > 0)
                            {// само на 2(втори) урок има упражнение
                                tempLesson = scheduleLessons[index2];
                                tempExercise = scheduleLessons[index4];
                                scheduleLessons[index2] = scheduleLessons[index1];
                                scheduleLessons[index1] = tempLesson;
                                scheduleLessons.RemoveAt(index4);
                                scheduleLessons.Insert(index1 + 1, tempExercise);
                            }
                            else
                            {// има 2 урока, но няма упражнения
                                temp = scheduleLessons[index1];
                                scheduleLessons[index1] = scheduleLessons[index2];
                                scheduleLessons[index2] = temp;
                            }

                        }

                        break;
                    case "Exercise":
                        lessonTitle1 = operation[1];
                        exercise = lessonTitle1 + "-Exercise";
                        index1 = scheduleLessons.FindIndex(x => x == lessonTitle1);
                        index2 = scheduleLessons.FindIndex(x => x == exercise);
                        if (index1 >= 0 && index2 < 0)
                        {
                            scheduleLessons.Insert(index1 + 1, exercise);
                        }
                        else if (index1 < 0)
                        {
                            scheduleLessons.Add(lessonTitle1);
                            scheduleLessons.Add(exercise);
                        }

                        break;
                }

                manipulation = Console.ReadLine();
            }
            for (int i = 0; i < scheduleLessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{scheduleLessons[i]}");
            }

        }
    }
}
