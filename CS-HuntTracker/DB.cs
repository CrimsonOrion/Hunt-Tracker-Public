using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace CS_HuntTracker
{
    class DB
    {
        // Get the proper Connection string        
        private static string ConnectionString { get; } = Cred.ConnectionString;

        public static bool TestConnection()
        {
            bool result = false;

            try
            {
                MySqlConnection dbConnection = new MySqlConnection(ConnectionString);
                dbConnection.Open();
                if (dbConnection.State == ConnectionState.Open)
                {
                    result = true;
                    dbConnection.Close();
                }

                return result;
            }
            catch (Exception e)
            {
                ErrorMessages.LogError(e, MethodBase.GetCurrentMethod().Name);
                return result;
            }
        }
        
        public static void GetZoneInfo()
        {
            Zone.GetZones = new List<Zone>();
            string queryString = "SELECT tablename, name, region FROM `Zones`;";

            try
            {
                MySqlConnection dbConnection = new MySqlConnection(ConnectionString);
                // Open the database to work with it
                dbConnection.Open();

                // Prepare the query to run with dbCommand
                using (MySqlCommand dbCommand = new MySqlCommand(queryString, dbConnection))
                {
                    // Execute the query
                    using (MySqlDataReader queryReader = dbCommand.ExecuteReader())
                    {
                        // while the results are still being read...
                        while (queryReader.Read())
                        {
                            // Get the new coordinates to put on the map
                            Zone.GetZones.Add(new Zone(queryReader.GetString(0), queryReader.GetString(1), queryReader.GetString(2)));
                        }
                    }
                }

                dbConnection.Close();
            }
            catch (Exception e)
            {                
                ErrorMessages.LogError(e, MethodBase.GetCurrentMethod().Name);
            }            
        }

        public static List<SpawnPoint> GetSpawnPoints(HuntMapForm zone, string type)
        {
            List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
            string queryString = $"SELECT x, y, id, mobb, moba, mobs, mobb2, moba2 FROM `{zone.Name}`;";            

            try
            {
                MySqlConnection dbConnection = new MySqlConnection(ConnectionString);
                // Open the database to work with it
                dbConnection.Open();

                // Prepare the query to run with dbCommand
                using (MySqlCommand dbCommand = new MySqlCommand(queryString, dbConnection))
                {
                    // Execute the query
                    using (MySqlDataReader queryReader = dbCommand.ExecuteReader())
                    {
                        // while the results are still being read...
                        while (queryReader.Read())
                        {
                            // Get the new coordinates to put on the map
                            float x = queryReader.GetFloat(0);
                            float y = (float)queryReader.GetFloat(1);
                            int id;
                            int B;
                            int A;
                            int S;
                            int B2;
                            int A2;                            

                            id = queryReader.GetInt32(2);
                            B = queryReader.GetInt32(3);
                            A = queryReader.GetInt32(4);
                            S = queryReader.GetInt32(5);
                            B2 = queryReader.GetInt32(6);
                            A2 = queryReader.GetInt32(7);

                            spawnPoints.Add(new SpawnPoint(x, y, id, B.ToString(), A.ToString(), S.ToString(), B2.ToString(), A2.ToString(), zone, type));
                        }
                    }
                }

                dbConnection.Close();
            }
            catch (Exception e)
            {
                ErrorMessages.LogError(e, MethodBase.GetCurrentMethod().Name);
            }            

            return spawnPoints;
        }       

        public static void GetMaintenanceTime()
        {            
            string queryString = "SELECT * FROM `MaintenanceTime";

            try
            {
                MySqlConnection dbConnection = new MySqlConnection(ConnectionString);
                // Open the database to work with it
                dbConnection.Open();

                // Prepare the query to run with dbCommand
                using (MySqlCommand dbCommand = new MySqlCommand(queryString, dbConnection))
                {
                    // Execute the query
                    using (MySqlDataReader queryReader = dbCommand.ExecuteReader())
                    {
                        // while the results are still being read...
                        while (queryReader.Read())
                        {
                            // Get the new coordinates to put on the map
                            MobSpawnTimer.MaintTime = queryReader.GetDateTime(0).ToLocalTime();
                        }
                    }
                }

                dbConnection.Close();
            }
            catch (Exception e)
            {
                ErrorMessages.LogError(e, MethodBase.GetCurrentMethod().Name);
            }
        }

        private static List<string> GetMobName(string zone, int id)
        {
            string queryString = $"SELECT {id}, ( " +
                $"SELECT mob FROM MobSpawnInfo a INNER JOIN '{zone}' b ON a.ID = b.MobB WHERE b.ID = {id}) as B, ( " +
                $"SELECT mob FROM MobSpawnInfo a INNER JOIN '{zone}' b ON a.ID = b.MobA WHERE b.ID = {id}) as A, ( " +
                $"SELECT mob FROM MobSpawnInfo a INNER JOIN '{zone}' b ON a.ID = b.MobS WHERE b.ID = {id}) as S, ( " +
                $"SELECT mob FROM MobSpawnInfo a INNER JOIN '{zone}' b ON a.ID = b.MobB2 WHERE b.ID = {id}) as B2, ( " +
                $"SELECT mob FROM MobSpawnInfo a INNER JOIN '{zone}' b ON a.ID = b.MobA2 WHERE b.ID = {id}) as A2, x, y, spawned FROM '{zone}' WHERE id = {id};";
            MySqlConnection dbConnection = new MySqlConnection(ConnectionString);

            List<string> mobName = null;

            try
            {
                // Open the database to work with it
                dbConnection.Open();

                // Prepare the query to run with dbCommand
                using (MySqlCommand dbCommand = new MySqlCommand(queryString, dbConnection))
                {
                    // Execute the query
                    using (MySqlDataReader queryReader = dbCommand.ExecuteReader())
                    {
                        // while the results are still being read...
                        while (queryReader.Read())
                        {
                            // Get the name of the mob
                            mobName = new List<string> { queryReader.GetString(1), queryReader.GetString(2), queryReader.GetString(3), queryReader.GetString(4), queryReader.GetString(5) };
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ErrorMessages.LogError(e, MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                dbConnection.Close();
            }

            return mobName;
        }

        private static int GetID()
        {

            int id = 1;

            MySqlConnection dbConnection = new MySqlConnection(ConnectionString);

            try
            {
                string queryString = "Select COUNT(ID), MAX(ID) FROM `MobSpawnHistory`;";
                // Open the database to work with it
                dbConnection.Open();

                // Prepare the query to run with dbCommand
                using (MySqlCommand dbCommand = new MySqlCommand(queryString, dbConnection))
                {
                    // Execute the query
                    using (MySqlDataReader queryReader = dbCommand.ExecuteReader())
                    {
                        // while the results are still being read...
                        while (queryReader.Read())
                        {
                            // If there are any rows in the History table, get the MAX ID value and put it in `id` so it can be incremented.
                            if (queryReader.GetInt32(0) > 0)
                            {
                                id = queryReader.GetInt32(1);
                                id++;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ErrorMessages.LogError(e, MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                dbConnection.Close();
            }
            return id;
        }

        public static List<MobSpawnInfo> GetMobSpawnInfo()
        {
            string queryString = $"SELECT * FROM `MobSpawnInfo` WHERE rank = 'A' or rank = 'S';";
            List<MobSpawnInfo> mSI = new List<MobSpawnInfo>();
            try
            {
                MySqlConnection dbConnection = new MySqlConnection(ConnectionString);
                // Open the database to work with it
                dbConnection.Open();

                // Prepare the query to run with dbCommand
                using (MySqlCommand dbCommand = new MySqlCommand(queryString, dbConnection))
                {
                    // Execute the query
                    using (MySqlDataReader queryReader = dbCommand.ExecuteReader())
                    {
                        // while the results are still being read...
                        while (queryReader.Read())
                        {
                            // Get the Mob's spawn info
                            mSI.Add(new MobSpawnInfo(queryReader.GetInt32(0), queryReader.GetString(1), queryReader.GetString(2), queryReader.GetString(3), (TimeSpan)queryReader.GetValue(4), (TimeSpan)queryReader.GetValue(5), (TimeSpan)queryReader.GetValue(6), (TimeSpan)queryReader.GetValue(7), ConvertTimeZone.ToLocalTime(queryReader.GetDateTime(8)), queryReader.GetBoolean(9)));
                        }
                    }
                }

                dbConnection.Close();
            }
            catch (Exception e)
            {
                ErrorMessages.LogError(e, MethodBase.GetCurrentMethod().Name);
            }
            return mSI;
        }

        public static int UpdateMobToD(string mobName, string dateTimeOfDeath)
        {

            int recordsUpdated = 0;
            if (mobName.Contains("'")) { mobName = mobName.Replace("'", "`"); }
            string queryString = $"UPDATE `MobSpawnInfo` SET LastSeen = '{dateTimeOfDeath}' WHERE mob = '{mobName}';";

            try
            {
                MySqlConnection dbConnection = new MySqlConnection(ConnectionString);
                // Open the database to work with it
                dbConnection.Open();

                // Prepare the query to run with dbCommand
                using (MySqlCommand dbCommand = new MySqlCommand(queryString, dbConnection))
                {
                    recordsUpdated = dbCommand.ExecuteNonQuery();
                }

                dbConnection.Close();
            }
            catch (Exception e)
            {
                ErrorMessages.LogError(e, MethodBase.GetCurrentMethod().Name);
            }

            return recordsUpdated;
        }
    }
}
