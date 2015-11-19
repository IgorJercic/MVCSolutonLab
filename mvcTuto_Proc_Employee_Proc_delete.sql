Create procedure spDeleteEmployee 
@id int
as  
Begin  
   delete from tblEmployee
 where Id = @id
End