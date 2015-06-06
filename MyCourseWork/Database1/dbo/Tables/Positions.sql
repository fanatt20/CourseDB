CREATE TABLE [dbo].[Positions] (
    [IDPosition]      INT            IDENTITY (0, 1) NOT NULL,
    [PositionStateID] INT            NOT NULL,
    [IDDepartment]    INT            NOT NULL,
    [Name]            NVARCHAR (50)  NOT NULL,
    [SalaryMax]       MONEY          NOT NULL,
    [Duties]          NVARCHAR (100) NOT NULL,
    CONSTRAINT [XPKPositions] PRIMARY KEY CLUSTERED ([IDPosition] ASC),
    CONSTRAINT [R_85] FOREIGN KEY ([IDDepartment]) REFERENCES [dbo].[Departments] ([IDDepartment]),
    CONSTRAINT [R_88] FOREIGN KEY ([PositionStateID]) REFERENCES [dbo].[PositionState] ([PositionStateID])
);


GO
CREATE TRIGGER tD_Positions ON dbo.Positions FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on Positions */
BEGIN
  DECLARE  @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* Positions  PositionRequirements on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="0004a0e8", PARENT_OWNER="", PARENT_TABLE="Positions"
    CHILD_OWNER="", CHILD_TABLE="PositionRequirements"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_84", FK_COLUMNS="IDPosition" */
    IF EXISTS (
      SELECT * FROM deleted,PositionRequirements
      WHERE
        /*  %JoinFKPK(PositionRequirements,deleted," = "," AND") */
        PositionRequirements.IDPosition = deleted.IDPosition
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete Positions because PositionRequirements exists.'
      GOTO error
    END

    /* ERwin Builtin Trigger */
    /* Positions  Contracts on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Positions"
    CHILD_OWNER="", CHILD_TABLE="Contracts"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_21", FK_COLUMNS="IDPosition" */
    IF EXISTS (
      SELECT * FROM deleted,Contracts
      WHERE
        /*  %JoinFKPK(Contracts,deleted," = "," AND") */
        Contracts.IDPosition = deleted.IDPosition
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete Positions because Contracts exists.'
      GOTO error
    END

    /* ERwin Builtin Trigger */
    /* PositionState  Positions on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="PositionState"
    CHILD_OWNER="", CHILD_TABLE="Positions"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_88", FK_COLUMNS="PositionStateID" */
    IF EXISTS (SELECT * FROM deleted,PositionState
      WHERE
        /* %JoinFKPK(deleted,PositionState," = "," AND") */
        deleted.PositionStateID = PositionState.PositionStateID AND
        NOT EXISTS (
          SELECT * FROM Positions
          WHERE
            /* %JoinFKPK(Positions,PositionState," = "," AND") */
            Positions.PositionStateID = PositionState.PositionStateID
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last Positions because PositionState exists.'
      GOTO error
    END

    /* ERwin Builtin Trigger */
    /* Departments  Positions on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Departments"
    CHILD_OWNER="", CHILD_TABLE="Positions"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_85", FK_COLUMNS="IDDepartment" */
    IF EXISTS (SELECT * FROM deleted,Departments
      WHERE
        /* %JoinFKPK(deleted,Departments," = "," AND") */
        deleted.IDDepartment = Departments.IDDepartment AND
        NOT EXISTS (
          SELECT * FROM Positions
          WHERE
            /* %JoinFKPK(Positions,Departments," = "," AND") */
            Positions.IDDepartment = Departments.IDDepartment
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last Positions because Departments exists.'
      GOTO error
    END


    /* ERwin Builtin Trigger */
    RETURN
error:
   RAISERROR (@errmsg, -- Message text.
              @severity, -- Severity (0~25).
              @state) -- State (0~255).
    rollback transaction
END

GO
CREATE TRIGGER tU_Positions ON dbo.Positions FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on Positions */
BEGIN
  DECLARE  @numrows int,
           @nullcnt int,
           @validcnt int,
           @insIDPosition integer,
           @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)

  SELECT @numrows = @@rowcount
  /* ERwin Builtin Trigger */
  /* Positions  PositionRequirements on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00055050", PARENT_OWNER="", PARENT_TABLE="Positions"
    CHILD_OWNER="", CHILD_TABLE="PositionRequirements"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_84", FK_COLUMNS="IDPosition" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDPosition)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,PositionRequirements
      WHERE
        /*  %JoinFKPK(PositionRequirements,deleted," = "," AND") */
        PositionRequirements.IDPosition = deleted.IDPosition
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update Positions because PositionRequirements exists.'
      GOTO error
    END
  END

  /* ERwin Builtin Trigger */
  /* Positions  Contracts on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Positions"
    CHILD_OWNER="", CHILD_TABLE="Contracts"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_21", FK_COLUMNS="IDPosition" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDPosition)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,Contracts
      WHERE
        /*  %JoinFKPK(Contracts,deleted," = "," AND") */
        Contracts.IDPosition = deleted.IDPosition
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update Positions because Contracts exists.'
      GOTO error
    END
  END

  /* ERwin Builtin Trigger */
  /* PositionState  Positions on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="PositionState"
    CHILD_OWNER="", CHILD_TABLE="Positions"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_88", FK_COLUMNS="PositionStateID" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(PositionStateID)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,PositionState
        WHERE
          /* %JoinFKPK(inserted,PositionState) */
          inserted.PositionStateID = PositionState.PositionStateID
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    select @nullcnt = count(*) from inserted where
      inserted.PositionStateID IS NULL
    IF @validcnt + @nullcnt != @numrows
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update Positions because PositionState does not exist.'
      GOTO error
    END
  END

  /* ERwin Builtin Trigger */
  /* Departments  Positions on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Departments"
    CHILD_OWNER="", CHILD_TABLE="Positions"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_85", FK_COLUMNS="IDDepartment" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDDepartment)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,Departments
        WHERE
          /* %JoinFKPK(inserted,Departments) */
          inserted.IDDepartment = Departments.IDDepartment
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    select @nullcnt = count(*) from inserted where
      inserted.IDDepartment IS NULL
    IF @validcnt + @nullcnt != @numrows
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update Positions because Departments does not exist.'
      GOTO error
    END
  END


  /* ERwin Builtin Trigger */
  RETURN
error:
   RAISERROR (@errmsg, -- Message text.
              @severity, -- Severity (0~25).
              @state) -- State (0~255).
    rollback transaction
END
