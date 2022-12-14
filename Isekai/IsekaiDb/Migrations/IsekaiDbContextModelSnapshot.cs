// <auto-generated />
using System;
using IsekaiDb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IsekaiDb.Migrations
{
    [DbContext(typeof(IsekaiDbContext))]
    partial class IsekaiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ArmorPassive", b =>
                {
                    b.Property<Guid>("ArmorPassivesArmorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArmorPassivesPassiveId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ArmorPassivesArmorId", "ArmorPassivesPassiveId");

                    b.HasIndex("ArmorPassivesPassiveId");

                    b.ToTable("ArmorPassive");
                });

            modelBuilder.Entity("CharacterPassive", b =>
                {
                    b.Property<Guid>("CharacterPassivesCharacterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CharacterPassivesPassiveId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CharacterPassivesCharacterId", "CharacterPassivesPassiveId");

                    b.HasIndex("CharacterPassivesPassiveId");

                    b.ToTable("CharacterPassive");
                });

            modelBuilder.Entity("CharacterSkill", b =>
                {
                    b.Property<Guid>("CharacterSkillCharacterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CharacterSkillSkillId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CharacterSkillCharacterId", "CharacterSkillSkillId");

                    b.HasIndex("CharacterSkillSkillId");

                    b.ToTable("CharacterSkill");
                });

            modelBuilder.Entity("ClassPassive", b =>
                {
                    b.Property<Guid>("ClassPassivesClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClassPassivesPassiveId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ClassPassivesClassId", "ClassPassivesPassiveId");

                    b.HasIndex("ClassPassivesPassiveId");

                    b.ToTable("ClassPassive");
                });

            modelBuilder.Entity("IsekaiDb.Domain.Entities.Armor", b =>
                {
                    b.Property<Guid>("ArmorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.HasKey("ArmorId");

                    b.ToTable("Armors");
                });

            modelBuilder.Entity("IsekaiDb.Domain.Entities.Character", b =>
                {
                    b.Property<Guid>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AirLevel")
                        .HasColumnType("int");

                    b.Property<int>("ArcaneLevel")
                        .HasColumnType("int");

                    b.Property<Guid?>("ArmorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Axe")
                        .HasColumnType("int");

                    b.Property<int>("Bow")
                        .HasColumnType("int");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CombatDefense")
                        .HasColumnType("int");

                    b.Property<int>("CombatHP")
                        .HasColumnType("int");

                    b.Property<int>("CombatLuck")
                        .HasColumnType("int");

                    b.Property<int>("CombatMagic")
                        .HasColumnType("int");

                    b.Property<int>("CombatResistance")
                        .HasColumnType("int");

                    b.Property<int>("CombatSkill")
                        .HasColumnType("int");

                    b.Property<int>("CombatSpeed")
                        .HasColumnType("int");

                    b.Property<int>("CombatSpirit")
                        .HasColumnType("int");

                    b.Property<int>("CombatStrength")
                        .HasColumnType("int");

                    b.Property<int>("CurseLevel")
                        .HasColumnType("int");

                    b.Property<int>("Dagger")
                        .HasColumnType("int");

                    b.Property<int>("DarkLevel")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("DefenseGrowth")
                        .HasColumnType("int");

                    b.Property<int>("EarthLevel")
                        .HasColumnType("int");

                    b.Property<int>("FireLevel")
                        .HasColumnType("int");

                    b.Property<int>("Fist")
                        .HasColumnType("int");

                    b.Property<int>("HP")
                        .HasColumnType("int");

                    b.Property<int>("HPGrowth")
                        .HasColumnType("int");

                    b.Property<int>("HeatLevel")
                        .HasColumnType("int");

                    b.Property<int>("HolyLevel")
                        .HasColumnType("int");

                    b.Property<int>("IceLevel")
                        .HasColumnType("int");

                    b.Property<int>("IllusionLevel")
                        .HasColumnType("int");

                    b.Property<int>("LavaLevel")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("LightLevel")
                        .HasColumnType("int");

                    b.Property<int>("LightningLevel")
                        .HasColumnType("int");

                    b.Property<int>("LiquidLevel")
                        .HasColumnType("int");

                    b.Property<int>("Luck")
                        .HasColumnType("int");

                    b.Property<int>("LuckGrowth")
                        .HasColumnType("int");

                    b.Property<int>("Magic")
                        .HasColumnType("int");

                    b.Property<int>("MagicGrowth")
                        .HasColumnType("int");

                    b.Property<int>("MagicRank")
                        .HasColumnType("int");

                    b.Property<int>("MindLevel")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NatureLevel")
                        .HasColumnType("int");

                    b.Property<int>("NecromancyLevel")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PoisonLevel")
                        .HasColumnType("int");

                    b.Property<int>("Race")
                        .HasColumnType("int");

                    b.Property<int>("Resistance")
                        .HasColumnType("int");

                    b.Property<int>("ResistanceGrowth")
                        .HasColumnType("int");

                    b.Property<int>("Skill")
                        .HasColumnType("int");

                    b.Property<int>("SkillGrowth")
                        .HasColumnType("int");

                    b.Property<int>("SpaceLevel")
                        .HasColumnType("int");

                    b.Property<int>("Spear")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int>("SpeedGrowth")
                        .HasColumnType("int");

                    b.Property<int>("Spirit")
                        .HasColumnType("int");

                    b.Property<int>("SpiritGrowth")
                        .HasColumnType("int");

                    b.Property<int>("SpiritRank")
                        .HasColumnType("int");

                    b.Property<int>("Staff")
                        .HasColumnType("int");

                    b.Property<int>("StatRank")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int>("StrengthGrowth")
                        .HasColumnType("int");

                    b.Property<int>("Sword")
                        .HasColumnType("int");

                    b.Property<string>("Types")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WaterLevel")
                        .HasColumnType("int");

                    b.Property<Guid?>("WeaponId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("WindLevel")
                        .HasColumnType("int");

                    b.HasKey("CharacterId");

                    b.HasIndex("ArmorId");

                    b.HasIndex("ClassId");

                    b.HasIndex("WeaponId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("IsekaiDb.Domain.Entities.Class", b =>
                {
                    b.Property<Guid>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DefenseGrowth")
                        .HasColumnType("int");

                    b.Property<int>("HPGrowth")
                        .HasColumnType("int");

                    b.Property<int>("LuckGrowth")
                        .HasColumnType("int");

                    b.Property<int>("MagicGrowth")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResistanceGrowth")
                        .HasColumnType("int");

                    b.Property<int>("Serie")
                        .HasColumnType("int");

                    b.Property<int>("SkillGrowth")
                        .HasColumnType("int");

                    b.Property<int>("SpeedGrowth")
                        .HasColumnType("int");

                    b.Property<int>("SpiritGrowth")
                        .HasColumnType("int");

                    b.Property<int>("StrengthGrowth")
                        .HasColumnType("int");

                    b.HasKey("ClassId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("IsekaiDb.Domain.Entities.Passive", b =>
                {
                    b.Property<Guid>("PassiveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("PassiveId");

                    b.ToTable("Passives");
                });

            modelBuilder.Entity("IsekaiDb.Domain.Entities.Skill", b =>
                {
                    b.Property<Guid>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Accuracy")
                        .HasColumnType("int");

                    b.Property<int>("AccuracyGain")
                        .HasColumnType("int");

                    b.Property<int>("Crit")
                        .HasColumnType("int");

                    b.Property<int>("CritGain")
                        .HasColumnType("int");

                    b.Property<int>("MagicType")
                        .HasColumnType("int");

                    b.Property<int>("ManaUsed")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<int>("PowerGain")
                        .HasColumnType("int");

                    b.Property<int>("Purpose")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("SkillId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("IsekaiDb.Domain.Entities.Weapon", b =>
                {
                    b.Property<Guid>("WeaponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Accuracy")
                        .HasColumnType("int");

                    b.Property<int>("Crit")
                        .HasColumnType("int");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("DamageType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("WeaponId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "20aa6fd0-6644-4b29-b79c-cd98ec738cf8",
                            ConcurrencyStamp = "1a1149ed-cc49-4f22-a75a-65a5e74abc00",
                            Name = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "dcaf37ef-4c11-4ce7-b2ef-e32e51a65aff",
                            ConcurrencyStamp = "89d54669-b6e6-4e80-a5cf-1a0f91307b12",
                            Name = "VISITOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "06efe430-9fe9-4357-a84d-6a72c9ec5d80",
                            RoleId = "20aa6fd0-6644-4b29-b79c-cd98ec738cf8"
                        },
                        new
                        {
                            UserId = "276d7131-a53d-46fb-999e-c2d8b4210d97",
                            RoleId = "dcaf37ef-4c11-4ce7-b2ef-e32e51a65aff"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PassiveSkill", b =>
                {
                    b.Property<Guid>("SkillPassivesPassiveId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SkillPassivesSkillId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SkillPassivesPassiveId", "SkillPassivesSkillId");

                    b.HasIndex("SkillPassivesSkillId");

                    b.ToTable("PassiveSkill");
                });

            modelBuilder.Entity("PassiveWeapon", b =>
                {
                    b.Property<Guid>("WeaponPassivesPassiveId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WeaponPassivesWeaponId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("WeaponPassivesPassiveId", "WeaponPassivesWeaponId");

                    b.HasIndex("WeaponPassivesWeaponId");

                    b.ToTable("PassiveWeapon");
                });

            modelBuilder.Entity("IsekaiDb.Domain.User.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.HasData(
                        new
                        {
                            Id = "06efe430-9fe9-4357-a84d-6a72c9ec5d80",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d1a8c612-e2af-4745-be72-6c4cbecd945c",
                            Email = "lordardyn26@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "LORDARDYN26@GMAIL.COM",
                            NormalizedUserName = "ARDYN",
                            PasswordHash = "AQAAAAEAACcQAAAAEGnHb0HxnM/BHa0fbCcO5am3Liz0TE8VZQdeB49LL+anV0v9datlIeH8UxR9cIKF/w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4f545099-5972-4353-bbef-2bdd4867171b",
                            TwoFactorEnabled = false,
                            UserName = "Ardyn"
                        },
                        new
                        {
                            Id = "276d7131-a53d-46fb-999e-c2d8b4210d97",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4a2a95b3-e1e3-4bfe-ba29-ff5f55564d2b",
                            Email = "remi-bellefleur71@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "REMI-BELLEFLEUR71@GMAIL.COM",
                            NormalizedUserName = "GUTTENBERG71",
                            PasswordHash = "AQAAAAEAACcQAAAAEPxPLCD8K53aTqPdlNE4pcHMFvuFQU58mTx7LhJsuD3p9FygUr1WAPgWoKmrbiLjMA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4a1f1ac2-58e2-4605-8e3a-e6429fb50b59",
                            TwoFactorEnabled = false,
                            UserName = "Guttenberg71"
                        });
                });

            modelBuilder.Entity("ArmorPassive", b =>
                {
                    b.HasOne("IsekaiDb.Domain.Entities.Armor", null)
                        .WithMany()
                        .HasForeignKey("ArmorPassivesArmorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IsekaiDb.Domain.Entities.Passive", null)
                        .WithMany()
                        .HasForeignKey("ArmorPassivesPassiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CharacterPassive", b =>
                {
                    b.HasOne("IsekaiDb.Domain.Entities.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterPassivesCharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IsekaiDb.Domain.Entities.Passive", null)
                        .WithMany()
                        .HasForeignKey("CharacterPassivesPassiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CharacterSkill", b =>
                {
                    b.HasOne("IsekaiDb.Domain.Entities.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterSkillCharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IsekaiDb.Domain.Entities.Skill", null)
                        .WithMany()
                        .HasForeignKey("CharacterSkillSkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClassPassive", b =>
                {
                    b.HasOne("IsekaiDb.Domain.Entities.Class", null)
                        .WithMany()
                        .HasForeignKey("ClassPassivesClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IsekaiDb.Domain.Entities.Passive", null)
                        .WithMany()
                        .HasForeignKey("ClassPassivesPassiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IsekaiDb.Domain.Entities.Character", b =>
                {
                    b.HasOne("IsekaiDb.Domain.Entities.Armor", "Armor")
                        .WithMany()
                        .HasForeignKey("ArmorId");

                    b.HasOne("IsekaiDb.Domain.Entities.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("IsekaiDb.Domain.Entities.Weapon", "Weapon")
                        .WithMany()
                        .HasForeignKey("WeaponId");

                    b.Navigation("Armor");

                    b.Navigation("Class");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PassiveSkill", b =>
                {
                    b.HasOne("IsekaiDb.Domain.Entities.Passive", null)
                        .WithMany()
                        .HasForeignKey("SkillPassivesPassiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IsekaiDb.Domain.Entities.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillPassivesSkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PassiveWeapon", b =>
                {
                    b.HasOne("IsekaiDb.Domain.Entities.Passive", null)
                        .WithMany()
                        .HasForeignKey("WeaponPassivesPassiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IsekaiDb.Domain.Entities.Weapon", null)
                        .WithMany()
                        .HasForeignKey("WeaponPassivesWeaponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
