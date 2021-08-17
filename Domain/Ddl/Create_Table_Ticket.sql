USE [WebApiDB]
GO

/****** Object:  Table [dbo].[Ticket]    Script Date: 17-8-2021 08:44:08 ******/
DROP TABLE [dbo].[Ticket]
GO

/****** Object:  Table [dbo].[Ticket]    Script Date: 17-8-2021 08:44:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ticket](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ticketnummer] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

