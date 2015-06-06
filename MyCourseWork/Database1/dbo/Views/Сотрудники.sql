CREATE VIEW dbo.Сотрудники
AS
SELECT        dbo.Human.Name AS Имя, dbo.Human.Surname AS Фамилия, dbo.Positions.Name AS Должность, dbo.PositionState.PositionState AS [Состояние позиции], dbo.Departments.Name AS Отдел, 
                         dbo.Contracts.EndAtOfficial AS [Официальное окончание], dbo.Contracts.Salary AS Зарплата, dbo.Contracts.DateOfSigning AS [Дата Подписания контракта], dbo.Human.Patronymic, dbo.Human.Birthday, 
                         dbo.Human.Education, dbo.Contracts.EndAtPractically, dbo.Human.HumanID
FROM            dbo.Human LEFT OUTER JOIN
                         dbo.Contracts ON dbo.Human.HumanID = dbo.Contracts.HumanID LEFT OUTER JOIN
                         dbo.Positions ON dbo.Contracts.IDPosition = dbo.Positions.IDPosition LEFT OUTER JOIN
                         dbo.Departments ON dbo.Positions.IDDepartment = dbo.Departments.IDDepartment LEFT OUTER JOIN
                         dbo.PositionState ON dbo.Positions.PositionStateID = dbo.PositionState.PositionStateID

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[29] 4[32] 2[20] 3) )"
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
         Top = -288
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Human"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Contracts"
            Begin Extent = 
               Top = 12
               Left = 278
               Bottom = 219
               Right = 458
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Positions"
            Begin Extent = 
               Top = 61
               Left = 571
               Bottom = 191
               Right = 741
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Departments"
            Begin Extent = 
               Top = 196
               Left = 1081
               Bottom = 357
               Right = 1251
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PositionState"
            Begin Extent = 
               Top = 42
               Left = 979
               Bottom = 188
               Right = 1149
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
      Begin ColumnWidths = 14
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
         Width = 1500
         Width = 1500
         Width = 15', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Сотрудники';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'00
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 1875
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Сотрудники';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Сотрудники';

