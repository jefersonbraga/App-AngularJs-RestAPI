﻿using System;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

//namespace Cursos.Api.Models
//{
//    // É possível adicionar Dados de usuário para o usuário ao incluir mais propriedades na sua Classe de usuário, visite https://go.microsoft.com/fwlink/?LinkID=317594 para obter mais informações.
//    public class ApplicationUser : IdentityUser
//    {
//    }

//    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
//    {
//        public ApplicationDbContext()
//            : base("Wescola", throwIfV1Schema: false)
//        {
//        }

//        public static ApplicationDbContext Create()
//        {
//            return new ApplicationDbContext();
//        }
//    }
//}

//#region Auxiliares

//namespace weventos
//{
//    public static class IdentityHelper
//    {
//        // Usado para XSRF ao vincular logons externos
//        public const string XsrfKey = "XsrfId";

//        public const string ProviderNameKey = "providerName";

//        public static string GetProviderNameFromRequest(HttpRequest request)
//        {
//            return request.QueryString[ProviderNameKey];
//        }

//        public const string CodeKey = "code";

//        public static string GetCodeFromRequest(HttpRequest request)
//        {
//            return request.QueryString[CodeKey];
//        }

//        public const string UserIdKey = "userId";

//        public static string GetUserIdFromRequest(HttpRequest request)
//        {
//            return HttpUtility.UrlDecode(request.QueryString[UserIdKey]);
//        }

//        public static string GetResetPasswordRedirectUrl(string code, HttpRequest request)
//        {
//            var absoluteUri = "/Account/ResetPassword?" + CodeKey + "=" + HttpUtility.UrlEncode(code);
//            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
//        }

//        public static string GetUserConfirmationRedirectUrl(string code, string userId, HttpRequest request)
//        {
//            var absoluteUri = "/Account/Confirm?" + CodeKey + "=" + HttpUtility.UrlEncode(code) + "&" + UserIdKey + "=" + HttpUtility.UrlEncode(userId);
//            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
//        }

//        private static bool IsLocalUrl(string url)
//        {
//            return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
//        }

//        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
//        {
//            if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
//            {
//                response.Redirect(returnUrl);
//            }
//            else
//            {
//                response.Redirect("~/");
//            }
//        }
//    }
//}

//#endregion Auxiliares