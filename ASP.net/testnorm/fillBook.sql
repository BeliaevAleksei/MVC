go
declare @i int
set @i = 1
while @i < 100
begin
	insert t100 values(@i)
	set @i = @i + 1
end

insert Book (Author, Name, Genre)
select 'Test Author',
'Name' + cast(num as varchar(10)), 
'Genre' + cast(num as varchar(10))
from (
	select t1.num * 100 * t2.num as id, t1.num from 
		t100 t1 cross join t100 t2
) t
go