CREATE TABLE [dbo].[MedicalInspectRegister] (
    [MedicalInspectID] INT            IDENTITY (0, 1) NOT NULL,
    [HumanID]          INT            NOT NULL,
    [StateID]          INT            NOT NULL,
    [DatePass]         DATE           NOT NULL,
    [Comment]          NVARCHAR (500) NOT NULL,
    CONSTRAINT [XPKMedicalInspect] PRIMARY KEY CLUSTERED ([MedicalInspectID] ASC),
    CONSTRAINT [R_24] FOREIGN KEY ([StateID]) REFERENCES [dbo].[MedicalStates] ([StateID]),
    CONSTRAINT [R_82] FOREIGN KEY ([HumanID]) REFERENCES [dbo].[Human] ([HumanID])
);


GO
CREATE TRIGGER tD_MedicalInspectRegister ON dbo.MedicalInspectRegister FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on MedicalInspectRegister */
BEGIN
  DECLARE  @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* Human  MedicalInspectRegister on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="0002b7ff", PARENT_OWNER="", PARENT_TABLE="Human"
    CHILD_OWNER="", CHILD_TABLE="MedicalInspectRegister"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_82", FK_COLUMNS="HumanID" */
    IF EXISTS (SELECT * FROM deleted,Human
      WHERE
        /* %JoinFKPK(deleted,Human," = "," AND") */
        deleted.HumanID = Human.HumanID AND
        NOT EXISTS (
          SELECT * FROM MedicalInspectRegister
          WHERE
            /* %JoinFKPK(MedicalInspectRegister,Human," = "," AND") */
            MedicalInspectRegister.HumanID = Human.HumanID
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last MedicalInspectRegister because Human exists.'
      GOTO error
    END

    /* ERwin Builtin Trigger */
    /* MedicalStates  MedicalInspectRegister on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="MedicalStates"
    CHILD_OWNER="", CHILD_TABLE="MedicalInspectRegister"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_24", FK_COLUMNS="StateID" */
    IF EXISTS (SELECT * FROM deleted,MedicalStates
      WHERE
        /* %JoinFKPK(deleted,MedicalStates," = "," AND") */
        deleted.StateID = MedicalStates.StateID AND
        NOT EXISTS (
          SELECT * FROM MedicalInspectRegister
          WHERE
            /* %JoinFKPK(MedicalInspectRegister,MedicalStates," = "," AND") */
            MedicalInspectRegister.StateID = MedicalStates.StateID
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last MedicalInspectRegister because MedicalStates exists.'
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
CREATE TRIGGER tU_MedicalInspectRegister ON dbo.MedicalInspectRegister FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on MedicalInspectRegister */
BEGIN
  DECLARE  @numrows int,
           @nullcnt int,
           @validcnt int,
           @insMedicalInspectID integer,
           @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)

  SELECT @numrows = @@rowcount
  /* ERwin Builtin Trigger */
  /* Human  MedicalInspectRegister on child update no action */
  /* ERWIN_RELATION:CHECKSUM="000304cb", PARENT_OWNER="", PARENT_TABLE="Human"
    CHILD_OWNER="", CHILD_TABLE="MedicalInspectRegister"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_82", FK_COLUMNS="HumanID" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(HumanID)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,Human
        WHERE
          /* %JoinFKPK(inserted,Human) */
          inserted.HumanID = Human.HumanID
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    select @nullcnt = count(*) from inserted where
      inserted.HumanID IS NULL
    IF @validcnt + @nullcnt != @numrows
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update MedicalInspectRegister because Human does not exist.'
      GOTO error
    END
  END

  /* ERwin Builtin Trigger */
  /* MedicalStates  MedicalInspectRegister on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="MedicalStates"
    CHILD_OWNER="", CHILD_TABLE="MedicalInspectRegister"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_24", FK_COLUMNS="StateID" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(StateID)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,MedicalStates
        WHERE
          /* %JoinFKPK(inserted,MedicalStates) */
          inserted.StateID = MedicalStates.StateID
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    select @nullcnt = count(*) from inserted where
      inserted.StateID IS NULL
    IF @validcnt + @nullcnt != @numrows
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update MedicalInspectRegister because MedicalStates does not exist.'
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
