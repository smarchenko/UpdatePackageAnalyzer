using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpdatePackageAnalyzer
{
  using System.IO;
  using System.Xml;

  using Sitecore.Shell.Applications.ContentEditor;
  using Sitecore.Update.Commands;
  using Sitecore.Update.Configuration;
  using Sitecore.Update.Interfaces;

  public static class CommandSerializer
  {
    public static void Serialize(string path, ICommand command)
    {
      string commandStr = string.Empty;
      if (command != null)
      {
        commandStr = Serialize(command);
      }

      using (var writer = new StreamWriter(path, false))
      {
        writer.Write(commandStr);
      }
    }

    public static string Serialize(ICommand command)
    {
      var stream = new MemoryStream();
      XmlWriter writer = GetWriter(stream);
      SerializationContext context = SerializationCommandFactory.GetSerializationContext();
      SerializationCommandFactory.SerializeCommand(command, writer, context);
      writer.Close();
      stream.Seek(0, SeekOrigin.Begin);
      string value;
      using (var reader = new StreamReader(stream))
      {
        value = reader.ReadToEnd();
      }

      return value;
    }

    public static XmlWriter GetWriter(Stream stream)
    {
      var settings = new XmlWriterSettings
                       {
                         Indent = true,
                         NewLineHandling = NewLineHandling.Entitize,
                         ConformanceLevel = ConformanceLevel.Fragment
                       };
      return XmlWriter.Create(stream, settings);
    }

    public static XmlReader GetReader(Stream stream)
    {
      var settings = new XmlReaderSettings
      {
        IgnoreWhitespace = true,
        ConformanceLevel = ConformanceLevel.Fragment
      };

      return XmlReader.Create(stream, settings);
    }
  }
}
