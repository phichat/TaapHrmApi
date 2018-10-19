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
            //modelBuilder.Entity<HrmTestQuestionSet>(entity =>
            //{
            //    entity.HasKey(e => e.Id);

            //    entity.ForMySQLHasCollation("utf8_general_ci");

            //    entity.ToTable("hrm_test_question_set");

            //    entity.Property(e => e.Id)
            //          .HasColumnName("id");

            //    entity.Property(e => e.QuestionSet)
            //          .HasColumnName("question_set")
            //          .ForMySQLHasCollation("utf8_general_ci")
            //          .HasMaxLength(255);

            //    entity.Property(e => e.TimeOut)
            //          .HasColumnName("time_out");

            //    entity.Property(e => e.IsActive)
            //          .HasColumnName("is_active")
            //          .ForMySQLHasDefaultValue(1);

            //    entity.Property(e => e.UpdateDatePosi)
            //          .HasColumnName("update_date_posi");

            //    entity.Property(e => e.UpdateUserPosi)
            //          .HasColumnName("update_user_posi");
            //});

            //modelBuilder.Entity<HrmTestQuestion>(entity =>
            //{
            //    entity.HasKey(e => e.Id);

            //    entity.ForMySQLHasCollation("utf8_general_ci");

            //    entity.ToTable("hrm_test_question");

            //    entity.Property(e => e.Id)
            //          .HasColumnName("id");

            //    entity.Property(e => e.QuestionSetId)
            //          .HasColumnName("question_set_id");

            //    entity.Property(e => e.Question)
            //          .HasColumnName("question")
            //          .ForMySQLHasCollation("utf8_general_ci")
            //          .HasMaxLength(255);

            //    entity.Property(e => e.Img)
            //          .HasColumnName("img")
            //          .ForMySQLHasCollation("utf8_general_ci")
            //          .IsUnicode(false);

            //    entity.Property(e => e.ImgName)
            //          .HasColumnName("imgName")
            //          .ForMySQLHasCollation("utf8_general_ci")
            //          .HasMaxLength(255)
            //          .IsUnicode(false);

            //    entity.Property(e => e.Answer)
            //          .HasColumnName("answer");

            //    entity.Property(e => e.IsActive)
            //          .HasColumnName("is_active")
            //          .HasDefaultValue(1);

            //    entity.Property(e => e.UpdateUserPosi)
            //          .HasColumnName("update_user_posi");

            //    entity.Property(e => e.UpdateDatePosi)
            //          .HasColumnName("update_date_posi")
            //          .HasColumnType("datetime");

            //});

            //modelBuilder.Entity<HrmTestChoice>(entity =>
            //{
            //    entity.HasKey(e => e.Id);

            //    entity.ForMySQLHasCollation("utf8_general_ci");

            //    entity.ToTable("hrm_test_choice");

            //    entity.Property(e => e.Id)
            //          .HasColumnName("id");

            //    entity.Property(e => e.QuestionId)
            //          .HasColumnName("question_id");

            //    entity.Property(e => e.Choice)
            //          .HasColumnName("choice")
            //          .ForMySQLHasCollation("utf8_general_ci")
            //          .HasMaxLength(255);

            //    entity.Property(e => e.Img)
            //          .HasColumnName("img")
            //          .ForMySQLHasCollation("utf8_general_ci")
            //          .IsUnicode(false);

            //    entity.Property(e => e.ImgName)
            //          .HasColumnName("imgName")
            //          .ForMySQLHasCollation("utf8_general_ci")
            //          .HasMaxLength(255)
            //          .IsUnicode(false);

            //    entity.Property(e => e.IsActive)
            //          .HasColumnName("is_active")
            //          .HasDefaultValue(1);

            //    entity.Property(e => e.AnswerChoice)
            //          .HasColumnName("answer_choice");

            //    entity.Property(e => e.UpdateDatePosi)
            //          .HasColumnName("update_date_posi")
            //          .HasColumnType("datetime");

            //    entity.Property(e => e.UpdateUserPosi)
            //          .HasColumnName("update_user_posi");
            //});

            //modelBuilder.Entity<HrmTestResult>(entity =>
            //{
            //    entity.HasKey(e => e.Id);

            //    entity.ForMySQLHasCollation("utf8_general_ci");

            //    entity.ToTable("hrm_test_result");

            //    entity.Property(e => e.Id)
            //          .HasColumnName("id");

            //    entity.Property(e => e.UserId)
            //          .HasColumnName("user_id");

            //    entity.Property(e => e.QuestionSetId)
            //          .HasColumnName("question_set_id");

            //    entity.Property(e => e.TimeOut)
            //          .HasColumnName("time_out");

            //    entity.Property(e => e.TimeUse)
            //          .HasColumnName("time_use");

            //    entity.Property(e => e.Pass)
            //          .HasColumnName("pass");

            //    entity.Property(e => e.Fail)
            //          .HasColumnName("fail");

            //    entity.Property(e => e.Total)
            //          .HasColumnName("total");

            //});

            //modelBuilder.Entity<HrmUser>(entity =>
            //{
            //    entity.HasKey(e => e.Id);

            //    entity.ForMySQLHasCollation("utf8_general_ci");

            //    entity.ToTable("hrm_user");

            //    entity.Property(e => e.UserName)
            //          .HasColumnName("username")
            //          .ForMySQLHasCollation("utf8_general_ci")
            //          .HasMaxLength(150);

            //    entity.Property(e => e.Password)
            //          .HasColumnName("password")
            //          .ForMySQLHasCollation("utf8_general_ci")
            //          .HasMaxLength(255);

            //    entity.Property(e => e.FullName)
            //          .HasColumnName("fullname")
            //          .ForMySQLHasCollation("utf8_general_ci")
            //          .HasMaxLength(100);

            //    entity.Property(e => e.Email)
            //          .HasColumnName("email")
            //          .ForMySQLHasCollation("utf8_general_ci")
            //          .HasMaxLength(100);

            //    entity.Property(e => e.UserType)
            //          .HasColumnName("user_type");

            //    entity.Property(e => e.CrDate)
            //          .HasColumnName("crdate")
            //          .HasColumnType("datetime");

            //    entity.Property(e => e.Enable)
            //          .HasColumnName("enable")
            //          .ForMySQLHasCollation("utf8_general_ci")
            //          .HasMaxLength(1);

            //    entity.Property(e => e.ComId)
            //          .HasColumnName("com_id");

            //    entity.Property(e => e.Level)
            //          .HasColumnName("level")
            //          .ForMySQLHasCollation("utf8_general_ci")
            //          .HasMaxLength(10);

            //    entity.Property(e => e.UserExpdate)
            //          .HasColumnName("user_expdate")
            //          .HasColumnType("date");

            //    entity.Property(e => e.UserSme)
            //          .HasColumnName("user_sme");

            //    entity.Property(e => e.Tel)
            //          .HasColumnName("tel")
            //          .ForMySQLHasCollation("utf8_general_ci")
            //          .HasMaxLength(10);

            //    entity.Property(e => e.UserIt)
            //          .HasColumnName("user_it")
            //          .ForMySQLHasCollation("utf8_general_ci")
            //          .HasMaxLength(150);

            //});

            //modelBuilder.Entity<HrmTestResultDetail>(entity =>
            //{
            //    entity.HasKey(e => e.Id);

            //    entity.ForMySQLHasCollation("utf8_general_ci");

            //    entity.ToTable("hrm_test_result_detail");

            //    entity.Property(e => e.Id)
            //          .HasColumnName("id");

            //    entity.Property(e => e.TestResultId)
            //          .HasColumnName("test_result_id");

            //    entity.Property(e => e.QuestionId)
            //          .HasColumnName("question_id");

            //    entity.Property(e => e.TestedQuestion)
            //          .HasColumnName("tested_question")
            //          .ForMySQLHasCollation("utf8_general_ci")
            //          .HasMaxLength(255);

            //    entity.Property(e => e.TestedAnswer)
            //          .HasColumnName("tested_answer")
            //          .ForMySQLHasCollation("utf8_general_ci")
            //          .HasMaxLength(255);

            //    entity.Property(e => e.Answer)
            //          .HasColumnName("answer")
            //          .ForMySQLHasCollation("utf8_general_ci")
            //          .HasMaxLength(255);

            //    entity.Property(e => e.Result)
            //          .HasColumnName("result")
            //          .HasColumnType("bit");
            //});

        }
    }
}
