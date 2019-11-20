namespace LYLStudio.Core.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class ObjectHelper
    {
        /// <summary>
        /// 可複製來自不同物件同屬性名稱之屬性值
        /// </summary>
        /// <typeparam name="TSrc"></typeparam>
        /// <typeparam name="TDest"></typeparam>
        /// <param name="src">來源物件</param>
        /// <param name="dest">目標物件</param>
        /// <param name="skipSrcNull">忽略來源屬性為Null</param>
        /// <param name="skipDestNull">忽略目標屬性為Null</param>
        /// <param name="excludeProeprties">排除屬性清單</param>
        public static void CopyPropeties<TSrc, TDest>(TSrc src, TDest dest, bool skipSrcNull = true, bool skipDestNull = true, params string[] excludeProeprties)
            where TSrc : class
            where TDest : class
        {
            if (src is null)
            {
                return;
            }

            foreach (var destProperty in typeof(TDest).GetProperties())
            {
                //string name = destProperty.Name;
                if (excludeProeprties != null && excludeProeprties.Contains(destProperty.Name))
                    continue;

                try
                {
                    var srcProperty = typeof(TSrc).GetProperty(destProperty.Name);
                    if (srcProperty is null)
                        continue;

                    object srcValue = srcProperty.GetValue(src);
                    if (srcValue is null && skipSrcNull)
                        continue;

                    object destValue = destProperty.GetValue(dest);
                    if (destValue is null && skipDestNull)
                        continue;

                    var isNullableType = IsNullableType(destProperty.PropertyType);

                    var targetType = isNullableType ? Nullable.GetUnderlyingType(destProperty.PropertyType) : destProperty.PropertyType;

                    object value = null;

                    if (!(srcValue is null))
                    {
                        if (targetType.IsEnum)
                        {
                            value = Enum.Parse(targetType, srcValue.ToString());
                        }
                        else
                        {
                            value = Convert.ChangeType(srcValue, targetType);
                        }
                    }

                    destProperty.SetValue(dest, value);
                }
                catch (ArgumentNullException)
                {
                    throw;
                }
                catch (InvalidCastException)
                {
                    throw;
                }
                catch (FormatException)
                {
                    throw;
                }
                catch (OverflowException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// 從<typeparamref name="TSrc"/>複寫屬性值至<typeparamref name="TDest"/>
        /// </summary>
        /// <typeparam name="TSrc">來源類別，等同<typeparamref name="TDest"/>或<typeparamref name="TDest"/>的基底類別</typeparam>
        /// <typeparam name="TDest">目標類別</typeparam>
        /// <param name="src">來源物件</param>
        /// <param name="dest">目標物件</param>
        public static void OverrideProperties<TSrc, TDest>(TSrc src, TDest dest)
            where TDest : class, TSrc
        {
            foreach (var propertyInfo in src.GetType().GetProperties())
            {
                object value = propertyInfo.GetValue(src);

                if (value != null)
                    propertyInfo.SetValue(dest, Convert.ChangeType(value, propertyInfo.PropertyType), null);
            };
        }

        /// <summary>
        /// 迴圈透過<paramref name="callback"/>取屬性為KeyValuePair
        /// </summary>
        /// <typeparam name="T">對象類別</typeparam>
        /// <param name="obj">對象物件</param>
        /// <param name="callback">Callback函式</param>
        public static void ForEachProperty<T>(T obj, Action<KeyValuePair<object, object>> callback)
        {
            foreach (var item in obj.GetType().GetProperties())
            {
                callback(new KeyValuePair<object, object>(item.Name, item.GetValue(obj)));
            }
        }

        /// <summary>
        /// 迴圈透過<paramref name="callback"/>取屬性為KeyValuePair,並且針對屬性進行操作
        /// </summary>
        /// <typeparam name="T">對象類別</typeparam>
        /// <param name="obj">對象物件</param>
        /// <param name="callback">Callback函式</param>
        public static void ForEachProperty<T>(T obj, Action<PropertyInfo, KeyValuePair<object, object>> callback)
        {
            foreach (var item in obj.GetType().GetProperties())
            {
                callback(item, new KeyValuePair<object, object>(item.Name, item.GetValue(obj)));
            }
        }

        /// <summary>
        /// 確認是否為NullableType
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }

        public static PropertyInfo GetPropertyFromName(object inputObject, string propertyName)
        {
            Type type = inputObject.GetType();
            return type.GetProperty(propertyName);
        }

        public static void SetValue(object inputObject, string propertyName, object propertyVal)
        {
            //find out the type
            Type type = inputObject.GetType();

            //get the property information based on the type
            System.Reflection.PropertyInfo propertyInfo = type.GetProperty(propertyName);

            //find the property type
            _ = propertyInfo.PropertyType;

            //Convert.ChangeType does not handle conversion to nullable types
            //if the property type is nullable, we need to get the underlying type of the property
            var targetType = IsNullableType(propertyInfo.PropertyType) ? Nullable.GetUnderlyingType(propertyInfo.PropertyType) : propertyInfo.PropertyType;

            //Returns an System.Object with the specified System.Type and whose value is
            //equivalent to the specified object.
            //propertyVal = Convert.ChangeType(propertyVal, targetType);

            if (targetType.IsEnum)
            {
                propertyVal = Enum.Parse(targetType, propertyVal.ToString());
            }
            else
            {
                propertyVal = Convert.ChangeType(propertyVal, targetType);
            }

            //Set the value of the property
            propertyInfo.SetValue(inputObject, propertyVal, null);

        }

        //public static void CopyPropeties(TFrom from, TTo to, params string[] excludePropertyName)
        //{


        //    foreach (var item in from.GetType().GetProperties())
        //    {
        //        try
        //        {
        //            if (excludePropertyName != null && excludePropertyName.Contains(item.Name))
        //                continue;

        //            var toProperty = to.GetType().GetProperty(item.Name);

        //            if (toProperty == null)
        //                continue;

        //            var fromPropertyObject = item.GetValue(from);

        //            if (fromPropertyObject is null)
        //                continue;

        //            toProperty.SetValue(to, fromPropertyObject);
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }
        //}
    }
}
