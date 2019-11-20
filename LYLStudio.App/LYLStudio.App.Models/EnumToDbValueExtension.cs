using System;

namespace LYLStudio.App.Models
{
    public sealed class DBValueAttribute : Attribute
    {
        public string DbValue { get; }
        public DBValueAttribute(string DbValue)
        {
            this.DbValue = DbValue;
        }
    }

    public static class EnumMappingHelper
    {

        public static string GetDBValue<T>(T enumeration)
        {
            var members = enumeration.GetType().GetMember(enumeration.ToString());
            var attributes = members[0].GetCustomAttributes(typeof(DBValueAttribute), false);
            var dbValue = (attributes[0] as DBValueAttribute).DbValue;
            return dbValue;
        }

        public static T GetEnum<T, A>(string dbValue, string propertyName) where A : Attribute
        {
            //todo
            var result = default(T);
            _ = typeof(A);
            if (default(T).GetType().IsEnum)
            {
                var fields = default(T).GetType().GetFields();
                //.Where(f => f.CustomAttributes.Contains(attributeType));


            }

            return result;
        }
    }

}
