CREATE TABLE [dbo].[Departments] (
    [IDDepartment] INT           IDENTITY (0, 1) NOT NULL,
    [Name]         NVARCHAR (50) NOT NULL,
    CONSTRAINT [XPKDepartment] PRIMARY KEY CLUSTERED ([IDDepartment] ASC)
);


GO
CREATE TRIGGER tD_Departments ON Departments FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on Departments */
BEGIN
  DECLARE  @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* Departments  Positions on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="000117e4", PARENT_OWNER="", PARENT_TABLE="Departments"
    CHILD_OWNER="", CHILD_TABLE="Positions"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_85", FK_COLUMNS="IDDepartment" */
    IF EXISTS (
      SELECT * FROM deleted,Positions
      WHERE
        /*  %JoinFKPK(Positions,deleted," = "," AND") */
        Positions.IDDepartment = deleted.IDDepartment
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete Departments because Positions exists.'
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
CREATE TRIGGER tU_Departments ON Departments FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on Departments */
BEGIN
  DECLARE  @numrows int,
           @nullcnt int,
           @validcnt int,
           @insIDDepartment integer,
           @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)

  SELECT @numrows = @@rowcount
  /* ERwin Builtin Trigger */
  /* Departments  Positions on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00012e81", PARENT_OWNER="", PARENT_TABLE="Departments"
    CHILD_OWNER="", CHILD_TABLE="Positions"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_85", FK_COLUMNS="IDDepartment" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(IDDepartment)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,Positions
      WHERE
        /*  %JoinFKPK(Positions,deleted," = "," AND") */
        Positions.IDDepartment = deleted.IDDepartment
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update Departments because Positions exists.'
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
