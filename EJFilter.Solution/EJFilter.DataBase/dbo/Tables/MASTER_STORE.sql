CREATE TABLE [dbo].[MASTER_STORE] (
    [StoreId]   INT           IDENTITY (1, 1) NOT NULL,
    [StoreCode] INT           NOT NULL,
    [StoreName] VARCHAR (100) NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_MASTER_STORE]
    ON [dbo].[MASTER_STORE]([StoreCode] ASC);

