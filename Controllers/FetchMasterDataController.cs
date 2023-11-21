using HIMS_MASTERDATA.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Cors;
using HIMS_MASTERDATA.Repository;
using HIMS_MASTERDATA.BHISHAK_APP_DB_Master;
using Microsoft.Extensions.Configuration;

using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net.Mail;
using System.Net;

namespace HIMS_MASTERDATA.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FetchMasterDataController : ControllerBase
    {

        private readonly IFetchMasterData_Repository _repository;


        public FetchMasterDataController(IFetchMasterData_Repository repository)
        {
            _repository = repository;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        private string GetUserName()
        {

            string userName = "";
            var userNameClaim = User.Claims.FirstOrDefault(claim => claim.Type == "Username");
            if (userNameClaim != null)
            {
                userName = userNameClaim.Value;
                //  return Ok($"Logged-in User Name: {userName}");
            }
            return userName;
            //return Ok($"Logged-in User Name: {userName}");
        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<DoctorVo>> GetDoctor()
        {
            return await _repository.GetDoctor();
        }

        [HttpGet]
        [Authorize]
        [Route("[Action]")]
        [EnableCors("AllowAllHeaders")]
        public async Task<IEnumerable<DoctorVo>> GetRefDoctors()
        {
            return await _repository.GetRefDoctors();
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<AreaVo>> GetArea()
        {

            return await _repository.GetArea();

        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        // [Authorize]
        public async Task<IEnumerable<CorporateVo>> GetCorporate(int Id)
        {
            return await _repository.GetCorporate(Id);
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<NationalityVo>> GetNationality()
        {
            return await _repository.GetNationality();
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<SpecialityVo>> GetSpeciality()
        {

            return await _repository.GetSpeciality();
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<OccupationVo>> GetOccupation()
        {

            return await _repository.GetOccupation();

        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<PatientRelationVo>> GetPatientRelation()
        {
            return await _repository.GetPatientRelation();
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<PatientVo>> GetPatientDetails(string mobilenumber,int OrganizationId)
        {
            return await _repository.getpatientdetails(mobilenumber, OrganizationId);
        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<PatientIdVo>> GetPatientDetailsbypid(long patientid)
        {
            return await _repository.GetPatientDetailsbypid(patientid);
        }


        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<RelegionVo>> GetReligion()
        {
            return await _repository.GetReligion();
        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<RolesVo>> GetRoles()
        {
            return await _repository.GetRoles();
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        // [Authorize]
        public async Task<IEnumerable<OrganizationVo>> GetOrganizations()
        {
            return await _repository.GetOrganizations();
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<FecilityVo>> GetFecility(int id)
        {
            return await _repository.GetFecilities(id);
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<TblAdmFacility>> GetTotalFecility()
        {
            return await _repository.GetTotalFecilities();
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<AdminDashBoardVo>> GetTotalPatientcount()
        {
            return await _repository.GetAdminDashBoardDetails();
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<List<bindStateDistrictVo>> GetDistricts(int Id)
        {

            var response = await _repository.GetDistricts(Id);
            return response;

        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<List<bindStateDistrictVo>> GetStates()
        {
            return await _repository.GetStates();
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<List<ScheduleTypeVo>> GetScheduleTypes()
        {

            var response = await _repository.GetScheduleTypes();
            return response;
        }
        [EnableCors("AllowAllHeaders")]
        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public async Task<List<UserListVo>> GetUserList(ReqUserListVo Obj)
        {
            return await _repository.GetUserList(Obj);
        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<DoctorVo>> GetRefDoctorsbySpeciality(int Id)
        {
            return await _repository.GetRefDoctorsbySpeciality(Id);
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<DoctorVo>> GetDoctorsByspaciality(int Id)
        {
            return await _repository.GetDoctorsByspaciality(Id);
        }


        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<ChargegroupVo>> GetChargeGroups(int Id)
        {
            return await _repository.GetChargeGroups(Id);
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<ChargeItemsVo>> GetChargeItems(int Id)
        {
            return await _repository.GetChargeItems(Id);
        }
        [EnableCors("AllowAllHeaders")]
        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<GetAppointment2Vo>> GetAppointments(GetAppointmentFiltersVo Input)
        {
            try
            {
                var response = await _repository.GetAppointments(Input);

                return response;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<GetAppointment2Vo>> GetAppointmentsToday()
        {
            try
            {
                var response = await _repository.GetAppointmentsToday();

                return response;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpGet]
        [Route("[action]")]
        [Authorize]

        public async Task<IEnumerable<AppointmentstatusVo>> GetAppointmentsStatus()
        {
            var response = await _repository.GetAppointmentsStatus();

            return response;
        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<GetPaymentModeVo>> GetPaymentMode()
        {
            var response = await _repository.GetPaymentMode();

            return response;
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<GetPaymentCategoryVo>> GetPaymentCategory()
        {
            var response = await _repository.GetPaymentCategory();
            return response;
        }


        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<GetExistedPatientAppointmentVocs>> GetExistedPatientsForAppointment(string MobileNumber)
        {
            var response = await _repository.GetExistedPatientsForAppointment(MobileNumber);
            return response;
        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<GetExistedPatientAppointmentVocs>> GetPatientDetailsbypidnew(int patientid)
        {
            var response = await _repository.GetPatientDetailsbypidnew(patientid);
            return response;

        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<EditAppointmentVo>> GetEditAppointmentdetails(int AppointmentId)
        {
            var response = await _repository.GetEditAppointmentdetails(AppointmentId);
            return response;
        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public List<DateTime> SaveTime()
        {

            string AM = " AM";
            string PM = " PM";
            List<DateTime> obj = new List<DateTime>();
            int n = 24;
            int e = 0;
            int e2 = 1;
            for (int i = 0; i < n; i++)
            {

                string ex = "";
                int inc = 0;
                if (e < 10)
                {
                    ex = "0" + e;
                }
                else ex = e.ToString();



                for (var j = 0; j < 12; j++)
                {
                    //if(e==12)
                    //{
                    string r = inc < 10 ? "0" + inc : inc + "";
                    string o1 = ex + ":" + r;
                    obj.Add(Convert.ToDateTime(o1));
                    inc = inc + 5;
                    //}
                    //else
                    //{
                    //    string r = inc < 10 ? "0" + inc : inc + "";
                    //    string o1 = ex + ":" + r + AM;
                    //    obj.Add(Convert.ToDateTime(o1));
                    //    inc = inc + 5;
                }






                e++;

            }

            for (int i = 0; i < obj.Count; i++)
            {

            }
            //var d = DateTime.Now;
            //var h = (obj.Where(x => x.TimeOfDay > d.TimeOfDay).ToList());
            // var k= (h.Where(x => x.TimeOfDay > h[0].TimeOfDay).ToList());
            return obj;


        }


        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public IEnumerable<string> GetTimeSlotsForTimePicker(DateTime _Date, int TimeInterval)
        {
            var timeIntervals = _repository.GetTimeSlotsForTimePicker(_Date, TimeInterval);
            return timeIntervals;

        }


        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public bool IsUsernameValid(string UserName, int OrganizationId)
        {
            var timeIntervals = _repository.IsUsernameValid(UserName, OrganizationId);
            return timeIntervals;

        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        public void savedata()
        {
            _repository.savedata();


        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<GetVitalSignsVo>> GetVitalSigns()
        {
            var timeIntervals = await _repository.GetVitalSigns();
            return timeIntervals;

        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<VitalsignVo>> GetVitalSignsDetails(int Id)
        {
            var response = await _repository.GetVitalSignsDetails(Id);
            return response;
        }
        [EnableCors("AllowAllHeaders")]
        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<GetVitalSignsListToBindByspecialityVo>> LoadVitalSignsData(GetVitalssignsInputVo obj)
        {
            var response = await _repository.LoadVitalSignsData(obj);
            return response;
        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<string> GetOrganizationAddress(int Id)
        {
            var jsonresult = await _repository.GetOrganizationAddress(Id);
            return JsonConvert.SerializeObject(jsonresult);
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<List<GetOrg_FacilityData>> GetorganizationMappedData()
        {
            return await _repository.GetorganizationMappedData();

        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<List<GetFacilitiesDataByOrganization>> GetFacilitiesList(int Id)
        {
            return await _repository.GetFacilitiesList(Id);
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<List<GetUserDetailsForUpdateVo>> GetUserListDetailsbyId(int UserId)
        {
            var a = GetUserName();
            return await _repository.GetUserListDetailsbyId(UserId);
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<int> UpdateUserDetails(GetUserDetailsForUpdateVo User)
        {
            var a = GetUserName();
            return await _repository.UpdateUserDetails(User, a);
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<DoctorVo>> GetDoctorList(int OrgnizationId, int FacilityId, int SpecialityId)
        {
            var a = GetUserName();
            return await _repository.GetDoctorList(OrgnizationId, FacilityId, SpecialityId);
        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        // [Authorize]
        public async Task<List<DoctorDashBoardVo>> GetDoctorDashBoardData(int OrgID, int FacID, int DoctorId)
        {
            return await _repository.GetDoctorDashBoardData(OrgID, FacID, DoctorId);
        }
        //public Task<List<GetFacilitiesDataByOrganization>> GetFacilitiesList(int Id)
        //{
        //    return await _repository.getfa
        //}




        [HttpGet]
        [Route("[Action]")]
        [EnableCors("AllowAllHeaders")]
        public async Task<IEnumerable<CalendarSchedule>> GetScheduledTime(DateTime selectedDate, int providerId, int FacilityId)
        {
            return await _repository.GetScheduledTime(selectedDate, providerId, FacilityId);
        }
        [HttpGet]
        [Route("[Action]")]
        [EnableCors("AllowAllHeaders")]
        public async Task<IEnumerable<CalendarSchedule>> GetBookedAppointments(string selectedDate, int providerId, int FacilityId)
        {
            return await _repository.GetBookedAppointments(selectedDate, providerId, FacilityId);
        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<GetAppointmentVo>> GetSelectedAppointmentdetails(DateTime AppointmentDate, TimeSpan startTime, int providerId, int facilityId)
        {
            var response = await _repository.GetSelectedAppointmentdetails(AppointmentDate, startTime, providerId, facilityId);
            return response;
        }


        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<GetOrganizationDataVo> GetOrganizationData(int Id)
        {
            var response = await _repository.GetOrganizationData(Id);
            return response;
        }


        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<List<FrontDeskDashBoardVo>> GetFrontDeskDashBoardCount(int OrganizationId, int FacilityId)
        {
            var response = await _repository.GetFrontDeskDashBoardCount(OrganizationId, FacilityId);
            return response;
        }


        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IEnumerable<DoctorVo>> GetRefDoctorsbyFacility(int SpecialityID, int OrganizationId, int FacilityId)
        {
            var response = await _repository.GetRefDoctorsbyFacility(SpecialityID, OrganizationId, FacilityId);
            return response;
        }

        [HttpPost("send")]
        public IActionResult SendEmail([FromBody] EmailModel emailModel)
        {
            //try
            //{
            //    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            //    var smtpClient = new SmtpClient("smtp.mail.yahoo.com")
            //    {
            //        Port = 587,
            //        Credentials = new NetworkCredential("madhubabu.mandaloju@yahoo.com", "Ntpl@1234"),
            //        EnableSsl = true,
            //    };

            //    var mailMessage = new MailMessage
            //    {
            //        From = new MailAddress("madhubabu.mandaloju@yahoo.com"),
            //        Subject = emailModel.Subject,
            //        Body = emailModel.Body,
            //        IsBodyHtml = true,
            //    };

            //    mailMessage.To.Add(emailModel.To);

            //    smtpClient.Send(mailMessage);
            //    return Ok("Email sent successfully");
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest($"Email could not be sent: {ex.Message}");
            //}

            // Yahoo Mail SMTP server settings

            string smtpHost = "smtp.mail.yahoo.com";
            int smtpPort = 587;
            string yahooUsername = "madhubabu.mandaloju@yahoo.com";
            string yahooPassword = " Ntpl@1234";

            // Create a new MailMessage
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(yahooUsername);
            mail.To.Add("madhubabu.mandaloju@ntc-in.com");
            mail.Subject = "Test Email";
            mail.Body = "This is a test email from Yahoo Mail to Gmail.";

            // Create a SmtpClient
            SmtpClient smtpClient = new SmtpClient(smtpHost);
            smtpClient.Port = smtpPort;
            smtpClient.Credentials = new NetworkCredential(yahooUsername, yahooPassword);
            smtpClient.EnableSsl = true;

            try
            {
                // Send the email
                smtpClient.Send(mail);
                //  Console.WriteLine("Email sent successfully.");
                return Ok("Email sent successfully");
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error sending email: " + ex.Message);
                return BadRequest($"Email could not be sent: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("[Action]")]
        [EnableCors("AllowAllHeaders")]
        [Authorize]
        public async Task<string> GetPatientName(string Rescheduleappointmetid)
        {
            var jsonresult = await _repository.GetPatientName(Rescheduleappointmetid);
            return JsonConvert.SerializeObject(jsonresult);
        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        //[Authorize]
        public async Task<IEnumerable<GetFacilityTariffDatacs>> GetFaciltyTarifffDetails(int OrganizationId, int FacilityId)
        {
            var response = await _repository.GetFacilityTariffDetails(OrganizationId, FacilityId);
            //var response = await _repository.GetFacilityTariffDetails();
            return response;

        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[Action]")]
       
        //[Authorize]
        public async Task<IEnumerable<ChargeItemVo>> GetChargeItemDeatils()
            {
                var response = await _repository.GetChargeItemDeatils();
                return response;
            }
        [Authorize]
        [HttpGet]
        [Route("[Action]")]
        [EnableCors("AllowAllHeaders")]
        public async Task<List<CalendarSchedule>> GetResechduleslotsData(string selectedDate, int providerId, int FacilityId)
        {
            return await _repository.GetResechduleslotsData(selectedDate, providerId, FacilityId);
        }
        [HttpGet]
        [Route("[Action]")]
        [EnableCors("AllowAllHeaders")]
        [Authorize]
        public async Task<List<UserFacilityListVo>> userlistbyfacilitylist(int Userid)
        {
            return await _repository.userlistbyfacilitylist(Userid);
        }
        [EnableCors("AllowAllHeaders")]
        [HttpPost]
        //[Authorize]
        [Route("[Action]")]
        //[Authorize]
        public int SaveFacilityTariffDetails(List<FacilityChargeItemDetails> obj)
        {
            var response = _repository.SaveFacilityTariffDetails(obj);

            return response;
        }
        [EnableCors("AllowAllHeaders")]
        [HttpPost]
        //[Authorize]
        [Route("[Action]")]
        //[Authorize]
        public int UpdateFacilityTariffDetails(FacilityChargeItemDetails obj)
        {
            var response = _repository.UpdateFacilityTariffDetails(obj);

            return response;
        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        //[Authorize]
        [Route("[Action]")]
        //[Authorize]
        public int RemoveFacilityTariffChargeId(int Id)
        {
            var response = _repository.RemoveFacilityTariffChargeId(Id);

            return response;
        }
        [HttpGet]
        [Route("[Action]")]
        [EnableCors("AllowAllHeaders")]
        public async Task<List<CalendarSchedule>> GetExtraReScheduleDates(string selectedDate, int providerId, int FacilityId)
        {
            return await _repository.GetExtraReScheduleDates(selectedDate, providerId, FacilityId);
        }
        [HttpGet]
        [Route("[Action]")]
        [EnableCors("AllowAllHeaders")]
        public async Task<List<GetPatientDetailsbyAppointment>> GetPatientDatabyPatientTempID(int PatientTempId)
        {
            return await _repository.GetPatientDatabyPatientTempID(PatientTempId);
        }
        [HttpGet]
        [Route("[Action]")]
        [EnableCors("AllowAllHeaders")]
        public async Task<decimal> GetConsultationAmount(int DoctorId, int Organizationd, int FacilityId, int ChargeItemId)
        {
            return await _repository.GetConsultationAmount(DoctorId, Organizationd, FacilityId, ChargeItemId);
        }

    }
}
    

