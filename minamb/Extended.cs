using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using minamb.Models;

namespace minamb
{
    public static class IdentityExtensions
    {
        public static string GetNome(this IIdentity identity)
        {
            return new ApplicationDbContext().Users.Find(identity.GetUserId()).Nome;
        }
    }

    public static class EnumExtensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
            where TAttribute : Attribute
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<TAttribute>();
        }

        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .GetName();
        }
    }

    public static class Padrao
    {
        public static string ToData(this DateTime data)
        {
            return data.ToString("dd/MM/yyyy HH:mm");
        }

        public static string ToKwanza(this decimal valor)
        {
            return $"{valor} kz";
        }
    }


}