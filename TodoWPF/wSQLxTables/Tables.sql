DROP TABLE  [todo_wpf];

CREATE TABLE [todo_wpf] (
    [id]           INT      IDENTITY (1, 1) NOT NULL,    
    [echeance] VARCHAR (50)	 NOT NULL,
    [titre] VARCHAR (50) NOT NULL,
	[description]	VARCHAR (50) NOT NULL,
	[details]	VARCHAR (50) NOT NULL,
	[important]	VARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

SET IDENTITY_INSERT [todo_wpf] ON
INSERT INTO [todo_wpf] ([id],[echeance],[titre],[description],[details],[important])
VALUES
(1,'Daily', 'TodoDaily 01', 'Description de la TodoDaily 01','Détails de la TodoDaily 01','true'),
(2,'Swing', 'TodoSwing 01', 'Description de la TodoSwing 01','Détails de la TodoSwing 01','true'),
(3,'Long', 'TodoLong 01', 'Description de la TodoLong 01','Détails de la TodoLong 01','true'),
(4,'Daily', 'TodoDaily 02', 'Description de la TodoDaily 02','Détails de la TodoDaily 02','false'),
(5,'Swing', 'TodoSwing 02', 'Description de la TodoSwing 02','Détails de la TodoSwing 02','false'),
(6,'Long', 'TodoLong 02', 'Description de la TodoLong 02','Détails de la TodoLong 02','false'),
(7,'Daily', 'TodoDaily 03', 'Description de la TodoDaily 03','Détails de la TodoDaily 03','false'),
(8,'Swing', 'TodoSwing 03', 'Description de la TodoSwing 03','Détails de la TodoSwing 03','false'),
(9,'Long', 'TodoLong 03', 'Description de la TodoLong 03','Détails de la TodoLong 03','false')
SET IDENTITY_INSERT [patient_wpf] OFF