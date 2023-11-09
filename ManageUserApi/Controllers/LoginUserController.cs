using ManageUserApi.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ManageUserApi.Controllers
{
    public class LoginUserController : ApiController
    {
        ClsUserDbManage User = new ClsUserDbManage();
        CommonResponse comm = new CommonResponse();
        [HttpPost]
        [BasicAuthenticationAttribute]
        public CommonResponse CheckLogin(JObject JObj)
        {
            try
            {
                string UserName = JObj["UserName"].ToString();
                string Password = JObj["Password"].ToString();
                string TokenKey = JObj["TokenKey"].ToString();
                string DeviceInfo = JObj["DeviceInfo"].ToString();
                if(UserName=="" || Password=="" || TokenKey=="" || DeviceInfo=="")
                {
                    comm.StatusCode = 401;
                    comm.StatusMsg = "Validation Error";
                    comm.Data = "Please Enter All Details";
                    return comm;
                }
                else
                {
                    DataTable dt = User.UserLogin(UserName, Password, TokenKey,DeviceInfo);
                    if (dt != null && dt.Rows.Count >0){
                        comm.StatusCode = 200;
                        comm.StatusMsg = "Login Success";
                        comm.Data = dt;
                    }
                    else
                    {
                        comm.StatusCode = 201;
                        comm.StatusMsg = "Invalid User or Password";
                        comm.Data = "Data Not Found";
                    }
                }
            }
            catch (Exception ex)
            {
                comm.StatusCode = 400;
                comm.StatusMsg = "Techanical Issue";
                comm.Data = ex.Message.ToString();
            }
            return comm;
        }
    }
}
