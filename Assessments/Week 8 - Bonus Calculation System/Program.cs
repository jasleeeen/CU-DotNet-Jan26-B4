namespace BonusCalculationSystem
{
    public class EmployeeBonus
    {
        public decimal BaseSalary { get; set; }
        public int PerformanceRating { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal DepartmentMultiplier { get; set; }
        public double AttendancePercentage { get; set; }
        public decimal NetAnnualBonus
        {
            get
            {
                decimal totalBonus;
                if (BaseSalary <= 0) return 0m;

                if (PerformanceRating < 1 || PerformanceRating > 5) throw new InvalidOperationException("Invalid Rating");
                decimal baseBonusPerc=0m;
                switch(PerformanceRating)
                {
                    case 1: baseBonusPerc = 0m; break;
                    case 2: baseBonusPerc = 0.05m; break;
                    case 3: baseBonusPerc = 0.12m; break;
                    case 4: baseBonusPerc = 0.18m; break;
                    case 5: baseBonusPerc = 0.25m; break;
                }
                totalBonus = BaseSalary * baseBonusPerc;

                if (YearsOfExperience > 10) totalBonus += BaseSalary * 0.05m;
                else if (YearsOfExperience > 5) totalBonus += BaseSalary * 0.03m;

                if (AttendancePercentage < 0 || AttendancePercentage > 100) throw new InvalidOperationException("Invalid Attendance Percentage");
                if (AttendancePercentage < 85) totalBonus = totalBonus * 0.80m;

                totalBonus = totalBonus * DepartmentMultiplier;

                decimal maxBonus = BaseSalary * 0.40m;
                if (totalBonus > maxBonus) totalBonus = maxBonus;

                decimal tax;
                if (totalBonus <= 150000) tax = 0.10m;
                else if (totalBonus <=300000) tax = 0.20m;
                else tax = 0.30m;
                totalBonus = totalBonus - (totalBonus * tax);
                return Math.Round(totalBonus, 2);
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
