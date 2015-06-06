CREATE TABLE [dbo].[Contracts] (
    [ContractID]       INT   IDENTITY (0, 1) NOT NULL,
    [HumanID]          INT   NOT NULL,
    [IDPosition]       INT   NOT NULL,
    [Salary]           MONEY NOT NULL,
    [DateOfSigning]    DATE  NOT NULL,
    [EndAtOfficial]    DATE  NOT NULL,
    [EndAtPractically] DATE  NULL,
    [PreviousContract] INT   NULL,
    CONSTRAINT [XPKContract] PRIMARY KEY CLUSTERED ([ContractID] ASC),
    CONSTRAINT [R_21] FOREIGN KEY ([IDPosition]) REFERENCES [dbo].[Positions] ([IDPosition]),
    CONSTRAINT [R_55] FOREIGN KEY ([HumanID]) REFERENCES [dbo].[Human] ([HumanID])
);


GO
CREATE TRIGGER tD_Contracts ON dbo.Contracts FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on Contracts */
BEGIN
  DECLARE  @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* Contracts  MembersSchedule on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="000378be", PARENT_OWNER="", PARENT_TABLE="Contracts"
    CHILD_OWNER="", CHILD_TABLE="MembersSchedule"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_86", FK_COLUMNS="ContractID" */
    IF EXISTS (
      SELECT * FROM deleted,MembersSchedule
      WHERE
        /*  %JoinFKPK(MembersSchedule,deleted," = "," AND") */
        MembersSchedule.ContractID = deleted.ContractID
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete Contracts because MembersSchedule exists.'
      GOTO error
    END

    /* ERwin Builtin Trigger */
    /* Human  Contracts on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Human"
    CHILD_OWNER="", CHILD_TABLE="Contracts"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_55", FK_COLUMNS="HumanID" */
    IF EXISTS (SELECT * FROM deleted,Human
      WHERE
        /* %JoinFKPK(deleted,Human," = "," AND") */
        deleted.HumanID = Human.HumanID AND
        NOT EXISTS (
          SELECT * FROM Contracts
          WHERE
            /* %JoinFKPK(Contracts,Human," = "," AND") */
            Contracts.HumanID = Human.HumanID
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last Contracts because Human exists.'
      GOTO error
    END

    /* ERwin Builtin Trigger */
    /* Positions  Contracts on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Positions"
    CHILD_OWNER="", CHILD_TABLE="Contracts"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_21", FK_COLUMNS="IDPosition" */
    IF EXISTS (SELECT * FROM deleted,Positions
      WHERE
        /* %JoinFKPK(deleted,Positions," = "," AND") */
        deleted.IDPosition = Positions.IDPosition AND
        NOT EXISTS (
          SELECT * FROM Contracts
          WHERE
            /* %JoinFKPK(Contracts,Positions," = "," AND") */
            Contracts.IDPosition = Positions.IDPosition
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last Contracts because Positions exists.'
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
CREATE TRIGGER tU_Contracts ON dbo.Contracts FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on Contracts */
BEGIN
  DECLARE  @numrows int,
           @nullcnt int,
           @validcnt int,
           @insContractID integer,
           @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)

  SELECT @numrows = @@rowcount
  /* ERwin Builtin Trigger */
  /* Contracts  MembersSchedule on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00040c71", PARENT_OWNER="", PARENT_TABLE="Contracts"
    CHILD_OWNER="", CHILD_TABLE="MembersSchedule"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_86", FK_COLUMNS="ContractID" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(ContractID)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,MembersSchedule
      WHERE
        /*  %JoinFKPK(MembersSchedule,deleted," = "," AND") */
        MembersSchedule.ContractID = deleted.ContractID
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update Contracts because MembersSchedule exists.'
      GOTO error
    END
  END

  /* ERwin Builtin Trigger */
  /* Human  Contracts on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Human"
    CHILD_OWNER="", CHILD_TABLE="Contracts"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_55", FK_COLUMNS="HumanID" */
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
             @errmsg = 'Cannot update Contracts because Human does not exist.'
      GOTO error
    END
  END

  /* ERwin Builtin Trigger */
  /* Positions  Contracts on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Positions"
    CHILD_OWNER="", CHILD_TABLE="Contracts"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_21", FK_COLUMNS="IDPosition" */
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
             @errmsg = 'Cannot update Contracts because Positions does not exist.'
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
