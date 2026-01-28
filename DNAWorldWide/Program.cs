using System;

namespace DNAWorldWide
{
    /// <summary>
    /// Class to handle forensic reports
    /// </summary>
    public class ForensicReport
    {
        private Dictionary<string,DateOnly> reportDict=new Dictionary<string, DateOnly>(); // To store reportingOfficerName and reportFiledDate

        public void addReportDetails(string reportingOfficerName,DateOnly reportFiledDate ) // Method to add report details
        {
            reportDict.Add(reportingOfficerName,reportFiledDate);
        }
        public List<String> getOfficersWhoFiledReportsOnDate(DateOnly reportFiledDate) // Method to get officers who filed reports on specified date
        {
            var result=reportDict.Where(x=> x.Value==reportFiledDate).Select(x=>x.Key).ToList();
            return result;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of Reports: ");
            int number=int.Parse(Console.ReadLine());
            ForensicReport forensicreport=new ForensicReport();
            if(number <= 0)
            {
                Console.WriteLine("No Reports Found!");
                return;
            }
            Console.WriteLine("Enter the report details (ReportingOfficerName:ReportFiledDate in dd-mm-yyyy  format): ");
            for( int i=0;i<number;i++)
            {
                string[] reportDetails=Console.ReadLine().Split(":");
                DateOnly date=DateOnly.ParseExact(reportDetails[1],"dd-mm-yyyy");
                forensicreport.addReportDetails(reportDetails[0],date);
            }
            Console.WriteLine("Enter the report filed date to filter officers (in dd-mm-yyyy format): ");
            DateOnly filedDate=DateOnly.ParseExact(Console.ReadLine(),"dd-mm-yyyy");
            var result=forensicreport.getOfficersWhoFiledReportsOnDate(filedDate);
            if(result.Count == 0)
            {
                Console.WriteLine("No officers found who filed reports on the given date.");
            }
            else
            {
                Console.WriteLine("Officers who filed reports on the given date:");
                foreach(var officer in result)
                {
                    Console.WriteLine(officer);
                }
            }
            
        }
    }

}