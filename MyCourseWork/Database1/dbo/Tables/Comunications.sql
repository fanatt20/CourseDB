CREATE TABLE [dbo].[Comunications] (
    [ComunicationID]    INT           IDENTITY (0, 1) NOT NULL,
    [HumanID]           INT           NOT NULL,
    [ComunicationType]  INT           NOT NULL,
    [ComunicationValue] NVARCHAR (50) NOT NULL,
    CONSTRAINT [XPKComunication] PRIMARY KEY CLUSTERED ([ComunicationID] ASC),
    CONSTRAINT [R_75] FOREIGN KEY ([ComunicationType]) REFERENCES [dbo].[ComunicationType] ([ComunicationTypeID]),
    CONSTRAINT [R_79] FOREIGN KEY ([HumanID]) REFERENCES [dbo].[Human] ([HumanID])
);


GO
CREATE TRIGGER tD_Comunications ON dbo.Comunications FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on Comunications */
BEGIN
  DECLARE  @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* Human  Comunications on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="0002af23", PARENT_OWNER="", PARENT_TABLE="Human"
    CHILD_OWNER="", CHILD_TABLE="Comunications"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_79", FK_COLUMNS="HumanID" */
    IF EXISTS (SELECT * FROM deleted,Human
      WHERE
        /* %JoinFKPK(deleted,Human," = "," AND") */
        deleted.HumanID = Human.HumanID AND
        NOT EXISTS (
          SELECT * FROM Comunications
          WHERE
            /* %JoinFKPK(Comunications,Human," = "," AND") */
            Comunications.HumanID = Human.HumanID
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last Comunications because Human exists.'
      GOTO error
    END

    /* ERwin Builtin Trigger */
    /* ComunicationType  Comunications on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="ComunicationType"
    CHILD_OWNER="", CHILD_TABLE="Comunications"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_75", FK_COLUMNS="ComunicationType" */
    IF EXISTS (SELECT * FROM deleted,ComunicationType
      WHERE
        /* %JoinFKPK(deleted,ComunicationType," = "," AND") */
        deleted.ComunicationType = ComunicationType.ComunicationTypeID AND
        NOT EXISTS (
          SELECT * FROM Comunications
          WHERE
            /* %JoinFKPK(Comunications,ComunicationType," = "," AND") */
            Comunications.ComunicationType = ComunicationType.ComunicationTypeID
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last Comunications because ComunicationType exists.'
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
CREATE TRIGGER tU_Comunications ON dbo.Comunications FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on Comunications */
BEGIN
  DECLARE  @numrows int,
           @nullcnt int,
           @validcnt int,
           @insComunicationID integer,
           @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)

  SELECT @numrows = @@rowcount
  /* ERwin Builtin Trigger */
  /* Human  Comunications on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00031fca", PARENT_OWNER="", PARENT_TABLE="Human"
    CHILD_OWNER="", CHILD_TABLE="Comunications"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_79", FK_COLUMNS="HumanID" */
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
             @errmsg = 'Cannot update Comunications because Human does not exist.'
      GOTO error
    END
  END

  /* ERwin Builtin Trigger */
  /* ComunicationType  Comunications on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="ComunicationType"
    CHILD_OWNER="", CHILD_TABLE="Comunications"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_75", FK_COLUMNS="ComunicationType" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(ComunicationType)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,ComunicationType
        WHERE
          /* %JoinFKPK(inserted,ComunicationType) */
          inserted.ComunicationType = ComunicationType.ComunicationTypeID
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    select @nullcnt = count(*) from inserted where
      inserted.ComunicationType IS NULL
    IF @validcnt + @nullcnt != @numrows
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update Comunications because ComunicationType does not exist.'
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
