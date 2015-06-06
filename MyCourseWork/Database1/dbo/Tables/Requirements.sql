CREATE TABLE [dbo].[Requirements] (
    [IDRequirements] INT           IDENTITY (0, 1) NOT NULL,
    [Name]           NVARCHAR (60) NULL,
    CONSTRAINT [XPKRequirements] PRIMARY KEY CLUSTERED ([IDRequirements] ASC)
);


GO
CREATE TRIGGER tD_Requirements ON Requirements FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on Requirements */
BEGIN
  DECLARE  @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* Requirements  PositionRequirements on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="0001389e", PARENT_OWNER="", PARENT_TABLE="Requirements"
    CHILD_OWNER="", CHILD_TABLE="PositionRequirements"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_83", FK_COLUMNS="IDRequirements" */
    IF EXISTS (
      SELECT * FROM deleted,PositionRequirements
      WHERE
        /*  %JoinFKPK(PositionRequirements,deleted," = "," AND") */
        PositionRequirements.IDRequirements = deleted.IDRequirements
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete Requirements because PositionRequirements exists.'
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
CREATE TRIGGER tU_Requirements ON Requirements FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on Requirements */
BEGIN
  DECLARE  @numrows int,
           @nullcnt int,
           @validcnt int,
           @insIDRequirements integer,
           @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)

  SELECT @numrows = @@rowcount
  /* ERwin Builtin Trigger */
  /* Requirements  PositionRequirements on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00015247", PARENT_OWNER="", PARENT_TABLE="Requirements"
    CHILD_OWNER="", CHILD_TABLE="PositionRequirements"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_83", FK_COLUMNS="IDRequirements" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDRequirements)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,PositionRequirements
      WHERE
        /*  %JoinFKPK(PositionRequirements,deleted," = "," AND") */
        PositionRequirements.IDRequirements = deleted.IDRequirements
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update Requirements because PositionRequirements exists.'
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
