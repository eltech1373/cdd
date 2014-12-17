use CCD
go

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

if not exists (select * from sys.tables where name = 'gamer')
begin
	create table [gamer](
		gamer_id [uniqueidentifier] not null,
		gamer_name [nvarchar](256) not null,
		gamer_pass [nvarchar](256) not null,
		gamer_type [int] not null
		constraint [pk_ccd_gamer] primary key clustered(
			gamer_id asc) with (ignore_dup_key = off) on [primary]
			) on [primary]
end
go

if not exists (select * from sys.tables where name = 'log')
begin
	create table [log](
		log_id [uniqueidentifier] not null,
		log_gamer_id [uniqueidentifier] not null,
		log_result [int] not null,
		log_date [date] not null
		constraint [pk_ccd_log] primary key clustered(
			log_id asc) with (ignore_dup_key = off) on [primary]
	) on [primary]

	alter table [log] with check add constraint [fx_ccd_log_gamer]
	foreign key ([log_gamer_id])
	references [gamer] ([gamer_id])
end
go