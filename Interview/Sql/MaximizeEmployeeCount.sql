CREATE TABLE candidates (
  id SERIAL PRIMARY KEY,
  position VARCHAR NOT NULL,
  salary INT NOT NULL
);

--budget 50000

insert into candidates values (20, 'junior', 10000);
insert into candidates values (30, 'senior', 15000);
insert into candidates values (40, 'senior', 30000);
insert into candidates values (50, 'junior', 1000);
insert into candidates values (60, 'junior', 2000);

insert into candidates values (120, 'junior', 10000);
insert into candidates values (130, 'junior', 15000);
insert into candidates values (140, 'junior', 30000);
insert into candidates values (450, 'junior', 60000);

delete from candidates where  position = 'junior' and salary < 10000

delete from candidates where  position = 'senior'

select * from candidates

-- test input
insert into candidates values (20, 'junior', 10000);
insert into candidates values (30, 'senior', 15000);
insert into candidates values (40, 'senior', 30000);

-- should return 0,2 as there are max 0 juniors and 2 seniors can be selected, 
-- maxing senior count first then junior count

select 
(
	select count(*) from
	(
		select *, sum(salary) 
		over (order by salary asc) as total from 
		candidates, 
		(
			select count(*) as seniors, min(50000 - total) as remaining  from    
			(
				select id, salary, sum(salary) 
				over (order by salary asc) as total
				from candidates where position = 'senior' 
				and salary <= 50000
				order by total desc
			) a where a.total <= 50000
		) b where position = 'junior'
	) c 
	where (total <= remaining or remaining is null) and total <= 50000
)
as juniors, 
(
	select count(*) from    
	(
		select id, salary, sum(salary) 
		over (order by salary asc) as total
		from candidates where position = 'senior' 
		and salary <= 50000
		order by total desc
	) s where s.total <= 50000
)  
as seniors;