﻿using MailKit.Net.Smtp;
using MessageSevice.Core.MessageModel;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MessageSevice.Core.Default
{
	public class EmailMessageSender : IMessageSender<Email>
	{
		public void Send(Email message)
		{
			string configName = message.MailServerConfigName != null ? message.MailServerConfigName : Constants.DefaulMailServerConfigName;

			if (!GlobalConfiguration.Configuration.Configurations.Keys.Contains(configName))
				throw new InvalidOperationException("");

			var mailServerConfig = (MailServerConfiguration)GlobalConfiguration.Configuration.Configurations[configName];

			var mimeMessage = new MimeMessage();
			mimeMessage.To.AddRange(message.To.Select(x => new MailboxAddress(x.Name, x.Address)));
			mimeMessage.From.AddRange(message.From.Select(x => new MailboxAddress(x.Name, x.Address)));

			mimeMessage.Subject = message.Subject;

			//We will say we are sending HTML. But there are options for plaintext etc. 
			var body = new TextPart(TextFormat.Html)
			{
				Text = message.Body
			};

			var multipart = new Multipart("mixed");
			multipart.Add(body);
			message.Attachments.ForEach(a =>
			{
				var stream = new MemoryStream(a.Content);
				new MimePart(a.ContentType)
				{
					Content = new MimeContent(stream, ContentEncoding.Default),
					FileName = a.Name
				};
			});

			//Be careful that the SmtpClient class is the one from Mailkit not the framework!
			using (var emailClient = new SmtpClient())
			{
				//The last parameter here is to use SSL (Which you should!)
				emailClient.Connect(mailServerConfig.SmtpServer, mailServerConfig.SmtpPort, true);

				//Remove any OAuth functionality as we won't be using it. 
				emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

				emailClient.Authenticate(mailServerConfig.SmtpUsername, mailServerConfig.SmtpPassword);

				emailClient.Send(mimeMessage);

				emailClient.Disconnect(true);
			}
		}
	}
}
