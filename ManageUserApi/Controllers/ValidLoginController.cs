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
    public class ValidLoginController : ApiController
    {
        ClsUserDbManage User = new ClsUserDbManage();
        CommonResponse comm = new CommonResponse();
        [HttpPost]
        [BasicAuthenticationAttribute]
        public CommonResponse CheckAuthoriseLogin(JObject JObj)
        {
            try
            {
                string TokenKey = JObj["TokenKey"].ToString();
                string DeviceInfo = JObj["DeviceInfo"].ToString();
                if(TokenKey=="" || DeviceInfo == "")
                {
                    comm.StatusCode = 401;
                    comm.StatusMsg = "Validation Error";
                    comm.Data = "Not Found";
                    return comm;
                }
                else
                {
                    DataTable dt = User.CheckAuthoriseLogin(TokenKey, DeviceInfo);
                    if (dt!= null && dt.Rows.Count > 0)
                    {
                        comm.StatusCode = 200;
                        comm.StatusMsg = "Success Fetch Data";
                        comm.Data = dt;
                    }
                    else
                    {
                        comm.StatusCode = 201;
                        comm.StatusMsg = "Invalid TokenKey Or Device Info";
                        comm.Data = "Data Not Found";
                    }
                }
            }
            catch (Exception ex)
            {
                comm.StatusCode = 201;
                comm.StatusMsg = "Techincal Error";
                comm.Data = "Not Found";
            }
            return comm;
        }
    }
}
