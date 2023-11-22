using HIMS_MASTERDATA.BHISHAK_APP_DB_Master;
using HIMS_MASTERDATA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIMS_MASTERDATA.Repository
{
    public interface IFetchMasterData_Repository
    {
        public Task<IEnumerable<DoctorVo>> GetDoctor();
        public Task<IEnumerable<DoctorVo>> GetRefDoctors();
        public Task<IEnumerable<AreaVo>> GetArea();
        public Task<IEnumerable<CorporateVo>> GetCorporate(int Id);
        public Task<IEnumerable<NationalityVo>> GetNationality();
        public Task<IEnumerable<SpecialityVo>> GetSpeciality();
        public Task<IEnumerable<OccupationVo>> GetOccupation();
        public Task<IEnumerable<PatientRelationVo>> GetPatientRelation();
        // getpatientdetails  public Task<List<PatientVo>> GetPatientDetails(string MobileNumber);
        public Task<List<PatientVo>> getpatientdetails(string MobileNumber,int OrganizationId);
        public Task<IEnumerable<RelegionVo>> GetReligion();
        public Task<IEnumerable<PatientIdVo>> GetPatientDetailsbypid(long patientid);
        public Task<IEnumerable<RolesVo>> GetRoles();
        public Task<List<OrganizationVo>> GetOrganizations();
        public Task<List<FecilityVo>> GetFecilities(int id);
        public Task<List<FecilityVo>> GetFecilities();
        public Task<IEnumerable<TblAdmFacility>> GetTotalFecilities();
        public Task<List<bindStateDistrictVo>> GetDistricts(int Id);
        public Task<List<bindStateDistrictVo>> GetStates();
        public Task<List<ScheduleTypeVo>> GetScheduleTypes();
        public Task<List<UserListVo>> GetUserList(ReqUserListVo Obj);
        public Task<IEnumerable<DoctorVo>> GetRefDoctorsbySpeciality(int Id);
        public Task<IEnumerable<AdminDashBoardVo>> GetAdminDashBoardDetails();
        public Task<IEnumerable<DoctorVo>> GetDoctorsByspaciality(int Id);

        public Task<IEnumerable<ChargegroupVo>> GetChargeGroups(int Id);
        public Task<IEnumerable<ChargeItemsVo>> GetChargeItems(int Id);
        public Task<IEnumerable<GetAppointment2Vo>> GetAppointments(GetAppointmentFiltersVo Input);
        public Task<IEnumerable<AppointmentstatusVo>> GetAppointmentsStatus();
        public Task<IEnumerable<GetPaymentModeVo>> GetPaymentMode();
        public Task<IEnumerable<GetPaymentCategoryVo>> GetPaymentCategory();
        public Task<IEnumerable<GetExistedPatientAppointmentVocs>> GetExistedPatientsForAppointment(string MobileNumber);

        public Task<IEnumerable<GetExistedPatientAppointmentVocs>> GetPatientDetailsbypidnew(int patientid);

        public Task<IEnumerable<EditAppointmentVo>> GetEditAppointmentdetails(int AppointmentId);

        public Task<IEnumerable<GetAppointment2Vo>> GetAppointmentsToday();
        public IEnumerable<string> GetTimeSlotsForTimePicker(DateTime _Date,int TimeInterval);
        public bool IsUsernameValid(string UserName,int OrganizationId);
        public void savedata();
        public Task<IEnumerable<GetVitalSignsVo>> GetVitalSigns();
        public Task<IEnumerable<VitalsignVo>> GetVitalSignsDetails(int Id);
        public Task<IEnumerable<GetVitalSignsListToBindByspecialityVo>> LoadVitalSignsData(GetVitalssignsInputVo obj);
        public Task<string> GetOrganizationAddress(int Id);
        public Task<List<GetOrg_FacilityData>> GetorganizationMappedData();
        public Task<List<GetFacilitiesDataByOrganization>> GetFacilitiesList(int Id);
        public Task<List<GetUserDetailsForUpdateVo>> GetUserListDetailsbyId(int UserId);
        public Task<int> UpdateUserDetails(GetUserDetailsForUpdateVo User, string Username);
        public Task<IEnumerable<DoctorVo>> GetDoctorList(int OrgnizationId, int FacilityId, int SpecialityId);
        public Task<List<DoctorDashBoardVo>> GetDoctorDashBoardData(int OrgID, int FacID, int DoctorId);
        public Task<IEnumerable<CalendarSchedule>> GetScheduledTime(DateTime selectedDate, int providerId, int FacilityId);
        public Task<IEnumerable<CalendarSchedule>> GetBookedAppointments(string selectedDate, int providerId, int FacilityId);
        public Task<IEnumerable<GetAppointmentVo>> GetSelectedAppointmentdetails(DateTime AppointmentDate, TimeSpan startTime, int providerId, int facilityId);
        public Task<GetOrganizationDataVo> GetOrganizationData(int Id);
        public Task<List<FrontDeskDashBoardVo>> GetFrontDeskDashBoardCount(int OrganizationId, int FacilityId);

        public Task<IEnumerable<DoctorVo>> GetRefDoctorsbyFacility(int SpecialityID, int OrganizationId, int FacilityId);
        public Task<string> GetPatientName(string Rescheduleappointmetid);
        public Task<List<CalendarSchedule>> GetResechduleslotsData(string selectedDate, int providerId, int FacilityId);
        public Task<List<UserFacilityListVo>> userlistbyfacilitylist(int Userid);


        public Task<IEnumerable<GetFacilityTariffDatacs>> GetFacilityTariffDetails(int OrganizationId, int FacilityId);

        public Task<IEnumerable<ChargeItemVo>> GetChargeItemDeatils();

        public int SaveFacilityTariffDetails(List<FacilityChargeItemDetails> obj);
        public int UpdateFacilityTariffDetails(FacilityChargeItemDetails obj);

        public int RemoveFacilityTariffChargeId(int Id);
        public Task<List<CalendarSchedule>> GetExtraReScheduleDates(string selectedDate, int providerId, int FacilityId);
        public  Task<List<GetPatientDetailsbyAppointment>> GetPatientDatabyPatientTempID(int PatientTempId);
        public Task<decimal> GetConsultationAmount(int DoctorId, int Organizationd, int FacilityId, int ChargeItemId);
        public Task<List<PatientVo>> GetpatientDetailsForBilling(string mobilenumber, int OrganizationId);

    }

}

