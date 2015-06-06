CREATE TABLE [dbo].[MembersSchedule] (
    [MembersSchdeleID] INT           IDENTITY (0, 1) NOT NULL,
    [ContractID]       INT           NOT NULL,
    [DayName]          NVARCHAR (20) NOT NULL,
    [StartWorkAt]      TIME (7)      NULL,
    [EndWorkAt]        TIME (7)      NULL,
    CONSTRAINT [XPKMembersSchudele] PRIMARY KEY CLUSTERED ([MembersSchdeleID] ASC),
    CONSTRAINT [R_86] FOREIGN KEY ([ContractID]) REFERENCES [dbo].[Contracts] ([ContractID])
);


GO
CREATE TRIGGER tD_MembersSchedule ON dbo.MembersSchedule FOR DELETE AS
/* ERwin Builtin Trigger */
/* DELETE trigger on MembersSchedule */
BEGIN
  DECLARE  @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)
    /* ERwin Builtin Trigger */
    /* Contracts  MembersSchedule on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="000169b7", PARENT_OWNER="", PARENT_TABLE="Contracts"
    CHILD_OWNER="", CHILD_TABLE="MembersSchedule"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_86", FK_COLUMNS="ContractID" */
    IF EXISTS (SELECT * FROM deleted,Contracts
      WHERE
        /* %JoinFKPK(deleted,Contracts," = "," AND") */
        deleted.ContractID = Contracts.ContractID AND
        NOT EXISTS (
          SELECT * FROM MembersSchedule
          WHERE
            /* %JoinFKPK(MembersSchedule,Contracts," = "," AND") */
            MembersSchedule.ContractID = Contracts.ContractID
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last MembersSchedule because Contracts exists.'
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
CREATE TRIGGER tU_MembersSchedule ON dbo.MembersSchedule FOR UPDATE AS
/* ERwin Builtin Trigger */
/* UPDATE trigger on MembersSchedule */
BEGIN
  DECLARE  @numrows int,
           @nullcnt int,
           @validcnt int,
           @insMembersSchdeleID integer,
           @errno   int,
           @severity int,
           @state    int,
           @errmsg  varchar(255)

  SELECT @numrows = @@rowcount
  /* ERwin Builtin Trigger */
  /* Contracts  MembersSchedule on child update no action */
  /* ERWIN_RELATION:CHECKSUM="0001937e", PARENT_OWNER="", PARENT_TABLE="Contracts"
    CHILD_OWNER="", CHILD_TABLE="MembersSchedule"
    P2C_VERB_PHRASE="", C2P_VERB_PHRASE="", 
    FK_CONSTRAINT="R_86", FK_COLUMNS="ContractID" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(ContractID)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,Contracts
        WHERE
          /* %JoinFKPK(inserted,Contracts) */
          inserted.ContractID = Contracts.ContractID
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    select @nullcnt = count(*) from inserted where
      inserted.ContractID IS NULL
    IF @validcnt + @nullcnt != @numrows
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update MembersSchedule because Contracts does not exist.'
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
