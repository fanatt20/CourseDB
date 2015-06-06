CREATE VIEW dbo.[Все контракты]
AS
SELECT        dbo.Human.Name AS Имя, dbo.Human.Patronymic AS Отчество, dbo.Human.Surname AS Фамилия, Positions_1.Name AS [Текущая должность], dbo.Departments.Name AS Отдел, ct.Salary AS Зарплата, 
                         prevPosition.Name AS [Прошлая позиция], ct.DateOfSigning AS [Дата подписания], ct.EndAtOfficial AS [Официальное окончание], ct.EndAtPractically AS [Фактическое окончание]
FROM            dbo.Contracts AS ct INNER JOIN
                         dbo.Positions AS Positions_1 ON ct.IDPosition = Positions_1.IDPosition INNER JOIN
                         dbo.Departments ON Positions_1.IDDepartment = dbo.Departments.IDDepartment LEFT OUTER JOIN
                         dbo.Contracts AS prevContract ON prevContract.ContractID = ct.PreviousContract LEFT OUTER JOIN
                         dbo.Positions AS prevPosition ON prevContract.IDPosition = prevPosition.IDPosition INNER JOIN
                         dbo.Human ON ct.HumanID = dbo.Human.HumanID

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Top = -192
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ct"
            Begin Extent = 
               Top = 28
               Left = 188
               Bottom = 158
               Right = 368
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "Positions_1"
            Begin Extent = 
               Top = 61
               Left = 713
               Bottom = 191
               Right = 883
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Departments"
            Begin Extent = 
               Top = 63
               Left = 1044
               Bottom = 159
               Right = 1214
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "prevContract"
            Begin Extent = 
               Top = 160
               Left = 903
               Bottom = 290
               Right = 1083
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "prevPosition"
            Begin Extent = 
               Top = 6
               Left = 1252
               Bottom = 136
               Right = 1422
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Human"
            Begin Extent = 
               Top = 6
               Left = 1460
               Bottom = 136
               Right = 1630
            End
            DisplayFlags = 280
            TopColumn = 3
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
         Width = 2340
       ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Все контракты';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'  Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 2730
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 2880
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1365
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Все контракты';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Все контракты';

