﻿using Newtonsoft.Json.Linq;
using Umbraco.Core.Composing;
using Umbraco.Core.Models;

namespace Umbraco.Web.PropertyEditors
{
    internal static class NestedContentHelper
    {
        private const string CacheKeyPrefix = "Umbraco.Web.PropertyEditors.NestedContent.GetPreValuesCollectionByDataTypeId_";

        public static PreValueCollection GetPreValuesCollectionByDataTypeId(int dtdId)
        {
            var preValueCollection = (PreValueCollection) Current.ApplicationCache.RuntimeCache.GetCacheItem(
                string.Concat(CacheKeyPrefix, dtdId),
                () => Current.Services.DataTypeService.GetPreValuesCollectionByDataTypeId(dtdId));

            return preValueCollection;
        }

        public static void ClearCache(int id)
        {
            Current.ApplicationCache.RuntimeCache.ClearCacheItem(
                string.Concat(CacheKeyPrefix, id));
        }

        public static IContentType GetElementType(JObject item)
        {
            var contentTypeAlias = item[NestedContentPropertyEditor.ContentTypeAliasPropertyKey]?.ToObject<string>();
            return string.IsNullOrEmpty(contentTypeAlias)
                ? null
                : Current.Services.ContentTypeService.Get(contentTypeAlias);
        }
    }
}
