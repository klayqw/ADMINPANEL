﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FINALBANK.Models;

namespace FINALBANK.Service;

class Func
{

    public static int SendCodeEmail(User user)
    {
        int code = new Random().Next(10000, 99999);

        string fromMail = "pudgearcane5@gmail.com";
        string fromPassword = "pwauepbjjpoovets";

        var strComputerName = "UNIVERSALBANK";

        MailMessage message = new MailMessage();
        message.From = new MailAddress(fromMail);
        message.Subject = strComputerName;
        message.To.Add(new MailAddress(user.Email));
        message.Body = "<html><body>";
        message.Body += code;
        message.Body += "<br>";
        message.Body += "Have a good day!";
        message.IsBodyHtml = true;

        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(fromMail, fromPassword),
            EnableSsl = true,
        };

        smtpClient.Send(message);

        return code;
    }
   
}
