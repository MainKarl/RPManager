using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IsekaiDb.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armors",
                columns: table => new
                {
                    ArmorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Power = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armors", x => x.ArmorId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HPGrowth = table.Column<int>(type: "int", nullable: false),
                    StrengthGrowth = table.Column<int>(type: "int", nullable: false),
                    MagicGrowth = table.Column<int>(type: "int", nullable: false),
                    DefenseGrowth = table.Column<int>(type: "int", nullable: false),
                    ResistanceGrowth = table.Column<int>(type: "int", nullable: false),
                    SpeedGrowth = table.Column<int>(type: "int", nullable: false),
                    SkillGrowth = table.Column<int>(type: "int", nullable: false),
                    LuckGrowth = table.Column<int>(type: "int", nullable: false),
                    SpiritGrowth = table.Column<int>(type: "int", nullable: false),
                    Serie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "Passives",
                columns: table => new
                {
                    PassiveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passives", x => x.PassiveId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Power = table.Column<int>(type: "int", nullable: false),
                    PowerGain = table.Column<int>(type: "int", nullable: false),
                    Accuracy = table.Column<int>(type: "int", nullable: false),
                    AccuracyGain = table.Column<int>(type: "int", nullable: false),
                    Crit = table.Column<int>(type: "int", nullable: false),
                    CritGain = table.Column<int>(type: "int", nullable: false),
                    ManaUsed = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Purpose = table.Column<int>(type: "int", nullable: false),
                    MagicType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    WeaponId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Accuracy = table.Column<int>(type: "int", nullable: false),
                    Crit = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    DamageType = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.WeaponId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArmorPassive",
                columns: table => new
                {
                    ArmorPassivesArmorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArmorPassivesPassiveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmorPassive", x => new { x.ArmorPassivesArmorId, x.ArmorPassivesPassiveId });
                    table.ForeignKey(
                        name: "FK_ArmorPassive_Armors_ArmorPassivesArmorId",
                        column: x => x.ArmorPassivesArmorId,
                        principalTable: "Armors",
                        principalColumn: "ArmorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmorPassive_Passives_ArmorPassivesPassiveId",
                        column: x => x.ArmorPassivesPassiveId,
                        principalTable: "Passives",
                        principalColumn: "PassiveId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassPassive",
                columns: table => new
                {
                    ClassPassivesClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassPassivesPassiveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassPassive", x => new { x.ClassPassivesClassId, x.ClassPassivesPassiveId });
                    table.ForeignKey(
                        name: "FK_ClassPassive_Classes_ClassPassivesClassId",
                        column: x => x.ClassPassivesClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassPassive_Passives_ClassPassivesPassiveId",
                        column: x => x.ClassPassivesPassiveId,
                        principalTable: "Passives",
                        principalColumn: "PassiveId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassiveSkill",
                columns: table => new
                {
                    SkillPassivesPassiveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillPassivesSkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassiveSkill", x => new { x.SkillPassivesPassiveId, x.SkillPassivesSkillId });
                    table.ForeignKey(
                        name: "FK_PassiveSkill_Passives_SkillPassivesPassiveId",
                        column: x => x.SkillPassivesPassiveId,
                        principalTable: "Passives",
                        principalColumn: "PassiveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassiveSkill_Skills_SkillPassivesSkillId",
                        column: x => x.SkillPassivesSkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Race = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    HP = table.Column<int>(type: "int", nullable: false),
                    CombatHP = table.Column<int>(type: "int", nullable: false),
                    HPGrowth = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    CombatStrength = table.Column<int>(type: "int", nullable: false),
                    StrengthGrowth = table.Column<int>(type: "int", nullable: false),
                    Magic = table.Column<int>(type: "int", nullable: false),
                    CombatMagic = table.Column<int>(type: "int", nullable: false),
                    MagicGrowth = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    CombatDefense = table.Column<int>(type: "int", nullable: false),
                    DefenseGrowth = table.Column<int>(type: "int", nullable: false),
                    Resistance = table.Column<int>(type: "int", nullable: false),
                    CombatResistance = table.Column<int>(type: "int", nullable: false),
                    ResistanceGrowth = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    CombatSpeed = table.Column<int>(type: "int", nullable: false),
                    SpeedGrowth = table.Column<int>(type: "int", nullable: false),
                    Skill = table.Column<int>(type: "int", nullable: false),
                    CombatSkill = table.Column<int>(type: "int", nullable: false),
                    SkillGrowth = table.Column<int>(type: "int", nullable: false),
                    Luck = table.Column<int>(type: "int", nullable: false),
                    CombatLuck = table.Column<int>(type: "int", nullable: false),
                    LuckGrowth = table.Column<int>(type: "int", nullable: false),
                    Spirit = table.Column<int>(type: "int", nullable: false),
                    CombatSpirit = table.Column<int>(type: "int", nullable: false),
                    SpiritGrowth = table.Column<int>(type: "int", nullable: false),
                    ArcaneLevel = table.Column<int>(type: "int", nullable: false),
                    IllusionLevel = table.Column<int>(type: "int", nullable: false),
                    MindLevel = table.Column<int>(type: "int", nullable: false),
                    FireLevel = table.Column<int>(type: "int", nullable: false),
                    LavaLevel = table.Column<int>(type: "int", nullable: false),
                    HeatLevel = table.Column<int>(type: "int", nullable: false),
                    WaterLevel = table.Column<int>(type: "int", nullable: false),
                    LiquidLevel = table.Column<int>(type: "int", nullable: false),
                    IceLevel = table.Column<int>(type: "int", nullable: false),
                    AirLevel = table.Column<int>(type: "int", nullable: false),
                    LightningLevel = table.Column<int>(type: "int", nullable: false),
                    WindLevel = table.Column<int>(type: "int", nullable: false),
                    EarthLevel = table.Column<int>(type: "int", nullable: false),
                    NatureLevel = table.Column<int>(type: "int", nullable: false),
                    PoisonLevel = table.Column<int>(type: "int", nullable: false),
                    LightLevel = table.Column<int>(type: "int", nullable: false),
                    HolyLevel = table.Column<int>(type: "int", nullable: false),
                    SpaceLevel = table.Column<int>(type: "int", nullable: false),
                    DarkLevel = table.Column<int>(type: "int", nullable: false),
                    CurseLevel = table.Column<int>(type: "int", nullable: false),
                    NecromancyLevel = table.Column<int>(type: "int", nullable: false),
                    Fist = table.Column<int>(type: "int", nullable: false),
                    Sword = table.Column<int>(type: "int", nullable: false),
                    Spear = table.Column<int>(type: "int", nullable: false),
                    Axe = table.Column<int>(type: "int", nullable: false),
                    Dagger = table.Column<int>(type: "int", nullable: false),
                    Staff = table.Column<int>(type: "int", nullable: false),
                    Bow = table.Column<int>(type: "int", nullable: false),
                    StatRank = table.Column<int>(type: "int", nullable: false),
                    MagicRank = table.Column<int>(type: "int", nullable: false),
                    SpiritRank = table.Column<int>(type: "int", nullable: false),
                    Types = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WeaponId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ArmorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Characters_Armors_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Armors",
                        principalColumn: "ArmorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "WeaponId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PassiveWeapon",
                columns: table => new
                {
                    WeaponPassivesPassiveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeaponPassivesWeaponId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassiveWeapon", x => new { x.WeaponPassivesPassiveId, x.WeaponPassivesWeaponId });
                    table.ForeignKey(
                        name: "FK_PassiveWeapon_Passives_WeaponPassivesPassiveId",
                        column: x => x.WeaponPassivesPassiveId,
                        principalTable: "Passives",
                        principalColumn: "PassiveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassiveWeapon_Weapons_WeaponPassivesWeaponId",
                        column: x => x.WeaponPassivesWeaponId,
                        principalTable: "Weapons",
                        principalColumn: "WeaponId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterPassive",
                columns: table => new
                {
                    CharacterPassivesCharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CharacterPassivesPassiveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterPassive", x => new { x.CharacterPassivesCharacterId, x.CharacterPassivesPassiveId });
                    table.ForeignKey(
                        name: "FK_CharacterPassive_Characters_CharacterPassivesCharacterId",
                        column: x => x.CharacterPassivesCharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterPassive_Passives_CharacterPassivesPassiveId",
                        column: x => x.CharacterPassivesPassiveId,
                        principalTable: "Passives",
                        principalColumn: "PassiveId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSkill",
                columns: table => new
                {
                    CharacterSkillCharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CharacterSkillSkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSkill", x => new { x.CharacterSkillCharacterId, x.CharacterSkillSkillId });
                    table.ForeignKey(
                        name: "FK_CharacterSkill_Characters_CharacterSkillCharacterId",
                        column: x => x.CharacterSkillCharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSkill_Skills_CharacterSkillSkillId",
                        column: x => x.CharacterSkillSkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "938d72f8-7a76-4ba9-ae7f-43438ae3f4a6", "c98772ab-dff4-4f3d-8d88-715d4297ebfb", "ADMINISTRATOR", null },
                    { "228ffaab-c99b-497e-ac86-80a53eaf2e9a", "7bd82da3-bdd3-44c4-91e6-6c82b0dd072b", "VISITOR", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "c839d1ec-2861-42d0-9a3a-cc798f484f9c", 0, "83458b4a-43a5-45f6-98f4-130984ec6ad7", "ApplicationUser", "lordardyn26@gmail.com", false, false, null, "LORDARDYN26@GMAIL.COM", "ARDYN", "AQAAAAEAACcQAAAAEDEesOT/FSK5UColNuo8ZQWOE6lN3vHyBb6QkNJhG0+1KlM2xymY3upat9B1Kuu35Q==", null, false, "d4ae7bca-b975-4c7d-8f82-cadfecf7792e", false, "Ardyn" },
                    { "88729eff-efdf-4742-bce8-dc5bb62de12d", 0, "4e71eec7-21d1-4a88-9e05-fbbd7b2425da", "ApplicationUser", "remi-bellefleur71@gmail.com", false, false, null, "REMI-BELLEFLEUR71@GMAIL.COM", "GUTTENBERG71", "AQAAAAEAACcQAAAAECCKwkG0ZvfFYN3G6edk1jgOUL6yOgbX1bHX42BZINbf2HTJ2aWGxU69n+O+3E8+mw==", null, false, "1b2b2afc-b906-465c-804a-fb6c89f36f82", false, "Guttenberg71" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "938d72f8-7a76-4ba9-ae7f-43438ae3f4a6", "c839d1ec-2861-42d0-9a3a-cc798f484f9c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "228ffaab-c99b-497e-ac86-80a53eaf2e9a", "88729eff-efdf-4742-bce8-dc5bb62de12d" });

            migrationBuilder.CreateIndex(
                name: "IX_ArmorPassive_ArmorPassivesPassiveId",
                table: "ArmorPassive",
                column: "ArmorPassivesPassiveId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterPassive_CharacterPassivesPassiveId",
                table: "CharacterPassive",
                column: "CharacterPassivesPassiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ArmorId",
                table: "Characters",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ClassId",
                table: "Characters",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_WeaponId",
                table: "Characters",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkill_CharacterSkillSkillId",
                table: "CharacterSkill",
                column: "CharacterSkillSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassPassive_ClassPassivesPassiveId",
                table: "ClassPassive",
                column: "ClassPassivesPassiveId");

            migrationBuilder.CreateIndex(
                name: "IX_PassiveSkill_SkillPassivesSkillId",
                table: "PassiveSkill",
                column: "SkillPassivesSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_PassiveWeapon_WeaponPassivesWeaponId",
                table: "PassiveWeapon",
                column: "WeaponPassivesWeaponId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmorPassive");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CharacterPassive");

            migrationBuilder.DropTable(
                name: "CharacterSkill");

            migrationBuilder.DropTable(
                name: "ClassPassive");

            migrationBuilder.DropTable(
                name: "PassiveSkill");

            migrationBuilder.DropTable(
                name: "PassiveWeapon");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Passives");

            migrationBuilder.DropTable(
                name: "Armors");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Weapons");
        }
    }
}
