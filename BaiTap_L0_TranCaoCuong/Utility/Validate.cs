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
            if (string.IsNullOrEmpty(name) || name.Length > ConstantsLimit.NameLengtmax)
            {
                throw new ArgumentNullException($"Minimum name from one to{ConstantsLimit.NameLengtmax} characters.");
            }
        }

        public static void CheckDob(DateTime dob)
        {
            if (dob.Year < ConstantsLimit.Yearmin)
            {
                throw new ArgumentNullException($"Minimum year of birth from year {ConstantsLimit.Yearmin}.");
            }
        }

        public static void CheckHeight(float height)
        {
            if (height < ConstantsLimit.Heightmin || height > ConstantsLimit.Heightmax)
            {
                throw new ArgumentNullException($"Minimum height from {ConstantsLimit.Heightmin} and {ConstantsLimit.Heightmax}.");
            }
        }

        public static void CheckWeight(float weight)
        {
            if (weight < ConstantsLimit.weightmin || weight > ConstantsLimit.weightmax)
            {
                throw new ArgumentNullException($"Weight ranges from {ConstantsLimit.weightmin} to {ConstantsLimit.weightmax}.");
            }
        }

        public static void CheckIdStudent(string id)
        {
            if (string.IsNullOrWhiteSpace(id) || id.Length != ConstantsLimit.StudentIdLength)
                throw new ArgumentException($"Student ID {ConstantsLimit.StudentIdLength} characters.");
        }

        public static void CheckNameSchool(string schoolName)
        {
            if (string.IsNullOrEmpty(schoolName) || schoolName.Length >= ConstantsLimit.SchoolNamemax)
                throw new ArgumentException($"Current school must be less than {ConstantsLimit.SchoolNamemax} characters.");
        }

        public static void CheckStartLearning(int year)
        {
            if (year <= ConstantsLimit.YearSchoolmax) throw new ArgumentException($"The year of starting university must be from {ConstantsLimit.YearSchoolmax}.");
        }

        public static bool CheckAvg(double avg)
        {
            //if (avg < Const.Avg_min)
            //    return false;
            //if (avg > Const.Avg_max)
            //    return false;
            //return true;
            return avg >= ConstantsLimit.Avgmin && avg <= ConstantsLimit.Avgmax;
        }
        public static void CheckAddress(string address)
        {
            if (string.IsNullOrEmpty(address) || address.Length > ConstantsLimit.AddressLengthmax)
            {
                throw new ArgumentNullException($"Person name must be between 1 and {ConstantsLimit.AddressLengthmax} characters.");
            }
        }
    }
}
