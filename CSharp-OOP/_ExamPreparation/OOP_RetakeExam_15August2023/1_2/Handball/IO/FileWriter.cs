﻿using Handball.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.IO
{
    public class FileWriter : IWriter
    {
        public FileWriter()
        {
            using (StreamWriter writer = new StreamWriter("../../../output.txt", false))
            {
                writer.Write("");
            }
        }
        public void Write(string message)
        {
            using (StreamWriter writer = new StreamWriter("../../../output.txt", true))
            {
                writer.Write(message);
            }
        }

        public void WriteLine(string message)
        {
            using (StreamWriter writer = new StreamWriter("../../../output.txt", true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
