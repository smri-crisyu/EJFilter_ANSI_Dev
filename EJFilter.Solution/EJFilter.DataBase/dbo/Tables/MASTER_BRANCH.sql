CREATE TABLE [dbo].[MASTER_BRANCH] (
    [BranchId]   INT           IDENTITY (1, 1) NOT NULL,
    [BranchCode] INT           NOT NULL,
    [BranchName] VARCHAR (100) NOT NULL,
    [StoreCode]  INT           NOT NULL,
    CONSTRAINT [PK_MASTER_BRANCH] PRIMARY KEY CLUSTERED ([BranchId] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_MASTER_BRANCH]
    ON [dbo].[MASTER_BRANCH]([BranchCode] ASC, [StoreCode] ASC);

