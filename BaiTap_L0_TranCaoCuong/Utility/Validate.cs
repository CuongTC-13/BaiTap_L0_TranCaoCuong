using BaiTap_L0_TranCaoCuong.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap_L0_TranCaoCuong.Utility
{
    public static class Validate
    {
        public static void CheckName(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length > Const.NameLength_max)
            {
                throw new ArgumentNullException($"Minimum name from one to{Const.NameLength_max} characters.");
            }
        }

        public static void CheckDob(DateTime dob)
        {
            if (dob.Year < Const.Year_min)
            {
                throw new ArgumentNullException($"Minimum year of birth from year {Const.Year_min}.");
            }
        }

        public static void CheckHeight(float height)
        {
            if (height < Const.Height_min || height > Const.Height_max)
            {
                throw new ArgumentNullException($"Minimum height from {Const.Height_min} and {Const.Height_max}.");
            }
        }

        public static void CheckWeight(float weight)
        {
            if (weight < Const.weight_min || weight > Const.weight_max)
            {
                throw new ArgumentNullException($"Weight ranges from {Const.weight_min} to {Const.weight_max}.");
            }
        }

        public static void CheckIdStudent(string id)
        {
            if (string.IsNullOrWhiteSpace(id) || id.Length != Const.Student_id)
                throw new ArgumentException($"Student ID {Const.Student_id} characters.");
        }

        public static void CheckNameSchool(string schoolName)
        {
            if (string.IsNullOrEmpty(schoolName) || schoolName.Length >= Const.School_Name_max)
                throw new ArgumentException($"Current school must be less than {Const.School_Name_max} characters.");
        }

        public static void CheckStartLearning(int year)
        {
            if (year <= Const.YearSchool_max) throw new ArgumentException($"The year of starting university must be from {Const.YearSchool_max}.");
        }

        public static void CheckAvg(double gpa)
        {
            if (gpa < Const.Avg_min || gpa > Const.Avg_max)
                throw new ArgumentException($"The average score must be within the range {Const.Avg_min} to {Const.Avg_max}.");
        }
        public static void CheckAddress(string address)
        {
            if (string.IsNullOrEmpty(address) || address.Length > Const.AddressLength_max)
            {
                throw new ArgumentNullException($"Person name must be between 1 and {Const.AddressLength_max} characters.");
            }
        }
    }
}
