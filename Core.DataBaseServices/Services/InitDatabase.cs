﻿using Core.FreeSqlServices;
using Core.UsuallyCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataBaseServices
{
    public class InitDatabase : SystemServices
    {
        public InitDatabase() : base(DataBaseFactory.Core_DataBase.FreeSql)
        {
            //ClearTable();
            InitConfig();
        }

        public void ClearTable()
        {
            DataBaseFactory.Core_DataBase.FreeSql.Ado.ExecuteNonQuery(CommonSQL.ClearTableSql);
        }

        public void InitConfig()
        {
            // 初始化数据库设置
            if (!GetEntitys<SQLConfig>().Any())
            {
                SQLConfig configSqlserver = new SQLConfig()
                {
                    Type = FreeSql.DataType.SqlServer,
                    GetDataBaseSQL = "SELECT name AS DataBaseName FROM sys.sysdatabases ORDER BY name",
                    GetTableSQL = @"select DB_NAME() As DataBaseName,a.name AS TableName,ISNULL(b.value,'') AS TableDescription,(CASE WHEN b.value IS NULL THEN '0' ELSE 1 END ) HasDescription from sys.tables a LEFT JOIN  sys.extended_properties  b 
                                on a.object_id = b.major_id AND  b.minor_id = 0 ORDER BY a.name",
                    GetColumnSQL = @" 
                               SELECT	
	DB_NAME() AS DataBaseName,	
    obj.name AS TableName,
    col.name as ColumnName,
    col.is_identity IsIdentity,
    convert(bit,(case when col.is_nullable = 0 then 1 else 0 end)) as IsRequire,
    convert(int,col.max_length) as MaxLength,
    tp.name as SQLType,
    ep.value as ColumnDescription,
    convert(bit,(
        select count(*) from sys.sysobjects
        where parent_obj=obj.id
        and name=(
            select top 1 name from sys.sysindexes ind
            inner join sys.sysindexkeys indkey
            on ind.indid=indkey.indid
            and indkey.colid=col.column_id
            and indkey.id=obj.id
            where ind.id=obj.id
            and ind.name like 'PK_%'
        )
    )) as IsPrimarykey
    from sys.sysobjects obj
    inner join sys.columns col
    on obj.id = col.object_id
    left join sys.systypes tp
    on col.system_type_id=tp.xusertype
    left join sys.extended_properties ep
    on ep.major_id=obj.id
    and ep.minor_id=col.column_id
    and ep.name='MS_Description' where obj.xtype = 'U'
    order BY obj.name,col.column_id  ",
                    AddExtendedproperty = @"EXECUTE sp_addextendedproperty N'MS_Description', '{2}', N'user', N'dbo', N'table', N'{0}', N'column', N'{1}'"
                   ,
                    ModifyExtendedproperty = @"EXECUTE sp_updateextendedproperty 'MS_Description', '{2}', 'user', dbo, 'table', '{0}', 'column', {1}"
                   ,
                    AddTableExtendedproperty = @"EXECUTE sp_addextendedproperty   N'MS_Description','{1}',N'user',N'dbo',N'table',N'{0}',NULL,NULL"
                   ,
                    ModifyTableExtendedproperty = @"EXECUTE sp_updateextendedproperty   N'MS_Description','{1}',N'user',N'dbo',N'table',N'{0}',NULL,NULL"
                };
                SQLConfig configMySql = new SQLConfig()
                {
                    Type = FreeSql.DataType.MySql,
                    GetDataBaseSQL = "SELECT `SCHEMA_NAME`   as DataBaseName FROM `information_schema`.`SCHEMATA`",
                    GetTableSQL = @"use information_schema;  
                                select table_name as TableName,
                                table_comment As TableDescription from tables where table_schema = '@DataBaseName'",
                    GetColumnSQL = @"
                                use {1};
                                SELECT TABLE_NAME 'TableName'
                                ,ORDINAL_POSITION 'ORDINAL_POSITION'
                                ,COLUMN_NAME 'ColumnName'
                                ,COLUMN_DEFAULT 'COLUMN_DEFAULT',
                                CASE WHEN IS_NULLABLE = 'YES' THEN 1 ELSE 0 END AS 'IsRequire'
																,DATA_TYPE 'SQLType'
                                ,CASE WHEN  ISNULL(CHARACTER_MAXIMUM_LENGTH) = 1 THEN 0 ELSE CHARACTER_MAXIMUM_LENGTH END AS 'MaxLength'
                                ,COLUMN_COMMENT 'ColumnDescription'
                                ,CASE WHEN COLUMN_KEY = 'PRI' THEN 1 ELSE 0 END AS IsPrimarykey
								,CASE WHEN EXTRA ='auto_increment'  THEN 1 ELSE 0 END AS IsIdentity
                                FROM INFORMATION_SCHEMA.COLUMNS  
                                WHERE    TABLE_NAME='{2}' and table_schema = '{1}';
                                 "
                };
                Create<SQLConfig>(configSqlserver);
                Create<SQLConfig>(configMySql);
                 
            }
        }
    }
}
