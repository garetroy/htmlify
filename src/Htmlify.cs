using System;
using System.IO;
using htmlify.src.Exceptions;

namespace htmlify
{
    public class Htmlify
    {
        public Htmlify(byte[] docxFile)
        {
            m_docxFile = docxFile;
            m_docxFilePath = null;
            m_htmlString = "";
            m_memoryStream = new MemoryStream();
        }

        public Htmlify(string docxFilePath)
        {
            m_docxFile = null; 
            m_docxFilePath = docxFilePath;
            m_htmlString = "";
            m_memoryStream = new MemoryStream();

            PopulateStream();
        }

        ~Htmlify()
        {
            m_memoryStream.Close();
        }
         
        private void PopulateStream()
        {
            try
            {
                if (m_htmlString != null) //Meaning we are trying to populate by string
                    using (FileStream stream = new FileStream(m_docxFilePath, FileMode.Open, FileAccess.Read))
                    {
                        stream.CopyTo(m_memoryStream);
                    }
                else
                    m_memoryStream.Read(m_docxFile, 0, m_docxFile.Length);
            }
            catch (IOException ioException)
            {
                string message = "Could not populate MemoryStream from FileStream";
                throw new MemoryPopulationFailed(message, ioException);
            }
            catch(ArgumentNullException argException)
            {
                string message = "Byte Array is null";
                throw new MemoryPopulationFailed(message, argException);
            }
        }

        public string HtmlString
        {
            get { return m_htmlString; }
        }

        public string FilePath
        {
            get { return m_docxFilePath; }
        }

        private readonly string m_htmlString;
        private readonly byte[] m_docxFile;
        private readonly string m_docxFilePath;
        private readonly MemoryStream m_memoryStream;
    }
}
