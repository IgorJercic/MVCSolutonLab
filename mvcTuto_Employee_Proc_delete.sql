Create procedure spDeleteEmployee
@Id int
as
Begin
 Delete from tblEmployee 
 where Id = @Id
End