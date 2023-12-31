USE [proyecto_tesis_david]
GO
/****** Object:  Table [dbo].[catalogo_seguimiento]    Script Date: 14/08/2023 19:50:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[catalogo_seguimiento](
	[cas_id] [bigint] IDENTITY(1,1) NOT NULL,
	[esp_id] [bigint] NULL,
	[cas_nombre] [varchar](100) NULL,
	[cas_estado] [smallint] NULL,
 CONSTRAINT [PK_catalogo_seguimiento] PRIMARY KEY CLUSTERED 
(
	[cas_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[citas]    Script Date: 14/08/2023 19:50:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[citas](
	[cit_id] [bigint] IDENTITY(1,1) NOT NULL,
	[mes_id] [bigint] NULL,
	[cit_fecha_atencion] [date] NULL,
	[cit_inicio_atencion] [time](7) NULL,
	[cit_fin_atencion] [time](7) NULL,
	[cit_estado_paciente] [varchar](25) NULL,
	[cit_observaciones] [varchar](100) NULL,
	[cit_estado] [smallint] NULL,
	[usu_id] [bigint] NULL,
 CONSTRAINT [PK_citas] PRIMARY KEY CLUSTERED 
(
	[cit_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[empresa]    Script Date: 14/08/2023 19:50:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empresa](
	[emp_id] [bigint] IDENTITY(1,1) NOT NULL,
	[emp_nombre] [varchar](150) NULL,
	[emp_identificacion] [varchar](15) NULL,
	[emp_correo] [varchar](150) NULL,
	[emp_telefono] [varchar](15) NULL,
	[emp_direccion] [nchar](10) NULL,
 CONSTRAINT [PK_empresa] PRIMARY KEY CLUSTERED 
(
	[emp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[especialidades]    Script Date: 14/08/2023 19:50:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[especialidades](
	[esp_id] [bigint] IDENTITY(1,1) NOT NULL,
	[esp_nombre] [varchar](50) NULL,
	[esp_descripcion] [varchar](250) NULL,
	[esp_fecha_registro] [datetime] NULL,
	[esp_estado] [smallint] NULL,
	[emp_id] [bigint] NULL,
 CONSTRAINT [PK_especialidades] PRIMARY KEY CLUSTERED 
(
	[esp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[horarios]    Script Date: 14/08/2023 19:50:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[horarios](
	[hor_id] [bigint] IDENTITY(1,1) NOT NULL,
	[med_id] [bigint] NULL,
	[hor_fecha_atencion] [date] NULL,
	[hor_inicio_atencion] [time](7) NULL,
	[hor_fin_atencion] [time](7) NULL,
	[hor_estado] [smallint] NULL,
 CONSTRAINT [PK_horarios] PRIMARY KEY CLUSTERED 
(
	[hor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[indice_seguimiento]    Script Date: 14/08/2023 19:50:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[indice_seguimiento](
	[ise_id] [bigint] IDENTITY(1,1) NOT NULL,
	[esp_id] [bigint] NULL,
	[ise_numero] [int] NULL,
	[usu_id] [bigint] NULL,
 CONSTRAINT [PK_indice_seguimiento] PRIMARY KEY CLUSTERED 
(
	[ise_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[medicos]    Script Date: 14/08/2023 19:50:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[medicos](
	[med_id] [bigint] IDENTITY(1,1) NOT NULL,
	[med_nombres] [varchar](25) NULL,
	[med_apellidos] [varchar](25) NULL,
	[med_cedula] [char](11) NULL,
	[med_direccion] [varchar](100) NULL,
	[med_correo] [nvarchar](50) NULL,
	[med_telefono] [varchar](25) NULL,
	[med_sexo] [char](1) NULL,
	[med_num_csp] [varchar](10) NULL,
	[med_estado] [smallint] NULL,
	[emp_id] [bigint] NULL,
 CONSTRAINT [PK_medicos] PRIMARY KEY CLUSTERED 
(
	[med_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[medicos_especialidades]    Script Date: 14/08/2023 19:50:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[medicos_especialidades](
	[mes_id] [bigint] IDENTITY(1,1) NOT NULL,
	[esp_id] [bigint] NULL,
	[med_id] [bigint] NULL,
	[mes_estado] [smallint] NULL,
 CONSTRAINT [PK_medicos_especialidades] PRIMARY KEY CLUSTERED 
(
	[mes_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[menu]    Script Date: 14/08/2023 19:50:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[menu](
	[men_id] [bigint] IDENTITY(1,1) NOT NULL,
	[men_nombre] [varchar](150) NULL,
	[men_men_id] [bigint] NULL,
	[men_tipo] [varchar](50) NULL,
	[men_icono] [varchar](50) NULL,
	[men_url] [varchar](250) NULL,
	[men_orden] [smallint] NULL,
	[men_codigo_unico] [varchar](10) NULL,
	[men_estado] [smallint] NULL,
 CONSTRAINT [PK_menu] PRIMARY KEY CLUSTERED 
(
	[men_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[menu_accion]    Script Date: 14/08/2023 19:50:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[menu_accion](
	[mea_id] [bigint] IDENTITY(1,1) NOT NULL,
	[men_id] [bigint] NULL,
	[tip_id] [bigint] NULL,
	[mea_estado] [smallint] NULL,
 CONSTRAINT [PK_menu_accion] PRIMARY KEY CLUSTERED 
(
	[mea_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[menu_perfil]    Script Date: 14/08/2023 19:50:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[menu_perfil](
	[mep_id] [bigint] IDENTITY(1,1) NOT NULL,
	[men_id] [bigint] NULL,
	[per_id] [bigint] NULL,
	[mep_estado] [smallint] NULL,
	[mea_id] [bigint] NULL,
 CONSTRAINT [PK_menu_perfil] PRIMARY KEY CLUSTERED 
(
	[mep_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[perfil]    Script Date: 14/08/2023 19:50:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[perfil](
	[per_id] [bigint] IDENTITY(1,1) NOT NULL,
	[per_nombre] [varchar](150) NULL,
	[per_estado] [smallint] NULL,
	[emp_id] [bigint] NULL,
 CONSTRAINT [PK_perfil] PRIMARY KEY CLUSTERED 
(
	[per_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[seguimiento_paciente]    Script Date: 14/08/2023 19:50:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seguimiento_paciente](
	[sep_id] [bigint] IDENTITY(1,1) NOT NULL,
	[cas_id] [bigint] NULL,
	[sep_observacion] [varchar](50) NULL,
	[sep_finalizar] [bit] NULL,
	[usu_id] [bigint] NULL,
	[cit_id] [bigint] NULL,
 CONSTRAINT [PK_seguimiento_paciente] PRIMARY KEY CLUSTERED 
(
	[sep_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 14/08/2023 19:50:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[usu_id] [bigint] IDENTITY(1,1) NOT NULL,
	[usu_nombres] [varchar](250) NULL,
	[usu_apellidos] [varchar](250) NULL,
	[usu_email] [varchar](50) NULL,
	[usu_password] [varchar](500) NULL,
	[usu_estado] [smallint] NULL,
	[per_id] [bigint] NULL,
	[usu_cedula] [char](11) NULL,
	[usu_direccion] [varchar](100) NULL,
	[usu_telefono] [varchar](25) NULL,
	[usu_sexo] [char](1) NULL,
	[usu_fecha_nacimiento] [date] NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[usu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[catalogo_seguimiento] ON 

INSERT [dbo].[catalogo_seguimiento] ([cas_id], [esp_id], [cas_nombre], [cas_estado]) VALUES (1, 3, N'skdjkdkfks', 1)
INSERT [dbo].[catalogo_seguimiento] ([cas_id], [esp_id], [cas_nombre], [cas_estado]) VALUES (2, 1, N'HJJKKKJHJH', 1)
INSERT [dbo].[catalogo_seguimiento] ([cas_id], [esp_id], [cas_nombre], [cas_estado]) VALUES (3, 4, N'jhkjkjkljkllj', 1)
SET IDENTITY_INSERT [dbo].[catalogo_seguimiento] OFF
GO
SET IDENTITY_INSERT [dbo].[citas] ON 

INSERT [dbo].[citas] ([cit_id], [mes_id], [cit_fecha_atencion], [cit_inicio_atencion], [cit_fin_atencion], [cit_estado_paciente], [cit_observaciones], [cit_estado], [usu_id]) VALUES (46, 1, CAST(N'2023-08-03' AS Date), CAST(N'12:00:00' AS Time), CAST(N'13:00:00' AS Time), N'hlkj', N'hkkk', 1, 7)
INSERT [dbo].[citas] ([cit_id], [mes_id], [cit_fecha_atencion], [cit_inicio_atencion], [cit_fin_atencion], [cit_estado_paciente], [cit_observaciones], [cit_estado], [usu_id]) VALUES (49, 5, CAST(N'2023-08-05' AS Date), CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), N'fgjskdjgks', N'fdgdghfh', 1, 6)
SET IDENTITY_INSERT [dbo].[citas] OFF
GO
SET IDENTITY_INSERT [dbo].[empresa] ON 

INSERT [dbo].[empresa] ([emp_id], [emp_nombre], [emp_identificacion], [emp_correo], [emp_telefono], [emp_direccion]) VALUES (1, N'empresa sistema', N'12345', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[empresa] OFF
GO
SET IDENTITY_INSERT [dbo].[especialidades] ON 

INSERT [dbo].[especialidades] ([esp_id], [esp_nombre], [esp_descripcion], [esp_fecha_registro], [esp_estado], [emp_id]) VALUES (1, N'Traumatología', N'tratamiento y prevención de las lesiones del aparato musculo esquelético.', CAST(N'2023-11-06T00:00:00.000' AS DateTime), 1, NULL)
INSERT [dbo].[especialidades] ([esp_id], [esp_nombre], [esp_descripcion], [esp_fecha_registro], [esp_estado], [emp_id]) VALUES (2, N'Ginecología', N'diagnóstico y tratamiento de enfermedades de los órganos reproductivos femeninos.', CAST(N'2023-11-06T00:00:00.000' AS DateTime), 1, NULL)
INSERT [dbo].[especialidades] ([esp_id], [esp_nombre], [esp_descripcion], [esp_fecha_registro], [esp_estado], [emp_id]) VALUES (3, N'Pediatría', N'trastornos del corazón', CAST(N'2023-07-20T00:00:00.000' AS DateTime), 1, NULL)
INSERT [dbo].[especialidades] ([esp_id], [esp_nombre], [esp_descripcion], [esp_fecha_registro], [esp_estado], [emp_id]) VALUES (4, N'Dermatología', N'trastornos de la piel', CAST(N'2023-07-20T00:00:00.000' AS DateTime), 1, NULL)
INSERT [dbo].[especialidades] ([esp_id], [esp_nombre], [esp_descripcion], [esp_fecha_registro], [esp_estado], [emp_id]) VALUES (5, N'Gastroenterología', N' trastornos metabólicos y hormonales', CAST(N'2023-07-20T00:00:00.000' AS DateTime), 1, NULL)
INSERT [dbo].[especialidades] ([esp_id], [esp_nombre], [esp_descripcion], [esp_fecha_registro], [esp_estado], [emp_id]) VALUES (6, N'Odontologia', N'trastornos del sistema nervioso', CAST(N'2023-07-20T00:00:00.000' AS DateTime), 1, NULL)
INSERT [dbo].[especialidades] ([esp_id], [esp_nombre], [esp_descripcion], [esp_fecha_registro], [esp_estado], [emp_id]) VALUES (7, N'Psicología', N'Trastornos de la mente', CAST(N'2023-08-05T00:00:00.000' AS DateTime), 1, NULL)
INSERT [dbo].[especialidades] ([esp_id], [esp_nombre], [esp_descripcion], [esp_fecha_registro], [esp_estado], [emp_id]) VALUES (8, N'Cirugía Vascular', N'Tratamiento', CAST(N'2023-08-05T00:00:00.000' AS DateTime), 1, NULL)
INSERT [dbo].[especialidades] ([esp_id], [esp_nombre], [esp_descripcion], [esp_fecha_registro], [esp_estado], [emp_id]) VALUES (9, N'Medicina Interna', N'Medicina Interna', CAST(N'2023-08-05T00:00:00.000' AS DateTime), 1, NULL)
INSERT [dbo].[especialidades] ([esp_id], [esp_nombre], [esp_descripcion], [esp_fecha_registro], [esp_estado], [emp_id]) VALUES (10, N'Medicina General', N'Medicina General', CAST(N'2023-08-05T00:00:00.000' AS DateTime), 1, NULL)
INSERT [dbo].[especialidades] ([esp_id], [esp_nombre], [esp_descripcion], [esp_fecha_registro], [esp_estado], [emp_id]) VALUES (11, N'Ecografía', N'Ecografía', CAST(N'2023-08-05T00:00:00.000' AS DateTime), 1, NULL)
INSERT [dbo].[especialidades] ([esp_id], [esp_nombre], [esp_descripcion], [esp_fecha_registro], [esp_estado], [emp_id]) VALUES (12, N'Urología', N'Urología', CAST(N'2023-08-06T00:00:00.000' AS DateTime), 1, NULL)
INSERT [dbo].[especialidades] ([esp_id], [esp_nombre], [esp_descripcion], [esp_fecha_registro], [esp_estado], [emp_id]) VALUES (13, N'Oftalmología', N'Oftalmología', CAST(N'2023-08-05T00:00:00.000' AS DateTime), 1, NULL)
INSERT [dbo].[especialidades] ([esp_id], [esp_nombre], [esp_descripcion], [esp_fecha_registro], [esp_estado], [emp_id]) VALUES (14, N'Rehabilitación', N'Rehabilitación', CAST(N'2023-08-12T00:00:00.000' AS DateTime), 1, NULL)
INSERT [dbo].[especialidades] ([esp_id], [esp_nombre], [esp_descripcion], [esp_fecha_registro], [esp_estado], [emp_id]) VALUES (15, N'Nutrición', N'Nutrición', CAST(N'2023-08-04T00:00:00.000' AS DateTime), 1, NULL)
SET IDENTITY_INSERT [dbo].[especialidades] OFF
GO
SET IDENTITY_INSERT [dbo].[medicos] ON 

INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (1, N'patricio', N'landazuri', N'1710221447 ', N'Solanda', N'asdd@gmail.com', N'0988552201', N'm', N'15523', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (2, N'Fernando ', N'Perez', N'17254665   ', N'Solanda', N'mdfgkl@gmail.com', N'2154541', N'M', N'56545', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (3, N'Santiago', N'Perez', N'17511554545', N'Cumbaya', N'mkfjdkfjks@gmail.com', N'32545445', N'M', N'121215', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (4, N'Lorena', N'Aguirre', N'1789543612 ', N'Tumbaco', N'loreaguirre@gmail.com', N'24555545', N'F', N'123234', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (5, N'Héctor', N'Zurita', N'175478931  ', N'Solanda', N'hectorzurita@gmail.com', N'254789348', N'M', N'457891', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (6, N'Tania ', N'Suarez', N'1714578932 ', N'Solanda', N'taniasuarez@gmail.com', N'0968545620', N'F', N'122455', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (7, N'Catalina', N'Burbano', N'1789545632 ', N'Solanda', N'catalinaburbano@gmail.com', N'245652455', N'F', N'54552452', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (8, N'María', N'Darquea', N'1721785942 ', N'Solanda', N'mariadarquea@gmail.com', N'0988446578', N'F', N'25158454', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (9, N'Marco', N'López', N'1707915684 ', N'Solanda', N'marcolopez@gmail.com', N'52445214', N'M', N'56454548', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (10, N'Julia', N'Collantes', N'17054789645', N'Solanda', N'juliacollantes@gmail.com', N'0955542255', N'F', N'15154155', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (11, N'Jennifer', N'Muñoz', N'1704896325 ', N'Solanda', N'jemuñoz@gmail.com', N'09698564554455', N'F', N'554', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (12, N'Sylvia', N'Logacho', N'175247898  ', N'Solanda', N'sylvialogacho@gmail.com', N'09555454545', N'F', N'12151541', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (13, N'Guadalupe', N'Lamar', N'1785154515 ', N'Solanda', N'guadalupelamar@gmail.com', N'09684565', N'F', N'12154515', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (14, N'Francisco', N'Castellanos', N'17078541215', N'Solanda', N'francastellanos@gmail.com', N'065451545', N'M', N'5454554', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (15, N'Pablo ', N'Castellanos', N'170791545  ', N'Solanda', N'pablocastellanos@gmail.com', N'099954575514', N'M', N'1541545', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (16, N'Ramiro', N'Ramadan', N'17048751254', N'Solanda', N'ramiroramadan@gmail.com', N'098452145', N'M', N'455752', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (17, N'Alfredo', N'Alava', N'178245785  ', N'Solanda', N'alava@gmail.com', N'245152445', N'M', N'45454', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (19, N'Zahira ', N'Martinez', N'175424515  ', N'Solanda', N'zmartinez@gmail.com', N'54545454', N'F', N'4545454', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (20, N'Pavlo', N'Carvajal', N'1545454    ', N'Solanda', N'pavlocarvajal@gmail.com', N'454545454', N'M', N'5454545220', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (21, N'Anibal', N'Yupa', N'17545454554', N'Solanda', N'yupa@gmail.com', N'56565656', N'M', N'878749', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (22, N'Fanny', N'Logroño', N'1445565    ', N'Solanda', N'fannylo@gmail.com', N'0984551515', N'F', N'4514545', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (23, N'Pabloo', N'Serrano', N'1751545456 ', N'Solanda', N'pserran11o@gmail.com', N'09966564', N'M', N'7879789', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (24, N'Nidian', N'Torres', N'1752497892 ', N'Solanda', N'nidiantorres@gmail.com', N'09991135644', N'F', N'9956565', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (25, N'Geovanna', N'Rocha', N'17895454545', N'Solanda', N'geovannarocha@gmail.com', N'0999117896', N'F', N'654548840', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (26, N'Diego', N'Cruz', N'878848484  ', N'Solanda', N'cruzd@gmail.com', N'099841215', N'M', N'898950', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (27, N'Isabel', N'Bustilllos', N'1751545454 ', N'Solanda', N'bustillosisable@gmail.com', N'4511218487', N'F', N'7841521', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (28, N'Jeinny', N'Vargas', N'5484514    ', N'Solanda', N'jeinnyvarfas@gmail.com', N'54584545', N'F', N'84847554', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (29, N'Luis', N'Rodriguez', N'1785152151 ', N'Solanda', N'luisrodri@gmail.com', N'48484548', N'M', N'914984', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (30, N'Erika', N'Vinueza', N'4878484685 ', N'Solanda', N'erivinueza@gmail.com', N'09884545454', N'F', N'6546455', 1, NULL)
INSERT [dbo].[medicos] ([med_id], [med_nombres], [med_apellidos], [med_cedula], [med_direccion], [med_correo], [med_telefono], [med_sexo], [med_num_csp], [med_estado], [emp_id]) VALUES (31, N'Zah', N'Lamar', N'175154545  ', N'Solanda', N'zalamar@gmail,com', N'1545451', N'F', N'84854848', 1, NULL)
SET IDENTITY_INSERT [dbo].[medicos] OFF
GO
SET IDENTITY_INSERT [dbo].[medicos_especialidades] ON 

INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (1, 2, 4, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (2, 1, 1, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (3, 2, 2, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (4, 1, 3, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (5, 4, 2, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (6, 1, 2, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (7, 7, 5, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (8, 7, 6, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (9, 3, 7, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (10, 3, 8, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (11, 5, 9, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (12, 4, 10, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (13, 4, 11, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (14, 1, 12, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (15, 8, 31, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (16, 9, 14, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (17, 9, 15, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (18, 10, 16, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (19, 11, 17, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (20, 12, 20, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (21, 2, 19, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (22, 2, 21, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (23, 2, 22, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (24, 13, 23, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (25, 13, 24, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (26, 14, 25, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (27, 14, 26, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (28, 14, 27, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (29, 6, 28, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (30, 6, 29, 1)
INSERT [dbo].[medicos_especialidades] ([mes_id], [esp_id], [med_id], [mes_estado]) VALUES (31, 15, 30, 1)
SET IDENTITY_INSERT [dbo].[medicos_especialidades] OFF
GO
SET IDENTITY_INSERT [dbo].[menu] ON 

INSERT [dbo].[menu] ([men_id], [men_nombre], [men_men_id], [men_tipo], [men_icono], [men_url], [men_orden], [men_codigo_unico], [men_estado]) VALUES (1, N'Carrera', 2, NULL, N'', N'', 4, NULL, 0)
INSERT [dbo].[menu] ([men_id], [men_nombre], [men_men_id], [men_tipo], [men_icono], [men_url], [men_orden], [men_codigo_unico], [men_estado]) VALUES (2, N'Administración', NULL, NULL, NULL, NULL, 1, NULL, 1)
INSERT [dbo].[menu] ([men_id], [men_nombre], [men_men_id], [men_tipo], [men_icono], [men_url], [men_orden], [men_codigo_unico], [men_estado]) VALUES (3, N'Perfil', 2, NULL, NULL, N'perfil', 1, NULL, 1)
INSERT [dbo].[menu] ([men_id], [men_nombre], [men_men_id], [men_tipo], [men_icono], [men_url], [men_orden], [men_codigo_unico], [men_estado]) VALUES (4, N'Paciente', 21, NULL, NULL, N'usuario', 10, NULL, 1)
INSERT [dbo].[menu] ([men_id], [men_nombre], [men_men_id], [men_tipo], [men_icono], [men_url], [men_orden], [men_codigo_unico], [men_estado]) VALUES (5, N'Menú', 2, NULL, NULL, N'menu', 3, NULL, 1)
INSERT [dbo].[menu] ([men_id], [men_nombre], [men_men_id], [men_tipo], [men_icono], [men_url], [men_orden], [men_codigo_unico], [men_estado]) VALUES (6, N'Permisos menú', 2, NULL, N'', N'menuPerfil', 7, NULL, 1)
INSERT [dbo].[menu] ([men_id], [men_nombre], [men_men_id], [men_tipo], [men_icono], [men_url], [men_orden], [men_codigo_unico], [men_estado]) VALUES (9, N'Seguimiento y diagnóstico', NULL, NULL, N'', NULL, 3, NULL, 1)
INSERT [dbo].[menu] ([men_id], [men_nombre], [men_men_id], [men_tipo], [men_icono], [men_url], [men_orden], [men_codigo_unico], [men_estado]) VALUES (15, N'Inicio', NULL, NULL, N'', N'starter', 1, NULL, 0)
INSERT [dbo].[menu] ([men_id], [men_nombre], [men_men_id], [men_tipo], [men_icono], [men_url], [men_orden], [men_codigo_unico], [men_estado]) VALUES (17, N'Médico', 21, NULL, N'', N'medico', 1, NULL, 1)
INSERT [dbo].[menu] ([men_id], [men_nombre], [men_men_id], [men_tipo], [men_icono], [men_url], [men_orden], [men_codigo_unico], [men_estado]) VALUES (18, N'Especialidades', 21, NULL, N'', N'especialidade', 9, NULL, 1)
INSERT [dbo].[menu] ([men_id], [men_nombre], [men_men_id], [men_tipo], [men_icono], [men_url], [men_orden], [men_codigo_unico], [men_estado]) VALUES (19, N'Citas', 21, NULL, N'', N'cita', 5, NULL, 1)
INSERT [dbo].[menu] ([men_id], [men_nombre], [men_men_id], [men_tipo], [men_icono], [men_url], [men_orden], [men_codigo_unico], [men_estado]) VALUES (20, N'Preguntas', 9, NULL, N'', N'catalogoSeguimiento', 1, NULL, 1)
INSERT [dbo].[menu] ([men_id], [men_nombre], [men_men_id], [men_tipo], [men_icono], [men_url], [men_orden], [men_codigo_unico], [men_estado]) VALUES (21, N'Gestión citas médicas', NULL, NULL, N'', NULL, 2, NULL, 1)
INSERT [dbo].[menu] ([men_id], [men_nombre], [men_men_id], [men_tipo], [men_icono], [men_url], [men_orden], [men_codigo_unico], [men_estado]) VALUES (22, N'Medicos especialidades', 21, NULL, N'', N'medicosEspecialidade', 3, NULL, 1)
INSERT [dbo].[menu] ([men_id], [men_nombre], [men_men_id], [men_tipo], [men_icono], [men_url], [men_orden], [men_codigo_unico], [men_estado]) VALUES (23, N'Horarios disponibles', 21, NULL, N'', N'horario', 4, NULL, 0)
INSERT [dbo].[menu] ([men_id], [men_nombre], [men_men_id], [men_tipo], [men_icono], [men_url], [men_orden], [men_codigo_unico], [men_estado]) VALUES (24, N'Seguimiento paciente', 9, NULL, N'', N'seguimientoPaciente', 3, NULL, 1)
SET IDENTITY_INSERT [dbo].[menu] OFF
GO
SET IDENTITY_INSERT [dbo].[menu_perfil] ON 

INSERT [dbo].[menu_perfil] ([mep_id], [men_id], [per_id], [mep_estado], [mea_id]) VALUES (2, 3, 1, 1, NULL)
INSERT [dbo].[menu_perfil] ([mep_id], [men_id], [per_id], [mep_estado], [mea_id]) VALUES (3, 4, 1, 1, NULL)
INSERT [dbo].[menu_perfil] ([mep_id], [men_id], [per_id], [mep_estado], [mea_id]) VALUES (4, 5, 1, 1, NULL)
INSERT [dbo].[menu_perfil] ([mep_id], [men_id], [per_id], [mep_estado], [mea_id]) VALUES (5, 6, 1, 1, NULL)
INSERT [dbo].[menu_perfil] ([mep_id], [men_id], [per_id], [mep_estado], [mea_id]) VALUES (11, 17, 1, 1, NULL)
INSERT [dbo].[menu_perfil] ([mep_id], [men_id], [per_id], [mep_estado], [mea_id]) VALUES (12, 18, 1, 1, NULL)
INSERT [dbo].[menu_perfil] ([mep_id], [men_id], [per_id], [mep_estado], [mea_id]) VALUES (13, 20, 1, 1, NULL)
INSERT [dbo].[menu_perfil] ([mep_id], [men_id], [per_id], [mep_estado], [mea_id]) VALUES (14, 22, 1, 1, NULL)
INSERT [dbo].[menu_perfil] ([mep_id], [men_id], [per_id], [mep_estado], [mea_id]) VALUES (15, 23, 1, 1, NULL)
INSERT [dbo].[menu_perfil] ([mep_id], [men_id], [per_id], [mep_estado], [mea_id]) VALUES (16, 19, 1, 1, NULL)
INSERT [dbo].[menu_perfil] ([mep_id], [men_id], [per_id], [mep_estado], [mea_id]) VALUES (17, 24, 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[menu_perfil] OFF
GO
SET IDENTITY_INSERT [dbo].[perfil] ON 

INSERT [dbo].[perfil] ([per_id], [per_nombre], [per_estado], [emp_id]) VALUES (1, N'Super Administrador', 1, 1)
INSERT [dbo].[perfil] ([per_id], [per_nombre], [per_estado], [emp_id]) VALUES (2, N'Médico', 1, 1)
INSERT [dbo].[perfil] ([per_id], [per_nombre], [per_estado], [emp_id]) VALUES (4, N'Paciente', 1, 1)
SET IDENTITY_INSERT [dbo].[perfil] OFF
GO
SET IDENTITY_INSERT [dbo].[seguimiento_paciente] ON 

INSERT [dbo].[seguimiento_paciente] ([sep_id], [cas_id], [sep_observacion], [sep_finalizar], [usu_id], [cit_id]) VALUES (15, 2, NULL, 0, 7, NULL)
INSERT [dbo].[seguimiento_paciente] ([sep_id], [cas_id], [sep_observacion], [sep_finalizar], [usu_id], [cit_id]) VALUES (16, 2, NULL, 0, 7, NULL)
INSERT [dbo].[seguimiento_paciente] ([sep_id], [cas_id], [sep_observacion], [sep_finalizar], [usu_id], [cit_id]) VALUES (17, 3, NULL, 0, 6, NULL)
INSERT [dbo].[seguimiento_paciente] ([sep_id], [cas_id], [sep_observacion], [sep_finalizar], [usu_id], [cit_id]) VALUES (18, 3, NULL, 0, 6, 49)
SET IDENTITY_INSERT [dbo].[seguimiento_paciente] OFF
GO
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([usu_id], [usu_nombres], [usu_apellidos], [usu_email], [usu_password], [usu_estado], [per_id], [usu_cedula], [usu_direccion], [usu_telefono], [usu_sexo], [usu_fecha_nacimiento]) VALUES (1, N'Super administrador', N'Super administrador', N'info@gmail.com', N'1000:QbuMlpHfIcIFuKzJrwkxU6a8uH6sWfeb:zG8cjU4qZVyT0fmL/iXz6Lz0k8Q=', 1, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[usuario] ([usu_id], [usu_nombres], [usu_apellidos], [usu_email], [usu_password], [usu_estado], [per_id], [usu_cedula], [usu_direccion], [usu_telefono], [usu_sexo], [usu_fecha_nacimiento]) VALUES (6, N'David marcelo', N'Cabezas gutierrez', N'kirad2011@gmail.com', N'1000:jOg0Lc2WNNvS6xlyH4/8aVQfT4rC0Yrv:mt8dbpBlCCOgUVDmVKiazOl2Aqk=', 1, 4, N'172189502  ', N'Solanda', N'096985562', N'1', CAST(N'1987-08-10' AS Date))
INSERT [dbo].[usuario] ([usu_id], [usu_nombres], [usu_apellidos], [usu_email], [usu_password], [usu_estado], [per_id], [usu_cedula], [usu_direccion], [usu_telefono], [usu_sexo], [usu_fecha_nacimiento]) VALUES (7, N'Anahis milena', N'Velasquez castro', N'mileanacami@gmail.com', N'1000:IAeM7ws/obViKwaC+uNltXgSTFbk0BXH:427FTCRBAExJ5Bl08nSphMW+MIw=', 1, 4, N'1752947901 ', N'Miravalle', N'254464541', N'F', CAST(N'1999-10-03' AS Date))
INSERT [dbo].[usuario] ([usu_id], [usu_nombres], [usu_apellidos], [usu_email], [usu_password], [usu_estado], [per_id], [usu_cedula], [usu_direccion], [usu_telefono], [usu_sexo], [usu_fecha_nacimiento]) VALUES (8, N'Ana maria', N'Castro ortiz', N'skdjsk@gmail.com', N'1000:zbYiP5ND9v3HItlQWfjGYnNLAu+HvKPS:nB52Od+kgYqV6kNBHIZbBxJjgqI=', 1, 4, N'1707918312 ', N'Miravalle', N'2898369', N'F', CAST(N'1966-09-09' AS Date))
SET IDENTITY_INSERT [dbo].[usuario] OFF
GO
ALTER TABLE [dbo].[catalogo_seguimiento]  WITH CHECK ADD  CONSTRAINT [FK_catalogo_seguimiento_especialidades] FOREIGN KEY([esp_id])
REFERENCES [dbo].[especialidades] ([esp_id])
GO
ALTER TABLE [dbo].[catalogo_seguimiento] CHECK CONSTRAINT [FK_catalogo_seguimiento_especialidades]
GO
ALTER TABLE [dbo].[citas]  WITH CHECK ADD  CONSTRAINT [FK_citas_medicos_especialidades] FOREIGN KEY([mes_id])
REFERENCES [dbo].[medicos_especialidades] ([mes_id])
GO
ALTER TABLE [dbo].[citas] CHECK CONSTRAINT [FK_citas_medicos_especialidades]
GO
ALTER TABLE [dbo].[citas]  WITH CHECK ADD  CONSTRAINT [FK_citas_usuario] FOREIGN KEY([usu_id])
REFERENCES [dbo].[usuario] ([usu_id])
GO
ALTER TABLE [dbo].[citas] CHECK CONSTRAINT [FK_citas_usuario]
GO
ALTER TABLE [dbo].[especialidades]  WITH CHECK ADD  CONSTRAINT [FK_especialidades_empresa] FOREIGN KEY([emp_id])
REFERENCES [dbo].[empresa] ([emp_id])
GO
ALTER TABLE [dbo].[especialidades] CHECK CONSTRAINT [FK_especialidades_empresa]
GO
ALTER TABLE [dbo].[horarios]  WITH CHECK ADD  CONSTRAINT [FK_horarios_medicos] FOREIGN KEY([med_id])
REFERENCES [dbo].[medicos] ([med_id])
GO
ALTER TABLE [dbo].[horarios] CHECK CONSTRAINT [FK_horarios_medicos]
GO
ALTER TABLE [dbo].[indice_seguimiento]  WITH CHECK ADD  CONSTRAINT [FK_indice_seguimiento_especialidades] FOREIGN KEY([esp_id])
REFERENCES [dbo].[especialidades] ([esp_id])
GO
ALTER TABLE [dbo].[indice_seguimiento] CHECK CONSTRAINT [FK_indice_seguimiento_especialidades]
GO
ALTER TABLE [dbo].[indice_seguimiento]  WITH CHECK ADD  CONSTRAINT [FK_indice_seguimiento_usuario] FOREIGN KEY([usu_id])
REFERENCES [dbo].[usuario] ([usu_id])
GO
ALTER TABLE [dbo].[indice_seguimiento] CHECK CONSTRAINT [FK_indice_seguimiento_usuario]
GO
ALTER TABLE [dbo].[medicos]  WITH CHECK ADD  CONSTRAINT [FK_medicos_empresa] FOREIGN KEY([emp_id])
REFERENCES [dbo].[empresa] ([emp_id])
GO
ALTER TABLE [dbo].[medicos] CHECK CONSTRAINT [FK_medicos_empresa]
GO
ALTER TABLE [dbo].[medicos_especialidades]  WITH CHECK ADD  CONSTRAINT [FK_medicos_especialidades_especialidades] FOREIGN KEY([esp_id])
REFERENCES [dbo].[especialidades] ([esp_id])
GO
ALTER TABLE [dbo].[medicos_especialidades] CHECK CONSTRAINT [FK_medicos_especialidades_especialidades]
GO
ALTER TABLE [dbo].[medicos_especialidades]  WITH CHECK ADD  CONSTRAINT [FK_medicos_especialidades_medicos] FOREIGN KEY([med_id])
REFERENCES [dbo].[medicos] ([med_id])
GO
ALTER TABLE [dbo].[medicos_especialidades] CHECK CONSTRAINT [FK_medicos_especialidades_medicos]
GO
ALTER TABLE [dbo].[menu]  WITH CHECK ADD  CONSTRAINT [FK_menu_menu] FOREIGN KEY([men_men_id])
REFERENCES [dbo].[menu] ([men_id])
GO
ALTER TABLE [dbo].[menu] CHECK CONSTRAINT [FK_menu_menu]
GO
ALTER TABLE [dbo].[menu_accion]  WITH CHECK ADD  CONSTRAINT [FK_menu_accion_menu] FOREIGN KEY([men_id])
REFERENCES [dbo].[menu] ([men_id])
GO
ALTER TABLE [dbo].[menu_accion] CHECK CONSTRAINT [FK_menu_accion_menu]
GO
ALTER TABLE [dbo].[menu_perfil]  WITH CHECK ADD  CONSTRAINT [FK_menu_perfil_menu] FOREIGN KEY([men_id])
REFERENCES [dbo].[menu] ([men_id])
GO
ALTER TABLE [dbo].[menu_perfil] CHECK CONSTRAINT [FK_menu_perfil_menu]
GO
ALTER TABLE [dbo].[menu_perfil]  WITH CHECK ADD  CONSTRAINT [FK_menu_perfil_menu_accion] FOREIGN KEY([mea_id])
REFERENCES [dbo].[menu_accion] ([mea_id])
GO
ALTER TABLE [dbo].[menu_perfil] CHECK CONSTRAINT [FK_menu_perfil_menu_accion]
GO
ALTER TABLE [dbo].[menu_perfil]  WITH CHECK ADD  CONSTRAINT [FK_menu_perfil_perfil] FOREIGN KEY([per_id])
REFERENCES [dbo].[perfil] ([per_id])
GO
ALTER TABLE [dbo].[menu_perfil] CHECK CONSTRAINT [FK_menu_perfil_perfil]
GO
ALTER TABLE [dbo].[perfil]  WITH CHECK ADD  CONSTRAINT [FK_perfil_empresa] FOREIGN KEY([emp_id])
REFERENCES [dbo].[empresa] ([emp_id])
GO
ALTER TABLE [dbo].[perfil] CHECK CONSTRAINT [FK_perfil_empresa]
GO
ALTER TABLE [dbo].[seguimiento_paciente]  WITH CHECK ADD  CONSTRAINT [FK_seguimiento_paciente_catalogo_seguimiento] FOREIGN KEY([cas_id])
REFERENCES [dbo].[catalogo_seguimiento] ([cas_id])
GO
ALTER TABLE [dbo].[seguimiento_paciente] CHECK CONSTRAINT [FK_seguimiento_paciente_catalogo_seguimiento]
GO
ALTER TABLE [dbo].[seguimiento_paciente]  WITH CHECK ADD  CONSTRAINT [FK_seguimiento_paciente_citas] FOREIGN KEY([cit_id])
REFERENCES [dbo].[citas] ([cit_id])
GO
ALTER TABLE [dbo].[seguimiento_paciente] CHECK CONSTRAINT [FK_seguimiento_paciente_citas]
GO
ALTER TABLE [dbo].[seguimiento_paciente]  WITH CHECK ADD  CONSTRAINT [FK_seguimiento_paciente_usuario] FOREIGN KEY([usu_id])
REFERENCES [dbo].[usuario] ([usu_id])
GO
ALTER TABLE [dbo].[seguimiento_paciente] CHECK CONSTRAINT [FK_seguimiento_paciente_usuario]
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [FK_usuario_perfil] FOREIGN KEY([per_id])
REFERENCES [dbo].[perfil] ([per_id])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [FK_usuario_perfil]
GO
