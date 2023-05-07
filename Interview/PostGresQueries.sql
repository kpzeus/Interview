select a.dept_no, round(e/m, 2) as ratio from (
select d.dept_no, count(distinct emp_no) as m from dept_manager d where to_date <= '1995-01-01'
group by d.dept_no) a, (
select dept_no, count(emp_no) as e from dept_emp where to_date <= '1995-01-01'
group by dept_no) b where a.dept_no = b.dept_no
order by a.dept_no

select
left(e.first_name,1) as first_name,
left(e.last_name,1) as last_name,
e.gender,
round(avg(s.salary),2) as ABGsal
from employees e, salaries s
where e.emp_no = s.emp_no and e.emp_no = 10070
group by e.first_name, e.last_name, e

select b.dept_name, a.strength,
case
when strength < 20000 then 'L'
when strength >=20000 and strength <= 50000 then 'M'
when strength > 50000 then 'H'
end as strength_symbol from
(select d.dept_no, count(d.emp_no) as strength
from dept_emp d
group by d.dept_no) a, departments b
where a.dept_no = b.dept_no order by strength

create table players (
	player_id INT not null unique,
	group_id INT not null
);

create table matches (
	match_id INT not null unique,
	first_player INT not null,
	second_player INT not null,
	first_score INT not null,
	second_score INT not null
);

insert into players values(20, 2);
insert into players values(30, 1);
insert into players values(40, 3);
insert into players values(45, 1);
insert into players values(50, 2);
insert into players values(65, 1);
insert into matches values(1, 30, 45, 10, 12);
insert into matches values(2, 20, 50, 5, 5);
insert into matches values(13, 65, 45, 10, 10);
insert into matches values(5, 30, 65, 3, 15);
insert into matches values(42, 45, 65, 8, 4);

select s.group_id, min(b.player_id) as winner_id from
(
	select group_id, Coalesce(max(score), 0) as score from
	(
		select group_id, p.player_id, sum(first_score) + sum(second_score) as score
		from players p 
		left join matches m on p.player_id = m.first_player or p.player_id = m.second_player
		group by group_id, p.player_id
	) a group by group_id
) s, players p1, 
(
	select player_id, Coalesce(max(score), 0) as score from
	(
		select group_id, p.player_id, sum(first_score) + sum(second_score) as score
		from players p 
		left join matches m on p.player_id = m.first_player or p.player_id = m.second_player
		group by group_id, p.player_id
	) a group by player_id
) b where s.group_id = p1.group_id and s.score = b.score and b.player_id = p1.player_id
group by s.group_id 
order by s.group_id