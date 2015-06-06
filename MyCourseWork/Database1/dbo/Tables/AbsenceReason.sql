CREATE TABLE [dbo].[AbsenceReason] (
    [IDAbsenceReason] INT           IDENTITY (0, 1) NOT NULL,
    [Reason]          NVARCHAR (50) NOT NULL,
    CONSTRAINT [XPKAbsenceReason] PRIMARY KEY CLUSTERED ([IDAbsenceReason] ASC)
);


GO
CREATE TRIGGER tD_AbsenceReason ON AbsenceReason FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on AbsenceReason */
BEGIN
  DECLARE  @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* AbsenceReason  AbsenceRegister on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="00013058", PARENT_OWNER="", PARENT_TABLE="AbsenceReason"
    CHILD_OWNER="", CHILD_TABLE="AbsenceRegister"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_87", FK_COLUMNS="IDAbsenceReason" */
    IF EXISTS (
      SELECT * FROM deleted,AbsenceRegister
      WHERE
        /*  %JoinFKPK(AbsenceRegister,deleted," = "," AND") */
        AbsenceRegister.IDAbsenceReason = deleted.IDAbsenceReason
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete AbsenceReason because AbsenceRegister exists.'
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
CREATE TRIGGER tU_AbsenceReason ON AbsenceReason FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on AbsenceReason */
BEGIN
  DECLARE  @numrows int,
           @nullcnt int,
           @validcnt int,
           @insIDAbsenceReason integer,
           @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)

  SELECT @numrows = @@rowcount
  /* ERwin Builtin Trigger */
  /* AbsenceReason  AbsenceRegister on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="000140f7", PARENT_OWNER="", PARENT_TABLE="AbsenceReason"
    CHILD_OWNER="", CHILD_TABLE="AbsenceRegister"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_87", FK_COLUMNS="IDAbsenceReason" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDAbsenceReason)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,AbsenceRegister
      WHERE
        /*  %JoinFKPK(AbsenceRegister,deleted," = "," AND") */
        AbsenceRegister.IDAbsenceReason = deleted.IDAbsenceReason
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update AbsenceReason because AbsenceRegister exists.'
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
