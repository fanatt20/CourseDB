CREATE TABLE [dbo].[PositionRequirements] (
    [PositionRequirementsID] INT IDENTITY (0, 1) NOT NULL,
    [IDRequirements]         INT NULL,
    [IDPosition]             INT NULL,
    CONSTRAINT [XPKPositionRequirements] PRIMARY KEY CLUSTERED ([PositionRequirementsID] ASC),
    CONSTRAINT [R_83] FOREIGN KEY ([IDRequirements]) REFERENCES [dbo].[Requirements] ([IDRequirements]),
    CONSTRAINT [R_84] FOREIGN KEY ([IDPosition]) REFERENCES [dbo].[Positions] ([IDPosition])
);


GO
CREATE TRIGGER tD_PositionRequirements ON PositionRequirements FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on PositionRequirements */
BEGIN
  DECLARE  @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* Positions  PositionRequirements on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="0002d550", PARENT_OWNER="", PARENT_TABLE="Positions"
    CHILD_OWNER="", CHILD_TABLE="PositionRequirements"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_84", FK_COLUMNS="IDPosition" */
    IF EXISTS (SELECT * FROM deleted,Positions
      WHERE
        /* %JoinFKPK(deleted,Positions," = "," AND") */
        deleted.IDPosition = Positions.IDPosition AND
        NOT EXISTS (
          SELECT * FROM PositionRequirements
          WHERE
            /* %JoinFKPK(PositionRequirements,Positions," = "," AND") */
            PositionRequirements.IDPosition = Positions.IDPosition
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last PositionRequirements because Positions exists.'
      GOTO error
    END

    /* ERwin Builtin Trigger */
    /* Requirements  PositionRequirements on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Requirements"
    CHILD_OWNER="", CHILD_TABLE="PositionRequirements"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_83", FK_COLUMNS="IDRequirements" */
    IF EXISTS (SELECT * FROM deleted,Requirements
      WHERE
        /* %JoinFKPK(deleted,Requirements," = "," AND") */
        deleted.IDRequirements = Requirements.IDRequirements AND
        NOT EXISTS (
          SELECT * FROM PositionRequirements
          WHERE
            /* %JoinFKPK(PositionRequirements,Requirements," = "," AND") */
            PositionRequirements.IDRequirements = Requirements.IDRequirements
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last PositionRequirements because Requirements exists.'
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
CREATE TRIGGER tU_PositionRequirements ON PositionRequirements FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on PositionRequirements */
BEGIN
  DECLARE  @numrows int,
           @nullcnt int,
           @validcnt int,
           @insPositionRequirementsID integer,
           @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)

  SELECT @numrows = @@rowcount
  /* ERwin Builtin Trigger */
  /* Positions  PositionRequirements on child update no action */
  /* ERWIN_RELATION:CHECKSUM="0003198a", PARENT_OWNER="", PARENT_TABLE="Positions"
    CHILD_OWNER="", CHILD_TABLE="PositionRequirements"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_84", FK_COLUMNS="IDPosition" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDPosition)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,Positions
        WHERE
          /* %JoinFKPK(inserted,Positions) */
          inserted.IDPosition = Positions.IDPosition
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    select @nullcnt = count(*) from inserted where
      inserted.IDPosition IS NULL
    IF @validcnt + @nullcnt != @numrows
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update PositionRequirements because Positions does not exist.'
      GOTO error
    END
  END

  /* ERwin Builtin Trigger */
  /* Requirements  PositionRequirements on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Requirements"
    CHILD_OWNER="", CHILD_TABLE="PositionRequirements"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_83", FK_COLUMNS="IDRequirements" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDRequirements)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,Requirements
        WHERE
          /* %JoinFKPK(inserted,Requirements) */
          inserted.IDRequirements = Requirements.IDRequirements
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    select @nullcnt = count(*) from inserted where
      inserted.IDRequirements IS NULL
    IF @validcnt + @nullcnt != @numrows
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update PositionRequirements because Requirements does not exist.'
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
