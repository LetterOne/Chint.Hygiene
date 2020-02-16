using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace Common.Library.Extention
{
    public static partial class Extention
    {
        /// <summary>
        /// DataTable转List
        /// </summary>
        /// <typeparam name="T">转换类型</typeparam>
        /// <param name="dt">数据源</param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable dt)
        {
            List<T> list = new List<T>();

            //确认参数有效,若无效则返回Null
            if (dt == null)
                return list;
            else if (dt.Rows.Count == 0)
                return list;

            Dictionary<string, string> dicField = new Dictionary<string, string>();
            Dictionary<string, string> dicProperty = new Dictionary<string, string>();
            Type type = typeof(T);

            //创建字段字典，方便查找字段名
            type.GetFields().ForEach(aFiled =>
            {
                dicField.Add(aFiled.Name.ToLower(), aFiled.Name);
            });

            //创建属性字典，方便查找属性名
            type.GetProperties().ForEach(aProperty =>
            {
                dicProperty.Add(aProperty.Name.ToLower(), aProperty.Name);
            });

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //创建泛型对象
                T _t = Activator.CreateInstance<T>();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string memberKey = dt.Columns[j].ColumnName.ToLower();

                    //字段赋值
                    if (dicField.ContainsKey(memberKey))
                    {
                        FieldInfo theField = type.GetField(dicField[memberKey]);
                        var dbValue = dt.Rows[i][j];
                        if (dbValue.GetType() == typeof(DBNull))
                            dbValue = null;
                        if (dbValue != null)
                        {
                            Type memberType = theField.FieldType;
                            if (memberType.IsGenericType && memberType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                            {
                                NullableConverter newNullableConverter = new NullableConverter(memberType);
                                dbValue = newNullableConverter.ConvertFrom(dbValue);
                            }
                            else
                            {
                                dbValue = Convert.ChangeType(dbValue, memberType);
                            }
                        }
                        theField.SetValue(_t, dbValue);
                    }
                    //属性赋值
                    if (dicProperty.ContainsKey(memberKey))
                    {
                        PropertyInfo theProperty = type.GetProperty(dicProperty[memberKey]);
                        var dbValue = dt.Rows[i][j];
                        if (dbValue.GetType() == typeof(DBNull))
                            dbValue = null;
                        if (dbValue != null)
                        {
                            Type memberType = theProperty.PropertyType;
                            if (memberType.IsGenericType && memberType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                            {
                                NullableConverter newNullableConverter = new NullableConverter(memberType);
                                dbValue = newNullableConverter.ConvertFrom(dbValue);
                            }
                            else
                            {
                                dbValue = Convert.ChangeType(dbValue, memberType);
                            }
                        }
                        theProperty.SetValue(_t, dbValue);
                    }
                }
                list.Add(_t);
            }
            return list;
        }
    }
}
