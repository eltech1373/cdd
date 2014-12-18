use CCD
go

insert into gamer values
(NEWID(),
 'lada',
 '1',
 0),
 (NEWID(),
  'katory',
  '1',
  1)
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