CREATE TABLE [dbo].[ComunicationType] (
    [ComunicationTypeID] INT           IDENTITY (0, 1) NOT NULL,
    [Name]               NVARCHAR (20) NULL,
    CONSTRAINT [XPKComunicationType] PRIMARY KEY CLUSTERED ([ComunicationTypeID] ASC)
);


GO
CREATE TRIGGER tD_ComunicationType ON ComunicationType FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on ComunicationType */
BEGIN
  DECLARE  @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* ComunicationType  Comunications on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="000132bb", PARENT_OWNER="", PARENT_TABLE="ComunicationType"
    CHILD_OWNER="", CHILD_TABLE="Comunications"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_75", FK_COLUMNS="ComunicationType" */
    IF EXISTS (
      SELECT * FROM deleted,Comunications
      WHERE
        /*  %JoinFKPK(Comunications,deleted," = "," AND") */
        Comunications.ComunicationType = deleted.ComunicationTypeID
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete ComunicationType because Comunications exists.'
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
CREATE TRIGGER tU_ComunicationType ON ComunicationType FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on ComunicationType */
BEGIN
  DECLARE  @numrows int,
           @nullcnt int,
           @validcnt int,
           @insComunicationTypeID integer,
           @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)

  SELECT @numrows = @@rowcount
  /* ERwin Builtin Trigger */
  /* ComunicationType  Comunications on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00014cb7", PARENT_OWNER="", PARENT_TABLE="ComunicationType"
    CHILD_OWNER="", CHILD_TABLE="Comunications"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_75", FK_COLUMNS="ComunicationType" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(ComunicationTypeID)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,Comunications
      WHERE
        /*  %JoinFKPK(Comunications,deleted," = "," AND") */
        Comunications.ComunicationType = deleted.ComunicationTypeID
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update ComunicationType because Comunications exists.'
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
