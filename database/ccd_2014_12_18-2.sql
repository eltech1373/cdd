use CCD
go

IF OBJECT_ID ('check_deck_count', 'TR') IS NOT NULL
   DROP TRIGGER check_deck_count;
GO
CREATE TRIGGER check_deck_count
ON [card_in_deck]
FOR INSERT
AS
	if exists (select count(card_in_deck_deck_id) from card_in_deck group by card_in_deck_deck_id having count(card_in_deck_deck_id) > 30)
	begin
		raiserror('Cards in the deck can be no more than 30', 16, 1);
		rollback transaction;
	end
GO