﻿CREATE VIEW dbo.[Не закрытые отсутствия]
AS
SELECT        dbo.Human.Name AS Имя, dbo.Human.Surname AS Фамилия, dbo.AbsenceReason.Reason AS [Причина отсутствия], dbo.AbsenceRegister.StartAt AS [Начиная с], dbo.Departments.Name AS Отдел, 
                         dbo.Positions.Name AS Позиция, dbo.AbsenceRegister.EndAt, dbo.AbsenceRegister.IDAbsenceReason, dbo.AbsenceRegister.HumanID
FROM            dbo.AbsenceReason INNER JOIN
                         dbo.AbsenceRegister ON dbo.AbsenceReason.IDAbsenceReason = dbo.AbsenceRegister.IDAbsenceReason INNER JOIN
                         dbo.Human ON dbo.AbsenceRegister.HumanID = dbo.Human.HumanID INNER JOIN
                         dbo.Contracts ON dbo.Human.HumanID = dbo.Contracts.HumanID INNER JOIN
                         dbo.Positions ON dbo.Contracts.IDPosition = dbo.Positions.IDPosition INNER JOIN
                         dbo.Departments ON dbo.Positions.IDDepartment = dbo.Departments.IDDepartment
WHERE        (dbo.AbsenceRegister.EndAt IS NULL)

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
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "AbsenceReason"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 221
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AbsenceRegister"
            Begin Extent = 
               Top = 7
               Left = 393
               Bottom = 137
               Right = 580
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Human"
            Begin Extent = 
               Top = 23
               Left = 666
               Bottom = 153
               Right = 836
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Contracts"
            Begin Extent = 
               Top = 6
               Left = 913
               Bottom = 136
               Right = 1093
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "Positions"
            Begin Extent = 
               Top = 6
               Left = 1339
               Bottom = 136
               Right = 1509
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Departments"
            Begin Extent = 
               Top = 20
               Left = 1583
               Bottom = 116
               Right = 1753
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
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
        ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Не закрытые отсутствия';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N' Width = 1500
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
         Alias = 900
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Не закрытые отсутствия';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Не закрытые отсутствия';

