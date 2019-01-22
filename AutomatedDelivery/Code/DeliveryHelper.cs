using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using AutomatedDelivery.Models;
using System.Configuration;

namespace AutomatedDelivery.Code
{
    public class DeliveryHelper : IDisposable
    {
        public DeliveryModels.UpdateDelivery GetDelivery(int DeliveriesId)
        {
            DeliveryModels.UpdateDelivery Delivery = new DeliveryModels.UpdateDelivery();
            //DeliveryModels.GetDeliveries DelItems = null;

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DeliverySystem"].ToString()))
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.getdelivery";

                        cmd.Parameters.Add("@deliveriesId", SqlDbType.Int, -1).Value = DeliveriesId;

                        using (IDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (rdr.Read())
                            {
                                Delivery = new DeliveryModels.UpdateDelivery();

                                Delivery.deliveriesId = Convert.ToInt32(rdr["deliveriesid"]);
                                Delivery.deliveryId = Convert.ToInt32(rdr["deliveryid"]);
                                Delivery.from = rdr["from"].ToString();
                                Delivery.to = rdr["to"].ToString();
                                Delivery.message = rdr["message"].ToString();
                                Delivery.active = Convert.ToBoolean(rdr["active"]);
                            }
                        } // using (IDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    } // using(SqlCommand cmd = new SqlCommand())
                } // using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DeliverySystem"].ToString()))
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Delivery;
        }

        public List<DeliveryModels.GetDeliveries> GetDeliveries()
        {
            List<DeliveryModels.GetDeliveries> DelList = new List<DeliveryModels.GetDeliveries>();
            DeliveryModels.GetDeliveries DelItems = null;

            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DeliverySystem"].ToString()))
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.getdeliveries";

                        using (IDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (rdr.Read())
                            {
                                DelItems = new DeliveryModels.GetDeliveries();

                                DelItems.deliveriesid = Convert.ToInt32(rdr["deliveriesid"]);
                                DelItems.info = rdr["info"].ToString();

                                DelList.Add(DelItems);
                            }
                        }
                    } // using(SqlCommand cmd = new SqlCommand())
                } // using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DeliverySystem"].ToString()))
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return DelList;
        } // public DataTable GetDeliveries()

        // Deletes a delivery item from db.deliveries
        public void UpdateDelivery(DeliveryModels.UpdateDelivery Delivery)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DeliverySystem"].ToString()))
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.editdelivery";

                        cmd.Parameters.Add("@deliveriesId", SqlDbType.Int, -1).Value = Delivery.deliveriesId;
                        cmd.Parameters.Add("@from", SqlDbType.VarChar, 50).Value = Delivery.from;
                        cmd.Parameters.Add("@to", SqlDbType.VarChar, 50).Value = Delivery.to;
                        cmd.Parameters.Add("@message", SqlDbType.VarChar, 8000).Value = Delivery.message;
                        cmd.Parameters.Add("active", SqlDbType.Bit, -1).Value = Delivery.active;

                        cmd.ExecuteNonQuery();
                    } // using (SqlCommand cmd = new SqlCommand())
                } // using(SqlConnection cnn = new SqlConnection
            } // try
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } // public void insertDelivery(Models.DeliveryModels.Delivery delivery)

        // Deletes a delivery item from db.deliveries
        public void DeleteDelivery(int DeliveriesId)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DeliverySystem"].ToString()))
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.deactivatedelivery";

                        cmd.Parameters.Add("@deliveriesid", SqlDbType.Int, -1).Value = DeliveriesId;

                        int records = cmd.ExecuteNonQuery();
                    } // using (SqlCommand cmd = new SqlCommand())
                } // using(SqlConnection cnn = new SqlConnection
            } // try
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } // public void insertDelivery(Models.DeliveryModels.Delivery delivery)

        // Inserts a new delivery item into db.deliveries
        public void InsertDelivery(DeliveryModels.SaveDelivery delivery)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DeliverySystem"].ToString()))
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.insertnewdelivery";

                        cmd.Parameters.Add("@deliveryid", SqlDbType.Int, -1).Value = delivery.deliveryId;
                        cmd.Parameters.Add("@from", SqlDbType.VarChar, 50).Value = delivery.from;
                        cmd.Parameters.Add("@to", SqlDbType.VarChar, 50).Value = delivery.to;
                        cmd.Parameters.Add("@message", SqlDbType.VarChar, 8000).Value = delivery.message;
                        cmd.Parameters.Add("active", SqlDbType.Bit, -1).Value = delivery.active;

                        cmd.ExecuteNonQuery();
                    } // using (SqlCommand cmd = new SqlCommand())
                } // using(SqlConnection cnn = new SqlConnection
            } // try
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } // public void insertDelivery(Models.DeliveryModels.Delivery delivery)

        public void Dispose()
        {
            // Add cleanup code here.
        }
    }
}