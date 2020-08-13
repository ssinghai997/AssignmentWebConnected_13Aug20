create database AssignmentData
use AssignmentData

create table Players(Name varchar(20), Sport varchar(20))

insert into Players values('Virat Kohli','Cricket')
insert into Players values('Sania Mirza','Tennis')
insert into Players values('Sania Nehwal','Badminton')
insert into Players values('Sunil Chhetri','Football')

Alter table Players
drop column Name

alter table Players
add PlayerName varchar(20)
select * from Players

insert into Players values('Virat Kohli','Cricket')
insert into Players values('Sania Mirza','Tennis')
insert into Players values('Sania Nehwal','Badminton')
insert into Players values('Sunil Chhetri','Football')

select * from Players

drop table Players
create table Players(PlayerName varchar(20), Sport varchar(20))
insert into Players values('Virat Kohli','Cricket')
insert into Players values('Sania Mirza','Tennis')
insert into Players values('Sania Nehwal','Badminton')
insert into Players values('Sunil Chhetri','Football')

select * from Players

