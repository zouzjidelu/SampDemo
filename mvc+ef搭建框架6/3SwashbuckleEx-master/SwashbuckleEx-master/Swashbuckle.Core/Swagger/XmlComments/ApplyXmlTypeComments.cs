﻿using System.Reflection;
using System.Xml.XPath;

namespace Swashbuckle.Swagger.XmlComments
{
    public class ApplyXmlTypeComments : IModelFilter
    {
        private const string MemberXPath = "/doc/members/member[@name='{0}']";
        private const string SummaryTag = "summary";

        private readonly XPathDocument _xmlDoc;

        private readonly XPathNavigator _navigator;

        public ApplyXmlTypeComments(string filePath)
            : this(new XPathDocument(filePath)) { }

        public ApplyXmlTypeComments(XPathDocument xmlDoc)
        {
            _xmlDoc = xmlDoc;
            _navigator = xmlDoc.CreateNavigator();
        }

        public XPathNavigator XmlNavigator
        {
            get { return _navigator; }
        }

        public void Apply(Schema model, ModelFilterContext context)
        {            
            var commentId = XmlCommentsIdHelper.GetCommentIdForType(context.SystemType);
            var typeNode = _navigator.SelectSingleNode(string.Format(MemberXPath, commentId));

            if (typeNode != null)
            {
                var summaryNode = typeNode.SelectSingleNode(SummaryTag);
                if (summaryNode != null)
                    model.description = summaryNode.ExtractContent();
            }

            if (model.properties != null)
            {
                foreach (var entry in model.properties)
                {
                    var jsonProperty = context.JsonObjectContract.Properties[entry.Key];
                    if (jsonProperty == null) continue;

                    ApplyPropertyComments(_navigator, entry.Value, jsonProperty.PropertyInfo());
                }
            }
        }

        private static void ApplyPropertyComments(XPathNavigator navigator, Schema propertySchema, PropertyInfo propertyInfo)
        {
            if (propertyInfo == null) return;

            var commentId = XmlCommentsIdHelper.GetCommentIdForProperty(propertyInfo);
            var propertyNode = navigator.SelectSingleNode(string.Format(MemberXPath, commentId));
            if (propertyNode == null) return;

            var propSummaryNode = propertyNode.SelectSingleNode(SummaryTag);
            if (propSummaryNode != null)
            {
                propertySchema.description = propSummaryNode.ExtractContent();
            }
        }
    }
}