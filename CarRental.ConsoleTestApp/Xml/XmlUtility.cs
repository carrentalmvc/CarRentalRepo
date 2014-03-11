using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace CarRental.ConsoleTestApp
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
                var settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.ValidationFlags = System.Xml.Schema.XmlSchemaValidationFlags.ProcessInlineSchema;
                var schemaSet = new XmlSchemaSet();
                schemaSet.Add("http://www.Carrentals.com/XmlSchemas",@"C:\ASPNET\CarRentalMVCAnilRennish\CarRentalRepo\CarRental.ConsoleTestApp\Xml\Person.xsd");
                settings.Schemas.Add(schemaSet);
                settings.ValidationEventHandler += Schema_Validation_ErrorHandler;

                using (var stream = new StreamReader(xml))
                {
                    using (var rdr = XmlReader.Create(stream, settings))
                    {
                        while (rdr.Read())
                        {
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