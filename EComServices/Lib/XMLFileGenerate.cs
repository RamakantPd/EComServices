using EComServices.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EComServices.Lib
{
    public class XMLFileGenerate
    {
        private readonly AdbContextConfiguration _context;
        private readonly IWebHostEnvironment _hostenvironmwnt;
        public XMLFileGenerate(AdbContextConfiguration context, IWebHostEnvironment hostenvironmwnt)
        {
            _context = context;
            _hostenvironmwnt = hostenvironmwnt;
        }
        private String XMLFileCreate(string filenm)
        {
            string message = "";
            //File Name
            // var filenm = "RegisteredUser5.xml";
            //File Path with File Name
            var wwwrootpath = _hostenvironmwnt.ContentRootPath;
            string path = Path.Combine(wwwrootpath + "/XML_Files/" + filenm);
            //End

            List<UserRegistrationModel> list = new List<UserRegistrationModel>();
            list = _context.UserRegistration.ToList();
            //
            //UserRegistrationModel rgst1 = new UserRegistrationModel();
            //Type of File Name
            XmlSerializer xs = new XmlSerializer(typeof(List<UserRegistrationModel>));
            TextWriter txt = new StreamWriter(path);
            //Data written on XML File
            xs.Serialize(txt, list);
            //End
            txt.Close();
            return message;
        }
    }
}
