DROP TABLE  [todo_wpf];

CREATE TABLE [todo_wpf] (
    [id]           INT      IDENTITY (1, 1) NOT NULL,    
    [echeance] VARCHAR (50)	 NOT NULL,
	[date_creation] DATE NOT NULL,
    [titre] VARCHAR (50) NOT NULL,
	[description]	VARCHAR (50) NOT NULL,
	[details]	VARCHAR (50) NOT NULL,
	[important]	VARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

SET IDENTITY_INSERT [todo_wpf] ON
INSERT INTO [todo_wpf] ([id],[echeance],[date_creation],[titre],[description],[details],[important])
VALUES
(1,'Daily','12/25/2019', 'TodoDaily 01', 'Description de la TodoDaily 01','Détails de la TodoDaily 01','true'),
(2,'Swing','12/25/2019', 'TodoSwing 01', 'Description de la TodoSwing 01','Détails de la TodoSwing 01','true'),
(3,'Long','12/25/2019', 'TodoLong 01', 'Description de la TodoLong 01','Détails de la TodoLong 01','true'),
(4,'Daily','12/25/2019', 'TodoDaily 02', 'Description de la TodoDaily 02','Détails de la TodoDaily 02','false'),
(5,'Swing','12/25/2019', 'TodoSwing 02', 'Description de la TodoSwing 02','Détails de la TodoSwing 02','false'),
(6,'Long','12/25/2019', 'TodoLong 02', 'Description de la TodoLong 02','Détails de la TodoLong 02','false'),
(7,'Daily','12/25/2019', 'TodoDaily 03', 'Description de la TodoDaily 03','Détails de la TodoDaily 03','false'),
(8,'Swing','12/25/2019', 'TodoSwing 03', 'Description de la TodoSwing 03','Détails de la TodoSwing 03','false'),
(9,'Long','12/25/2019', 'TodoLong 03', 'Description de la TodoLong 03','Détails de la TodoLong 03','false')
SET IDENTITY_INSERT [todo_wpf] OFF

--CREATE TABLE todo_wpf (
--    id          INT      (IDENTITY (1, 1)) NOT NULL,    
--    echeance VARCHAR (50)	 NOT NULL,
--	date_creation DATE NOT NULL,
--    titre VARCHAR (50) NOT NULL,
--	description	VARCHAR (50) NOT NULL,
--	details	VARCHAR (50) NOT NULL,
--	important	VARCHAR (10) NOT NULL,
--    PRIMARY KEY CLUSTERED (id, ASC)
--);

--INSERT INTO todo_wpf (echeance,date_creation,titre,description,details,important)
--VALUES
--('Daily','2019/12/25', 'TodoDaily 01', 'Description de la TodoDaily 01','Détails de la TodoDaily 01','true'),
--('Swing','2019/12/25', 'TodoSwing 01', 'Description de la TodoSwing 01','Détails de la TodoSwing 01','true'),
--('Long','2019/12/25', 'TodoLong 01', 'Description de la TodoLong 01','Détails de la TodoLong 01','true'),
--('Daily','2019/12/25', 'TodoDaily 02', 'Description de la TodoDaily 02','Détails de la TodoDaily 02','false'),
--('Swing','2019/12/25', 'TodoSwing 02', 'Description de la TodoSwing 02','Détails de la TodoSwing 02','false'),
--('Long','2019/12/25', 'TodoLong 02', 'Description de la TodoLong 02','Détails de la TodoLong 02','false'),
--('Daily','2019/12/25', 'TodoDaily 03', 'Description de la TodoDaily 03','Détails de la TodoDaily 03','false'),
--('Swing','2019/12/25', 'TodoSwing 03', 'Description de la TodoSwing 03','Détails de la TodoSwing 03','false'),
--('Long','2019/12/25', 'TodoLong 03', 'Description de la TodoLong 03','Détails de la TodoLong 03','false');