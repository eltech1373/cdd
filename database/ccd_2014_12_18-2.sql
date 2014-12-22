use CCD
go

IF OBJECT_ID ('create_right', 'TR') IS NOT NULL
   DROP TRIGGER create_right;
GO
CREATE TRIGGER create_right
ON [gamer]
FOR INSERT
AS
	if (select count(*) from inserted join [right] on right_user_type = gamer_type) = 0
	begin
		insert into [right] (right_id, right_user_type, right_edit_card, right_edit_log, right_edit_user)
			select NEWID(), gamer_type, 0, 0, 0 from inserted group by gamer_type
	end
GO