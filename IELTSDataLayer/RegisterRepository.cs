using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IELTSDataLayer
{
    public class RegisterRepository : IRegisterRepository
    {

        public dynamic RegisterTest(TestInfo testInfo)
        {
            try
            {
                using (IELTSOnlineEntities context = new IELTSOnlineEntities())
                {
                    //AddressInfo add1 = new AddressInfo() { AddressI = "Address2", AddressII = "Address II", Email = "Email@email.com", MobilePhone = "12121212", Telephone = "123123123", ZipOrPostalCode = "123123", TestInfo = testInfo};
                    //context.AddressInfoes.Add(add1);
                    testInfo.ReceiptNumber = Guid.NewGuid().ToString().Replace("{", "").Replace("}", "").Substring(0,20);       
                    context.TestInfoes.Add(testInfo);
                    context.SaveChanges();
                }
                return JsonConvert.SerializeObject(new { Status = "1", Message = "Success" });
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                return JsonConvert.SerializeObject(new { Status = "0", Message = ex.Message.ToString() });
            }
        }


        public dynamic GetTestDetails(string identityNumber, string receiptNumber)
        {
            try
            {
                using (IELTSOnlineEntities context = new IELTSOnlineEntities())
                {
                    TestInfo tinfo = context.TestInfoes.Where(t => t.ReceiptNumber == receiptNumber && t.StudentInfo.IdentityValue == identityNumber).FirstOrDefault();
                    return JsonConvert.SerializeObject(new { TestDate = tinfo.CreatedDate, FullName = tinfo.StudentInfo.FirstName + " " + tinfo.StudentInfo.LastName,IdentityID=tinfo.StudentInfo.IdentityValue,ReceiptNumber=tinfo.ReceiptNumber,DOB=tinfo.StudentInfo.DateOfBirth,Gender=tinfo.StudentInfo.Gender,Nationality=tinfo.StudentInfo.CountryNationalCode,FirstLanguage=tinfo.StudentInfo.FirstLanguageCode });
                }
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { Status = "0", Message = "Failed" });
            }
        }
    }
}
