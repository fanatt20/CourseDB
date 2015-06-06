/*SELECT Name, [0] AS [Address], [1] AS [Mobile Phone 1], [2] AS [Mobile Phone 2], [3] AS [Skype], [4] AS [ICQ]
	FROM 
	(SELECT Human.Name,Human.Surname,Comunications.HumanID,Comunications.ComunicationType, ComunicationType.ComunicationTypeID,Comunications.ComunicationValue
		FROM Comunications 
			join ComunicationType on Comunications.ComunicationType=ComunicationType.ComunicationTypeID
			join Human on Human.HumanID=Comunications.HumanID
	) c 
	PIVOT
	(
		count(Surname)
	for
		c.ComunicationType 
			IN
			( [0], [1], [2], [3], [4] )
	) AS pvt
select CONCAT(Name,' ',Surname), [Address] from 
s(elect Human.Name,Human.Surname,Comunications.ComunicationType,Comunications.ComunicationValue 
from Comunications 
join Human on Comunications.HumanID= Human.HumanID
where ComunicationType=0
) as c
unpivot (
[Address] for fields in (ComunicationValue) 
)as unpvt
select Name,Surname,[Address],[Mob1],[Mob2],[Skype]
from Comunications join Human on Comunications.HumanID=Human.HumanID
left join 
	(select HumanID,[Address] from Communications where 
select * from ComunicationType;
select * from Comunications
Примитивно, но работает*/
CREATE VIEW dbo.[Связи с людьми]
AS
SELECT        AllRows.HumanID, dbo.Human.Name AS Имя, dbo.Human.Surname AS Фамилия, CASE WHEN Contracts.ContractID IS NULL THEN 0 ELSE 1 END AS [Является работником], 
                         ValType0.ComunicationValue AS Адрес, ValType1.ComunicationValue AS [Сотовый телефон 2], ValType2.ComunicationValue AS [Сотовый телефон 1], ValType3.ComunicationValue AS Skype, 
                         ValType4.ComunicationValue AS ICQ, ValType5.ComunicationValue AS [Домашний телефон]
FROM            (SELECT DISTINCT HumanID
                          FROM            dbo.Comunications) AS AllRows LEFT OUTER JOIN
                         dbo.Comunications AS ValType0 ON AllRows.HumanID = ValType0.HumanID AND ValType0.ComunicationType = 0 LEFT OUTER JOIN
                         dbo.Comunications AS ValType4 ON AllRows.HumanID = ValType4.HumanID AND ValType4.ComunicationType = 4 LEFT OUTER JOIN
                         dbo.Comunications AS ValType5 ON AllRows.HumanID = ValType5.HumanID AND ValType5.ComunicationType = 5 LEFT OUTER JOIN
                         dbo.Comunications AS ValType1 ON AllRows.HumanID = ValType1.HumanID AND ValType1.ComunicationType = 1 LEFT OUTER JOIN
                         dbo.Comunications AS ValType3 ON AllRows.HumanID = ValType3.HumanID AND ValType3.ComunicationType = 3 LEFT OUTER JOIN
                         dbo.Comunications AS ValType2 ON AllRows.HumanID = ValType2.HumanID AND ValType2.ComunicationType = 2 INNER JOIN
                         dbo.Human ON dbo.Human.HumanID = AllRows.HumanID LEFT OUTER JOIN
                         dbo.Contracts ON dbo.Human.HumanID = dbo.Contracts.HumanID

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[28] 2[14] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "AllRows"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 85
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ValType0"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 440
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ValType4"
            Begin Extent = 
               Top = 6
               Left = 478
               Bottom = 136
               Right = 672
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ValType5"
            Begin Extent = 
               Top = 6
               Left = 710
               Bottom = 136
               Right = 904
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ValType1"
            Begin Extent = 
               Top = 6
               Left = 942
               Bottom = 136
               Right = 1136
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ValType3"
            Begin Extent = 
               Top = 6
               Left = 1174
               Bottom = 136
               Right = 1368
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ValType2"
            Begin Extent = 
               Top = 6
               Left = 1406
               Bottom = 136
               Right = 1600
            End
            DisplayFlags = 28', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Связи с людьми';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'0
            TopColumn = 0
         End
         Begin Table = "Human"
            Begin Extent = 
               Top = 6
               Left = 1638
               Bottom = 136
               Right = 1808
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Contracts"
            Begin Extent = 
               Top = 90
               Left = 38
               Bottom = 220
               Right = 218
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 11
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 2745
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Связи с людьми';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Связи с людьми';

