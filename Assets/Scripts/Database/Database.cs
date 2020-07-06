using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SqLite References
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.UI;
using Assets.Scripts.Model;

namespace Assets.Scripts.Database
{
    public class Database
    {
        private string conn, sqlQuery;
        IDbConnection dbconn;
        IDbCommand dbcmd;
        private IDataReader reader;

        string DatabaseName = "log.s3db";

        public Database()
        {
            string filepath = Application.persistentDataPath + "/" + DatabaseName;
            if (!File.Exists(filepath))
            {
                Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                                 Application.dataPath + "!/assets/Employers");

                #if PLATFORM_ANDROID
                WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/log.s3db");
                while (!loadDB.isDone) { }
                File.WriteAllBytes(filepath, loadDB.bytes);
                #else
                var loadDb = Application.dataPath + "/Raw/" + DatabaseName;
                // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
                #endif
            }

            conn = "URI=file:" + filepath;

            Debug.Log("Establishing connection to: " + conn);
            dbconn = new SqliteConnection(conn);
            dbconn.Open();

            string query;
            query = "CREATE TABLE SearchLog (ID INTEGER PRIMARY KEY AUTOINCREMENT, caseNo varchar(100), fullName varchar(200))";
            try
            {
                dbcmd = dbconn.CreateCommand();
                dbcmd.CommandText = query;
                reader = dbcmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }

        public void InsertLog(Case caseObject)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();
                sqlQuery = string.Format($"insert into SearchLog (caseNo, fullName) values (\"{caseObject.CaseNo}\",\"{caseObject.FullName}\")");
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
            Debug.Log("Insert Done  ");
        }

        public string ReadAllLog()
        {
            string caseNo, fullName, returnString = "";
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                IDbCommand dbcmd = dbconn.CreateCommand();
                string sqlQuery = "SELECT  caseNo, fullName " + "FROM SearchLog";
                dbcmd.CommandText = sqlQuery;
                IDataReader reader = dbcmd.ExecuteReader();
                while (reader.Read())
                {
                    caseNo = reader.GetString(0);
                    fullName = reader.GetString(1);

                    returnString += caseNo + " - " + fullName + "\n";
                    Debug.Log(" caseNo =" + caseNo + "fullName=" + fullName);
                }
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                dbconn.Close();

                return returnString;
            }
        }

        public string ReadLogById(string id)
        {
            string caseNo, fullName, returnString = "";
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                IDbCommand dbcmd = dbconn.CreateCommand();
                string sqlQuery = "SELECT caseNo, fullName " + "FROM SearchLog where id =" + id;
                dbcmd.CommandText = sqlQuery;
                IDataReader reader = dbcmd.ExecuteReader();
                while (reader.Read())
                {
                    caseNo = reader.GetString(0);
                    fullName = reader.GetString(1);
                    returnString += caseNo + " - " + fullName + "\n";

                    Debug.Log(" caseNo =" + caseNo + "fullName=" + fullName);

                }
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                dbconn.Close();

                return returnString;
            }
        }
    }
}