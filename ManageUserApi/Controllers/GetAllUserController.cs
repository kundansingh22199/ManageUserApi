using ManageUserApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ManageUserApi.Controllers
{
    public class GetAllUserController : ApiController
    {
        CommonResponse comm = new CommonResponse();
        ClsUserDbManage user = new ClsUserDbManage();
        [HttpPost]
        [BasicAuthenticationAttribute]
        public CommonResponse GetAllUserData()
        {
            try
            {
                DataTable dt = user.GetAllUser();
                if (dt.Rows.Count > 0)
                {
                    comm.StatusCode = 200;
                    comm.StatusMsg = "Sucessfully Fetch Data";
                    comm.Data = dt;
                }
                else
                {
                    comm.StatusCode = 201;
                    comm.StatusMsg = "No One User Registerd";
                    comm.Data = "Data Not Found";
                }
            }
            catch (Exception ex)
            {
                comm.StatusCode = 501;
                comm.StatusMsg = "Technican Issue";
                comm.Data = ex.Message.ToString();
            }
            return comm;
        }
    }
}
