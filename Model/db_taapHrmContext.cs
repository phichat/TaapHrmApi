using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        public virtual DbSet<VtChoice> VtChoice { get; set; }
        public virtual DbSet<VtQuestion> VtQuestion { get; set; }
        public virtual DbSet<VtScore> VtScore { get; set; }

        public virtual DbSet<HrmTestQuestionSet> HrmTestQuestionSets { get; set; }
        public virtual DbSet<HrmTestQuestion> HrmTestQuestions { get; set; }
        public virtual DbSet<HrmTestChoice> HrmTestChoices { get; set; }
        public virtual DbSet<HrmTestResult> HrmTestResults { get; set; }
        public virtual DbSet<HrmTestResultDetail> HrmTestResultDetails { get; set; }
        public virtual DbSet<HrmUser> HrmUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VtChoice>(entity =>
            {
                entity.ToTable("VT_Choice");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Choice)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ImgName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ImgSource).IsUnicode(false);

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VtQuestion>(entity =>
            {
                entity.ToTable("VT_Question");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Answer)
                    .IsUnicode(false);

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ImgName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ImgSource).IsUnicode(false);

                entity.Property(e => e.Question)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VtScore>(entity =>
            {
                entity.ToTable("VT_Score");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CareerType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HrmTestQuestionSet>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("hrm_test_question_set");

                entity.Property(e => e.Id)
                      .HasColumnName("id");

                entity.Property(e => e.QuestionSet)
                      .HasColumnName("question_set")
                      .HasMaxLength(255);

                entity.Property(e => e.TimeOut)
                      .HasColumnName("time_out");

                entity.Property(e => e.IsActive)
                      .HasColumnName("is_active")
                      .HasDefaultValue(1);

                entity.Property(e => e.UpdateDatePosi)
                      .HasColumnName("update_date_posi");

                entity.Property(e => e.UpdateUserPosi)
                      .HasColumnName("update_user_posi");
            });
            
            modelBuilder.Entity<HrmTestQuestion>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("hrm_test_question");

                entity.Property(e => e.Id)
                      .HasColumnName("id");

                entity.Property(e => e.QuestionSetId)
                      .HasColumnName("question_set_id");

                entity.Property(e => e.Question)
                      .HasColumnName("question")
                      .HasMaxLength(255);

                entity.Property(e => e.Img)
                      .HasColumnName("img")
                      .IsUnicode(false);

                entity.Property(e => e.ImgName)
                      .HasColumnName("imgName")
                      .HasMaxLength(255)
                      .IsUnicode(false);

                entity.Property(e => e.Answer)
                      .HasColumnName("answer");

                entity.Property(e => e.IsActive)
                      .HasColumnName("is_active")
                      .HasDefaultValue(1);

                entity.Property(e => e.UpdateUserPosi)
                      .HasColumnName("update_user_posi");

                entity.Property(e => e.UpdateDatePosi)
                      .HasColumnName("update_date_posi")
                      .HasColumnType("datetime");

            });

            modelBuilder.Entity<HrmTestChoice>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("hrm_test_choice");

                entity.Property(e => e.Id)
                      .HasColumnName("id");

                entity.Property(e => e.QuestionId)
                      .HasColumnName("question_id");

                entity.Property(e => e.Choice)
                      .HasColumnName("choice")
                      .HasMaxLength(255);

                entity.Property(e => e.Img)
                      .HasColumnName("img")
                      .IsUnicode(false);

                entity.Property(e => e.ImgName)
                      .HasColumnName("imgName")
                      .HasMaxLength(255)
                      .IsUnicode(false);

                entity.Property(e => e.IsActive)
                      .HasColumnName("is_active")
                      .HasDefaultValue(1);

                entity.Property(e => e.AnswerChoice)
                      .HasColumnName("answer_choice");

                entity.Property(e => e.UpdateDatePosi)
                      .HasColumnName("update_date_posi")
                      .HasColumnType("datetime");

                entity.Property(e => e.UpdateUserPosi)
                      .HasColumnName("update_user_posi");
            });

            modelBuilder.Entity<HrmTestResult>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("hrm_test_result");

                entity.Property(e => e.Id)
                      .HasColumnName("id");

                entity.Property(e => e.UserId)
                      .HasColumnName("user_id");

                entity.Property(e => e.QuestionSetId)
                      .HasColumnName("question_set_id");

                entity.Property(e => e.TimeOut)
                      .HasColumnName("time_out");

                entity.Property(e => e.TimeUse)
                      .HasColumnName("time_use");

                entity.Property(e => e.Pass)
                      .HasColumnName("pass");

                entity.Property(e => e.Fail)
                      .HasColumnName("fail");

                entity.Property(e => e.Total)
                      .HasColumnName("total");

                entity.Property(e => e.IsActive)
                      .HasColumnName("is_active");
            });

            modelBuilder.Entity<HrmUser>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("hrm_user");

                entity.Property(e => e.UserName)
                      .HasColumnName("username")
                      .HasMaxLength(150);

                entity.Property(e => e.Password)
                      .HasColumnName("password")
                      .HasMaxLength(255);

                entity.Property(e => e.FullName)
                      .HasColumnName("fullname")
                      .HasMaxLength(100);

                entity.Property(e => e.Email)
                      .HasColumnName("email")
                      .HasMaxLength(100);

                entity.Property(e => e.UserType)
                      .HasColumnName("user_type");

                entity.Property(e => e.CrDate)
                      .HasColumnName("crdate")
                      .HasColumnType("datetime");

                entity.Property(e => e.Enable)
                      .HasColumnName("enable")
                      .HasMaxLength(1);

                entity.Property(e => e.ComId)
                      .HasColumnName("com_id");

                entity.Property(e => e.Level)
                      .HasColumnName("level")
                      .HasMaxLength(10);

                entity.Property(e => e.UserExpdate)
                      .HasColumnName("user_expdate")
                      .HasColumnType("date");

                entity.Property(e => e.UserSme)
                      .HasColumnName("user_sme");

                entity.Property(e => e.Tel)
                      .HasColumnName("tel")
                      .HasMaxLength(10);

                entity.Property(e => e.UserIt)
                      .HasColumnName("user_it")
                      .HasMaxLength(150);

            });

            modelBuilder.Entity<HrmTestResultDetail>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("hrm_test_result_detail");

                entity.Property(e => e.Id)
                      .HasColumnName("id");

                entity.Property(e => e.TestResultId)
                      .HasColumnName("test_result_id");

                entity.Property(e => e.QuestionId)
                      .HasColumnName("question_id");

                entity.Property(e => e.TestedQuestion)
                      .HasColumnName("tested_question")
                      .HasMaxLength(255);

                entity.Property(e => e.TestedAnswer)
                      .HasColumnName("tested_answer")
                      .HasMaxLength(255);

                entity.Property(e => e.Answer)
                      .HasColumnName("answer")
                      .HasMaxLength(255);

                entity.Property(e => e.Result)
                      .HasColumnName("result")
                      .HasColumnType("bit");
            });
        }
    }
}
