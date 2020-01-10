USE [TransferDB]
GO

/****** Object: Table [dbo].[TransferLogs] Script Date: 1/7/2020 11:47:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TransferLogs] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [FromAccount]    INT             NOT NULL,
    [ToAccount]      INT             NOT NULL,
    [TransferAmount] DECIMAL (18, 2) NOT NULL
);

insert into [dbo].[TransferLogs] ([FromAccount], [ToAccount],[TransferAmount]) 
values(2,1,'15.20')
select * from [dbo].[TransferLogs]

