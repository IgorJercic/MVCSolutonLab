USE [sample2_mvc]
GO
/****** Object:  StoredProcedure [dbo].[spAddEmployee]    Script Date: 27.8.2015. 18:50:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spAddEmployee]  
@Name nvarchar(50) = null,  
@Gender nvarchar (10) = null,  
@City nvarchar (50)  = null,  
@DateOfBirth DateTime = null 
as  
Begin  
 Insert into tblEmployee (Name, Gender, City, DateOfBirth)  
 Values (@Name, @Gender, @City, @DateOfBirth)  
End