using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MySql.Data.EntityFrameworkCore.Extensions;

namespace TaapHrmApi.Model
{
    public partial class db_taapHrmContext : DbContext
    {
        public db_taapHrmContext()
        {
        }

        public db_taapHrmContext(DbContextOptions<db_taapHrmContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HrmTestQuestionSet> HrmTestQuestionSets { get; set; }
        public virtual DbSet<HrmTestQuestion> HrmTestQuestions { get; set; }
        public virtual DbSet<HrmTestChoice> HrmTestChoices { get; set; }
        public virtual DbSet<HrmTestResult> HrmTestResults { get; set; }
        public virtual DbSet<HrmTestResultDetail> HrmTestResultDetails { get; set; }
        public virtual DbSet<HrmUser> HrmUsers { get; set; }
        public virtual DbSet<HrmDepartment> HrmDepartment { get; set; }
        public virtual DbSet<HrmDepartmentPosition> HrmDepartmentPosition { get; set; }
        public virtual DbSet<HrmEmployee> HrmEmployee { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrmTestChoice>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("hrm_test_choice");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AnswerChoice)
                    .HasColumnName("answer_choice")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Choice)
                    .IsRequired()
                    .HasColumnName("choice")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Img)
                    .HasColumnName("img")
                    .HasColumnType("longtext");

                entity.Property(e => e.ImgName)
                    .HasColumnName("imgName")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValue(1)
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuestionId)
                    .HasColumnName("question_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdateDatePosi)
                    .HasColumnName("update_date_posi")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateUserPosi)
                    .HasColumnName("update_user_posi")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<HrmTestQuestion>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("hrm_test_question");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Answer)
                    .HasColumnName("answer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Img)
                    .HasColumnName("img")
                    .HasColumnType("longtext");

                entity.Property(e => e.ImgName)
                    .HasColumnName("imgName")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValue(1)
                    .HasColumnType("int(11)");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasColumnName("question")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.QuestionSetId)
                    .HasColumnName("question_set_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdateDatePosi)
                    .HasColumnName("update_date_posi")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateUserPosi)
                    .HasColumnName("update_user_posi")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<HrmTestQuestionSet>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("hrm_test_question_set");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValue(1)
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuestionSet)
                    .IsRequired()
                    .HasColumnName("question_set")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TimeOut)
                    .HasColumnName("time_out")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdateDatePosi)
                    .HasColumnName("update_date_posi")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateUserPosi)
                    .HasColumnName("update_user_posi")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<HrmTestResult>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("hrm_test_result");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fail)
                    .HasColumnName("fail")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pass)
                    .HasColumnName("pass")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QuestionSetId)
                    .HasColumnName("question_set_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TimeOut)
                    .HasColumnName("time_out")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TimeUse)
                    .HasColumnName("time_use")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsActive)
                      .HasColumnName("is_active")
                      .HasDefaultValue(0)
                      .HasColumnType("int(1)");
            });

            modelBuilder.Entity<HrmTestResultDetail>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("hrm_test_result_detail");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasColumnName("answer")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.QuestionId)
                    .HasColumnName("question_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.TestResultId)
                    .HasColumnName("test_result_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TestedAnswer)
                    .IsRequired()
                    .HasColumnName("tested_answer")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TestedQuestion)
                    .IsRequired()
                    .HasColumnName("tested_question")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<HrmUser>(entity =>
            {
                entity.ToTable("hrm_user");

                entity.HasIndex(e => e.ComId)
                    .HasName("user_suppliers");

                entity.HasIndex(e => e.Enable)
                    .HasName("enable");

                entity.HasIndex(e => e.UserType)
                    .HasName("user_type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ComId)
                    .HasColumnName("com_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CrDate)
                    .HasColumnName("crdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Enable)
                    .IsRequired()
                    .HasColumnName("enable")
                    .HasColumnType("char(1)");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("fullname")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasColumnName("level")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasColumnName("tel")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.UserExpdate)
                    .HasColumnName("user_expdate")
                    .HasColumnType("date");

                entity.Property(e => e.UserIt)
                    .IsRequired()
                    .HasColumnName("user_it")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.UserSme)
                    .HasColumnName("user_sme")
                    .HasColumnType("int(1)");

                entity.Property(e => e.UserType)
                    .HasColumnName("user_type")
                    .HasColumnType("int(3)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(150)");
            });

            modelBuilder.Entity<HrmDepartment>(entity =>
            {
                entity.HasKey(e => e.IdDep);

                entity.ToTable("hrm_department");

                entity.Property(e => e.IdDep)
                    .HasColumnName("id_dep")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AddDateDep)
                    .HasColumnName("add_date_dep")
                    .HasColumnType("datetime");

                entity.Property(e => e.AddUserDep)
                    .HasColumnName("add_user_dep")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodeNameDep)
                    .IsRequired()
                    .HasColumnName("code_name_dep")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.NameDep)
                    .IsRequired()
                    .HasColumnName("name_dep")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.StatusDep)
                    .HasColumnName("status_dep")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdateDateDep)
                    .HasColumnName("update_date_dep")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdateUserDep)
                    .HasColumnName("update_user_dep")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<HrmDepartmentPosition>(entity =>
            {
                entity.HasKey(e => e.IdDeposi);

                entity.ToTable("hrm_department_position");

                entity.Property(e => e.IdDeposi)
                    .HasColumnName("id_deposi")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AddDateDeposi)
                    .HasColumnName("add_date_deposi")
                    .HasColumnType("datetime");

                entity.Property(e => e.AddUserDeposi)
                    .HasColumnName("add_user_deposi")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodeNameDeposi)
                    .IsRequired()
                    .HasColumnName("code_name_deposi")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.DepIdDeposi)
                    .HasColumnName("dep_id_deposi")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LevelDeposi)
                    .HasColumnName("level_deposi")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NameDeposi)
                    .IsRequired()
                    .HasColumnName("name_deposi")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PetitionDeposi)
                    .HasColumnName("petition_deposi")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoleDeposi)
                    .HasColumnName("role_deposi")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StatusDeposi)
                    .HasColumnName("status_deposi")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdateDateDeposi)
                    .HasColumnName("update_date_deposi")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdateUserDeposi)
                    .HasColumnName("update_user_deposi")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<HrmEmployee>(entity =>
            {
                entity.HasKey(e => e.IdEmp);

                entity.ToTable("hrm_employee");

                entity.Property(e => e.IdEmp)
                    .HasColumnName("id_emp")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AddDateEmp)
                    .HasColumnName("add_date_emp")
                    .HasColumnType("datetime");

                entity.Property(e => e.AddUserEmp)
                    .HasColumnName("add_user_emp")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DepartPosiIdEmp)
                    .HasColumnName("depart_posi_id_emp")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FirstnameEmp)
                    .IsRequired()
                    .HasColumnName("firstname_emp")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LastnameEmp)
                    .IsRequired()
                    .HasColumnName("lastname_emp")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.NoAzEmp)
                    .IsRequired()
                    .HasColumnName("no_az_emp")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.NoNumberEmp)
                    .IsRequired()
                    .HasColumnName("no_number_emp")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.StatusEmp)
                    .HasColumnName("status_emp")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdateDateEmp)
                    .HasColumnName("update_date_emp")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UpdateUserEmp)
                    .HasColumnName("update_user_emp")
                    .HasColumnType("int(11)");
            });
        }
    }
}
