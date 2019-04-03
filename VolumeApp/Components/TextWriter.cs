using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace VolumeApp.Components
{
    public class TextWriter : ITextWriter, IDisposable
    {
        private string _locationPath;
        private string _fileName;
        private System.IO.TextWriter _textWriter;
        private System.IO.TextReader _textReader;
        private string _fullPath => Path.Combine(_locationPath, _fileName);

        public TextWriter(string locationPath, string fileName)
        {
            if(string.IsNullOrWhiteSpace(locationPath))
            {
                throw new ArgumentNullException(nameof(locationPath));
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            _locationPath = locationPath;
            _fileName = fileName;
        }

        public void WriteLine(string input)
        {
            using (_textWriter = File.AppendText(_fullPath))
            {
                _textWriter.WriteLine(input);
            }
        }

        public string ReadAll()
        {
            if (File.Exists(_fullPath))
            {
                using (_textReader = File.OpenText(_fullPath))
                {
                    return _textReader.ReadToEnd();
                }
            }
            else
            {
                return "";
            }
        }

        public void Clear()
        {
            using (_textWriter = File.CreateText(_fullPath)) { }
        }

        public void Dispose()
        {
            if(_textReader != null)
            {
                _textReader.Close();
                _textReader.Dispose();
            }

            if (_textWriter != null)
            {
                _textWriter.Close();
                _textWriter.Dispose();
            }
            
        }
    }
}
