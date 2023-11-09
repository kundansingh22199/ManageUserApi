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
    public class UserRegisterationController : ApiController
    {
        CommonResponse comm = new CommonResponse();
        UserDetails Ud = new UserDetails();
        ClsUserDbManage User = new ClsUserDbManage();
        [HttpPost]
        [BasicAuthentication]
        public CommonResponse GetUserByMobile(UserDetails ud)
        {
            try
            {
                DataTable dt = User.GetUserByMobileNo(ud.Mobile);
                if (dt.Rows.Count > 0)
                {
                    comm.StatusCode = 400;
                    comm.StatusMsg = "Mobile No Already Registerd";
                    comm.Data = "Try To Diffrent Mobile No";
                }
                else
                {
                    if (ModelState.IsValid == true)
                    {
                        int result = User.UserRegistration(ud);
                        comm.StatusCode = 200;
                        comm.StatusMsg = "User Registerd Sucessfully";
                        comm.Data = ud;
                    }
                    else
                    {
                        var error = ModelState.SelectMany(ms => ms.Value.Errors.Select(e => e.ErrorMessage));
                        comm.StatusCode = 209;
                        comm.StatusMsg = error;
                        comm.Data = ud;
                    }
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
