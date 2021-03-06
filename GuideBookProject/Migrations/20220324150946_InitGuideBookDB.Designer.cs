// <auto-generated />
using GuideBookProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GuideBookProject.Migrations
{
    [DbContext(typeof(GuideDbContext))]
    [Migration("20220324150946_InitGuideBookDB")]
    partial class InitGuideBookDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GuideBookProject.Models.CommInfo", b =>
                {
                    b.Property<int>("CommInfoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("VarChar(40)");

                    b.Property<string>("Location")
                        .HasColumnType("VarChar(30)");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TelNo")
                        .HasColumnType("VarChar(12)");

                    b.HasKey("CommInfoID");

                    b.HasIndex("PersonID");

                    b.ToTable("CommInfos");
                });

            modelBuilder.Entity("GuideBookProject.Models.Person", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .HasColumnType("VarChar(20)");

                    b.Property<string>("Name")
                        .HasColumnType("VarChar(20)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Surname")
                        .HasColumnType("VarChar(20)");

                    b.HasKey("UserID");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("GuideBookProject.Models.CommInfo", b =>
                {
                    b.HasOne("GuideBookProject.Models.Person", "Person")
                        .WithMany("CommInfos")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("GuideBookProject.Models.Person", b =>
                {
                    b.Navigation("CommInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
