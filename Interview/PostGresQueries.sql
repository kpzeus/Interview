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
