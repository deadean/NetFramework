namespace SmtpTest
{
	using System;
	using System.Text;
	using System.Xml.Serialization;
	using MailBee;
	using MailBee.Mime;
	using MailBee.Security;
	using MailBee.SmtpMail;

	public class Program
	{
		private const string MailBeeLicenseKey = "MN700-68A0DF51A04DA0F7A0CF5C78B1D9-4B8C";
		private const int MailBeeMaxLogSize = 0x500000; // 5 MB

		private static void Main(string[] args)
		{
			Global.LicenseKey = MailBeeLicenseKey;

			var settings = new CMailServerSettings
			{
				AuthenticationType = enAuthenticationType.PasswordClearText,
				HostName = "smtp.yandex.ru",
				Password = "810experimentum1989",
				Port = 465,
				UserName = "deadean@yandex.ru",
				SocketType = enSocketType.Ssl,
				UserNameType = enUserNameType.EmailAddress
			};
			var server = InitializeSmtpServer(settings);
			var client = InitializeSmtpClient(server);

			client.Connect();
			client.Hello();
			client.Login();

			var message = new MailMessage
			{
				XMailer = "Phone",
				From = new EmailAddress(settings.UserName),
				To = new EmailAddressCollection("deadeano@gmail.com"),
				Charset = Encoding.UTF8.WebName,
				Subject = string.Format("test_{0}", DateTime.Now.TimeOfDay),
				BodyPlainText = "Test email message body"
			};

			message.Attachments.Add("Test.log");

			client.Message = message;
			client.Send(settings.UserName, (string)null);

			if (client.IsBusy)
			{
				client.Abort();
			}
			else
			{
				client.Disconnect();
			}
		}

		private static Smtp InitializeSmtpClient(SmtpServer smtpServer)
		{
			var smtp = new Smtp();

			//smtp.Disconnected += OnSmtpDisconnected;
			//smtp.Disposed += OnSmtpDisposed;
			//smtp.ErrorOccurred += OnErrorOccurred;
			//smtp.MessageNotSent += OnMessageNotSent;
			//smtp.MessageSent += OnMessageSent;

			smtp.Log.MaxSize = MailBeeMaxLogSize;
			smtp.Log.Filename = "Test.log";
			smtp.Log.Enabled = true;

			smtp.DnsServers.Autodetect();
			smtp.SmtpServers.Add(smtpServer);

			smtp.Message.Builder.SetMessageIDOnSend = true;
			smtp.Message.Charset = Encoding.UTF8.WebName;
			smtp.RequestEncoding = Encoding.UTF8;
			smtp.ResponseEncoding = Encoding.UTF8;

			return smtp;
		}

		private static SmtpServer InitializeSmtpServer(CMailServerSettings settings)
		{
			var smtpServer = new SmtpServer(settings.HostName, settings.UserName, settings.Password) { Port = settings.Port };

			switch (settings.SocketType)
			{
				case enSocketType.Ssl:
					smtpServer.SslProtocol = SecurityProtocol.Auto;
					smtpServer.SslMode = SslStartupMode.OnConnect;
					break;
				case enSocketType.StartTls:
					smtpServer.SslProtocol = SecurityProtocol.Auto;
					smtpServer.SslMode = SslStartupMode.UseStartTlsIfSupported;
					break;
			}

			return smtpServer;
		}

		
		//private static TObject Deserialize<TObject>(string value, params Type[] extraTypes)
		//{
		//	if (string.IsNullOrEmpty(value))
		//		return default(TObject);

		//	using (var reader = new StringReader(value))
		//	{
		//		var xmlSerializer = extraTypes.IsNullOrEmpty()
		//			? new XmlSerializer(typeof(TObject))
		//			: new XmlSerializer(typeof(TObject), extraTypes);

		//		return (TObject)xmlSerializer.Deserialize(reader);
		//	}
		//}

		[Serializable]
		[XmlRoot("Settings")]
		public class CMailServerSettings
		{
			#region Fields

			[NonSerialized]
			private string mvPassword;

			#endregion // Fields

			#region Properties

			[XmlElement("HostName")]
			public string HostName { get; set; }

			[XmlElement("Socket")]
			public enSocketType SocketType { get; set; }

			[XmlElement("Port")]
			public int Port { get; set; }

			[XmlElement("UserNameType")]
			public enUserNameType UserNameType { get; set; }

			[XmlElement("Authentication")]
			public enAuthenticationType AuthenticationType { get; set; }

			[XmlElement("UserName")]
			public string UserName { get; set; }

			[XmlIgnore]
			public string Password
			{
				set { mvPassword = value; }
				get { return mvPassword; }
			}

			#endregion // Properties

			#region Methods

			public bool ShouldSerializeUserNameType()
			{
				return UserNameType != enUserNameType.EmailAddress;
			}

			public bool ShouldSerializeAuthenticationType()
			{
				return AuthenticationType != enAuthenticationType.PasswordClearText;
			}

			public bool ShouldSerializeUserName()
			{
				return AuthenticationType != enAuthenticationType.None && !string.IsNullOrWhiteSpace(UserName);
			}

			public bool ShouldSerializeEncyptedPassword()
			{
				return AuthenticationType != enAuthenticationType.None && !string.IsNullOrWhiteSpace(Password);
			}

			#endregion // Methods
		}

		[Serializable]
		[XmlRoot("Authentication")]
		public enum enAuthenticationType
		{
			[XmlEnum("ClearText")]
			PasswordClearText = 0, // do not change default

			[XmlEnum("Encrypted")]
			PasswordEncrypted,

			[XmlEnum("NTLM")]
			Ntlm,

			[XmlEnum("GSSAPI")]
			GssApi,

			[XmlEnum("IPAddress")]
			ClientIpAddress,

			[XmlEnum("TLSCertificate")]
			TlsClientCertificate,

			[XmlEnum("None")]
			None
		}

		[Serializable]
		[XmlRoot("UserName")]
		public enum enUserNameType
		{
			[XmlEnum("Email")]
			EmailAddress = 0, // do not change default

			[XmlEnum("LocalPart")]
			EmailLocalPart,

			[XmlEnum("Domain")]
			EmailDomain,

			[XmlEnum("RealName")]
			RealName
		}

		[Serializable]
		[XmlRoot("Socket")]
		public enum enSocketType
		{
			[XmlEnum("Plain")]
			Plain,

			[XmlEnum("SSL")]
			Ssl,

			[XmlEnum("STARTTLS")]
			StartTls
		}
	}
}