CREATE TABLE [dbo].[AbsenceRegister] (
    [AbsenceRegisterID] INT  IDENTITY (0, 1) NOT NULL,
    [HumanID]           INT  NOT NULL,
    [IDAbsenceReason]   INT  NOT NULL,
    [StartAt]           DATE NOT NULL,
    [EndAt]             DATE NULL,
    CONSTRAINT [XPKAbsence] PRIMARY KEY CLUSTERED ([AbsenceRegisterID] ASC),
    CONSTRAINT [R_80] FOREIGN KEY ([HumanID]) REFERENCES [dbo].[Human] ([HumanID]),
    CONSTRAINT [R_87] FOREIGN KEY ([IDAbsenceReason]) REFERENCES [dbo].[AbsenceReason] ([IDAbsenceReason])
);


GO
CREATE TRIGGER tD_AbsenceRegister ON dbo.AbsenceRegister FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on AbsenceRegister */
BEGIN
  DECLARE  @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* AbsenceReason  AbsenceRegister on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00029cbd", PARENT_OWNER="", PARENT_TABLE="AbsenceReason"
    CHILD_OWNER="", CHILD_TABLE="AbsenceRegister"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_87", FK_COLUMNS="IDAbsenceReason" */
    IF EXISTS (SELECT * FROM deleted,AbsenceReason
      WHERE
        /* %JoinFKPK(deleted,AbsenceReason," = "," AND") */
        deleted.IDAbsenceReason = AbsenceReason.IDAbsenceReason AND
        NOT EXISTS (
          SELECT * FROM AbsenceRegister
          WHERE
            /* %JoinFKPK(AbsenceRegister,AbsenceReason," = "," AND") */
            AbsenceRegister.IDAbsenceReason = AbsenceReason.IDAbsenceReason
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last AbsenceRegister because AbsenceReason exists.'
      GOTO error
    END

    /* ERwin Builtin Trigger */
    /* Human  AbsenceRegister on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Human"
    CHILD_OWNER="", CHILD_TABLE="AbsenceRegister"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_80", FK_COLUMNS="HumanID" */
    IF EXISTS (SELECT * FROM deleted,Human
      WHERE
        /* %JoinFKPK(deleted,Human," = "," AND") */
        deleted.HumanID = Human.HumanID AND
        NOT EXISTS (
          SELECT * FROM AbsenceRegister
          WHERE
            /* %JoinFKPK(AbsenceRegister,Human," = "," AND") */
            AbsenceRegister.HumanID = Human.HumanID
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last AbsenceRegister because Human exists.'
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
CREATE TRIGGER tU_AbsenceRegister ON dbo.AbsenceRegister FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on AbsenceRegister */
BEGIN
  DECLARE  @numrows int,
           @nullcnt int,
           @validcnt int,
           @insAbsenceRegisterID integer,
           @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)

  SELECT @numrows = @@rowcount
  /* ERwin Builtin Trigger */
  /* AbsenceReason  AbsenceRegister on child update no action */
  /* ERWIN_RELATION:CHECKSUM="000322db", PARENT_OWNER="", PARENT_TABLE="AbsenceReason"
    CHILD_OWNER="", CHILD_TABLE="AbsenceRegister"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_87", FK_COLUMNS="IDAbsenceReason" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(IDAbsenceReason)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,AbsenceReason
        WHERE
          /* %JoinFKPK(inserted,AbsenceReason) */
          inserted.IDAbsenceReason = AbsenceReason.IDAbsenceReason
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    select @nullcnt = count(*) from inserted where
      inserted.IDAbsenceReason IS NULL
    IF @validcnt + @nullcnt != @numrows
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update AbsenceRegister because AbsenceReason does not exist.'
      GOTO error
    END
  END

  /* ERwin Builtin Trigger */
  /* Human  AbsenceRegister on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Human"
    CHILD_OWNER="", CHILD_TABLE="AbsenceRegister"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_80", FK_COLUMNS="HumanID" */
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
             @errmsg = 'Cannot update AbsenceRegister because Human does not exist.'
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
