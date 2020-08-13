alter proc sp_UpdatePlayer
@PlayerName varchar(20),
@Sport varchar(20)
as
begin
update Players set PlayerName=@PlayerName where Sport=@Sport
end