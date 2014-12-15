if not exists (select * from sys.tables where name = 'card')
begin
	create table [card](
		card_id [uniqueidentifier] not null,
		card_name [nvarchar](256) not null,
		card_hp [int] not null,
		card_atk [int] not null,
		card_rang [int] not null,
		card_special_type [int] not null,
		card_special_value [int] not null,
		card_type [int] not null,
		constraint [pk_ccd_card] primary key clustered(
			card_id asc) with (ignore_dup_key = off) on [primary]
			) on [primary]
end
go