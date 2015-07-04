﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping_Mall.Database
{
    public class DBFunction
    {
        private String tableName = "product";
        //依照欄位查詢
        public String[] searchByColumn(String fieldName)
        {
            DBConnector db = new DBConnector();
            String sqlStr = "SELECT " + fieldName + " FROM " + tableName;
            return db.sqlSelect(sqlStr);
        }
        //查詢Schema
        public String[] searchSchema(String fieldName)
        {
            DBConnector db = new DBConnector();
            String sqlStr = "SELECT id FROM sysobjects WHERE name = '" + tableName + "'";
            String[] id = db.sqlSelect(sqlStr);

            String sqlResult = "SELECT name FROM syscolumns WHERE id='" + id[0] + "'";
            return db.sqlSelect(sqlResult);
        }
        //查詢列
        public String[] searchByRow(String column, String value)
        {
            DBConnector db = new DBConnector();
            String sqlStr = "SELECT * FROM " + tableName + " WHERE " + column + " = '" + value + "'";

            return db.sqlSelect(sqlStr); 
        }
        //查詢範圍內的資料列
        public String[] searchByRow(String column, int minValue, int maxValue)
        {
            DBConnector db = new DBConnector();
            String sqlStr = "SELECT * FROM " + tableName + " WHERE " + column + " >= " + minValue + " AND " + column + " <= " + maxValue;

            return db.sqlSelect(sqlStr);
        }
        //新增列
        public String insert(String[] attributes, String[] value)
        {
            DBConnector db = new DBConnector();
            String s = "INSERT INTO [product](";
            for (int i = 1; i < attributes.Length-1; i++)
            {
                s += "[" + attributes[i] + "],";
            }
            s += "[" + attributes[attributes.Length - 1] + "])VALUES(";
            
            for (int i = 1; i < value.Length-1; i++)
            {
                s += "'" + value[i] + "',";
            }
            s += "'" + value[value.Length-1] + "')";
            return db.sql(s);
        }
        //刪除列
        public String delete(String fieldName, String value)
        {
            DBConnector db = new DBConnector();
            String sqlStr = "DELETE FROM "+tableName+" WHERE ["+fieldName +"] = '" + value + "'";
            return db.sql(sqlStr);
        }
        //修改字串欄位
        public String modify(String modifyColumn, String modifyValue, String conditionColumn, String conditionValue)
        {
            DBConnector db = new DBConnector();
            String sqlStr = "UPDATE " + tableName + " SET " + modifyColumn + " = '" + modifyValue + "' WHERE " + conditionColumn + " = '" + conditionValue + "'";
            return db.sql(sqlStr);
        }
        //修改數值欄位
        public String modify(String modifyColumn, int modifyValue, String conditionColumn, String conditionValue)
        {
            DBConnector db = new DBConnector();
            String sqlStr = "UPDATE " + tableName + " SET " + modifyColumn + " = " + modifyValue + " WHERE " + conditionColumn + " = '" + conditionValue + "'";
            return db.sql(sqlStr);
        }

    }
}