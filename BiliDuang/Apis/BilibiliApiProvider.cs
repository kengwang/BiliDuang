using System;
using System.Collections.Generic;
using System.Net.Http;

namespace BiliDuang.Apis
{
    public class BilibiliApiProvider
    {
        public readonly QueryDataInfo[] QueryDataInfos;

        /// <summary>
        /// 请求方式
        /// </summary>
        public readonly HttpMethod Method;

        /// <summary>
        /// 链接地址
        /// </summary>
        public readonly string Url;

        public BilibiliApiProvider(string url, QueryDataInfo[] queryDataInfos = null, HttpMethod method = null)
        {
            Url = url;
            QueryDataInfos = queryDataInfos ?? new QueryDataInfo[]{};
            Method = method ?? HttpMethod.Get;
        }

        public Dictionary<string, object> GetData(Dictionary<string, object> queries)
        {
            if (QueryDataInfos.Length == 0)
                return queries;
            var data = new Dictionary<string, object>();
            foreach (var queryDataInfo in QueryDataInfos)
            {
                switch (queryDataInfo.Type)
                {
                    case QueryDataType.Required:
                        data.Add(queryDataInfo.Key, queries[queryDataInfo.Key]);
                        break;
                    case QueryDataType.Optional:
                        if (queries.ContainsKey(queryDataInfo.Key) && queries[queryDataInfo.Key] != null)
                        {
                            data.Add(queryDataInfo.Key, queries[queryDataInfo.Key]);
                        }
                        else
                        {
                            if (queryDataInfo.DefaultValue != null)
                                data.Add(queryDataInfo.Key, queryDataInfo.DefaultValue);
                        }

                        break;
                    case QueryDataType.Constant:
                        if (queryDataInfo.DefaultValue != null)
                            data.Add(queryDataInfo.Key, queryDataInfo.DefaultValue);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return data;
        }
    }

    public sealed class QueryDataInfo
    {
        public string Key;
        public QueryDataType Type;
        public object DefaultValue;

        public QueryDataInfo(string key, QueryDataType type = QueryDataType.Required) : this(key, type, null)
        {
        }

        public QueryDataInfo(string key, QueryDataType type, object defaultValue)
        {
            Key = key;
            Type = type;
            DefaultValue = defaultValue;
        }
    }

    public enum QueryDataType
    {
        Required, // 必选参数
        Optional, // 可选参数
        Constant // 常数
    }
}