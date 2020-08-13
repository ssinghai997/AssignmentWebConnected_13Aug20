create proc sp_DeletePlayer
@PlayerName varchar(20)
as
begin
delete from Players where PlayerName=@playername
end