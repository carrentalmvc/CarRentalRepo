using System;
using System.Configuration;
using System.Xml;
using System.Xml.Schema;

namespace CarRentals.Core
{
    public enum XmlValidationStatus
    {
        FailedToParse = 1,
        FailedSchemaValidation = 2,
        ValidXml = 3
    }

    public class XmlUtility
    {
        private XmlValidationStatus _status;

        public XmlValidationStatus ValidateXml(string xml)
        {
            try
            {
                _status = XmlValidationStatus.ValidXml;
                var schemaLocation = ConfigurationManager.AppSettings["SchemaLocation"].ToString();
                var settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                var schemaSet = new XmlSchemaSet();
                schemaSet.Add(null, schemaLocation);
                settings.Schemas.Add(schemaSet);
                settings.ValidationEventHandler += Schema_Validation_ErrorHandler;

                using (var rdr = XmlReader.Create(new XmlTextReader(xml), settings))
                {
                    while (rdr.Read())
                    {
                        if (rdr.NodeType == XmlNodeType.Element)
                        {
                            var elementName = rdr.Name;
                        }
                    }
                }
            }

            catch (XmlException ex)
            {
                throw;
            }

            catch (Exception ex)
            {
                throw;
            }

            return _status;
        }

        private void Schema_Validation_ErrorHandler(object sender, System.Xml.Schema.ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Error)
            {
                _status = XmlValidationStatus.FailedSchemaValidation;
                var responseMessage = new SchemaErrorResponseMessage();
                if (e.Exception != null)
                {
                    responseMessage.LineNumber = e.Exception.LineNumber;
                    responseMessage.LinePosition = e.Exception.LinePosition;
                }

                responseMessage.ErrorMessage = e.Message;
            }
        }
    }
}