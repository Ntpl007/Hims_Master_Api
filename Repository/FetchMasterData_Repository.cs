using HIMS_MASTERDATA.StoreProcedures;
using HIMS_MASTERDATA.ViewModel;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIMS_MASTERDATA.BHISHAK_APP_DB_Master;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using HIMS_MASTERDATA.BHISHAK_APP_DB;

namespace HIMS_MASTERDATA.Repository
{
    public class FetchMasterData_Repository : IFetchMasterData_Repository
    {




        private readonly bhishak_app_dbContext _context;
        private readonly StoreProceduresContext _Spcontext;
        public FetchMasterData_Repository(bhishak_app_dbContext context, StoreProceduresContext Spcontext)
        {
            _context = context;
            _Spcontext = Spcontext;

        }

        public async Task<IEnumerable<DoctorVo>> GetDoctor()
        {
            var objdoctors = await _context.TblUsers.Where(x => x.Status == true && x.IsProvider == true).ToListAsync();
            var list = (from p in objdoctors
                        select new DoctorVo
                        {
                            firstName = p.ListName,
                            ProviderId = p.UserId
                        }
                    );

            return list;
        }
        public async Task<IEnumerable<DoctorVo>> GetRefDoctors()
        {

            var objdoctors = await (from p in _context.TblUsers.Where(x => x.Status == true && x.IsProvider == false)
                                    select new DoctorVo
                                    {
                                        firstName = p.ListName,
                                        ProviderId = p.UserId

                                    }

                         ).ToListAsync();

            return objdoctors;

        }

        public async Task<IEnumerable<DoctorVo>> GetRefDoctorsbySpeciality(int Id)
        {

            var objdoctors = await (from p in _context.TblUsers.Where(x => x.Status == true && x.IsProvider == false && x.SpecialityId == Id)
                                    select new DoctorVo
                                    {
                                        firstName = p.ListName,
                                        ProviderId = p.UserId

                                    }

                         ).ToListAsync();

            return objdoctors;

        }
        public async Task<IEnumerable<DoctorVo>> GetRefDoctorsbyFacility(int SpecialityID, int OrganizationId, int FacilityId)
        {

            var objdoctors = await (from p in _context.TblUsers
                                    .Where(x => x.Status == true && x.IsProvider == false && x.SpecialityId == SpecialityID && x.OrganizationId == OrganizationId && x.FacilityId == FacilityId)
                                    select new DoctorVo
                                    {
                                        firstName = p.ListName,
                                        ProviderId = p.UserId

                                    }

                         ).ToListAsync();

            return objdoctors;

        }
        public async Task<IEnumerable<AreaVo>> GetArea()
        {

            var objList = await (from p in _context.TblAdmAreas.Where(x => x.StatusId == 1 && x.AreaId <= 4884)
                                 select new AreaVo
                                 {
                                     AreaId = p.AreaId,
                                     AreaName = p.AreaName

                                 }

                       ).ToListAsync();

            return objList;



        }
        public async Task<IEnumerable<CorporateVo>> GetCorporate(int Id)
        {

            var objlist = await (from p in _context.TblCorporates where p.StatusId == 1 && p.PaymentCategoryId == Id
                                 select new CorporateVo
                                 {
                                     CORPORATE_ID = p.CorporateId,
                                     CORPORATE_NAME = p.CorporateName

                                 }
                        ).ToListAsync();

            return objlist;

        }
        public async Task<IEnumerable<NationalityVo>> GetNationality()
        {

            var objlist = await (from p in _context.TblAdmNationalities
                                 select new NationalityVo
                                 {
                                     NATIONALITY_ID = p.NationalityId,
                                     NATIONALITY_NAME = p.NationalityName

                                 }
                         ).ToListAsync();

            return objlist;

        }
        public async Task<IEnumerable<SpecialityVo>> GetSpeciality()
        {

            var objlist = await (from p in _context.TblAdmSpecialities
                                 select new SpecialityVo
                                 {
                                     SpecialityID = p.SpecialityId,
                                     Speciality = p.Speciality

                                 }
                        ).ToListAsync();

            return objlist;

        }
        public async Task<IEnumerable<OccupationVo>> GetOccupation()
        {

            var objlist = await (from p in _context.TblAdmOccupationMasters
                                 select new OccupationVo
                                 {

                                     ID = p.Id,
                                     Occupation = p.Occupation

                                 }
                        ).ToListAsync();

            return objlist;

        }
        public async Task<IEnumerable<PatientRelationVo>> GetPatientRelation()
        {

            var objlist = await (from p in _context.TblAdmPatientRelations
                                 select new PatientRelationVo
                                 {

                                     RELATION_ID = p.RelationId,
                                     RELATION = p.Relation

                                 }
                        ).ToListAsync();

            return objlist;

        }
        public async Task<List<PatientVo>> getpatientdetails(string mobilenumber, int OrganizationId)
        {
            try
            {
                List<PatientVo> objlist = new List<PatientVo>();
                {
                    var mobile = new MySqlParameter
                        ("mobile", mobilenumber);
                    var _OrganizationId = new MySqlParameter
                       ("OrganizationId", OrganizationId);
                    using (var context = new StoreProceduresContext())
                    {
                        objlist = await context.getpatientdetails.FromSqlRaw("call GetPatientDetails(@mobile,@OrganizationId)", mobile, _OrganizationId).ToListAsync();
                    }
                    return objlist;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
          
        }
        public async Task<List<PatientVo>> GetpatientDetailsForBilling(string mobilenumber, int OrganizationId)
        {
            try
            {
                List<PatientVo> objlist = new List<PatientVo>();
                {
                    var mobile = new MySqlParameter
                        ("mobile", mobilenumber);
                    var _OrganizationId = new MySqlParameter
                       ("OrganizationId", OrganizationId);
                    using (var context = new StoreProceduresContext())
                    {
                        objlist = await context.GetpatientDetailsForBilling.FromSqlRaw("call GetpatientDetailsForBilling(@mobile,@OrganizationId)", mobile, _OrganizationId).ToListAsync();
                    }
                    return objlist;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        
        public async Task<IEnumerable<PatientIdVo>> GetPatientDetailsbypid(long patientid)
        {

            List<PatientIdVo> objlist = new List<PatientIdVo>();

            var PatientId = new MySqlParameter("PatientId", patientid);

            objlist = await _Spcontext.GetPatientDetailsByID.FromSqlRaw("call GetPatientDetailsByID(@PatientId)", PatientId).ToListAsync();

            return objlist;
        }
        public async Task<IEnumerable<GetExistedPatientAppointmentVocs>> GetPatientDetailsbypidnew(int patientid)
        {

            var _PatientId = new MySqlParameter("PatientId", patientid);


            var response = await _Spcontext.GetPatientDetailsForBinding.FromSqlRaw("call GetPatientDetailsForBinding(@PatientId)", _PatientId).ToListAsync();

            return response;
        }
        public async Task<IEnumerable<RelegionVo>> GetReligion()
        {


            var objlist = await (from p in _context.TblAdmReligions
                                 select new RelegionVo
                                 {
                                     ReligionID = p.ReligionId,
                                     ReligionName = p.ReligionName

                                 }
                         ).ToListAsync();
            return objlist;

        }
        public async Task<IEnumerable<RolesVo>> GetRoles()
        {


            var objlist = await (from p in _context.TblRoles
                                 select new RolesVo
                                 {
                                     RoleId = p.RoleId,
                                     Role = p.RoleName

                                 }
                         ).ToListAsync();
            return objlist;



        }
        public async Task<List<OrganizationVo>> GetOrganizations()
        {

            var objlist = await (from p in _context.TblOrganizations
                                 select new OrganizationVo
                                 {
                                     OrganizationId = p.OrganizationId,
                                     Organization_Name = p.OrganizationName

                                 }
                         ).ToListAsync();
            return objlist;

        }
        public async Task<List<FecilityVo>> GetFecilities(int id)
        {

            var objlist = await (from k in _context.TblAdmFacilities

                                 join m in _context.TblFacilityMappings on k.FacilityId equals m.FacilityId
                                 where m.OrganizationId == id
                                 select new FecilityVo
                                 {
                                     FecilityId = k.FacilityId,
                                     Fecility_Name = k.FacilityName
                                 }

                        ).ToListAsync();

            return objlist;

        }
        public async Task<List<ScheduleTypeVo>> GetScheduleTypes()
        {

            var objlist = await (from x in _context.TblScheduleTypes
                                 orderby x.ScheduleTypeName ascending
                                 select new ScheduleTypeVo
                                 {
                                     ScheduleTypeId = x.ScheduleTypeId,
                                     ScheduleType_Name = x.ScheduleTypeName
                                 }).ToListAsync();


            if (objlist != null)
            {
                return objlist;
            }
            else return null;
        }
        public async Task<List<bindStateDistrictVo>> GetStates()
        {

            var objlist = await (from x in _context.TblAdmStates orderby x.Name ascending
                                 select new bindStateDistrictVo
                                 {
                                     Id = x.Id,
                                     Name = x.Name
                                 }).ToListAsync();


            if (objlist != null)
            {
                return objlist;
            }
            else return null;


        }
        public async Task<List<bindStateDistrictVo>> GetDistricts(int Id)
        {
            List<bindStateDistrictVo> objlist = new List<bindStateDistrictVo>();
            using (var context = new bhishak_app_dbContext())
            {
                objlist = await (from x in context.TblAdmDistricts where x.StateId == Id
                                 orderby x.Name ascending
                                 select new bindStateDistrictVo
                                 {
                                     Id = x.Id,
                                     Name = x.Name
                                 }).ToListAsync();

            }
            if (objlist != null)
            {
                return objlist;
            }
            else return null;


        }
        public async Task<IEnumerable<TblAdmFacility>> GetTotalFecilities()
        {

            var objlist = await (from k in _context.TblAdmFacilities
                                 select new TblAdmFacility
                                 {
                                     FacilityId = k.FacilityId,
                                     FacilityName = k.FacilityName,
                                     Createdby = k.Createdby,
                                     CreatedDate = k.CreatedDate
                                 }

                         ).ToListAsync();

            return objlist;

        }
        public async Task<IEnumerable<AdminDashBoardVo>> GetAdminDashBoardDetails()
        {

            var result = await _Spcontext.GetDashboardData.FromSqlRaw("call GetDashboardData()").ToListAsync();
            return result;

        }
        //public async Task<List<UserListVo>> GetUserList(string organization)
        //{
        //    var org = _context.TblOrganizations.Where(x => x.OrganizationName == organization).FirstOrDefault();
        //    var _organzation_Id = new MySqlParameter("organzation_Id", org.OrganizationId);
        //    var response = await _Spcontext.SP_GetUserList
        //        .FromSqlRaw("call SP_GetUserList(@organzation_Id)", _organzation_Id).ToListAsync();


        //    return response;
        //}
        public async Task<List<UserListVo>> GetUserList(ReqUserListVo Input)
        {
            try
            {

                var UserName = new MySqlParameter("Username", Input.Username);
                var Role = new MySqlParameter("Role", Input.Role == 0 ? null : Input.Role);
                var organization = new MySqlParameter("Organization", Input.Organization == 0 ? null : Input.Organization);
                var Facility = new MySqlParameter("Facility", Input.Facility == 0 ? null : Input.Facility);

                //  var org = _context.TblOrganizations.Where(x => x.OrganisationName == input).FirstOrDefault();
                //   var _organzation_Id = new MySqlParameter("organzation_Id", org.OrganizationId);
                var response = await _Spcontext.SP_SearchUserList
                .FromSqlRaw("call SP_SearchUserList(@Organization,@Facility,@Role,@Username)", organization, Facility, Role, UserName).ToListAsync();

                return response;

            }
            catch (Exception e)
            {
                throw e;
            }

            return null;
        }


        public async Task<IEnumerable<DoctorVo>> GetDoctorsByspaciality(int Id)
        {
            var result = await (from x in _context.TblUsers
                                where x.IsProvider == true && x.SpecialityId == Id && x.Status == true
                                select new DoctorVo
                                {
                                    firstName = x.ListName,
                                    ProviderId = x.UserId,

                                }).ToListAsync();
            return result;

        }

        public async Task<IEnumerable<ChargegroupVo>> GetChargeGroups(int Id)
        {
            var result = await (from x in _context.TblAdmChargeGroups
                                where x.StatusId == 1 && x.SchedulerTypeId == Id
                                select new ChargegroupVo
                                {
                                    ChargeGroupId = x.ChargeGroupId,
                                    ChargeGroup = x.ChargeGroup

                                }).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<ChargeItemsVo>> GetChargeItems(int Id)
        {
            var result = await (from x in _context.TblAdmChargeItems
                                where x.StatusId == 1 && x.ChargeGroupId == Id
                                select new ChargeItemsVo
                                {
                                    ChargeItemId = x.ChargeItemId,
                                    ChargeItem = x.ChargeItem

                                }).ToListAsync();
            return result;
        }
        public async Task<IEnumerable<GetAppointment2Vo>> GetAppointments(GetAppointmentFiltersVo Input)
        {
            try
            {
                // Set the global date format for display
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
                CultureInfo.DefaultThreadCurrentCulture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd";

                // Parse a date from a string using the global format
                // string dateStr = "09/09/2023";
                DateTime fromdate = DateTime.Parse(Input.FromDate.ToString(), CultureInfo.CurrentCulture);
                DateTime todate = DateTime.Parse(Input.ToDate.ToString(), CultureInfo.CurrentCulture);

                //  Console.WriteLine(parsedDate.ToString()); // Display the parsed date in the global format

                var FromDate = new MySqlParameter("FromDate", fromdate);
                var ToDate = new MySqlParameter("ToDate", todate);
                var PatientName = new MySqlParameter("PatientName", Input.PatientName);
                var MobileNumber = new MySqlParameter("MobileNumber", Input.MobileNumber);
                var DoctorId = new MySqlParameter("DoctorId", Input.DoctorId == 0 ? null : Input.DoctorId);
                var AppointmentStatusId = new MySqlParameter("AppointmentStatusId", Input.AppointmentStatusId == 0 ? null : Input.AppointmentStatusId);
                var OrganizationId = new MySqlParameter("OrganizationId", Input.OrganizationId);
                var FacilityId = new MySqlParameter("FacilityId", Input.FacilityId);
                var result = await _Spcontext.SP_GET_APPOINTMENTS_DATA.FromSqlRaw("call SP_GET_APPOINTMENTS_DATA(@FromDate,@ToDate,@PatientName,@MobileNumber,@DoctorId,@AppointmentStatusId,@OrganizationId,@FacilityId)", FromDate, ToDate, PatientName, MobileNumber, DoctorId, AppointmentStatusId, OrganizationId, FacilityId).ToListAsync();
                var k = result;
                return result;

            }
            catch (Exception e)
            {
                throw e;
            }

            return null;
        }
        public async Task<IEnumerable<GetAppointment2Vo>> GetAppointmentsToday()
        {

            var result = await _Spcontext.SP_GET_APPOINTMENTS_DATATODAY.FromSqlRaw("call SP_GET_APPOINTMENTS_DATATODAY()").ToListAsync();

            return result;

        }
        public async Task<IEnumerable<AppointmentstatusVo>> GetAppointmentsStatus()
        {
            var result = await (from x in _context.TblAdmAppointmentStatuses

                                select new AppointmentstatusVo
                                {
                                    AppointmentStatusID = x.AppointmentStatusId,
                                    AppointmentStatus = x.AppointmentStatus

                                }).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<GetPaymentModeVo>> GetPaymentMode()
        {
            var response = await (from x in _context.TblAdmPaymentModes where x.StatusId == 1
                                  select new GetPaymentModeVo
                                  {
                                      PAYMENT_MODE_ID = x.PaymentModeId,
                                      PAYMENT_MODE = x.PaymentMode
                                  }).ToListAsync();
            return response;
        }
        public async Task<IEnumerable<GetPaymentCategoryVo>> GetPaymentCategory()
        {
            var response = await (from x in _context.TblAdmPaymentCategories
                                  where x.StatusId == 1
                                  select new GetPaymentCategoryVo
                                  {
                                      Payment_Category_ID = x.PaymentCategoryId,
                                      PAYMENT_CATEGORY = x.PaymentCategory
                                  }).ToListAsync();
            return response;
        }

        public async Task<IEnumerable<GetExistedPatientAppointmentVocs>> GetExistedPatientsForAppointment(string MobileNumber)
        {
            List<GetExistedPatientAppointmentVocs> objlist = new List<GetExistedPatientAppointmentVocs>();
            {
                var mobile = new MySqlParameter
                    ("MobileNumber", MobileNumber);
                using (var context = new StoreProceduresContext())
                {
                    objlist = await context.GetExistedPatientsForAppointment.FromSqlRaw("call GetExistedPatientsForAppointment(@MobileNumber)", mobile).ToListAsync();
                }
                if (objlist != null)
                {
                    return objlist;
                }
                else return null;

            }

        }

        public async Task<IEnumerable<EditAppointmentVo>> GetEditAppointmentdetails(int AppointmentId)
        {
            var response = await (from x in _context.TblAppointmentPatientTemps
                                  join a in _context.TblAppointments on x.PatientTempId equals a.PatientTempId
                                  where a.PatientAppointmentId == AppointmentId
                                  select new EditAppointmentVo
                                  {
                                      Prefix = x.Prefix,
                                      FirstName = x.FirstName,
                                      LastName = x.LastName,
                                      DateOfBirth = x.DateOfBirth,
                                      Age = (int)x.Age,
                                      AgeModId = x.AgeMode,
                                      Gender = x.Sex,
                                      AadhaarNumber = x.AadharNo,
                                      MobileNumber = x.MobileNumber,
                                      RelegionId = x.ReligionId,
                                      NationalityId = x.NationalityId,
                                      HouseNo = x.DoorNo,
                                      StateId = x.StateId,
                                      DistrictId = x.DistrictId,
                                      City = x.City,
                                      Village = x.Village,
                                      PinCode = x.Pincode,
                                      AppointmentDate = a.AppointmentDate,
                                      StartTime = a.StartTime.ToString(),
                                      EndTime = a.EndTime.ToString(),
                                      AppointmentId = a.PatientAppointmentId,
                                      PatientTempId = x.PatientTempId,
                                      ScheduleTypeId = a.ScheduleTypeId,
                                      DoctorId = a.DoctorId,
                                      SpecialityID = a.SpecialityId

                                  }

                ).ToListAsync();
            return response;
        }

        public IEnumerable<string> GetTimeSlotsForTimePicker(DateTime _Date, int TimeInterval)
        {


            DateTime d = DateTime.Now;
            int currentHours = 6;//d.Hour;
            var currentMinuts = 0;// d.Minute;
            int requiredMinuts = 0;
            if (_Date.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy"))
            {
                currentHours = d.Hour;
                currentMinuts = d.Minute;
                if (currentMinuts <= 10)
                {
                    requiredMinuts = 15;
                }
                else if (currentMinuts <= 25)
                {
                    requiredMinuts = 30;
                }
                else if (currentMinuts <= 40)
                {
                    requiredMinuts = 45;
                }
                else if (currentMinuts <= 55)
                {
                    currentHours = currentHours + 1;
                    requiredMinuts = 0;
                }
                else if (currentMinuts > 55)
                {
                    currentHours = currentHours + 1;
                    requiredMinuts = 15;
                }
            }

            DateTime startTime = DateTime.Today.AddHours(currentHours).AddMinutes(requiredMinuts); // Start time (e.g., 8:00 AM)
            DateTime endTime = DateTime.Today.AddHours(22).AddMinutes(45); // End time (e.g., 6:00 PM)

            List<string> timeIntervals = GenerateTimeIntervals(startTime, endTime, TimeSpan.FromMinutes(TimeInterval));
            return timeIntervals;
        }
        static List<string> GenerateTimeIntervals(DateTime startTime, DateTime endTime, TimeSpan interval)
        {
            List<string> timeIntervals = new List<string>();
            List<DateTime> timeIntervals2 = new List<DateTime>();

            while (startTime <= endTime)
            {
                timeIntervals.Add((startTime.ToString("hh:mm tt"))); // Format time as "08:00 AM"
                startTime = startTime.Add(interval);
            }

            return timeIntervals;
        }

        public bool IsUsernameValid(string UserName, int OrganizationId)
        {
            var response = _context.TblUsers.Where(x => x.UserName == UserName && x.OrganizationId == OrganizationId).FirstOrDefault();
            if (response != null)
            {
                return true;
            }
            else return false;

        }
        public void savedata()
        {
            var speciality = _context.TblAdmSpecialities.Where(x => x.StatusId == 1).ToList();
            var facilitymappingids = _context.TblFacilityMappings.ToList();

            for (int i = 0; i < facilitymappingids.Count; i++)
            {

                for (int j = 0; j < speciality.Count; j++)
                {
                    TblFacilitySpecialityLnk obj = new TblFacilitySpecialityLnk();
                    obj.FacilityMappingId = facilitymappingids[i].FacilityMappingId;
                    obj.SpecialityId = speciality[j].SpecialityId;
                    obj.CreatedBy = "madhu";
                    obj.CreatedDate = DateTime.Now;
                    _context.TblFacilitySpecialityLnks.Add(obj);
                    _context.SaveChanges();
                }

            }




        }

        public async Task<IEnumerable<GetVitalSignsVo>> GetVitalSigns()
        {
            var response = await (from x in _context.TblAdmVitalsigns
                                  where x.StatusId == 1
                                  select new GetVitalSignsVo
                                  {
                                      VITAL_SIGN_ID = x.VitalSignId,
                                      VITAL_SIGN = x.VitalSign
                                  }).ToListAsync();


            return response;

        }
        public async Task<IEnumerable<VitalsignVo>> GetVitalSignsDetails(int Id)
        {
            var response = await (from x in _context.TblAdmVitalsigns
                                  where x.StatusId == 1 && x.VitalSignId == Id
                                  select new VitalsignVo
                                  {
                                      VITAL_SIGN_ID = x.VitalSignId,
                                      VITAL_SIGN = x.VitalSign,
                                      MIN_VALUE = x.MinValue == null ? "--" : x.MinValue,
                                      MAX_VALUE = x.MaxValue == null ? "--" : x.MaxValue,
                                      UNIT_OF_MEASURE = x.UnitOfMeasure == null ? "--" : x.UnitOfMeasure
                                  }).ToListAsync();


            return response;

        }

        public async Task<IEnumerable<GetVitalSignsListToBindByspecialityVo>> LoadVitalSignsData(GetVitalssignsInputVo obj)
        {
            try
            {
                var FacilityId = new MySqlParameter
                  ("FacilityId", obj.FacilityId);
                var OrganizationId = new MySqlParameter
                      ("OrganizationId", obj.OrganizationId);
                var SpecialityId = new MySqlParameter
                    ("SpecialityId", obj.SpecialityId);

                var objlist = await _Spcontext.SP_GetVitalSignsForSpeciality.FromSqlRaw("call SP_GetVitalSignsForSpeciality(@FacilityId,@OrganizationId,@SpecialityId)", FacilityId, OrganizationId, SpecialityId).ToListAsync();
                return objlist;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<List<FecilityVo>> GetFecilities()
        {

            var objlist = await (from k in _context.TblAdmFacilities

                                 join m in _context.TblFacilityMappings on k.FacilityId equals m.FacilityId

                                 select new FecilityVo
                                 {
                                     FecilityId = k.FacilityId,
                                     Fecility_Name = k.FacilityName
                                 }

                        ).ToListAsync();

            return objlist;

        }
        public async Task<string> GetOrganizationAddress(int Id)
        {

            string Address = await (from x in _context.TblOrganizations
                                    where x.OrganizationId == Id
                                    select x.Address).FirstAsync();
            return Address;
        }
        public async Task<List<GetOrg_FacilityData>> GetorganizationMappedData()
        {
            try
            {
                var response = await _Spcontext.SP_GetTotalOrganizationData
             .FromSqlRaw("call SP_GetTotalOrganizationData()").ToListAsync();

                return response;
            }
            catch (Exception e) { throw e; }

        }
        public async Task<List<GetFacilitiesDataByOrganization>> GetFacilitiesList(int Id)
        {
            try
            {

                var OrgId = new MySqlParameter
                  ("OrganizationId", Id);
                var response = await _Spcontext.GetFacilitiesByOrgId
             .FromSqlRaw("call GetFacilitiesByOrgId(@OrganizationId)", OrgId).ToListAsync();

                return response;
            }
            catch (Exception e) { throw e; }

        }

        public async Task<List<GetUserDetailsForUpdateVo>> GetUserListDetailsbyId(int UserId)
        {
            try
            {
                var Id = new MySqlParameter
                  ("UserId", UserId);
                var response = await _Spcontext.SP_GetUsersListByIdForUpdate
             .FromSqlRaw("call SP_GetUsersListByIdForUpdate(@UserId)", Id).ToListAsync();

                return response;
            }
            catch (Exception e) { throw e; }

        }
        public async Task<int> UpdateUserDetails(GetUserDetailsForUpdateVo User, string Username)
        {
            try
            {
                int resp = 0;
                var tbluser = await _context.TblUsers.Where(x => x.UserId == User.UserId).FirstOrDefaultAsync();
                if (tbluser != null)
                {
                    tbluser.FirstName = User.FirstName;
                    tbluser.LastName = User.LastName;
                    tbluser.FacilityId = User.FacilityId;
                    tbluser.SpecialityId = User.SpecialityId == 0 ? null : User.SpecialityId;
                    tbluser.RoleId = User.RoleId;
                    tbluser.ModifiedBy = Username;
                    tbluser.CreatedDate = DateTime.Now;
                    if (User.isProvider == 1)
                    {
                        tbluser.IsProvider = true;
                    }
                    else tbluser.IsProvider = false;
                    tbluser.MobileNumber = Convert.ToInt64(User.MobileNumber);

                    resp += await _context.SaveChangesAsync();
                    var userroles = _context.TblUserroles.Where(x => x.UserId == User.UserId).FirstOrDefault();
                    userroles.Roleid = User.RoleId;
                    userroles.ModifiedBy = Username;
                    userroles.ModifiedDate = DateTime.Now;
                    resp += await _context.SaveChangesAsync();
                }


                return resp;
            }
            catch (Exception e) { throw e; }

        }

        public async Task<IEnumerable<DoctorVo>> GetDoctorList(int OrgnizationId, int FacilityId, int SpecialityId)
        {


            var objdoctors = await _context.TblUsers
                .Where(x => x.Status == true && x.IsProvider == true && x.OrganizationId == OrgnizationId && x.FacilityId == FacilityId && x.SpecialityId == SpecialityId).ToListAsync();
            var list = (from p in objdoctors
                        select new DoctorVo
                        {
                            firstName = p.ListName,
                            ProviderId = p.UserId
                        }
                    );

            return list;

        }

        public async Task<List<DoctorDashBoardVo>> GetDoctorDashBoardData(int OrgID, int FacID, int DoctorId)
        {
            try
            {
                var OrganizationId = new MySqlParameter
                  ("OrganizationId", OrgID);
                var FacilityId = new MySqlParameter
                ("FacilityId", FacID);
                var Doctor = new MySqlParameter
                ("Doctor", DoctorId);
                var response = await _Spcontext.Sp_DashBoardForDoctor
             .FromSqlRaw("call Sp_DashBoardForDoctor2(@OrganizationId,@FacilityId,@Doctor)", OrganizationId, FacilityId, Doctor).ToListAsync();

                return response;
            }
            catch (Exception e) { throw e; }

        }
        public async Task<List<FrontDeskDashBoardVo>> GetFrontDeskDashBoardCount(int OrganizationId, int FacilityId)
        {
            try
            {
                var _OrganazationId = new MySqlParameter("OrganazationId", OrganizationId);
                var _FacilityId = new MySqlParameter("FacilityId", FacilityId);

                var objList = await _Spcontext.Sp_DashBoardForFrontDesk
                   .FromSqlRaw("call Sp_DashBoardForFrontDesk2(@OrganazationId,@FacilityId)", _OrganazationId, _FacilityId).ToListAsync();
                return objList;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public async Task<IEnumerable<CalendarSchedule>> GetScheduledTime(DateTime selectedDate, int ProviderId, int FacilityId)
        {
            try
            {
                var objdoctors = await (
                                from schedule in _context.TblProviderScheduleTemplates
                                join period in _context.TblProviderScheduleTemplatePeriods on schedule.ScheduleTemplateId equals period.ScheduleTemplateId
                                where schedule.ProviderId == ProviderId && schedule.FacilityId == FacilityId
                                && DateTime.Compare(schedule.ScheduleTemplateEffectiveDate.Value.Date, selectedDate.Date) <= 0
                               && DateTime.Compare(schedule.ScheduleTempateExpirationDate.Value.Date, selectedDate.Date) >= 0
                                && ((selectedDate.DayOfWeek == DayOfWeek.Monday && period.IsMonday == 1) ||
                                 (selectedDate.DayOfWeek == DayOfWeek.Tuesday && period.IsTuesday == 1) ||
                                 (selectedDate.DayOfWeek == DayOfWeek.Wednesday && period.IsWednesday == 1) ||
                                 (selectedDate.DayOfWeek == DayOfWeek.Thursday && period.IsThursday == 1) ||
                                 (selectedDate.DayOfWeek == DayOfWeek.Friday && period.IsFriday == 1) ||
                                 (selectedDate.DayOfWeek == DayOfWeek.Saturday && period.IsSaturday == 1) ||
                                 (selectedDate.DayOfWeek == DayOfWeek.Sunday && period.IsSunday == 1))
                                //&& period.ScheduleSlotStatusId == 1

                                select new CalendarSchedule
                                {
                                    startDate = period.PeriodStart.Value,
                                    endDate = period.PeriodEnd.Value,
                                    scheduleInterval = schedule.ScheduleIntravel,
                                    scheduleTemplatePeriodId = Convert.ToInt32(period.ScheduleTemplatePeriodId)
                                }).ToListAsync();

                for (int i = 0; i < objdoctors.Count; i++)
                {
                    var objdoctorsTemp = await (
                                from sechdule in _context.TblProviderSchedules
                                where sechdule.ScheduleTemplatePeriodId == objdoctors[i].scheduleTemplatePeriodId
                                && sechdule.ScheduleSlotStatusId == 3
                                && sechdule.PeriodStart.Value.Date == selectedDate.Date
                                select new CalendarSchedule
                                {
                                    startDate = sechdule.PeriodStart.Value,
                                    endDate = sechdule.PeriodEnd.Value
                                }).ToListAsync();
                    if (objdoctorsTemp.Count > 0)
                    {
                        if (objdoctorsTemp[0].startDate.TimeOfDay == objdoctors[i].startDate.TimeOfDay)
                        {
                            objdoctors.RemoveAt(i);
                        }
                    }
                }



                return objdoctors;

                //var objdoctors = await (
                //                from schedule in _context.TblProviderScheduleTemplates
                //                join period in _context.TblProviderScheduleTemplatePeriods on schedule.ScheduleTemplateId equals period.ScheduleTemplateId
                //                where schedule.ProviderId == ProviderId && schedule.FacilityId == FacilityId
                //                && DateTime.Compare(schedule.ScheduleTemplateEffectiveDate.Value.Date, selectedDate.Date) <= 0
                //               && DateTime.Compare(schedule.ScheduleTempateExpirationDate.Value.Date, selectedDate.Date) >= 0
                //                && ((selectedDate.DayOfWeek == DayOfWeek.Monday && period.IsMonday == 1) ||
                //                 (selectedDate.DayOfWeek == DayOfWeek.Tuesday && period.IsTuesday == 1) ||
                //                 (selectedDate.DayOfWeek == DayOfWeek.Wednesday && period.IsWednesday == 1) ||
                //                 (selectedDate.DayOfWeek == DayOfWeek.Thursday && period.IsThursday == 1) ||
                //                 (selectedDate.DayOfWeek == DayOfWeek.Friday && period.IsFriday == 1) ||
                //                 (selectedDate.DayOfWeek == DayOfWeek.Saturday && period.IsSaturday == 1) ||
                //                 (selectedDate.DayOfWeek == DayOfWeek.Sunday && period.IsSunday == 1))

                //                select new CalendarSchedule
                //                {
                //                    startDate = schedule.ScheduleStartTime.Value,
                //                    endDate = schedule.ScheduleEndTime.Value,
                //                    scheduleInterval = schedule.ScheduleIntravel
                //                }).ToListAsync();

                //return objdoctors;
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public async Task<IEnumerable<CalendarSchedule>> GetBookedAppointments(string selectedDate, int ProviderId, int FacilityId)
        {
            List<CalendarSchedule> appointments = new List<CalendarSchedule>();
            try
            {
                DateTime formattedDate = DateTime.Parse(selectedDate).Date;
                //if (DateTime.TryParseExact(selectedDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime formatteddate))
                //{
                appointments = await (
                                from appointment in _context.TblAppointments
                                where appointment.DoctorId == ProviderId && appointment.FacilityId == FacilityId &&
                                    appointment.StartTime >= formattedDate &&
                                     appointment.StartTime < formattedDate.AddDays(1)
                                select new CalendarSchedule
                                {
                                    startDate = appointment.StartTime.Value,
                                    endDate = appointment.EndTime.Value,
                                    providerId = appointment.PatientAppointmentId
                                }).ToListAsync();

                // } 
                return appointments;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<GetAppointmentVo>> GetSelectedAppointmentdetails(DateTime AppointmentDate, TimeSpan startTime, int providerId, int facilityId)
        {
            List<GetAppointmentVo> appointments = new List<GetAppointmentVo>();
            try
            {

                appointments = await (
                                from appointment in _context.TblAppointments
                                where appointment.DoctorId == providerId && appointment.FacilityId == facilityId
                                 && appointment.AppointmentDate.Date == AppointmentDate.Date

                                select new GetAppointmentVo
                                {
                                    AppointmentId = appointment.PatientAppointmentId,
                                    Start_Time = appointment.StartTime.Value

                                }).ToListAsync();

                // } 
                var filteredAppointments = appointments
    .Where(appointment =>
        appointment.Start_Time.Hour == startTime.Hours &&
        appointment.Start_Time.Minute == startTime.Minutes &&
        appointment.Start_Time.Second == startTime.Seconds)
    .ToList();
                return filteredAppointments;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public async Task<GetOrganizationDataVo> GetOrganizationData(int Id)
        {

            var Response = await (from x in _context.TblOrganizations
                                  where x.OrganizationId == Id
                                  select new GetOrganizationDataVo
                                  {
                                      OrganizationId = x.OrganizationId,
                                      Organization = x.OrganizationName,
                                      Address = x.Address,
                                      organizationimage = x.Organizationimage
                                      
                                  }).FirstAsync();
            return Response;
        }

        public async Task<string> GetPatientName(string Rescheduleappointmetid)
        {
            try
            {
                //DateTime formattedDate = DateTime.Parse(SelectedSoltDateTime);

                TblAppointment objTblAppointments = new TblAppointment();
                objTblAppointments = (from x in _context.TblAppointments
                                      where x.PatientAppointmentId == Convert.ToInt32(Rescheduleappointmetid)
                                      select x).FirstOrDefault();

                string Name = await (from x in _context.TblPatients
                                     where x.PatienTId == objTblAppointments.PatientId
                                     select x.FirstNAme).FirstAsync();
                return Name;
            }catch(Exception e)
            {
                throw e;
            }
         }
                public async Task<IEnumerable<GetFacilityTariffDatacs>> GetFacilityTariffDetails(int OrganizationId, int FacilityId)
                {
                    try
                    {
                        var organization = new MySqlParameter("OrganizationId", OrganizationId);
                        var Facility = new MySqlParameter("FacilityId", FacilityId);


                        var response = await _Spcontext.GetFacilityTariffDetails
                        .FromSqlRaw("call GetFacilityTariffDetails(@OrganizationId,@FacilityId)", organization, Facility).ToListAsync();

                        //var FecilityTariff = response.Where(x => x.Oraganisation_Id == OrganizationId && x.Facility_Id == FacilityId).ToList();

                        //return FecilityTariff;

                        return response;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                

                return null;
            }

        public async Task<IEnumerable<ChargeItemVo>> GetChargeItemDeatils()
        {
            var Response = await(from x in _context.TblAdmChargeItems
                                
                                 select new ChargeItemVo
                                 {
                                     ChargeItemId = x.ChargeItemId,
                                     ChargeItem = x.ChargeItem,
                                     UnitCost = x.UnitCost
                                 }).ToListAsync();
            return Response;
        }

        public int SaveFacilityTariffDetails(List<FacilityChargeItemDetails> obj)
        {
            int response = 0;
            try
            {
                           
                bhishak_app_dbContext context = new bhishak_app_dbContext();
              

                for (int i = 0; i < obj.Count; i++)
                {

                    TblFacilityTariffMaster tblFacilityTariffMaster = new TblFacilityTariffMaster();
                    tblFacilityTariffMaster.FacilityId = obj[i].FacilityId;
                    tblFacilityTariffMaster.OraganisationId = obj[i].Organization;
                    tblFacilityTariffMaster.ChargeItemId = obj[i].ChargeItemId;
                    tblFacilityTariffMaster.BasePrice = obj[i].BasePrice;
                    tblFacilityTariffMaster.UnitPrice = obj[i].UnitPrice;
                    tblFacilityTariffMaster.DisplayName = "";
                    tblFacilityTariffMaster.CreatedBy = obj[i].CreatedBy;
                    tblFacilityTariffMaster.CreatedDateTime = DateTime.Now;
                    context.TblFacilityTariffMasters.Add(tblFacilityTariffMaster);
                    context.SaveChanges();


                    response = 1;
                }
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public int UpdateFacilityTariffDetails(FacilityChargeItemDetails obj)
        {
            int response = 0;
            try
            {
                var entity = _context.TblFacilityTariffMasters.FirstOrDefault(item => item.FacilityTariffId ==obj.FacilityChargeId);

                
                if (entity != null)
                {
                   bhishak_app_dbContext context = new bhishak_app_dbContext();                   
                   entity.FacilityId = obj.FacilityId;
                   entity.OraganisationId = obj.Organization;
                   entity.ChargeItemId = obj.ChargeItemId;
                   entity.BasePrice = obj.BasePrice;
                   entity.UnitPrice = obj.UnitPrice;
                   entity.DisplayName = "";
                   entity.CreatedBy = obj.CreatedBy;
                   entity.CreatedDateTime = DateTime.Now;
                   context.TblFacilityTariffMasters.Update(entity);
                   context.SaveChanges();
                    response = 1;
                    
                }
                return response;

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public int RemoveFacilityTariffChargeId(int Id)
        {
            int response = 0;
            try
            {
                var entity = _context.TblFacilityTariffMasters.FirstOrDefault(item => item.FacilityTariffId == Id);


                if (entity != null)
                {
                    bhishak_app_dbContext context = new bhishak_app_dbContext();
                    
                    context.TblFacilityTariffMasters.Remove(entity);
                    context.SaveChanges();
                    response = 1;

                }
                return response;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<CalendarSchedule>> GetResechduleslotsData(string selectedDate, int ProviderId, int FacilityId)
        {
            List<CalendarSchedule> response = new List<CalendarSchedule>();

            try
            {
                var param = new MySqlParameter[] {
                        new MySqlParameter() {
                            ParameterName = "@providerid",
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ProviderId
                        },
                         new MySqlParameter() {
                            ParameterName = "@rescheduledate",
                            Direction = System.Data.ParameterDirection.Input,
                            Value = (selectedDate == null ? "" : selectedDate)
                        }};



                response = await _Spcontext.sp_GetReScheduleDates
                   .FromSqlRaw("call sp_GetReScheduleDates(@providerid, @rescheduledate)", param).ToListAsync();


                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<UserFacilityListVo>> userlistbyfacilitylist(int Userid)
        {
            string facilityList = "";

            int[] fid = null;
            List<UserFacilityListVo> objList = new List<UserFacilityListVo>();

            try
            {
                facilityList = (from x in _context.TblUsers
                                where x.UserId == Userid
                                select x.FacilityList).First();
                if(facilityList!=null && facilityList!="")
                 {
                    string[] parts = facilityList.Split(',');

                    for (int i = 0; i < parts.Length; i++)
                    {
                        //   List<UserFacilityListVo> obj = new List<UserFacilityListVo>();
                        // fid[i] =Convert.ToInt32(parts[i]);
                        var Id = new MySqlParameter
                                    ("Userid", Userid);
                        var FacilityListId = new MySqlParameter
                                         ("FacilityListId", Convert.ToInt32(parts[i]));
                        var obj = await _Spcontext.SP_UserbyFacilitylist
                    .FromSqlRaw("call SP_UserbyFacilitylist(@Userid,@FacilityListId)", Id, FacilityListId).ToListAsync();
                        objList.Add(obj[0]);
                        //return response;
                    }
                }

               

                return objList;


            }
            catch (Exception e)
            {
                throw e;
            }
           
        }

        public async Task<List<CalendarSchedule>> GetExtraReScheduleDates(string selectedDate, int ProviderId, int FacilityId)
        {
            List<CalendarSchedule> response = new List<CalendarSchedule>();

            try
            {
                var param = new MySqlParameter[] {
                        new MySqlParameter() {
                            ParameterName = "@providerid",
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ProviderId
                        },
                         new MySqlParameter() {
                            ParameterName = "@rescheduledate",
                            Direction = System.Data.ParameterDirection.Input,
                            Value = (selectedDate == null ? "" : selectedDate)
                        }};



                response = await _Spcontext.sp_GetExtraReScheduleDates
                   .FromSqlRaw("call sp_GetExtraReScheduleDates(@providerid, @rescheduledate)", param).ToListAsync();


                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<List<GetPatientDetailsbyAppointment>> GetPatientDatabyPatientTempID(int PatientTempId)
        {
            try
            {
                
                var _PatientTempId = new MySqlParameter("PatientTempId", PatientTempId);
                var response = await _Spcontext.SP_GETPATIENTDATABYPATIENTTEMPID
                .FromSqlRaw("call SP_GETPATIENTDATABYPATIENTTEMPID(@PatientTempId)", _PatientTempId).ToListAsync();
                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
           

        }
        public async Task<decimal> GetConsultationAmount(int DoctorId,int Organizationd,int FacilityId,int ChargeItemId)
        {
            try
            {
               // decimal c = 0;
                decimal ConsultationAmount = 0;
                var respone1 =await _context.TblFacilityDoctorTariffs.Where(x => (x.OraganisationId == Organizationd) && x.FacilityId == FacilityId && x.DoctorId == DoctorId && x.ChargeItemId == ChargeItemId).FirstOrDefaultAsync();
              
                if(respone1==null)
                {
                    var respone12 =await _context.TblFacilityTariffMasters.Where(x => (x.OraganisationId == Organizationd) && x.FacilityId == FacilityId && x.ChargeItemId == ChargeItemId).FirstOrDefaultAsync();
                    ConsultationAmount = (int)respone12.UnitPrice;
                }
                else
                {
                    ConsultationAmount = (int)respone1.OverridenPrice;
                }
                            return ConsultationAmount;
               
            }
            catch (Exception e)
            {
                throw e;
            }


        }
    }
}

