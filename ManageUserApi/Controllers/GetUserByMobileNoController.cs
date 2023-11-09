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
    public class GetUserByMobileNoController : ApiController
    {
        ClsUserDbManage user = new ClsUserDbManage();
        CommonResponse comm = new CommonResponse();
        [HttpPost]
        [BasicAuthenticationAttribute]
        public CommonResponse GetByMobileNo(JObject jobj)
        {
            try
            {
                string MobileNo = jobj["Mobile"].ToString();
                if (string.IsNullOrEmpty(MobileNo))
                {
                    comm.StatusCode = 401;
                    comm.StatusMsg = "Validatin error..!";
                    comm.Data = "Please Enter Mobile No..";
                    return comm;
                }
                DataTable dt = user.GetUserByMobileNo(MobileNo);
                if (dt.Rows.Count > 0)
                {
                    UserDetails Ud = new UserDetails();

                    Ud.Mobile = dt.Rows[0]["MobileNo"].ToString();
                    Ud.Name = dt.Rows[0]["Name"].ToString();
                    Ud.Email = dt.Rows[0]["Email"].ToString();
                    Ud.Address = dt.Rows[0]["Address"].ToString();
                    Ud.City = dt.Rows[0]["City"].ToString();
                    Ud.PinCode = dt.Rows[0]["PinCode"].ToString();
                    comm.StatusCode = 200;
                    comm.StatusMsg = "Sucessfully Fetch Data";
                    comm.Data = Ud;
                }
                else
                {
                    comm.StatusCode = 201;
                    comm.StatusMsg = "User Not Register..!";
                    comm.Data = "Send OTP on : " + MobileNo;
                }
            }
            catch (Exception ex)
            {
                comm.StatusCode = 506;
                comm.StatusMsg = "Techanical Issue";
                comm.Data = ex.Message.ToString();
            }
            return comm;
        }
    }
}
