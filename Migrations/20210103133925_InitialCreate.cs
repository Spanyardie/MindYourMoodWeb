using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MindYourMoodWeb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastActive = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
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
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Affirmations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    AffirmationText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affirmations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Affirmations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WithWhom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                name: "Attitudes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Feeling = table.Column<int>(type: "int", nullable: false),
                    ToWhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DoAction = table.Column<int>(type: "int", nullable: false),
                    ActionOf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attitudes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attitudes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChuffChartitems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Achievement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChuffChartType = table.Column<int>(type: "int", nullable: false),
                    AchievementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuffChartitems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChuffChartitems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uri = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseEmergencyCall = table.Column<bool>(type: "bit", nullable: false),
                    UseEmergencyEmail = table.Column<bool>(type: "bit", nullable: false),
                    UseEmergencySms = table.Column<bool>(type: "bit", nullable: false),
                    PhotoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fantasies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToWhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DoAction = table.Column<int>(type: "int", nullable: false),
                    ActionOf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fantasies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fantasies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feelings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToWhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DoAction = table.Column<int>(type: "int", nullable: false),
                    ActionOf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feelings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feelings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GenericTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextType = table.Column<int>(type: "int", nullable: false),
                    TextValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenericTexts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Healths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToWhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DoAction = table.Column<int>(type: "int", nullable: false),
                    ActionOf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Healths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Healths_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MoodLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsoCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                { 
                    table.PrimaryKey("PK_MoodLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackCount = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionType = table.Column<int>(type: "int", nullable: false),
                    WeeklyDay = table.Column<int>(type: "int", nullable: false),
                    MonthlyDay = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Problems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProblemText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Problems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToWhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DoAction = table.Column<int>(type: "int", nullable: false),
                    ActionOf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reactions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Feeling = table.Column<int>(type: "int", nullable: false),
                    ToWhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DoAction = table.Column<int>(type: "int", nullable: false),
                    ActionOf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relationships_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SafetyPlanCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalmMyself = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TellMyself = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WillCall = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WillGoTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyPlanCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SafetyPlanCards_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TellMyselfList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TellText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TellTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TellMyselfList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TellMyselfList_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThoughtRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThoughtRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThoughtRecords_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<int>(type: "int", nullable: true),
                    ActivityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Achievement = table.Column<int>(type: "int", nullable: false),
                    Intimacy = table.Column<int>(type: "int", nullable: false),
                    Pleasure = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityTimes_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentQuestions_Appointments_Id",
                        column: x => x.Id,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_PlayLists_Id",
                        column: x => x.Id,
                        principalTable: "PlayLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MedicationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalDailyDosage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medications_Prescriptions_Id",
                        column: x => x.Id,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProblemSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Step = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriorityOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProblemSteps_Problems_Id",
                        column: x => x.Id,
                        principalTable: "Problems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlternativeThoughts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Alternative = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeliefRating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlternativeThoughts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlternativeThoughts_ThoughtRecords_Id",
                        column: x => x.Id,
                        principalTable: "ThoughtRecords",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AutomaticThoughts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    HotThought = table.Column<bool>(type: "bit", nullable: false),
                    Thought = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutomaticThoughts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutomaticThoughts_ThoughtRecords_Id",
                        column: x => x.Id,
                        principalTable: "ThoughtRecords",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Moods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MoodList = table.Column<int>(type: "int", nullable: false),
                    MoodRating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moods_ThoughtRecords_Id",
                        column: x => x.Id,
                        principalTable: "ThoughtRecords",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Situations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoughtRecordId = table.Column<int>(type: "int", nullable: true),
                    Who = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    What = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    When = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Where = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Situations_ThoughtRecords_ThoughtRecordId",
                        column: x => x.ThoughtRecordId,
                        principalTable: "ThoughtRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicationsSpreads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicationId = table.Column<int>(type: "int", nullable: true),
                    Dosage = table.Column<int>(type: "int", nullable: false),
                    Relevance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationsSpreads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationsSpreads_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProblemIdeas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProblemId = table.Column<int>(type: "int", nullable: true),
                    IdeaText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemIdeas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProblemIdeas_Problems_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "Problems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProblemIdeas_ProblemSteps_Id",
                        column: x => x.Id,
                        principalTable: "ProblemSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvidenceAgainstHotThought",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Evidence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoughtRecordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvidenceAgainstHotThought", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvidenceAgainstHotThought_AutomaticThoughts_Id",
                        column: x => x.Id,
                        principalTable: "AutomaticThoughts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EvidenceAgainstHotThought_ThoughtRecords_ThoughtRecordId",
                        column: x => x.ThoughtRecordId,
                        principalTable: "ThoughtRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EvidenceForHotThought",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Evidence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoughtRecordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvidenceForHotThought", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvidenceForHotThought_AutomaticThoughts_Id",
                        column: x => x.Id,
                        principalTable: "AutomaticThoughts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EvidenceForHotThought_ThoughtRecords_ThoughtRecordId",
                        column: x => x.ThoughtRecordId,
                        principalTable: "ThoughtRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReRateMoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MoodListId = table.Column<int>(type: "int", nullable: false),
                    MoodRating = table.Column<int>(type: "int", nullable: false),
                    MoodId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReRateMoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReRateMoods_Moods_MoodId",
                        column: x => x.MoodId,
                        principalTable: "Moods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReRateMoods_ThoughtRecords_Id",
                        column: x => x.Id,
                        principalTable: "ThoughtRecords",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicationReminders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicationSpreadId = table.Column<int>(type: "int", nullable: true),
                    MedicationDay = table.Column<int>(type: "int", nullable: false),
                    MedicationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationReminders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationReminders_MedicationsSpreads_MedicationSpreadId",
                        column: x => x.MedicationSpreadId,
                        principalTable: "MedicationsSpreads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicationTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SpreadId = table.Column<int>(type: "int", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TakenTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationTimes_Medications_Id",
                        column: x => x.Id,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationTimes_MedicationsSpreads_SpreadId",
                        column: x => x.SpreadId,
                        principalTable: "MedicationsSpreads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProblemProCons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    StepId = table.Column<int>(type: "int", nullable: true),
                    ProblemId = table.Column<int>(type: "int", nullable: true),
                    ProConText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemProCons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProblemProCons_ProblemIdeas_Id",
                        column: x => x.Id,
                        principalTable: "ProblemIdeas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProblemProCons_Problems_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "Problems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProblemProCons_ProblemSteps_StepId",
                        column: x => x.StepId,
                        principalTable: "ProblemSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SolutionReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdeaId = table.Column<int>(type: "int", nullable: true),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Achieved = table.Column<bool>(type: "bit", nullable: false),
                    AchievedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolutionReviews_ProblemIdeas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "ProblemIdeas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SolutionsPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SolutionStep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriorityOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionsPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolutionsPlans_SolutionReviews_Id",
                        column: x => x.Id,
                        principalTable: "SolutionReviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserId",
                table: "Activities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTimes_ActivityId",
                table: "ActivityTimes",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Affirmations_UserId",
                table: "Affirmations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                column: "UserId");

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
                name: "IX_Attitudes_UserId",
                table: "Attitudes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuffChartitems_UserId",
                table: "ChuffChartitems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EvidenceAgainstHotThought_ThoughtRecordId",
                table: "EvidenceAgainstHotThought",
                column: "ThoughtRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_EvidenceForHotThought_ThoughtRecordId",
                table: "EvidenceForHotThought",
                column: "ThoughtRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Fantasies_UserId",
                table: "Fantasies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feelings_UserId",
                table: "Feelings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GenericTexts_UserId",
                table: "GenericTexts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Healths_UserId",
                table: "Healths",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationReminders_MedicationSpreadId",
                table: "MedicationReminders",
                column: "MedicationSpreadId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationsSpreads_MedicationId",
                table: "MedicationsSpreads",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationTimes_SpreadId",
                table: "MedicationTimes",
                column: "SpreadId");

            migrationBuilder.CreateIndex(
                name: "IX_MoodLists_UserId",
                table: "MoodLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayLists_UserId",
                table: "PlayLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_UserId",
                table: "Prescriptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemIdeas_ProblemId",
                table: "ProblemIdeas",
                column: "ProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemProCons_ProblemId",
                table: "ProblemProCons",
                column: "ProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemProCons_StepId",
                table: "ProblemProCons",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_Problems_UserId",
                table: "Problems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_UserId",
                table: "Reactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_UserId",
                table: "Relationships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReRateMoods_MoodId",
                table: "ReRateMoods",
                column: "MoodId");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyPlanCards_UserId",
                table: "SafetyPlanCards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Situations_ThoughtRecordId",
                table: "Situations",
                column: "ThoughtRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionReviews_IdeaId",
                table: "SolutionReviews",
                column: "IdeaId");

            migrationBuilder.CreateIndex(
                name: "IX_TellMyselfList_UserId",
                table: "TellMyselfList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ThoughtRecords_UserId",
                table: "ThoughtRecords",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityTimes");

            migrationBuilder.DropTable(
                name: "Affirmations");

            migrationBuilder.DropTable(
                name: "AlternativeThoughts");

            migrationBuilder.DropTable(
                name: "AppointmentQuestions");

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
                name: "Attitudes");

            migrationBuilder.DropTable(
                name: "ChuffChartitems");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "EvidenceAgainstHotThought");

            migrationBuilder.DropTable(
                name: "EvidenceForHotThought");

            migrationBuilder.DropTable(
                name: "Fantasies");

            migrationBuilder.DropTable(
                name: "Feelings");

            migrationBuilder.DropTable(
                name: "GenericTexts");

            migrationBuilder.DropTable(
                name: "Healths");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "MedicationReminders");

            migrationBuilder.DropTable(
                name: "MedicationTimes");

            migrationBuilder.DropTable(
                name: "MoodLists");

            migrationBuilder.DropTable(
                name: "ProblemProCons");

            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.DropTable(
                name: "ReRateMoods");

            migrationBuilder.DropTable(
                name: "SafetyPlanCards");

            migrationBuilder.DropTable(
                name: "Situations");

            migrationBuilder.DropTable(
                name: "SolutionsPlans");

            migrationBuilder.DropTable(
                name: "TellMyselfList");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AutomaticThoughts");

            migrationBuilder.DropTable(
                name: "MedicationsSpreads");

            migrationBuilder.DropTable(
                name: "Moods");

            migrationBuilder.DropTable(
                name: "SolutionReviews");

            migrationBuilder.DropTable(
                name: "PlayLists");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "ThoughtRecords");

            migrationBuilder.DropTable(
                name: "ProblemIdeas");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "ProblemSteps");

            migrationBuilder.DropTable(
                name: "Problems");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
