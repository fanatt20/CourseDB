CREATE TABLE [dbo].[MedicalStates] (
    [StateID] INT          IDENTITY (0, 1) NOT NULL,
    [Name]    VARCHAR (30) NOT NULL,
    CONSTRAINT [XPKMedicalStates] PRIMARY KEY CLUSTERED ([StateID] ASC)
);


GO
CREATE TRIGGER tD_MedicalStates ON MedicalStates FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on MedicalStates */
BEGIN
  DECLARE  @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* MedicalStates  MedicalInspectRegister on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="00012e48", PARENT_OWNER="", PARENT_TABLE="MedicalStates"
    CHILD_OWNER="", CHILD_TABLE="MedicalInspectRegister"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_24", FK_COLUMNS="StateID" */
    IF EXISTS (
      SELECT * FROM deleted,MedicalInspectRegister
      WHERE
        /*  %JoinFKPK(MedicalInspectRegister,deleted," = "," AND") */
        MedicalInspectRegister.StateID = deleted.StateID
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete MedicalStates because MedicalInspectRegister exists.'
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
CREATE TRIGGER tU_MedicalStates ON MedicalStates FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on MedicalStates */
BEGIN
  DECLARE  @numrows int,
           @nullcnt int,
           @validcnt int,
           @insStateID integer,
           @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)

  SELECT @numrows = @@rowcount
  /* ERwin Builtin Trigger */
  /* MedicalStates  MedicalInspectRegister on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="0001431a", PARENT_OWNER="", PARENT_TABLE="MedicalStates"
    CHILD_OWNER="", CHILD_TABLE="MedicalInspectRegister"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_24", FK_COLUMNS="StateID" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(StateID)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,MedicalInspectRegister
      WHERE
        /*  %JoinFKPK(MedicalInspectRegister,deleted," = "," AND") */
        MedicalInspectRegister.StateID = deleted.StateID
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update MedicalStates because MedicalInspectRegister exists.'
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
