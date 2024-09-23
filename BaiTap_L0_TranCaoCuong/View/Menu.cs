using BaiTap_L0_TranCaoCuong.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap_L0_TranCaoCuong.View
{
    public class Menu
    {
        public static void Main(string[] args)
        {
            StudentManage studentManage = new StudentManage();
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add a new student");
                Console.WriteLine("2. Search for a student by ID");
                Console.WriteLine("3. Update student by ID");
                Console.WriteLine("4. Delete student by ID");
                Console.WriteLine("5. Show all students");
                Console.WriteLine("6. Show Avg");
                Console.WriteLine("7. Show Learning Status");
                Console.WriteLine("8. Show List Students By Avg");
                Console.WriteLine("9. Save to file");
                Console.WriteLine("0. Exit program");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        studentManage.CreateStudent();
                        break;
                    case "2":
                        studentManage.GetStudentById();
                        break;
                    case "3":
                        studentManage.UpdateStudentById();
                        break;
                    case "4":
                        studentManage.DeleteStudentById();
                        break;
                    case "5":
                        studentManage.AllStudent();
                        break;
                    case "6":
                        studentManage.ShowAvg();
                        break;
                    case "7":
                        studentManage.ShowStatus();
                        break;
                    case "8":
                        studentManage.ShowListStudentsByAvg();
                        break;
                    case "9":
                        studentManage.SaveToFile();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
