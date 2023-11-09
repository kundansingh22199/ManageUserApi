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
    public class UpdateUserDatilsController : ApiController
    {
        CommonResponse comm = new CommonResponse();
        UserDetails Ud = new UserDetails();
        ClsUserDbManage User = new ClsUserDbManage();
        [HttpPost]
        [BasicAuthenticationAttribute]
        public CommonResponse UpdateByMobile(UserDetails ud)
        {
            
            try
            {
                DataTable dt = User.GetUserByMobileNo(ud.Mobile);
                if (dt.Rows.Count > 0)
                {
                    if (ModelState.IsValid == true)
                    {
                        int result = User.UpdateUserData(ud);
                        if (result > 0)
                        {
                            comm.StatusCode = 200;
                            comm.StatusMsg = "User Updated Sucessfully";
                            comm.Data = ud;
                        }
                        else
                        {
                            comm.StatusCode = 206;
                            comm.StatusMsg = "User Not Updated";
                            comm.Data = ud;
                        }
                    }
                    else
                    {
                        var error = ModelState.SelectMany(ms => ms.Value.Errors.Select(e => e.ErrorMessage));
                        comm.StatusCode = 209;
                        comm.StatusMsg = error;
                        comm.Data = ud;
                    }
                }
                else
                {
                    comm.StatusCode = 400;
                    comm.StatusMsg = "User Not Registerd";
                    comm.Data = "Try To Diffrent Mobile No";
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
