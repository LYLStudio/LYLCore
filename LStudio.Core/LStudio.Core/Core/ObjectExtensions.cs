namespace LStudio.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    
    public static class ObjectExtensions
    {
        /// <summary>
        /// 物件屬性複製，自己複製到其他
        /// </summary>
        /// <typeparam name="TSrc">來源類別</typeparam>
        /// <typeparam name="TDest">目標類別</typeparam>
        /// <param name="src">來源物件</param>
        /// <param name="dest">目標物件</param>
        /// <param name="skipSrcNull">忽略來源空值</param>
        /// <param name="skipDestNull">忽略目標空值</param>
        /// <param name="excludeProeprties">排除的屬性清單</param>
        public static void CopyPropertyTo<TSrc, TDest>(this TSrc src, TDest dest, bool skipSrcNull = true, bool skipDestNull = true, params string[] excludeProeprties)
            where TSrc : class
            where TDest : class
        {
            ObjectHelper.CopyPropeties(src, dest, skipSrcNull, skipDestNull, excludeProeprties);
        }

        /// <summary>
        /// 物件屬性複製，從其他複製到自己
        /// </summary>
        /// <typeparam name="TDest">目標類別</typeparam>
        /// <typeparam name="TSrc">來源類別</typeparam>
        /// <param name="dest">目標物件</param>
        /// <param name="src">來源物件</param>
        /// <param name="skipSrcNull">忽略來源空值</param>
        /// <param name="skipDestNull">忽略目標空值</param>
        /// <param name="excludeProeprties">排除的屬性清單</param>
        public static void CopyPropertyFrom<TDest, TSrc>(this TDest dest, TSrc src, bool skipSrcNull = true, bool skipDestNull = true, params string[] excludeProeprties)
            where TSrc : class
            where TDest : class
        {
            ObjectHelper.CopyPropeties(src, dest, skipSrcNull, skipDestNull, excludeProeprties);
        }

        /// <summary>
        /// 從<typeparamref name="TSrc"/>複寫屬性值至<typeparamref name="TDest"/>
        /// </summary>
        /// <typeparam name="TSrc">來源類別，等同<typeparamref name="TDest"/>或<typeparamref name="TDest"/>的基底類別</typeparam>
        /// <typeparam name="TDest">目標類別</typeparam>
        /// <param name="src">來源物件</param>
        /// <param name="dest">目標物件</param>
        public static void OverridePropertiesTo<TSrc, TDest>(this TSrc src, TDest dest)
            where TDest : class, TSrc
        {
            ObjectHelper.OverrideProperties(src, dest);
        }

        /// <summary>
        /// 從<typeparamref name="TSrc"/>複寫屬性值至<typeparamref name="TDest"/>
        /// </summary>
        /// <typeparam name="TDest">目標類別</typeparam>
        /// <typeparam name="TSrc">來源類別，等同<typeparamref name="TDest"/>或<typeparamref name="TDest"/>的基底類別</typeparam>
        /// <param name="dest">目標物件</param>
        /// <param name="src">來源物件</param>
        public static void OverridePropertiesFrom<TDest, TSrc>(this TDest dest, TSrc src)
            where TDest : class, TSrc
        {
            ObjectHelper.OverrideProperties(src, dest);
        }

        /// <summary>
        /// 迴圈透過<paramref name="callback"/>取屬性為KeyValuePair
        /// </summary>
        /// <typeparam name="T">對象類別</typeparam>
        /// <param name="value">對象物件</param>
        /// <param name="callback">Callback函式</param>
        public static void ForEachProperty<T>(this T value, Action<NameValue> callback)
        {
            ObjectHelper.ForEachProperty(value, callback);
        }

        /// <summary>
        /// 迴圈透過<paramref name="callback"/>取屬性為KeyValuePair,並且針對屬性進行操作
        /// </summary>
        /// <typeparam name="T">對象類別</typeparam>
        /// <param name="value">對象物件</param>
        /// <param name="callback">Callback函式</param>
        public static void ForEachProperty<T>(this T value, Action<PropertyInfo, NameValue> callback)
        {
            ObjectHelper.ForEachProperty(value, callback);
        }

        public static bool EqualsObject(this object value, object targetValue)
        {
            if (value is null) throw new ArgumentNullException(nameof(value));
            if (targetValue is null) throw new ArgumentNullException(nameof(targetValue));

            var targetArray = GetObjectByte(value);
            var expectedArray = GetObjectByte(targetValue);
            var equals = expectedArray.SequenceEqual(targetArray);
            return equals;
        }

        private static byte[] GetObjectByte(object model)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(model.GetType());
                xs.Serialize(memory, model);
                var array = memory.ToArray();
                return array;
            }
        }

        //public static TDest CloneByJson<TDest, TSrc>(this TSrc source)
        //{
        //    TDest dest = default(TDest);

        //    // initialize inner objects individually
        //    // for example in default constructor some list property initialized with some values,
        //    // but in 'source' these items are cleaned -
        //    // without ObjectCreationHandling.Replace default constructor values will be added to result
        //    var deserializeSettings = new JsonSerializerSettings
        //    {
        //        ObjectCreationHandling = ObjectCreationHandling.Replace,
        //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        //    };

        //    string json = JsonConvert.SerializeObject(source, deserializeSettings);
        //    dest = JsonConvert.DeserializeObject<TDest>(json);
        //    return dest;
        //}
    }
}
