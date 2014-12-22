use CCD
go

if not exists (select * from sys.tables where name = 'gamer')
begin
	create table [gamer](
		gamer_id [uniqueidentifier] not null,
		gamer_name [nvarchar](256) not null,
		gamer_pass [nvarchar](256) not null,
		gamer_right_id [uniqueidentifier] not null,
		gamer_title_id [uniqueidentifier] null
		constraint [pk_ccd_gamer] primary key clustered(
			gamer_id asc) with (ignore_dup_key = off) on [primary]
	) on [primary];

	create index [gamer_name_index] on [gamer]([gamer_name]);
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

if not exists (select * from sys.tables where name = 'right')
begin
	create table [right](
		right_id [uniqueidentifier] not null,
		right_user_type [int] not null,
		right_edit_card [bit] not null,
		right_edit_log [bit] not null,
		right_edit_user [bit] not null,
		constraint [pk_ccd_right] primary key clustered(
			right_id asc) with (ignore_dup_key = off) on [primary]
	) on [primary]
	
	alter table [gamer] with check add constraint [fx_ccd_gamer_right]
	foreign key ([gamer_right_id])
	references [right] ([right_id])
end
go

if not exists (select * from sys.tables where name = 'deck')
begin
	create table [deck](
		deck_id [uniqueidentifier] not null,
		deck_gamer_id [uniqueidentifier] not null,
		deck_name [varchar](256) not null,
		constraint [pk_ccd_deck] primary key clustered(
			deck_id asc) with (ignore_dup_key = off) on [primary]
	) on [primary]
	
	alter table [deck] with check add constraint [fx_ccd_deck_gamer]
	foreign key ([deck_gamer_id])
	references [gamer] ([gamer_id])
end
go

if not exists (select * from sys.tables where name = 'title')
begin
	create table [title](
		title_id [uniqueidentifier] not null,
		title_name [varchar](256) not null,
		title_description [varchar](256) not null,
		constraint [pk_ccd_title] primary key clustered(
			title_id asc) with (ignore_dup_key = off) on [primary]
	) on [primary]
	
	alter table [gamer] with check add constraint [fx_ccd_gamer_title]
	foreign key ([gamer_title_id])
	references [title] ([title_id])
end
go

if not exists (select * from sys.tables where name = 'card_in_deck')
begin
	create table [card_in_deck](
		card_in_deck_card_id [uniqueidentifier] not null,
		card_in_deck_deck_id [uniqueidentifier] not null,
		constraint [pk_ccd_card_in_deck] primary key clustered(
			card_in_deck_card_id, card_in_deck_deck_id asc) with (ignore_dup_key = off) on [primary]
	) on [primary]
	
	alter table [card_in_deck] with check add constraint [fx_ccd_card_in_deck_card]
	foreign key (card_in_deck_card_id)
	references [card] ([card_id])
	
	alter table [card_in_deck] with check add constraint [fx_ccd_card_in_deck_deck]
	foreign key (card_in_deck_deck_id)
	references [deck] ([deck_id])
end
go