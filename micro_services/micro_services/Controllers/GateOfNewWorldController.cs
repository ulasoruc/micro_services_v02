﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using micro_services.A00;
using micro_services.A00_Core;
using micro_services.A00_Model;
using micro_services_share;
using micro_services_share.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace micro_services.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GateOfNewWorldController : ControllerBase
    //public class GateOfNewWorldController : Controller
    {
        [AllowAnonymous]
        [HttpPost("auth")]
        public IActionResult Authenticate([FromBody] cRequest model)
        {

            cResponse response = new cResponse()
            {
                message_code = AppStaticInt.msg001Fail,
                message = AppStaticStr.msg0001WrongUserNamePass,
                token = string.Empty,
                data = string.Empty
            };


            response = recaptcha(model: model);
            if (response.message_code == AppStaticInt.msg0010reCaptaErrorMessage)
                return Ok(response);

            response = new classToken().Authenticate(model, ipAddress());


            if (AppStaticInt.msg001Fail == response.message_code)
                return Ok(response);

            //setTokenCookie(response.RefreshToken);

            return Ok(response);
        }

        //TODO:sonrasında gelen İP adreslere göre kısıtlama yada iptal işlemi yapılabilmesi için aşağıdaki method tutulacak
        private string ipAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

        [AllowAnonymous]
        [HttpPost("nuser")]
        public IActionResult NewUser([FromBody] cRequest model)
        {

            cResponse response = new cResponse()
            {
                message_code = AppStaticInt.msg001Fail,
                message = AppStaticStr.msg0001WrongUserNamePass,
                token = string.Empty,
                data = string.Empty
            };


            response = recaptcha(model: model);
            if (response.message_code == AppStaticInt.msg0010reCaptaErrorMessage)
                return BadRequest(response);

            response = new classToken().SaveNewUser(model, ipAddress());


            if (AppStaticInt.msg001Fail == response.message_code)
                return Ok(response);

            //setTokenCookie(response.RefreshToken);

            return Ok(response);
        }

        #region recapfcha işlemleri
        public GateOfNewWorldController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private readonly string _googleVerifyAddress = "https://www.google.com/recaptcha/api/siteverify";

        private readonly string _googleRecaptchaSecret = "6LcUT8kZAAAAAGpERh4ciAMeGskiG34Ezs01xODv";

        private readonly IHttpClientFactory _httpClientFactory;
        //private IHttpClientFactory _httpClientFactory;

        //[AllowAnonymous]
        //[HttpGet]
        private TokenResponse RecaptchaV3Vverify(string token)
        {
            TokenResponse tokenResponse = new TokenResponse()
            {
                Success = false
            };

            using (var client = _httpClientFactory.CreateClient())
            {
                var response = client.GetStringAsync($"{_googleVerifyAddress}?secret={_googleRecaptchaSecret}&response={token}");
                response.Wait();
                var responseResult = response.Result;
                tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseResult);

            }

            //return Json(tokenResponse);
            return tokenResponse;
        }
        private cResponse recaptcha(cRequest model)
        {
            // var a = Task.Run(async () => {
            //     return RecaptchaV3Vverify(model.token);
            // });


            cResponse res = new cResponse();

            if (model.token == "6LcUT8kZAAAAADHqHET4v2sJQr8Ozbta4Ti9s5dj") //flutter public kay ile token gönderiyor
                return res;

            TokenResponse a = RecaptchaV3Vverify(model.token);


            if (a.ErrorCodes != null)
            {
                res.message_code = AppStaticInt.msg0010reCaptaErrorMessage;
                res.message = a.ErrorCodes.ToString();
                res.token = "";
                res.data = JsonConvert.SerializeObject(a);

                return res;
            };

            if (a.Success != true)
            {
                res.message_code = AppStaticInt.msg0010reCaptaErrorMessage;
                res.message = a.ErrorCodes.ToString();
                res.token = "";
                res.data = JsonConvert.SerializeObject(a);

                return res;
            };
            double score = 0;
            double.TryParse(a.Score.ToString(), out score);

            if (score <= 0.7)
            {
                res.message_code = AppStaticInt.msg0010reCaptaErrorMessage;
                res.message = a.ErrorCodes.ToString();
                res.token = "";
                res.data = JsonConvert.SerializeObject(a);

                return res;
            };

            return res;
        }
        #endregion recapfcha işlemleri

        [AllowAnonymous]
        [HttpGet("activation")]
        public IActionResult Active(string actkey)
        {

            // yazılması gereken   https://../../Activation?acktKey=13628fe2-2ec8-41b0-99ad-eb96554f94c3
            cResponse response = new cResponse()
            {
                message_code = AppStaticInt.msg001Fail,
                message = AppStaticStr.msg0025ActivasyonHatasi,
                token = string.Empty,
                data = string.Empty
            };

            response = new classToken().userActivation(ACTkey: actkey);

            return Ok(response);
        }


        [AllowAnonymous]
        [HttpPost("forgetpass")]
        public IActionResult ForgetPass([FromBody] cRequest model)
        {
            cResponse response = new cResponse()
            {
                message = AppStaticStr.msg0040Hata,
                message_code = AppStaticInt.msg001Fail,
                token = "00",
                data = "00"
            };

            if (new NSOperation().ForgetPass(model: model) != 0)
            {
                response.message_code = AppStaticInt.msg001Succes;
                response.message = AppStaticStr.msg0045OK;
            }

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("forgetpassactivation")]
        public IActionResult ForgetPassActivation(string actkey)
        {
            cResponse response = new cResponse()
            {
                message = AppStaticStr.msg0040Hata,
                message_code = AppStaticInt.msg001Fail,
                token = "00",
                data = "00"
            };

            if (new NSOperation().ForgetPassActivation(actkey: actkey) != 0)
            {
                return Ok("İşlem Tamamlandı");
                // response.message_code = AppStaticInt.msg001Succes;
                // response.message = AppStaticStr.msg0045OK;
            }
            else
            {
                return Ok("Sorun var, teknik kısım ile iletişime geçiniz, info@zoradamlar.com");
            }

            //return Ok(response);
        }


        [HttpPost("mainuserlist")]
        public IActionResult MainUserList([FromBody] cRequest model)
        {
            cResponse response = new SOperation().CompanyUserList(model);

            return Ok(response);
        }

        [HttpPost("mainuserget")]
        public IActionResult MainUserGet([FromBody] cRequest model)
        {
            cResponse response = new SOperation().UserGet(model);

            return Ok(response);
        }

        [HttpPost("userinfo")]
        public IActionResult UserInfo([FromBody] cRequest model)
        {
            cResponse response = new cResponse()
            {
                message_code = AppStaticInt.msg001Fail,
                message = AppStaticStr.msg0025ActivasyonHatasi,
                token = string.Empty,
                data = string.Empty
            };


            response = new SOperation().UserGetALL(model);

            return Ok(response);
        }
        [HttpPost("retoken")]
        public IActionResult ReToken([FromBody] cRequest model)
        {
            cResponse response = new SOperation().userRetoken(model);
            return Ok(response);
        }

        [HttpPost("refcrud")]
        public IActionResult RefCrud([FromBody] cRequest model)
        {
            cResponse response = new SOperation().ref_crud(model);
            return Ok(response);
        }

        [HttpPost("refcrudstr")]
        public IActionResult RefCrudStr([FromBody] string value)
        {
            //string ss = "{\"token\":\"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjI5IiwibmJmIjoxNjEyMTYyNTk0LCJleHAiOjE2MTIxNjk3OTQsImlhdCI6MTYxMjE2MjU5NH0.QINQSuCwnwEdlylAkQlakTCQkRJ6YvLNGOjJYGtOY0A\",\"project_code\":2,\"prosses_code\":0,\"data\":\"29\",\"data_exe\":[{\"id\":0,\"info\":\"Single_crud\",\"value\":\"Get\"},{\"id\":1,\"info\":\"tablename\",\"value\":\"users\"},{\"id\":2,\"info\":\"Trans_crud\",\"value\":\"Single_crud\"},{\"id\":3,\"info\":\"primarykey\",\"value\":\"users_id\"},{\"id\":4,\"info\":\"srvoptname\",\"value\":\"Get\"}]}";
            //string ss = "{\"token\":\"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjI5IiwibmJmIjoxNjEyMTYyNTk0LCJleHAiOjE2MTIxNjk3OTQsImlhdCI6MTYxMjE2MjU5NH0.QINQSuCwnwEdlylAkQlakTCQkRJ6YvLNGOjJYGtOY0A\",\"project_code\":2,\"prosses_code\":0,\"data\":\"29\",\"data_exe\":[{\"id\":0,\"info\":\"Single_crud\",\"value\":\"Get\"}]}";
            string ss = "{\"token\":\"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjI5IiwibmJmIjoxNjEyMTYyNTk0LCJleHAiOjE2MTIxNjk3OTQsImlhdCI6MTYxMjE2MjU5NH0.QINQSuCwnwEdlylAkQlakTCQkRJ6YvLNGOjJYGtOY0A\",\"project_code\":2,\"prosses_code\":0,\"data\":\"29\",\"data_exe\":[{\"id\":0,\"info\":\"Single_crud\",\"value\":\"Get\"}]}";

            cRequest model1 = JsonConvert.DeserializeObject<cRequest>(ss);
            
            cRequest model = JsonConvert.DeserializeObject<cRequest>(value);
            cResponse response = new SOperation().ref_crud(model);
            return Ok(response);
        }


        [HttpPost("refcrudtrans")]
        public IActionResult RefCrudTrans([FromBody] cRequest model)
        {
            cResponse response = new SOperation().ref_crud_tran(model);
            return Ok(response);
        }

        [HttpPost("sendactivemail")]
        public IActionResult SendActivateMail([FromBody] cRequest model)
        {
            cResponse response = new SOperation().SendActMail(request: model);
            return Ok(response);
        }
        [HttpPost("refreshstaticlist")]
        public IActionResult refreshStaticList([FromBody] cRequest model)
        {
            cResponse response = new cResponse()
            {
                message_code = AppStaticInt.msg001Fail,
                message = AppStaticStr.msg0025ActivasyonHatasi,
                token = string.Empty,
                data = string.Empty
            };


            response = new SOperation().UserGet_AfterstatickListRefresh(model);

            return Ok(response);
        }

        [HttpPost("fltSaveUser")]
        public IActionResult fltSaveUser([FromBody] cRequest model)
        {
            cResponse response = new cResponse()
            {
                message_code = AppStaticInt.msg001Fail,
                message = AppStaticStr.msg0100flutKullaniciKayitHatasi,
                token = string.Empty,
                data = string.Empty
            };



            return Ok(response);
            
        }


    }
}
