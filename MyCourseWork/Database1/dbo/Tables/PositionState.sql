CREATE TABLE [dbo].[PositionState] (
    [PositionStateID] INT           IDENTITY (0, 1) NOT NULL,
    [PositionState]   NVARCHAR (50) NOT NULL,
    CONSTRAINT [XPKPositionState] PRIMARY KEY CLUSTERED ([PositionStateID] ASC)
);


GO
CREATE TRIGGER tD_PositionState ON PositionState FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on PositionState */
BEGIN
  DECLARE  @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* PositionState  Positions on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="000116d9", PARENT_OWNER="", PARENT_TABLE="PositionState"
    CHILD_OWNER="", CHILD_TABLE="Positions"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_88", FK_COLUMNS="PositionStateID" */
    IF EXISTS (
      SELECT * FROM deleted,Positions
      WHERE
        /*  %JoinFKPK(Positions,deleted," = "," AND") */
        Positions.PositionStateID = deleted.PositionStateID
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete PositionState because Positions exists.'
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
CREATE TRIGGER tU_PositionState ON PositionState FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on PositionState */
BEGIN
  DECLARE  @numrows int,
           @nullcnt int,
           @validcnt int,
           @insPositionStateID integer,
           @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)

  SELECT @numrows = @@rowcount
  /* ERwin Builtin Trigger */
  /* PositionState  Positions on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00013f98", PARENT_OWNER="", PARENT_TABLE="PositionState"
    CHILD_OWNER="", CHILD_TABLE="Positions"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_88", FK_COLUMNS="PositionStateID" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(PositionStateID)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,Positions
      WHERE
        /*  %JoinFKPK(Positions,deleted," = "," AND") */
        Positions.PositionStateID = deleted.PositionStateID
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update PositionState because Positions exists.'
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
