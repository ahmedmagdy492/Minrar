using Minrar_Archiver.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minrar_Archiver.Services
{
    public class ArchivingService
    {
        public byte[] Encode(List<FileEntity> files, bool isEncrypted = false)
        {
            List<byte> content = new List<byte>();
            string header = "MRAR";
            content.AddRange(Encoding.ASCII.GetBytes(header));
            content.Add(1); // version number
            content.Add(isEncrypted ? (byte)1 : (byte)0);
            content.Add((byte)files.Count);

            foreach(var file in files) 
            {
                // copying filename length
                byte[] fileNameInBytes = BitConverter.GetBytes(Util.GetFilenameLengthInBytes(file.FileName));
                content.AddRange(fileNameInBytes);

                // copying filename
                content.AddRange(Encoding.UTF8.GetBytes(file.FileName));

                // copy file content size
                content.AddRange(BitConverter.GetBytes(file.FileContent.Length));

                // copy file content
                content.AddRange(file.FileContent);
            }

            return content.ToArray();
        }

        public bool IsEncrypted(byte[] archiveContent)
        {
            return archiveContent[5] == 1;
        }

        public FileEntity[] Decode(byte[] archiveContent)
        {
            if (Encoding.ASCII.GetString(archiveContent[0..4]) != "MRAR")
            {
                throw new Exception("Invalid Minrar File Format");
            }

            var files = new List<FileEntity>();
            int fileOffset = 7;

            for(; fileOffset < archiveContent.Length;)
            {
                int fileNameSize = BitConverter.ToInt32(archiveContent[fileOffset..(fileOffset+4)]);
                fileOffset += 4;
                string fileName = Encoding.UTF8.GetString(archiveContent[fileOffset..(fileOffset+fileNameSize)]);
                fileOffset += fileNameSize;
                int fileContentSize = BitConverter.ToInt32(archiveContent[fileOffset..(fileOffset+4)]);
                fileOffset += 4;
                files.Add(new FileEntity
                {
                    FileName = fileName,
                    FileContent = archiveContent[fileOffset..(fileOffset+fileContentSize)],
                });
                fileOffset += fileContentSize;
            }

            return files.ToArray();
        }
    }
}
