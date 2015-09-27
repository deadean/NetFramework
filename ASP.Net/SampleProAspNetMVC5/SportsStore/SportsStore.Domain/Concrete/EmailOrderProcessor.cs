using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;
using System.Net.Mail;
using System.Net;

namespace SportsStore.Domain.Concrete
{
	public class EmailSettings
	{
		public string MailToAddress = "deadean@yandex.ru";
		public string MailFromAddress = "deadean@yandex.ru";
		public bool UseSel = true;
		public string Username = "deadean";
		public string Password = "";
		public string ServerName = "smtp.yandex.com";
		public int ServerPort = 587;
		public bool WriteAsFile = false;
		public string FileLocation = "/sports_store_emails";
	}
	public class EmailOrderProcessor : IOrderProcessor
	{

		#region Fields

		private EmailSettings modEmailSettings;

		#endregion

		#region Properties

		#endregion

		#region Ctor

		public EmailOrderProcessor(EmailSettings settings)
		{
			modEmailSettings = settings;
		}

		#endregion

		#region Public Methods

		public void ProcessOrder(Cart cart, ShippingDetails shippingDetails)
		{
			using (var smtpClient = new SmtpClient())
			{
				smtpClient.EnableSsl = modEmailSettings.UseSel;
				smtpClient.Host = modEmailSettings.ServerName;
				smtpClient.Port = modEmailSettings.ServerPort;
				smtpClient.Credentials = new NetworkCredential(modEmailSettings.Username, modEmailSettings.Password);
				smtpClient.UseDefaultCredentials = false;
				if (modEmailSettings.WriteAsFile)
				{
					smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
					smtpClient.PickupDirectoryLocation = modEmailSettings.FileLocation;
					smtpClient.EnableSsl = false;
				}

				StringBuilder body = new StringBuilder()
					.AppendLine("A new order has been submitted")
					.AppendLine("-----")
					.AppendLine("Items");
				foreach (var line in cart.Lines)
				{
					var subtotal = line.Product.Price * line.Quantity;
					body.AppendFormat("{0} x {1} (subtotal: {2:c})", line.Quantity, line.Product.Name, subtotal);
				}

				body.AppendFormat("Total order value: {0:c}", cart.ComputeTotalValue())
					.AppendLine("---")
					.AppendLine("Ship to:")
					.AppendLine(shippingDetails.Name)
					.AppendLine(shippingDetails.Line1)
					.AppendLine(shippingDetails.Line2 ?? "")
					.AppendLine(shippingDetails.Line3 ?? "")
					.AppendLine(shippingDetails.City)
					.AppendLine(shippingDetails.State ?? "")
					.AppendLine(shippingDetails.Country)
					.AppendLine(shippingDetails.Zip)
					.AppendLine("---")
					.AppendFormat("Gift wrap: {0}", shippingDetails.GiftWrap ? "Yes" : "No");

				MailMessage mailMessage = new MailMessage(
					modEmailSettings.MailFromAddress,
					modEmailSettings.MailToAddress,
          "New order submitted!",
					body.ToString()
					);

				if (modEmailSettings.WriteAsFile)
				{
					mailMessage.BodyEncoding = Encoding.ASCII;
				}

				smtpClient.Send(mailMessage);
			}	
		}

		#endregion

		#region Private Methods

		#endregion

		#region Protected Methods

		#endregion

	}
}
