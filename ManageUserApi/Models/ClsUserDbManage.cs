using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ManageUserApi.Models
{
    public class ClsUserDbManage : ClsConnection
    {
        public DataTable GetUserByMobileNo(string mobileNo)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand("SP_queryRemitter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MobileNo", mobileNo);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DataTable GetAllUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand("SP_GetAllRemitter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
       
        public int DeleteUserByMobileNo(string mobileNo)
        {
            try
            {
                int result = 0;
                SqlConnection con = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand("SP_deleteRemitter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MobileNo", mobileNo);
                con.Open();
                return result = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int UserRegistration(UserDetails ud)
        {
            Random rd = new Random();
            string pass = rd.Next(1111, 9999).ToString();
            int result = 0;
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SP_RegisterRemitter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MobileNo", ud.Mobile);
                cmd.Parameters.AddWithValue("@UserName", ud.Mobile);
                cmd.Parameters.AddWithValue("@Pass", pass);
                cmd.Parameters.AddWithValue("@Name", ud.Name);
                cmd.Parameters.AddWithValue("@Email", ud.Email);
                cmd.Parameters.AddWithValue("@Address", ud.Address);
                cmd.Parameters.AddWithValue("@City", ud.City);
                cmd.Parameters.AddWithValue("@PinCode", ud.PinCode);

                return result = cmd.ExecuteNonQuery();
                con.Close();

            }
            catch
            {
                return result;
            }
        }
        public int UpdateUserData(UserDetails ud)
        {
            int result = 0;
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SP_UpdateRemitter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MobileNo", ud.Mobile);
                cmd.Parameters.AddWithValue("@Name", ud.Name);
                cmd.Parameters.AddWithValue("@Email", ud.Email);
                cmd.Parameters.AddWithValue("@Address", ud.Address);
                cmd.Parameters.AddWithValue("@City", ud.City);
                cmd.Parameters.AddWithValue("@PinCode", ud.PinCode);

                return result = cmd.ExecuteNonQuery();
                con.Close();

            }
            catch
            {
                return result;
            }
        }
        public DataTable UserLogin(string UserName, string Password,string TokenKey,string DeviceInfo)
        {
            try
            {
                int result = 0;
                SqlConnection con = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand("GetUSerLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Pass", Password);
                cmd.Parameters.AddWithValue("@TokenKey", TokenKey);
                cmd.Parameters.AddWithValue("@DeviceInfo", DeviceInfo);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DataTable CheckAuthoriseLogin(string TokenKey, string DeviceInfo)
        {
            try
            {
                int result = 0;
                SqlConnection con = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand("Sp_AuthorisedLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TokenKey", TokenKey);
                cmd.Parameters.AddWithValue("@DeviceInfo", DeviceInfo);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}