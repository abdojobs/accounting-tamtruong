USE [Ketoan]
GO

/****** Object:  Index [UQ__Proceduc__A25C5AA719DFD96B]    Script Date: 10/28/2013 19:53:32 ******/
ALTER TABLE [dbo].[ProceduceType] ADD UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


