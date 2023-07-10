SELECT group_id, player_id
from (
SELECT group_id, player_id, COALESCE(sum(score), 1) as total
from (
SELECT group_id, p.player_id, sum(first_score) AS score
    FROM players p
    LEFT JOIN matches m ON p.player_id = m.first_player
    GROUP BY group_id, p.player_id
UNION
SELECT group_id, p.player_id, sum(second_score) AS score
    FROM players p
    LEFT JOIN matches m ON p.player_id = m.second_player
    GROUP BY group_id, p.player_id
) s group by group_id, player_id order by total desc, player_id
) s1
group by group_id
HAVING Max(total)
ORDER BY group_id