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

if not exists (select * from sys.tables where name = 'user')
begin
	create table [user](
		user_id [uniqueidentifier] not null,
		user_name [nvarchar](256) not null,
		user_pass [nvarchar](256) not null,
		user_type [int] not null
		constraint [pk_ccd_user] primary key clustered(
			user_id asc) with (ignore_dup_key = off) on [primary]
			) on [primary]
end
go

if not exists (select * from sys.tables where name = 'log')
begin
	create table [log](
		log_id [uniqueidentifier] not null,
		log_user_id [uniqueidentifier] not null,
		log_result [int] not null,
		log_date [date] not null
		constraint [pk_ccd_log] primary key clustered(
			log_id asc) with (ignore_dup_key = off) on [primary]
	) on [primary]

	alter table [log] with check add constraint [fx_ccd_log_user]
	foreign key ([log_user_id])
	references [user] ([user_id])
end
go