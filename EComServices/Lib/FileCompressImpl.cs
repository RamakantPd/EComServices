using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace EComServices.Lib
{
    public class FileCompressImpl
    {
        public string FileCompress(DirectoryInfo directoryInform, string filepath)
        {
            string msg = "";
            try
            {
                foreach (FileInfo filetoCompress in directoryInform.GetFiles())
                {
                    using (FileStream stream = filetoCompress.OpenRead())
                    {
                        if ((File.GetAttributes(filetoCompress.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & filetoCompress.Extension != ".gz")
                        {
                            using (FileStream compressfile = File.Create(filetoCompress.FullName + ".gz"))
                            {
                                using (GZipStream comprStream = new GZipStream(compressfile, CompressionMode.Compress))
                                {
                                    stream.CopyTo(comprStream);
                                }
                            }
                            FileInfo fileinfo = new FileInfo(filepath + Path.DirectorySeparatorChar + filetoCompress.Name + ".gz");
                            return msg = "File Compression Successfull";
                        }
                    };
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return msg;
        }
        public string FileDecompress(FileInfo fileinform)
        {
            string msg = "";
            try
            {
                using (FileStream file = fileinform.OpenRead())
                {
                    string currfile = fileinform.FullName;
                    string newfile = currfile.Remove(currfile.Length - fileinform.Extension.Length);
                    using (FileStream decompress = File.Create(newfile))
                    {
                        using (GZipStream decom = new GZipStream(file, CompressionMode.Decompress))
                        {
                            decom.CopyTo(decompress);
                            msg = "File Decompressed Successfull";
                            return msg;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            // return msg;
        }
    }
}
