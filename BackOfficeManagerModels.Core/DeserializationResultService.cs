using System.Xml.Serialization;

namespace BackOfficeManagerModels.Core
{
    public class DeserializationResultService
    {
        public object TransferToData(Uri uri,string xml)
        {
            r _deserializationResult;

            XmlSerializer serializer = new XmlSerializer(typeof(r));
            using (var sr = new StringReader(xml))
            {
                _deserializationResult = (r)serializer.Deserialize(sr);
            }

            ServerProperties serverProperties = new ServerProperties(
                _deserializationResult.serverName,
                _deserializationResult.edition,
                 _deserializationResult.version,
                _deserializationResult.computerName,
                _deserializationResult.serverState,
                uri.Scheme,
                uri.Host,
                uri.PathAndQuery,
                uri.Port.ToString(),
                _deserializationResult.isPresent.ToString().ToLower());
            //{
            //    ServerName = _deserializationResult.serverName,
            //    ServerState = _deserializationResult.serverState,
            //    Edition = _deserializationResult.edition,
            //    Version = _deserializationResult.version,
            //    ComputerName = _deserializationResult.computerName,
            //    IsPresent = _deserializationResult.isPresent.ToString().ToLower() //IMPORTANT

            //};
            return serverProperties;
        }
    }
}