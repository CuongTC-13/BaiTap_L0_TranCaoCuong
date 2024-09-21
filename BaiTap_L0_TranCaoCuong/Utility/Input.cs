using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BaiTap_L0_TranCaoCuong.Utility
{
    public class Input
    {
        public string GetName()
        {
            while (true)
            {
                try
                {
                    Console.Write("Please enter your name: ");
                    string input = Console.ReadLine();
                    Validate.CheckName(input);
                    return input;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}is invalid, please re-enter.");
                }
            }
        }

        public DateTime GetDate()
        {
            while (true)
            {
                string regex = @"\d{1,2}-\d{1,2}-\d{4}";
                while (true)
                {
                    Console.Write("Please enter date of birth: ");
                    string input = Console.ReadLine();

                    // Check format
                    if (Regex.IsMatch(input, regex))
                    {
                        // Check if input date exists
                        if (IsDateExist(input))
                        {
                            try
                            {
                                DateTime dob = DateTime.Parse(input);
                                Validate.CheckDob(dob);
                                return dob;
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine("Error: " + e.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Date does not exist!!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input must be in format dd-MM-yyyy");
                    }
                }
            }
        }
        private bool IsDateExist(string input)
        {
            try
            {
                DateTime.Parse(input);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public float GetHeight()
        {
            while (true)
            {
                try
                {
                    Console.Write("Please enter height: ");
                    string input = Console.ReadLine();
                    if (input.Contains(","))
                    {
                        Console.WriteLine("Cannot use ","");
                        continue;
                    }
                    float height = float.Parse(input, CultureInfo.InvariantCulture);
                    Validate.CheckHeight(height);
                    return height;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message} is invalid, please re-enter.");
                }
            }
        }
        public float GetWeight()
        {
            while (true)
            {
                try
                {
                    Console.Write("Please enter weight: ");
                    string input = Console.ReadLine();
                    if (input.Contains(","))
                    {
                        Console.WriteLine("Cannot use ","");
                        continue;
                    }
                    float weight = float.Parse(input, CultureInfo.InvariantCulture);
                    Validate.CheckWeight(weight);
                    return weight;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message} is invalid, please re-enter.");
                }
            }
        }
        public string GetIdStudent()
        {
            while (true)
            {
                try
                {
                    Console.Write("Please enter student id: ");
                    string input = Console.ReadLine();
                    Validate.CheckIdStudent(input);
                    return input;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message} is invalid, please re-enter.");
                }
            }
        }
        public string GetNameSchool()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter school name: ");
                    string input = Console.ReadLine();
                    Validate.CheckNameSchool(input);
                    return input;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message} is invalid, please re-enter.");
                }
            }
        }
        public int GetStartLearning()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter year started: ");
                    int year = int.Parse(Console.ReadLine());
                    Validate.CheckStartLearning(year);
                    return year;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message} is invalid, please re-enter.");
                }
            }
        }
        public double GetAvg()
        {
            while (true)
            {
                try
                {
                    Console.Write("Please enter Avg: ");
                    double avg = double.Parse(Console.ReadLine());
                    Validate.CheckAvg(avg);
                    return avg;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message} is invalid, please re-enter.");
                }
            }
        }
        public string GetAddress()
        {
            while (true)
            {
                try
                {
                    Console.Write("Please enter address: ");
                    string input = Console.ReadLine();
                    Validate.CheckAddress(input);
                    return input;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error: {e.Message}is invalid, please re-enter.");
                }
            }
        }
    }
}
