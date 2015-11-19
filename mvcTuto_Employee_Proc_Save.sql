Create procedure spSaveEmployee	  
@id int,
@Name nvarchar(50),  
@Gender nvarchar (10),  
@City nvarchar (50),  
@DateOfBirth DateTime  
as  
Begin  
 update tblEmployee set Name = @Name, Gender = @Gender, City = @City, DateOfBirth = @DateOfBirth
 where Id = @id
End