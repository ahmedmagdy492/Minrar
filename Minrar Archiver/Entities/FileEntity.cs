﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minrar_Archiver.Entities
{
    public class FileEntity
    {
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
    }
}
