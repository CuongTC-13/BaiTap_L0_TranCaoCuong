using BaiTap_L0_TranCaoCuong.Enum;
using BaiTap_L0_TranCaoCuong.Models;
using BaiTap_L0_TranCaoCuong.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap_L0_TranCaoCuong.Controller
{
    public class StudentManage
    {
        private List<student> _liststudent;
        private Input inp ;
        public StudentManage()
        {
            _liststudent = new List<student>();
            inp = new Input();
            
        }
        public void CreateStudent()
        {
            
            string name = inp.GetName();
            DateTime dOb = inp.GetDate();
            string address = inp.GetAddress();
            float height = inp.GetHeight();
            float weight = inp.GetWeight();
            string nameschool = inp.GetNameSchool();
            int yearStrarted = inp.GetStartLearning();
            double avg = inp.GetAvg();
            string studentId;
            while (true)
            {
                studentId = inp.GetIdStudent();
                if (_liststudent.Any(s => s.IdStudent.Equals(studentId, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Student ID already exists. Please enter a different Student ID.");
                }
                else
                {
                    break;
                }
            }

            student student = new student(name, dOb, address, height, weight, studentId, nameschool, yearStrarted, avg);
            _liststudent.Add(student);
            Console.WriteLine("Successfully added");
        }

        public student GetStudentById()
        {
            string studentId = inp.GetIdStudent();

            if (_liststudent.Any(s => s.IdStudent == studentId))
            {
                student student = _liststudent.First(s => s.IdStudent == studentId);
                Console.WriteLine(student.ToString());
                return student;
            }
            else
            {
                Console.WriteLine($"Student ID not found: {studentId}");
                return new student();
            }
        }

        public void UpdateStudentById()
        {
            student student = GetStudentById();
            if (student != null)
            {
                while (true)
                {
                    Console.WriteLine("\nSelect the item you want to edit");
                    Console.WriteLine("1. Name");
                    Console.WriteLine("2. Date of Birth");
                    Console.WriteLine("3. Address");
                    Console.WriteLine("4. Height");
                    Console.WriteLine("5. Weight");
                    Console.WriteLine("6. Current School");
                    Console.WriteLine("7. Year of University Entry");
                    Console.WriteLine("8. Avd");
                    Console.WriteLine("0. Exit");
                    Console.Write("Enter choice: ");
                    string choice = Console.ReadLine();
                    try
                    {
                        switch (choice)
                        {
                            case "1":
                                student.Name = inp.GetName();
                                break;
                            case "2":
                                student.DOB = inp.GetDate();
                                break;
                            case "3":
                                student.Address = inp.GetAddress();
                                break;
                            case "4":
                                student.Height = inp.GetHeight();
                                break;
                            case "5":
                                student.Weight = inp.GetWeight();
                                break;
                            case "6":
                                student.NameSchool = inp.GetNameSchool();
                                break;
                            case "7":
                                student.StartLearning = inp.GetStartLearning();
                                break;
                            case "8":
                                student.Average = inp.GetAvg();
                                break;
                            case "0":
                                Console.WriteLine("Exited");
                                return;
                            default:
                                Console.WriteLine("Invalid choice, please select again.");
                                break;
                        }

                        Console.WriteLine("Student details updated successfully:");
                        Console.WriteLine(student.ToString());
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}. Update failed.");
                    }
                }
            }
        }

        public void DeleteStudentById()
        {
            student student = GetStudentById();
            if (student != null)
            {
                _liststudent.Remove(student);
                Console.WriteLine("Deleted successfully");

                for (int i = 0; i < _liststudent.Count; i++)
                {
                    _liststudent[i].Id = i + 1;
                }
            }
        }

        public void AllStudent()
        {
            if (!_liststudent.Any())
            {
                Console.WriteLine("No student in the list");
                return;
            }
            foreach (student student in _liststudent)
            {
                Console.WriteLine(student.ToString());
            }
        }

        public void ShowStatus()
        {
            if (!_liststudent.Any())
            {
                Console.WriteLine("No students in the list");
                return;
            }

            var status = _liststudent
                .GroupBy(s => s.status)
                .Select(group => new
                {
                    TypeAverage = group.Key,
                    Percent = (double)group.Count() / _liststudent.Count * 100
                })
                .OrderByDescending(g => g.Percent)
                .ToList();

            foreach (var group in status)
            {
                Console.WriteLine($"{group.TypeAverage}: {group.Percent:F1}%");
            }
        }

        public void ShowAvg()
        {
            if (!_liststudent.Any())
            {
                Console.WriteLine("No students in the list");
                return;
            }
            Dictionary<double, int> avgs = new Dictionary<double, int>();

            foreach (student student in _liststudent)
            {
                if (avgs.ContainsKey(student.Average))
                {
                    avgs[student.Average]++;
                }
                else
                {
                    avgs[student.Average] = 1;
                }
            }

            foreach (var entry in avgs)
            {
                double percent = (double)entry.Value / _liststudent.Count * 100;
                Console.WriteLine($"Avg: {entry.Key} - {percent:F1}%");
            }
        }
        public void ShowListStudentsByAvg()
        {
            while (true)
            {
                Console.WriteLine("1. Poor");
                Console.WriteLine("2. Weak");
                Console.WriteLine("3. Average");
                Console.WriteLine("4. FAIR");
                Console.WriteLine("5. Good");
                Console.WriteLine("6. Excellent");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Choose option to show list student by avg: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ListAverage(AverageEnum.POOR);
                        break;
                    case "2":
                        ListAverage(AverageEnum.WEAK);
                        break;
                    case "3":
                        ListAverage(AverageEnum.AVERAGE);
                        break;
                    case "4":
                        ListAverage(AverageEnum.FAIR);
                        break;
                    case "5":
                        ListAverage(AverageEnum.GOOD);
                        break;
                    case "6":
                        ListAverage(AverageEnum.EXCELLENT);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void ListAverage(AverageEnum name)
        {
            var list = _liststudent.Where(s => s.status == name).ToList();
            if (!list.Any())
            {
                Console.WriteLine($"Student not found: {name}");
            }
            else
            {
                foreach (var student in list)
                {
                    Console.WriteLine(student.ToString());
                }
            }
        }

        public void SaveToFile()
        {
            string folderPath = @"D:\Học\BaiTap_L0_TranCaoCuong\BaiTap_L0_TranCaoCuong\Database";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath); 
            }
            string filePath = Path.Combine(folderPath, "List.txt");
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var student in _liststudent)
                    {
                        writer.WriteLine($"{student.Name}, {student.DOB.ToShortDateString()}, {student.Address}," +
                            $" {student.Height}, {student.Weight}, {student.IdStudent}, {student.NameSchool}," +
                            $" {student.StartLearning}, {student.Average}, {student.status}");
                    }
                }
                Console.WriteLine("S aved to file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }

        public void ReadFromFile()
        {
            string folderPath = @"D:\Học\BaiTap_L0_TranCaoCuong\BaiTap_L0_TranCaoCuong\Database";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, "List.txt");
            try
            {
                if (!File.Exists(filePath))
                {
                    using (StreamWriter sw = File.CreateText(filePath))
                    {
                        sw.WriteLine("name,dob,address,height,weight,studentId,school,yearStarted,avg,status"); 
                    }
                    return; 
                }

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    _liststudent.Clear();

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 10)
                        {
                            string name = parts[0].Trim();
                            DateTime dob = DateTime.Parse(parts[1]);
                            string address = parts[2].Trim();
                            float height = float.Parse(parts[3].Trim());
                            float weight = float.Parse(parts[4].Trim());
                            string studentId = parts[5].Trim();
                            string school = parts[6].Trim();
                            int yearStarted = int.Parse(parts[7].Trim());
                            double gpa = double.Parse(parts[8].Trim());

                            student student = new student(name, dob, address, height, weight, studentId, school, yearStarted, gpa);
                            _liststudent.Add(student);
                        }
                    }
                }
                Console.WriteLine("Data read from file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
            }
        }
    }
}
