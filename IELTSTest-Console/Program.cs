using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IELTSDataLayer;

namespace IELTSTest_Console
{
    class Program
    {
        static TestInfo tinfo;
        static AddressInfo address,add1,add2;
        static OfficeUse office;
        static StudentInfo student;
        static void Main(string[] args)
        {
            try
            {
                //new RegisterRepository().RegisterTest(CreateJunkData());
                new RegisterRepository().GetTestDetails("23423", "be63c100-9d88-4d2f-8");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            
        }
        public static TestInfo CreateJunkData()
        {
            try
            {

                address = new AddressInfo() { AddressI="Address1",AddressII="Address II",Email="Email@email.com",MobilePhone="12121212",Telephone="123123123",ZipOrPostalCode="123123",FK_TestInfoID=null};
                office = new OfficeUse() { AC=true,AdministratorInitials="AC",DateofPayment=DateTime.Now,GT=true,IDChecked=true,ReceiptNumber="guid",Scheme="Scheme",TestDate=DateTime.Now};
                student = new StudentInfo() { AddressInfo=address, ApplyingCountry = "AC", CountryNationalCode = "NC01", DateOfBirth = DateTime.Now,EducationLevel="EL01",EnglishLearningLocation="UK",EnglishLearningPeriod="5",FirstLanguageCode="01",FirstName="Madhu",Gender="Male",LastName="LNAME",OccupationLevel="01",OccupationSector="02",PermanentDisability="No",Title="Title" };
                tinfo = new TestInfo() { OfficeUse=office, StudentInfo=student, TestReason = "Reason", TestModule = "Module", TestCityLocation = "UAE", Status = 0, ResultCopyTo = true, CreatedDate = DateTime.Now, ModifiedDateTime = DateTime.Now, PreferredTestDate = DateTime.Now, ReceiptNumber = "RECEIPTMENT", SecondaryTestDate = DateTime.Now };
                add1 = new AddressInfo() { AddressI = "Address1", AddressII = "Address II", Email = "Email@email.com", MobilePhone = "12121212", Telephone = "123123123", ZipOrPostalCode = "123123",TestInfo=tinfo };
                add2 = new AddressInfo() { AddressI = "Address1", AddressII = "Address II", Email = "Email@email.com", MobilePhone = "12121212", Telephone = "123123123", ZipOrPostalCode = "123123", TestInfo = tinfo };
                return tinfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
