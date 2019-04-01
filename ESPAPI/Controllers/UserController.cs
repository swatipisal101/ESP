using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Cors;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ESPAPI.Models;
using ESPAPI.Repositories;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.IO;
using ESPAPI.Services;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace ESPAPI.Controllers
{
     [Route("api/[controller]")]
    [ApiController] 
    public class UserController : ControllerBase
    {

        private IUserRepository userdata;
        private readonly IHostingEnvironment _hostingEnvironment;
       // private readonly ISendEmailService _emailService;
        // private IUserRoleRepository userroledata;
        private IConfiguration _config;
        public string _ESPsiteLink;
        private DateTime linkExpTime;
       // public UserController(espContext context, IConfiguration config, IHostingEnvironment hostingEnvironment, ISendEmailService emailService)
        public UserController(espContext context, IConfiguration config, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            userdata = new UserRepository(context);
            //userroledata = new UserRoleRepository(context);
            _config = config;
           // _emailService = emailService;
            _ESPsiteLink = _config["ESPsiteLink:ESPsiteLink"];
        }

        /// <summary>
        /// LOGIN API to authenticate User and genereate token in response
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Token, UserId, RoleId</returns>
        [HttpPost]
        [AllowAnonymous]
        [EnableCors("AllowSpecificOrigin")]  
        [Route("Login")]
        public IActionResult Login([FromBody]User login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);
            if (user != null)
            {
                if (user.UserName != null)
                {
                    var tokenString = GenerateJSONWebToken(user);
                    response = Ok(new
                    {
                        token = tokenString,
                        userid = user.Id,
                        roleid = user.RoleId,                      
                        username = user.UserName,
                        Email = user.Email,                      
                        firstName = user.firstname,
                        lastname=user.lastname
                    });
                }
            }

            return response;
        }


        /// <summary>
        /// Create TOKEN
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            User user = userdata.GetUser(userInfo.UserName, userInfo.PasswordHash);
            // UserRole role = userroledata.GetRoleByID(user.Id);
            // string rolename =role.RoleName;
            string rolename = "admin";
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim(ClaimTypes.Role, rolename),
                new Claim("RoleId", userInfo.RoleId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User AuthenticateUser(User login)
        {
           
            User user = userdata.GetUser(login.UserName,login.PasswordHash);         
            return user;
        }


        [HttpPost]
        [Route("ForgotUsername/{email}")]
        [EnableCors("AllowSpecificOrigin")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotUsername(string email)
        {
            try
            {
                StringBuilder usernames = new StringBuilder();
              
                User user = userdata.GetUserByEmail(email);

                if (user != null)
                {
                  
                  
                    //Send email to user's emailid
                    string htmlBody = string.Empty;
                    string emiltosend = email;

                    //Get path of root(need to check on server)
                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    using (StreamReader sr = new StreamReader(contentRootPath + "/EmailTemplate/ForgotUsername.html"))
                    {
                        htmlBody = sr.ReadToEnd();
                    }

                    htmlBody = htmlBody.Replace("ESPLink", _ESPsiteLink);
                    htmlBody = htmlBody.Replace("userNameList", user.UserName.ToString());
                    SendEmailService s = new SendEmailService(_config);
                    await s.SendEmail(emiltosend, "Forgot Username", htmlBody, "");
                    return Ok(new { statusText = "Success" });
                }
                else
                {
                    return Ok(new { statusText = "Error" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { statusText = "Error" });
            }
        }

        [HttpPost]
        [Route("ForgotPassword")]
        [EnableCors("AllowSpecificOrigin")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody]resetuserpassmodel resetPassModel)
        {
            try
            {
                //var n1ql = "select c.*, META(c).id from " + _bucketName + " c where c.documentType = 'RegisteredUser' and LOWER(c.username) ='" + resetPassModel.username.ToLower() + "' and c.email ='" + resetPassModel.email + "'";
                ////var n1ql = "select c.*, META(c).id from " + _bucketName + " c where c.documentType = 'RegisteredUser' and c.username ='PssCt015'";
                //var query = QueryRequest.Create(n1ql);
                //query.ScanConsistency(_scanConsistency);
                //var result = _bucket.Query<UserModel>(query);
                User user = userdata.GetUserByEmailAndUserName(resetPassModel.email, resetPassModel.username);

                if (user != null)
                {
                    resetuserpassmodel model = new resetuserpassmodel
                    {
                        email = user.Email,
                        username = user.UserName
                    };

                    //string newToken = GenerateJSONResetToken(model);
                    string tokenString = GenerateJSONResetToken(model);

                    //var tokenString = EncryptString(newToken);
                    if (string.IsNullOrEmpty(tokenString) == false)
                    {
                        string emiltosend = user.Email;
                        //Get path of root(need to check on server)
                        string webRootPath = _hostingEnvironment.WebRootPath;
                        string contentRootPath = _hostingEnvironment.ContentRootPath;
                        string htmlBody = string.Empty;

                        using (StreamReader sr = new StreamReader(contentRootPath + "/EmailTemplate/ResetPassword.html"))
                        {
                            htmlBody = sr.ReadToEnd();
                        }
                        htmlBody = htmlBody.Replace("userName", user.firstname + " " + user.lastname);
                        htmlBody = htmlBody.Replace("ESPsiteLink", _ESPsiteLink);
                        htmlBody = htmlBody.Replace("ExpHours", _config["ResetPassLinkExp:ExpireHours"].ToString());
                        string sitelink = _ESPsiteLink.Substring(0, _ESPsiteLink.Length - 2) + "resetpass/" + tokenString;
                        //htmlBody = htmlBody.Replace("resetLink", "http://localhost:4200/resetpass/" + tokenString);
                        htmlBody = htmlBody.Replace("resetLink", sitelink);

                        //  await _emailService.SendEmail(emiltosend, "Reset Password", htmlBody, "");
                        SendEmailService s = new SendEmailService(_config);
                        await s.SendEmail(emiltosend, "Reset Password", htmlBody, "");
                        return Ok(new { statusText = "Reset Link Sent to your email." });
                    }
                    else
                    {
                        return Ok(new { statusText = "Error" });
                    }
                }
                else
                {
                    return Ok(new { statusText = "Entered email not match." });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { statusText = "Error" });
            }
        }
        private string GenerateJSONResetToken(resetuserpassmodel model)
        {
          

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            DateTime iatDate = DateTime.UtcNow;
            linkExpTime = iatDate.AddHours(Convert.ToInt32(_config["ResetPassLinkExp:ExpireHours"].ToString()));

            //  Finally create a Token
            JwtHeader header = new JwtHeader(credentials);

            //Some PayLoad that contain information about the  customer
            JwtPayload payload = new JwtPayload
            {
                 { "UserName", model.username},
                 { "EmailId", model.email },
                 { "ValidTo", linkExpTime }
            };

            JwtSecurityToken secToken = new JwtSecurityToken(header, payload);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            // Token to String so you can use it in your client
            string tokenString = handler.WriteToken(secToken);

            return tokenString;
        }


        [HttpPost]
        [Route("ResetPassword")]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult ResetPassword([FromBody]resetuserpassmodel resetModel)
        {
            try
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                JwtSecurityToken tokenS = handler.ReadToken(resetModel.token) as JwtSecurityToken;
                //string EmailId = tokenS.Claims.First(claim => claim.Type == "EmailId").Value;
                //string UserName = tokenS.Claims.First(claim => claim.Type == "UserName").Value;
                var data = tokenS.Payload.ToArray();
                string EmailId = data[1].Value.ToString();
                string UserName = data[0].Value.ToString();

                if (EmailId == resetModel.email)
                {
                    //var n1ql = "select c.*, META(c).id from " + _bucketName + " c where c.documentType = 'RegisteredUser' and c.username ='" + UserName + "' and c.email ='" + EmailId + "'";
                    //var query = QueryRequest.Create(n1ql);
                    //query.ScanConsistency(_scanConsistency);
                    //var result = _bucket.Query<UserModel>(query);
                    User user = userdata.GetUserByEmailAndUserName(resetModel.email, resetModel.username);
                    user.PasswordHash = resetModel.newpassword;
                    if (user!=null)
                    {
                        userdata.UpdateUser(user.Id, user);
                        return Ok(new { statusText = "Success" });
                    }
                    else
                    {
                        return Ok(new { statusText = "User does not exist." });
                    }
                }
                else
                {
                    return Ok(new { statusText = "Email not match." });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { statusText = "Error Occured." });
            }
        }

        [HttpPost]
        [Route("ChangePassword")]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult ChangePassword()
        {
            resetuserpassmodel changePasswordInfo = JsonConvert.DeserializeObject<resetuserpassmodel>(HttpContext.Request.Form["model"]);
            try
            {
                if (changePasswordInfo.currpassword == changePasswordInfo.newpassword)
                {
                    return Ok(new { statusText = "ErrorSamePassword" });
                }
                else
                {
                   
                    User user = userdata.GetUserById(changePasswordInfo.userid);

                    if (user != null)
                    {
                        if (user.PasswordHash.ToString() == changePasswordInfo.currpassword.ToString())
                        {
                            user.PasswordHash = changePasswordInfo.newpassword;
                            userdata.UpdateUser(user.Id, user);
                            return Ok(new { statusText = "Success" });
                        }
                        else
                        {
                            return Ok(new { statusText = "Error" });
                        }
                    }
                    else
                    {
                        return Ok(new { statusText = "" });
                    }

                }
            }
            catch (Exception)
            {
                return Ok(new { statusText = "Error" });
            }
        }

        [HttpPost]
        [Route("ValidateToken")]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult ValidateToken()
        {
            string tokenfromheader = HttpContext.Request.Headers["token"].ToString();
            try
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                JwtSecurityToken tokenS = handler.ReadToken(tokenfromheader) as JwtSecurityToken;

                var data = tokenS.Payload.ToArray();
                DateTime expDate = Convert.ToDateTime(data[2].Value);
                //DateTime expDate = tokenS.ValidTo;
                DateTime currentDate = DateTime.UtcNow;
                if (currentDate > expDate)
                {
                    return Ok(new { statusText = "Invalid" });
                }
                else
                {
                    return Ok(new { statusText = "Valid" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { statusText = "Error" });
            }
        }
    }
}