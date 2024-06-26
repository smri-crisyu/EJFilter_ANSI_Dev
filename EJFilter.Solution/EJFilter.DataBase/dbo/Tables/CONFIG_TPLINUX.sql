﻿CREATE TABLE [dbo].[CONFIG_TPLINUX] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [BRANCH_CODE]  VARCHAR (50)  NULL,
    [STORE_CODE]   VARCHAR (50)  NULL,
    [TYPE]         VARCHAR (50)  NULL,
    [COMPANY]      VARCHAR (200) NULL,
    [LOCATION]     VARCHAR (200) NULL,
    [ADDRESS_1]    VARCHAR (200) NULL,
    [ADDRESS_2]    VARCHAR (200) NULL,
    [ADDRESS_3]    VARCHAR (200) NULL,
    [ZIP_LOCATION] VARCHAR (100) NULL,
    [ZIP_CODE]     VARCHAR (100) NULL,
    [VATREGTIN_H]  VARCHAR (100) NULL,
    [SN_NO]        VARCHAR (50)  NULL,
    [MIN_NO]       VARCHAR (50)  NULL,
    [PTU_NO]       VARCHAR (50)  NULL,
    [VATREGTIN_F]  VARCHAR (50)  NULL,
    [ACCR_NO]      VARCHAR (50)  NULL,
    [DATE]         VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

