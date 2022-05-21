using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StarPeaceAdminHubDB.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agreement",
                columns: table => new
                {
                    AgreementNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FullfillmentPeriod = table.Column<byte>(type: "tinyint", nullable: false),
                    CreditsRequired = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreement", x => x.AgreementNumber);
                });

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
                name: "BookEvents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldVersion = table.Column<long>(type: "bigint", nullable: true),
                    NewVersion = table.Column<long>(type: "bigint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RetailPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CoverFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityVersion = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookTitleEvents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    BookTitleId = table.Column<int>(type: "int", nullable: false),
                    OldVersion = table.Column<long>(type: "bigint", nullable: true),
                    NewVersion = table.Column<long>(type: "bigint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTitleEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryEvents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldVersion = table.Column<long>(type: "bigint", nullable: true),
                    NewVersion = table.Column<long>(type: "bigint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UPC = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    QuantityInStock = table.Column<short>(type: "smallint", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SuggestedRetailPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DefaultUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentSpecialPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthlyUnitsSold = table.Column<short>(type: "smallint", nullable: false),
                    YearlyUnitsSold = table.Column<int>(type: "int", nullable: false),
                    TotalUnitsSold = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductNumber);
                });

            migrationBuilder.CreateTable(
                name: "Promotion",
                columns: table => new
                {
                    PromotionNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromotionReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PromotionStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PromotionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion", x => x.PromotionNumber);
                });

            migrationBuilder.CreateTable(
                name: "ActiveMember",
                columns: table => new
                {
                    MemberNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberDateOfLastOrder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberDaytimePhoneNumber = table.Column<int>(type: "int", nullable: false),
                    MemberBalanceDue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MemeberBonusBalanceAvailable = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AudioCategoryPreferance = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VideoCategoryPreference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BookCategoryPreference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NumberOfCreditsEarned = table.Column<int>(type: "int", nullable: false),
                    DateEnrolled = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrivacyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MediaPreference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditCardExp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreditCardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CreditCardType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MemberLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MemberFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MemberStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AgreementNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveMember", x => x.MemberNumber);
                    table.ForeignKey(
                        name: "FK_ActiveMember_Agreement_AgreementNumber",
                        column: x => x.AgreementNumber,
                        principalTable: "Agreement",
                        principalColumn: "AgreementNumber",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Categorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    EntityVersion = table.Column<long>(type: "bigint", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorys_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Merchandise",
                columns: table => new
                {
                    ProductNumber = table.Column<int>(type: "int", nullable: false),
                    MerchandiseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MerchandiseDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchandiseType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchandise", x => x.ProductNumber);
                    table.ForeignKey(
                        name: "FK_Merchandise_Product_ProductNumber",
                        column: x => x.ProductNumber,
                        principalTable: "Product",
                        principalColumn: "ProductNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderedProduct",
                columns: table => new
                {
                    OrderNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductNumber = table.Column<int>(type: "int", nullable: false),
                    QuantityOrdered = table.Column<short>(type: "smallint", nullable: false),
                    QuantityShipped = table.Column<short>(type: "smallint", nullable: false),
                    QuantityBackOrdered = table.Column<short>(type: "smallint", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreditsEarned = table.Column<short>(type: "smallint", nullable: false),
                    MemberNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedProduct", x => x.OrderNumber);
                    table.ForeignKey(
                        name: "FK_OrderedProduct_Product_ProductNumber",
                        column: x => x.ProductNumber,
                        principalTable: "Product",
                        principalColumn: "ProductNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    ProductNumber = table.Column<int>(type: "int", nullable: false),
                    TitleBook = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TitleCover = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CatelogDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CopyRightDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TitleCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreditValue = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.ProductNumber);
                    table.ForeignKey(
                        name: "FK_Title_Product_ProductNumber",
                        column: x => x.ProductNumber,
                        principalTable: "Product",
                        principalColumn: "ProductNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberOrder",
                columns: table => new
                {
                    OrderNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberNumber = table.Column<int>(type: "int", nullable: false),
                    OrderFillDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderShipName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    OrderShipAddress = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    OrderShipCity = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OrderShipPostalCode = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    ShippingInstructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderSubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderSalesTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderShopMethod = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    OrderShippingAndHandlingCosts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    OrderPrepaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderPaymentMethod = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PromotionNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberOrder", x => x.OrderNumber);
                    table.ForeignKey(
                        name: "FK_MemberOrder_Promotion_PromotionNumber",
                        column: x => x.PromotionNumber,
                        principalTable: "Promotion",
                        principalColumn: "PromotionNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AudioTitle",
                columns: table => new
                {
                    ProductNumber = table.Column<int>(type: "int", nullable: false),
                    Artist = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Units = table.Column<byte>(type: "tinyint", nullable: false),
                    MediaType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdvisoryCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductTitleNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioTitle", x => x.ProductNumber);
                    table.ForeignKey(
                        name: "FK_AudioTitle_Title_ProductNumber",
                        column: x => x.ProductNumber,
                        principalTable: "Title",
                        principalColumn: "ProductNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntityVersion = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTitles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookTitles_Title_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Title",
                        principalColumn: "ProductNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TitlePromotion",
                columns: table => new
                {
                    PromotionNumber = table.Column<int>(type: "int", nullable: false),
                    ProductNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitlePromotion", x => x.PromotionNumber);
                    table.ForeignKey(
                        name: "FK_TitlePromotion_Promotion_PromotionNumber",
                        column: x => x.PromotionNumber,
                        principalTable: "Promotion",
                        principalColumn: "PromotionNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TitlePromotion_Title_ProductNumber",
                        column: x => x.ProductNumber,
                        principalTable: "Title",
                        principalColumn: "ProductNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoTitle",
                columns: table => new
                {
                    ProductNumber = table.Column<int>(type: "int", nullable: false),
                    VideoProducer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VideoDirector = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VideoCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VideoSubCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClosedCaptions = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Language = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RunningTime = table.Column<short>(type: "smallint", nullable: false),
                    VideoMediaType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VideoEncoding = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ScreenAspect = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductTitleNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoTitle", x => x.ProductNumber);
                    table.ForeignKey(
                        name: "FK_VideoTitle_Title_ProductNumber",
                        column: x => x.ProductNumber,
                        principalTable: "Title",
                        principalColumn: "ProductNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionReferenceNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberNumber = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TransactionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionReferenceNumber);
                    table.ForeignKey(
                        name: "FK_Transaction_ActiveMember_MemberNumber",
                        column: x => x.MemberNumber,
                        principalTable: "ActiveMember",
                        principalColumn: "MemberNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_MemberOrder_OrderNumber",
                        column: x => x.OrderNumber,
                        principalTable: "MemberOrder",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveMember_AgreementNumber",
                table: "ActiveMember",
                column: "AgreementNumber");

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
                name: "IX_Books_ISBN",
                table: "Books",
                column: "ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Title",
                table: "Books",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_BookTitles_TitleId",
                table: "BookTitles",
                column: "TitleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorys_BookId",
                table: "Categorys",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorys_CategoryName",
                table: "Categorys",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_MemberOrder_PromotionNumber",
                table: "MemberOrder",
                column: "PromotionNumber");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProduct_ProductNumber",
                table: "OrderedProduct",
                column: "ProductNumber");

            migrationBuilder.CreateIndex(
                name: "IX_TitlePromotion_ProductNumber",
                table: "TitlePromotion",
                column: "ProductNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_MemberNumber",
                table: "Transaction",
                column: "MemberNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_OrderNumber",
                table: "Transaction",
                column: "OrderNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "AudioTitle");

            migrationBuilder.DropTable(
                name: "BookEvents");

            migrationBuilder.DropTable(
                name: "BookTitleEvents");

            migrationBuilder.DropTable(
                name: "BookTitles");

            migrationBuilder.DropTable(
                name: "CategoryEvents");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "Merchandise");

            migrationBuilder.DropTable(
                name: "OrderedProduct");

            migrationBuilder.DropTable(
                name: "TitlePromotion");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "VideoTitle");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "ActiveMember");

            migrationBuilder.DropTable(
                name: "MemberOrder");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropTable(
                name: "Agreement");

            migrationBuilder.DropTable(
                name: "Promotion");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
