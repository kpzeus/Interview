--Find the top 20 CreationDate
Select Top 20 CONVERT(VARCHAR(10), CreationDate,111) As CreationDate, SUM(ViewCount) As
ViewCount from Posts Where Tags Like '%python%' GROUP BY CONVERT(VARCHAR(10), CreationDate,111)
order by ViewCount desc

--LinkTypeId with PostTypeId = 1 (Pass)
Select Count(*) as Count, LinkTypeId from PostLinks p2, Posts p1 where p1.Id = p2.PostId Group By
LinkTypeId

--Tags containing "python"
Select Top 5 CreationDate, Count(*) as Count from Posts where CreationDate >= '2020/01/01' and
PostTypeId = 1 and Tags Like '%python%' and ClosedDate IS NOT NULL Group By CreationDate Order By
CreationDate

