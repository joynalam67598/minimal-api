--t sql code
if not exists (select 1 from dbo.[User])
begin
    insert into dbo.[User] (FirstName, LastName)
    values ('Joynal', 'Alam'), ('Sania', 'Amin'), ('John', 'Smith');
end