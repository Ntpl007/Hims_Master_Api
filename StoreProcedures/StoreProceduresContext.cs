using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HIMS_MASTERDATA.ViewModel;


#nullable disable

namespace HIMS_MASTERDATA.StoreProcedures
{
    public partial class StoreProceduresContext : DbContext
    {
        public StoreProceduresContext()
        {
        }

        public StoreProceduresContext(DbContextOptions<StoreProceduresContext> options)
            : base(options)
        {
        }
        public virtual DbSet<GetPatientDetailsbyAppointment> SP_GETPATIENTDATABYPATIENTTEMPID { get; set; }
        public virtual DbSet<CalendarSchedule> sp_GetExtraReScheduleDates { get; set; }
        public virtual DbSet<UserFacilityListVo> SP_UserbyFacilitylist { get; set; }
        public virtual DbSet<FacilityListOfUsersVo> SP_FacilityListForUser { get; set; }

        public virtual DbSet<FrontDeskDashBoardVo> Sp_DashBoardForFrontDesk { get; set; }
        
        public virtual DbSet<DoctorDashBoardVo> Sp_DashBoardForDoctor { get; set; }

        public virtual DbSet<GetUserDetailsForUpdateVo> SP_GetUsersListByIdForUpdate { get; set; }
        public virtual DbSet<UserListVo> SP_SearchUserList { get; set; }
        public virtual DbSet<GetFacilitiesDataByOrganization> GetFacilitiesByOrgId { get; set; }
        public virtual DbSet<GetExistedPatientAppointmentVocs> GetExistedPatientsForAppointment { get; set; }
        public virtual DbSet<AdminDashBoardVo> GetDashboardData { get; set; }
        public virtual DbSet<PatientVo> getpatientdetails { get; set; }
        public virtual DbSet<PatientVo> GetpatientDetailsForBilling { get; set; }
        public virtual DbSet<PatientIdVo> GetPatientDetailsByID { get; set; }
        public virtual DbSet<GetExistedPatientAppointmentVocs> GetPatientDetailsForBinding { get; set; }
        public virtual DbSet<UserListVo> SP_GetUserList { get; set; }
        public virtual DbSet<GetAppointment2Vo> SP_GET_APPOINTMENTS_DATA { get; set; }
        public virtual DbSet<GetAppointment2Vo> SP_GET_APPOINTMENTS_DATATODAY { get; set; }
        public virtual DbSet<GetVitalSignsListToBindByspecialityVo> SP_GetVitalSignsForSpeciality { get; set; }
        public virtual DbSet<GetOrg_FacilityData> SP_GetTotalOrganizationData { get; set; }
        public virtual DbSet<CalendarSchedule> sp_GetReScheduleDates { get; set; }

        public virtual DbSet<GetFacilityTariffDatacs> GetFacilityTariffDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Server=10.10.20.25;Database=bhishak_app_db; User=root;Password=root@123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GetFacilityTariffDatacs>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<PatientVo>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<PatientIdVo>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<AdminDashBoardVo>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<UserListVo>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<GetAppointmentVo>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<GetAppointment2Vo>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<GetExistedPatientAppointmentVocs>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<GetVitalSignsListToBindByspecialityVo>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<GetOrg_FacilityData>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<GetFacilitiesDataByOrganization>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<GetUserDetailsForUpdateVo>(entity =>
            {
                entity.HasNoKey();
            }); 
            modelBuilder.Entity<DoctorDashBoardVo>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<FrontDeskDashBoardVo>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<CalendarSchedule>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<FacilityListOfUsersVo>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<UserFacilityListVo>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<GetPatientDetailsbyAppointment>(entity =>
            {
                entity.HasNoKey();
            });
            


            OnModelCreatingPartial(modelBuilder);
            
        }
      

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
