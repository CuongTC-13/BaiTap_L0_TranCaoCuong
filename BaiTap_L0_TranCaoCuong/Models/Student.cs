using BaiTap_L0_TranCaoCuong.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap_L0_TranCaoCuong.Models
{
    public class student : Person
    {
        public string IdStudent { get; set; }
        public string NameSchool { get; set; }
        public int StartLearning { get; set; } // year
        public double Average { get; set; }
        public AverageEnum status { get; set; }
        public student()
        {
            
        }

        public student(string name, DateTime dob, string address, float height, float weight,string idStudent, string nameSchool, int startLearning, double average) : base(name, dob, address, height, weight)
        {
            IdStudent = idStudent;
            NameSchool = nameSchool;
            StartLearning = startLearning;
            Average = average;
            CheckAverage();
        }


        public void CheckAverage()
        {
            if (Average < 3)
                status = AverageEnum.POOR;
            else if (Average < 5)
                status = AverageEnum.WEAK;
            else if (Average < 6.5)
                status = AverageEnum.AVERAGE;
            else if (Average < 7.5)
                status = AverageEnum.FAIR;
            else if (Average < 9)
                status = AverageEnum.GOOD;
            else
                status = AverageEnum.EXCELLENT;
        }

        public override string ToString()
        {
            base.ToString();
            return $"StudentId: {IdStudent},Name = {Name}, NameSchool = {NameSchool}, StartLearning = {StartLearning}, Average = {Average}, Status = {status}";
        }
    }
}
