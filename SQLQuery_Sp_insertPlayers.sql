create proc sp_InsertPlayers
@PlayerName varchar(20),
@sport varchar(20)
as
begin
insert into Players(PlayerName, Sport) values(@PlayerName,@sport)
end