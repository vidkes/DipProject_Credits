USE [master]
GO
/****** Object:  Database [N_Credits]    Script Date: 17.05.2024 13:01:17 ******/
CREATE DATABASE [N_Credits]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'N_Credits', FILENAME = N'C:\DataBases\N_Credits.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'N_Credits_log', FILENAME = N'C:\DataBases\N_Credits_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [N_Credits] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [N_Credits].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [N_Credits] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [N_Credits] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [N_Credits] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [N_Credits] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [N_Credits] SET ARITHABORT OFF 
GO
ALTER DATABASE [N_Credits] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [N_Credits] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [N_Credits] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [N_Credits] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [N_Credits] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [N_Credits] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [N_Credits] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [N_Credits] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [N_Credits] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [N_Credits] SET  DISABLE_BROKER 
GO
ALTER DATABASE [N_Credits] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [N_Credits] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [N_Credits] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [N_Credits] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [N_Credits] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [N_Credits] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [N_Credits] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [N_Credits] SET RECOVERY FULL 
GO
ALTER DATABASE [N_Credits] SET  MULTI_USER 
GO
ALTER DATABASE [N_Credits] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [N_Credits] SET DB_CHAINING OFF 
GO
ALTER DATABASE [N_Credits] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [N_Credits] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [N_Credits] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [N_Credits] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'N_Credits', N'ON'
GO
ALTER DATABASE [N_Credits] SET QUERY_STORE = ON
GO
ALTER DATABASE [N_Credits] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [N_Credits]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 17.05.2024 13:01:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Role] [bit] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bankrupcy]    Script Date: 17.05.2024 13:01:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bankrupcy](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date1] [date] NULL,
	[Date2] [date] NULL,
	[Status] [nvarchar](50) NULL,
	[Resolution] [nvarchar](50) NULL,
 CONSTRAINT [PK_Bancrupcy] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client_data]    Script Date: 17.05.2024 13:01:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client_data](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Last_name] [nvarchar](50) NOT NULL,
	[First_name] [nvarchar](50) NOT NULL,
	[Father_name] [nvarchar](50) NULL,
	[Sex] [bit] NOT NULL,
	[Passport] [bigint] NOT NULL,
	[INN] [bigint] NULL,
	[Adress] [nvarchar](max) NULL,
	[Real_adress] [nvarchar](max) NOT NULL,
	[Marriage] [bit] NOT NULL,
	[Job] [nvarchar](50) NULL,
	[Job_position] [nvarchar](50) NULL,
	[salary] [float] NULL,
	[Credit_score] [float] NOT NULL,
	[report] [int] NOT NULL,
 CONSTRAINT [PK_Client_data] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FSSP]    Script Date: 17.05.2024 13:01:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FSSP](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Summ] [float] NULL,
	[in_Case] [nvarchar](50) NULL,
 CONSTRAINT [PK_FSSP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rep]    Script Date: 17.05.2024 13:01:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rep](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[INN] [bit] NOT NULL,
	[Tax_debits] [int] NOT NULL,
	[FSSP] [int] NOT NULL,
	[Bankruptcy] [int] NOT NULL,
	[Wanted] [bit] NOT NULL,
 CONSTRAINT [PK_Rep] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tax_debit]    Script Date: 17.05.2024 13:01:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tax_debit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Amount] [float] NULL,
	[Remain] [float] NULL,
 CONSTRAINT [PK_Tax_debit] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([ID], [Login], [Password], [Role]) VALUES (3, N'admin', N'admin', 1)
INSERT [dbo].[Accounts] ([ID], [Login], [Password], [Role]) VALUES (4, N'dfdf', N'fdfd', 0)
INSERT [dbo].[Accounts] ([ID], [Login], [Password], [Role]) VALUES (1005, N'KoSofi', N'44333', 0)
INSERT [dbo].[Accounts] ([ID], [Login], [Password], [Role]) VALUES (1006, N'SapDmit', N'99333', 0)
INSERT [dbo].[Accounts] ([ID], [Login], [Password], [Role]) VALUES (1008, N'Аввв', N'466693', 1)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Bankrupcy] ON 

INSERT [dbo].[Bankrupcy] ([ID], [Date1], [Date2], [Status], [Resolution]) VALUES (4, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bankrupcy] ([ID], [Date1], [Date2], [Status], [Resolution]) VALUES (5, CAST(N'2023-12-01' AS Date), CAST(N'2023-12-10' AS Date), N'Status 1', N'Procedure 1')
INSERT [dbo].[Bankrupcy] ([ID], [Date1], [Date2], [Status], [Resolution]) VALUES (6, CAST(N'2023-12-02' AS Date), CAST(N'2023-12-11' AS Date), N'Status 2', N'Procedure 2')
INSERT [dbo].[Bankrupcy] ([ID], [Date1], [Date2], [Status], [Resolution]) VALUES (7, CAST(N'2023-12-03' AS Date), CAST(N'2023-12-12' AS Date), N'Status 3', N'Procedure 3')
INSERT [dbo].[Bankrupcy] ([ID], [Date1], [Date2], [Status], [Resolution]) VALUES (8, CAST(N'2023-12-04' AS Date), CAST(N'2023-12-13' AS Date), N'Status 4', N'Procedure 4')
INSERT [dbo].[Bankrupcy] ([ID], [Date1], [Date2], [Status], [Resolution]) VALUES (9, CAST(N'2023-12-05' AS Date), CAST(N'2023-12-14' AS Date), N'Status 5', N'Procedure 5')
INSERT [dbo].[Bankrupcy] ([ID], [Date1], [Date2], [Status], [Resolution]) VALUES (10, CAST(N'2023-12-06' AS Date), CAST(N'2023-12-15' AS Date), N'Status 6', N'Procedure 6')
INSERT [dbo].[Bankrupcy] ([ID], [Date1], [Date2], [Status], [Resolution]) VALUES (11, CAST(N'2023-12-07' AS Date), CAST(N'2023-12-16' AS Date), N'Status 7', N'Procedure 7')
INSERT [dbo].[Bankrupcy] ([ID], [Date1], [Date2], [Status], [Resolution]) VALUES (12, CAST(N'2023-12-08' AS Date), CAST(N'2023-12-17' AS Date), N'Status 8', N'Procedure 8')
INSERT [dbo].[Bankrupcy] ([ID], [Date1], [Date2], [Status], [Resolution]) VALUES (13, CAST(N'2023-12-09' AS Date), CAST(N'2023-12-18' AS Date), N'Status 9', N'Procedure 9')
INSERT [dbo].[Bankrupcy] ([ID], [Date1], [Date2], [Status], [Resolution]) VALUES (14, CAST(N'2023-12-10' AS Date), CAST(N'2023-12-19' AS Date), N'Status 10', N'Procedure 10')
INSERT [dbo].[Bankrupcy] ([ID], [Date1], [Date2], [Status], [Resolution]) VALUES (15, NULL, NULL, NULL, NULL)
INSERT [dbo].[Bankrupcy] ([ID], [Date1], [Date2], [Status], [Resolution]) VALUES (16, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Bankrupcy] OFF
GO
SET IDENTITY_INSERT [dbo].[Client_data] ON 

INSERT [dbo].[Client_data] ([ID], [Last_name], [First_name], [Father_name], [Sex], [Passport], [INN], [Adress], [Real_adress], [Marriage], [Job], [Job_position], [salary], [Credit_score], [report]) VALUES (1, N'в', N'в', N'в', 0, 0, 3, N'в', N'в', 0, N'в', N'в', 3, 67.48, 4)
INSERT [dbo].[Client_data] ([ID], [Last_name], [First_name], [Father_name], [Sex], [Passport], [INN], [Adress], [Real_adress], [Marriage], [Job], [Job_position], [salary], [Credit_score], [report]) VALUES (2, N'Иванов', N'Иван', N'Иванович', 1, 1234567890, 123456789012, N'г. Москва, ул. Пушкина, д. 10', N'г. Москва, ул. Лермонтова, д. 5', 1, N'ООО Рога и копыта', N'Директор', 100000, 80.5, 6)
INSERT [dbo].[Client_data] ([ID], [Last_name], [First_name], [Father_name], [Sex], [Passport], [INN], [Adress], [Real_adress], [Marriage], [Job], [Job_position], [salary], [Credit_score], [report]) VALUES (3, N'Петров', N'Петр', N'Петрович', 1, 987654321, 98765432109, N'г. Санкт-Петербург, пр. Невский, д. 20', N'г. Санкт-Петербург, ул. Московская, д. 15', 0, N'ЗАО Компания', N'Менеджер', 70000, 75.2, 7)
INSERT [dbo].[Client_data] ([ID], [Last_name], [First_name], [Father_name], [Sex], [Passport], [INN], [Adress], [Real_adress], [Marriage], [Job], [Job_position], [salary], [Credit_score], [report]) VALUES (4, N'Сидорова', N'Мария', N'Ивановна', 0, 1122334455, 112233445566, N'г. Екатеринбург, ул. Ленина, д. 30', N'г. Екатеринбург, ул. Красноармейская, д. 25', 1, N'ИП Иванов', N'Бухгалтер', 50000, 70.8, 8)
INSERT [dbo].[Client_data] ([ID], [Last_name], [First_name], [Father_name], [Sex], [Passport], [INN], [Adress], [Real_adress], [Marriage], [Job], [Job_position], [salary], [Credit_score], [report]) VALUES (5, N'Кузнецов', N'Алексей', N'Алексеевич', 1, 5544332211, 554433221122, N'г. Новосибирск, ул. Гагарина, д. 40', N'г. Новосибирск, ул. Ленинградская, д. 35', 0, N'ООО СтройГрад', N'Инженер', 80000, 85.6, 9)
INSERT [dbo].[Client_data] ([ID], [Last_name], [First_name], [Father_name], [Sex], [Passport], [INN], [Adress], [Real_adress], [Marriage], [Job], [Job_position], [salary], [Credit_score], [report]) VALUES (6, N'Васильева', N'Елена', N'Сергеевна', 0, 9876543210, 987654321098, N'г. Казань, ул. Кирова, д. 50', N'г. Казань, ул. Советская, д. 45', 1, N'ЗАО ПромТех', N'Менеджер', 60000, 78.9, 10)
INSERT [dbo].[Client_data] ([ID], [Last_name], [First_name], [Father_name], [Sex], [Passport], [INN], [Adress], [Real_adress], [Marriage], [Job], [Job_position], [salary], [Credit_score], [report]) VALUES (7, N'Морозов', N'Андрей', N'Владимирович', 1, 1357924680, 135792468013, N'г. Волгоград, ул. Пушкина, д. 60', N'г. Волгоград, ул. Ленина, д. 55', 0, N'ИП Петров', N'Программист', 90000, 88.2, 11)
INSERT [dbo].[Client_data] ([ID], [Last_name], [First_name], [Father_name], [Sex], [Passport], [INN], [Adress], [Real_adress], [Marriage], [Job], [Job_position], [salary], [Credit_score], [report]) VALUES (8, N'Николаев', N'Никита', N'Игоревич', 1, 2468135790, 246813579024, N'г. Омск, ул. Лермонтова, д. 70', N'г. Омск, ул. Кирова, д. 65', 1, N'ОАО Прогресс', N'Директор', 120000, 90.1, 12)
INSERT [dbo].[Client_data] ([ID], [Last_name], [First_name], [Father_name], [Sex], [Passport], [INN], [Adress], [Real_adress], [Marriage], [Job], [Job_position], [salary], [Credit_score], [report]) VALUES (9, N'Козлова', N'Светлана', N'Олеговна', 0, 9876541230, 987654123098, N'г. Уфа, ул. Советская, д. 80', N'г. Уфа, ул. Московская, д. 75', 1, N'ООО СтройБуд', N'Бухгалтер', 55000, 76.5, 13)
INSERT [dbo].[Client_data] ([ID], [Last_name], [First_name], [Father_name], [Sex], [Passport], [INN], [Adress], [Real_adress], [Marriage], [Job], [Job_position], [salary], [Credit_score], [report]) VALUES (10, N'Белов', N'Артем', N'Дмитриевич', 1, 3692581470, 369258147036, N'г. Тюмень, ул. Гагарина, д. 90', N'г. Тюмень, ул. Ленина, д. 85', 0, N'ИП Сидоров', N'Менеджер', 70000, 82.4, 14)
INSERT [dbo].[Client_data] ([ID], [Last_name], [First_name], [Father_name], [Sex], [Passport], [INN], [Adress], [Real_adress], [Marriage], [Job], [Job_position], [salary], [Credit_score], [report]) VALUES (11, N'Смирнова', N'Татьяна', N'Александровна', 0, 9876543211, 987654321109, N'г. Самара, ул. Ленина, д. 100', N'г. Самара, ул. Киров', 0, N'ООО СтройБуд', N'Менеджер', 70000, 78.9, 15)
INSERT [dbo].[Client_data] ([ID], [Last_name], [First_name], [Father_name], [Sex], [Passport], [INN], [Adress], [Real_adress], [Marriage], [Job], [Job_position], [salary], [Credit_score], [report]) VALUES (12, N'tttttttttttttttt', N'ttttt', N'ttttttttttttttttt', 1, 2645, 54887, N'ttttttttttttttt', N'ttttttttttttt', 1, N'tttttttttt', N'ttttttttttttttttttt', 5154.5, 67.48, 22)
INSERT [dbo].[Client_data] ([ID], [Last_name], [First_name], [Father_name], [Sex], [Passport], [INN], [Adress], [Real_adress], [Marriage], [Job], [Job_position], [salary], [Credit_score], [report]) VALUES (13, N'вв', N'вв', N'вв', 0, 544545, 15488, N'твыор', N'вываолоа', 0, N'вв', N'ввв', 115.5, 67.48, 23)
SET IDENTITY_INSERT [dbo].[Client_data] OFF
GO
SET IDENTITY_INSERT [dbo].[FSSP] ON 

INSERT [dbo].[FSSP] ([ID], [Date], [Summ], [in_Case]) VALUES (4, NULL, NULL, NULL)
INSERT [dbo].[FSSP] ([ID], [Date], [Summ], [in_Case]) VALUES (5, CAST(N'2023-12-01' AS Date), 62189.260143836276, N'Subject 1')
INSERT [dbo].[FSSP] ([ID], [Date], [Summ], [in_Case]) VALUES (6, CAST(N'2023-12-02' AS Date), 21271.509511898883, N'Subject 2')
INSERT [dbo].[FSSP] ([ID], [Date], [Summ], [in_Case]) VALUES (7, CAST(N'2023-12-03' AS Date), 25770.402843324362, N'Subject 3')
INSERT [dbo].[FSSP] ([ID], [Date], [Summ], [in_Case]) VALUES (8, CAST(N'2023-12-04' AS Date), 71702.699827474557, N'Subject 4')
INSERT [dbo].[FSSP] ([ID], [Date], [Summ], [in_Case]) VALUES (9, CAST(N'2023-12-05' AS Date), 24063.502302627192, N'Subject 5')
INSERT [dbo].[FSSP] ([ID], [Date], [Summ], [in_Case]) VALUES (10, CAST(N'2023-12-06' AS Date), 43674.41686633155, N'Subject 6')
INSERT [dbo].[FSSP] ([ID], [Date], [Summ], [in_Case]) VALUES (11, CAST(N'2023-12-07' AS Date), 15956.36300461801, N'Subject 7')
INSERT [dbo].[FSSP] ([ID], [Date], [Summ], [in_Case]) VALUES (12, CAST(N'2023-12-08' AS Date), 82314.716520767775, N'Subject 8')
INSERT [dbo].[FSSP] ([ID], [Date], [Summ], [in_Case]) VALUES (13, CAST(N'2023-12-09' AS Date), 15449.044343211959, N'Subject 9')
INSERT [dbo].[FSSP] ([ID], [Date], [Summ], [in_Case]) VALUES (14, CAST(N'2023-12-10' AS Date), 39084.7759729895, N'Subject 10')
INSERT [dbo].[FSSP] ([ID], [Date], [Summ], [in_Case]) VALUES (15, NULL, NULL, NULL)
INSERT [dbo].[FSSP] ([ID], [Date], [Summ], [in_Case]) VALUES (16, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[FSSP] OFF
GO
SET IDENTITY_INSERT [dbo].[Rep] ON 

INSERT [dbo].[Rep] ([ID], [INN], [Tax_debits], [FSSP], [Bankruptcy], [Wanted]) VALUES (4, 1, 4, 4, 4, 0)
INSERT [dbo].[Rep] ([ID], [INN], [Tax_debits], [FSSP], [Bankruptcy], [Wanted]) VALUES (6, 1, 5, 5, 5, 1)
INSERT [dbo].[Rep] ([ID], [INN], [Tax_debits], [FSSP], [Bankruptcy], [Wanted]) VALUES (7, 0, 6, 6, 6, 0)
INSERT [dbo].[Rep] ([ID], [INN], [Tax_debits], [FSSP], [Bankruptcy], [Wanted]) VALUES (8, 1, 7, 7, 7, 0)
INSERT [dbo].[Rep] ([ID], [INN], [Tax_debits], [FSSP], [Bankruptcy], [Wanted]) VALUES (9, 1, 8, 8, 8, 0)
INSERT [dbo].[Rep] ([ID], [INN], [Tax_debits], [FSSP], [Bankruptcy], [Wanted]) VALUES (10, 0, 9, 9, 9, 1)
INSERT [dbo].[Rep] ([ID], [INN], [Tax_debits], [FSSP], [Bankruptcy], [Wanted]) VALUES (11, 0, 10, 10, 10, 0)
INSERT [dbo].[Rep] ([ID], [INN], [Tax_debits], [FSSP], [Bankruptcy], [Wanted]) VALUES (12, 0, 11, 11, 11, 0)
INSERT [dbo].[Rep] ([ID], [INN], [Tax_debits], [FSSP], [Bankruptcy], [Wanted]) VALUES (13, 0, 12, 12, 12, 1)
INSERT [dbo].[Rep] ([ID], [INN], [Tax_debits], [FSSP], [Bankruptcy], [Wanted]) VALUES (14, 1, 13, 13, 13, 0)
INSERT [dbo].[Rep] ([ID], [INN], [Tax_debits], [FSSP], [Bankruptcy], [Wanted]) VALUES (15, 1, 14, 14, 14, 0)
INSERT [dbo].[Rep] ([ID], [INN], [Tax_debits], [FSSP], [Bankruptcy], [Wanted]) VALUES (22, 1, 15, 15, 15, 0)
INSERT [dbo].[Rep] ([ID], [INN], [Tax_debits], [FSSP], [Bankruptcy], [Wanted]) VALUES (23, 1, 16, 16, 16, 0)
SET IDENTITY_INSERT [dbo].[Rep] OFF
GO
SET IDENTITY_INSERT [dbo].[Tax_debit] ON 

INSERT [dbo].[Tax_debit] ([ID], [Date], [Amount], [Remain]) VALUES (4, NULL, NULL, NULL)
INSERT [dbo].[Tax_debit] ([ID], [Date], [Amount], [Remain]) VALUES (5, CAST(N'2023-12-01' AS Date), 76528.91, 2556.41)
INSERT [dbo].[Tax_debit] ([ID], [Date], [Amount], [Remain]) VALUES (6, CAST(N'2023-12-02' AS Date), 19982.97, 1259.14)
INSERT [dbo].[Tax_debit] ([ID], [Date], [Amount], [Remain]) VALUES (7, CAST(N'2023-12-03' AS Date), 91818, 3316.85)
INSERT [dbo].[Tax_debit] ([ID], [Date], [Amount], [Remain]) VALUES (8, CAST(N'2023-12-04' AS Date), 74790.87, 8552.64)
INSERT [dbo].[Tax_debit] ([ID], [Date], [Amount], [Remain]) VALUES (9, CAST(N'2023-12-05' AS Date), 49653.11, 9190.91)
INSERT [dbo].[Tax_debit] ([ID], [Date], [Amount], [Remain]) VALUES (10, CAST(N'2023-12-06' AS Date), 32137.62, 7780.26)
INSERT [dbo].[Tax_debit] ([ID], [Date], [Amount], [Remain]) VALUES (11, CAST(N'2023-12-07' AS Date), 97999.08, 5499.59)
INSERT [dbo].[Tax_debit] ([ID], [Date], [Amount], [Remain]) VALUES (12, CAST(N'2023-12-08' AS Date), 80685.91, 8568.17)
INSERT [dbo].[Tax_debit] ([ID], [Date], [Amount], [Remain]) VALUES (13, CAST(N'2023-12-09' AS Date), 21334.02, 2210.05)
INSERT [dbo].[Tax_debit] ([ID], [Date], [Amount], [Remain]) VALUES (14, CAST(N'2023-12-10' AS Date), 98926.25, 6106.63)
INSERT [dbo].[Tax_debit] ([ID], [Date], [Amount], [Remain]) VALUES (15, NULL, NULL, NULL)
INSERT [dbo].[Tax_debit] ([ID], [Date], [Amount], [Remain]) VALUES (16, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Tax_debit] OFF
GO
ALTER TABLE [dbo].[Client_data]  WITH CHECK ADD  CONSTRAINT [FK_Client_data_Rep] FOREIGN KEY([report])
REFERENCES [dbo].[Rep] ([ID])
GO
ALTER TABLE [dbo].[Client_data] CHECK CONSTRAINT [FK_Client_data_Rep]
GO
ALTER TABLE [dbo].[Rep]  WITH CHECK ADD  CONSTRAINT [FK_Rep_Bankrupcy] FOREIGN KEY([Bankruptcy])
REFERENCES [dbo].[Bankrupcy] ([ID])
GO
ALTER TABLE [dbo].[Rep] CHECK CONSTRAINT [FK_Rep_Bankrupcy]
GO
ALTER TABLE [dbo].[Rep]  WITH CHECK ADD  CONSTRAINT [FK_Rep_FSSP] FOREIGN KEY([FSSP])
REFERENCES [dbo].[FSSP] ([ID])
GO
ALTER TABLE [dbo].[Rep] CHECK CONSTRAINT [FK_Rep_FSSP]
GO
ALTER TABLE [dbo].[Rep]  WITH CHECK ADD  CONSTRAINT [FK_Rep_Tax_debit] FOREIGN KEY([Tax_debits])
REFERENCES [dbo].[Tax_debit] ([ID])
GO
ALTER TABLE [dbo].[Rep] CHECK CONSTRAINT [FK_Rep_Tax_debit]
GO
USE [master]
GO
ALTER DATABASE [N_Credits] SET  READ_WRITE 
GO
