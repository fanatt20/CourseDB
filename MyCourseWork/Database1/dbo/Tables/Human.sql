CREATE TABLE [dbo].[Human] (
    [HumanID]     INT            IDENTITY (0, 1) NOT NULL,
    [Name]        NVARCHAR (20)  NOT NULL,
    [Surname]     NVARCHAR (20)  NOT NULL,
    [Patronymic]  NVARCHAR (20)  NULL,
    [Birthday]    DATE           NOT NULL,
    [MedicalCard] INT            NULL,
    [Education]   NVARCHAR (300) NULL,
    CONSTRAINT [XPKHuman] PRIMARY KEY CLUSTERED ([HumanID] ASC)
);


GO
CREATE TRIGGER tD_Human ON Human FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on Human */
BEGIN
  DECLARE  @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* Human  MedicalInspectRegister on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="0003fc7c", PARENT_OWNER="", PARENT_TABLE="Human"
    CHILD_OWNER="", CHILD_TABLE="MedicalInspectRegister"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_82", FK_COLUMNS="HumanID" */
    IF EXISTS (
      SELECT * FROM deleted,MedicalInspectRegister
      WHERE
        /*  %JoinFKPK(MedicalInspectRegister,deleted," = "," AND") */
        MedicalInspectRegister.HumanID = deleted.HumanID
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete Human because MedicalInspectRegister exists.'
      GOTO error
    END

    /* ERwin Builtin Trigger */
    /* Human  AbsenceRegister on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Human"
    CHILD_OWNER="", CHILD_TABLE="AbsenceRegister"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_80", FK_COLUMNS="HumanID" */
    IF EXISTS (
      SELECT * FROM deleted,AbsenceRegister
      WHERE
        /*  %JoinFKPK(AbsenceRegister,deleted," = "," AND") */
        AbsenceRegister.HumanID = deleted.HumanID
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete Human because AbsenceRegister exists.'
      GOTO error
    END

    /* ERwin Builtin Trigger */
    /* Human  Comunications on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Human"
    CHILD_OWNER="", CHILD_TABLE="Comunications"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_79", FK_COLUMNS="HumanID" */
    IF EXISTS (
      SELECT * FROM deleted,Comunications
      WHERE
        /*  %JoinFKPK(Comunications,deleted," = "," AND") */
        Comunications.HumanID = deleted.HumanID
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete Human because Comunications exists.'
      GOTO error
    END

    /* ERwin Builtin Trigger */
    /* Human  Contracts on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Human"
    CHILD_OWNER="", CHILD_TABLE="Contracts"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_55", FK_COLUMNS="HumanID" */
    IF EXISTS (
      SELECT * FROM deleted,Contracts
      WHERE
        /*  %JoinFKPK(Contracts,deleted," = "," AND") */
        Contracts.HumanID = deleted.HumanID
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete Human because Contracts exists.'
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
CREATE TRIGGER tU_Human ON Human FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on Human */
BEGIN
  DECLARE  @numrows int,
           @nullcnt int,
           @validcnt int,
           @insHumanID integer,
           @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)

  SELECT @numrows = @@rowcount
  /* ERwin Builtin Trigger */
  /* Human  MedicalInspectRegister on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00045aca", PARENT_OWNER="", PARENT_TABLE="Human"
    CHILD_OWNER="", CHILD_TABLE="MedicalInspectRegister"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_82", FK_COLUMNS="HumanID" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(HumanID)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,MedicalInspectRegister
      WHERE
        /*  %JoinFKPK(MedicalInspectRegister,deleted," = "," AND") */
        MedicalInspectRegister.HumanID = deleted.HumanID
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update Human because MedicalInspectRegister exists.'
      GOTO error
    END
  END

  /* ERwin Builtin Trigger */
  /* Human  AbsenceRegister on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Human"
    CHILD_OWNER="", CHILD_TABLE="AbsenceRegister"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_80", FK_COLUMNS="HumanID" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(HumanID)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,AbsenceRegister
      WHERE
        /*  %JoinFKPK(AbsenceRegister,deleted," = "," AND") */
        AbsenceRegister.HumanID = deleted.HumanID
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update Human because AbsenceRegister exists.'
      GOTO error
    END
  END

  /* ERwin Builtin Trigger */
  /* Human  Comunications on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Human"
    CHILD_OWNER="", CHILD_TABLE="Comunications"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_79", FK_COLUMNS="HumanID" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(HumanID)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,Comunications
      WHERE
        /*  %JoinFKPK(Comunications,deleted," = "," AND") */
        Comunications.HumanID = deleted.HumanID
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update Human because Comunications exists.'
      GOTO error
    END
  END

  /* ERwin Builtin Trigger */
  /* Human  Contracts on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Human"
    CHILD_OWNER="", CHILD_TABLE="Contracts"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_55", FK_COLUMNS="HumanID" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(HumanID)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,Contracts
      WHERE
        /*  %JoinFKPK(Contracts,deleted," = "," AND") */
        Contracts.HumanID = deleted.HumanID
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update Human because Contracts exists.'
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
