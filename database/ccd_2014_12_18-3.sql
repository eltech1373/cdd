use CCD
go


insert into [right] values
('CC097C23-50D4-400E-9F91-0019FCEC90BF',
 0,
 1,1,1),
 ('666A4D36-252A-4F85-9AED-0039BF71A4A0',
  1, 0, 0, 0)
 go
 
insert into [title] values
('F7B40267-5AE9-4B90-926C-582BBF8B3D59',
 'novice', 'new gamer')
 go

insert into gamer values
(NEWID(),
 'lada',
 '1',
 'CC097C23-50D4-400E-9F91-0019FCEC90BF',
 'F7B40267-5AE9-4B90-926C-582BBF8B3D59'),
 (NEWID(),
  'katory',
  '1',
  '666A4D36-252A-4F85-9AED-0039BF71A4A0',
  'F7B40267-5AE9-4B90-926C-582BBF8B3D59')
 go

insert into card values
(NEWID(),
 'Пехотинец',
 2, 1, 1, 0, 0, 1),
(NEWID(),
 'Десятник',
 4, 2, 2, 0, 0, 1),
(NEWID(),
 'Маг',
 2, 8, 3, 0, 0, 1),
(NEWID(),
 'Конюшня',
 2, 0, 5, 4, 1, 2),
(NEWID(),
 'Стена',
 5, 0, 5, 5, 1, 2);