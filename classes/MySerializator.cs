using Lesson12_13.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12_13.Core
{
    class MySerializator
    {
        protected string fileName;
        protected BinaryFormatter formatter;
        protected Stream stream;
        public MySerializator(string filename_)
        {
            fileName = filename_;
        }
        public void InFile(School instance)
        {
            formatter = new BinaryFormatter();
            stream = File.Create(fileName);
            formatter.Serialize(stream,instance);
            stream.Close();
            formatter = null;
        }
        public School FromFile()
        {
            formatter = new BinaryFormatter();
            stream = File.OpenRead(fileName);
            var data = formatter.Deserialize(stream) as School;
            stream.Close();
            return data;
        }
        public bool FileIsExist()
        {
            return File.Exists(fileName); 
        }
    }
}
