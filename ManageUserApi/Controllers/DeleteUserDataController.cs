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
    public class DeleteUserDataController : ApiController
    {
        CommonResponse comm = new CommonResponse();
        ClsUserDbManage User = new ClsUserDbManage();
        [HttpPost]
        [BasicAuthenticationAttribute]
        public CommonResponse DeleteUser(UserDetails ud)
        {
            try
            {
                DataTable dt = User.GetUserByMobileNo(ud.Mobile);
                if (dt.Rows.Count > 0)
                {
                    int result = User.DeleteUserByMobileNo(ud.Mobile);
                    if (result > 0)
                    {
                        comm.StatusCode = 200;
                        comm.StatusMsg = "User Deleted SuccessFull";
                        comm.Data = "Not Found";
                    }
                    else
                    {
                        comm.StatusCode = 206;
                        comm.StatusMsg = "UnSucessfully";
                        comm.Data = "Data Not Deleted";
                    }
                }
                else
                {
                    comm.StatusCode = 201;
                    comm.StatusMsg = "User Not Register..!";
                    comm.Data = "Try Diffrent Mobile No";
                }
            }
            catch (Exception)
            {
                comm.StatusCode = 501;
                comm.StatusMsg = "Technican Error";
                comm.Data = "Data Not Deleted";
            }
            return comm;
        }
    }
}
