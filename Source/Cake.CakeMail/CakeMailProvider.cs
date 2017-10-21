using System;
using System.Collections.Generic;
using System.Linq;
using Cake.CakeMail.Email;
using Cake.Common.Diagnostics;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Email.Common;
using CakeMail.RestClient;

namespace Cake.CakeMail
{
    /// <summary>
    /// Contains functionality related to CakeMail API
    /// </summary>
    [CakeAliasCategory("CakeMail")]
    public sealed class CakeMailProvider
    {
        private readonly ICakeContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CakeMailProvider"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CakeMailProvider(ICakeContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Send an email through CakeMail
        /// </summary>
        /// <param name="senderName">The name of the person sending the email</param>
        /// <param name="senderAddress">The email addresses of the person sending the email</param>
        /// <param name="recipientAddress">The email addresses of the person who will recieve the email</param>
        /// <param name="subject">The subject line of the email</param>
        /// <param name="htmlContent">The HTML content</param>
        /// <param name="textContent">The text content</param>
        /// <param name="settings">The settings to be used when sending the email</param>
        /// <returns>An instance of <see cref="CakeMailResult"/> indicating success/failure</returns>
        /// <example>
        /// <code>
        /// var apiKey = "... your api key ...";
        /// var userName = "... your username ...";
        /// var password = "... your password ...";
        /// try
        /// {
        ///     var result = CakeMail.SendEmail(
        ///         senderName: "Bob Smith",
        ///         senderAddress: "bob@example.com",
        ///         recipientAddress: "jane@example.com",
        ///         subject: "This is a test",
        ///         htmlContent: "<html><body>This is a test</body></html>",
        ///         textContent: "This is a test",
        ///         settings: new CakeMailEmailSettings
        ///         {
        ///         ApiKey = apiKey,
        ///         UserName = userName,
        ///         Password = password
        ///         }
        ///     );
        ///     if (result.Ok)
        ///     {
        ///         Information("Email succcessfully sent");
        ///     }
        ///     else
        ///     {
        ///         Error("Failed to send email: {0}", result.Error);
        ///     }
        /// }
        /// catch(Exception ex)
        /// {
        ///     Error("{0}", ex);
        /// }
        /// </code>
        /// </example>
        [CakeAliasCategory("Email")]
        public CakeMailResult SendEmail(string senderName, string senderAddress, string recipientAddress, string subject, string htmlContent, string textContent, CakeMailSettings settings)
        {
            var recipients = new[] { recipientAddress };
            return SendEmail(senderName, senderAddress, recipients, subject, htmlContent, textContent, settings);
        }

        /// <summary>
        /// Send an email through CakeMail
        /// </summary>
        /// <param name="senderName">The name of the person sending the email</param>
        /// <param name="senderAddress">The email addresses of the person sending the email</param>
        /// <param name="recipient">The MailAddress of the person who will recieve the email</param>
        /// <param name="subject">The subject line of the email</param>
        /// <param name="htmlContent">The HTML content</param>
        /// <param name="textContent">The text content</param>
        /// <param name="settings">The settings to be used when sending the email</param>
        /// <returns>An instance of <see cref="CakeMailResult"/> indicating success/failure</returns>
        /// <example>
        /// <code>
        /// var apiKey = "... your api key ...";
        /// var userName = "... your username ...";
        /// var password = "... your password ...";
        /// try
        /// {
        ///     var result = CakeMail.SendEmail(
        ///         senderName: "Bob Smith",
        ///         senderAddress: "bob@example.com",
        ///         recipientAddress: "jane@example.com",
        ///         subject: "This is a test",
        ///         htmlContent: "<html><body>This is a test</body></html>",
        ///         textContent: "This is a test",
        ///         settings: new CakeMailEmailSettings
        ///         {
        ///         ApiKey = apiKey,
        ///         UserName = userName,
        ///         Password = password
        ///         }
        ///     );
        ///     if (result.Ok)
        ///     {
        ///         Information("Email succcessfully sent");
        ///     }
        ///     else
        ///     {
        ///         Error("Failed to send email: {0}", result.Error);
        ///     }
        /// }
        /// catch(Exception ex)
        /// {
        ///     Error("{0}", ex);
        /// }
        /// </code>
        /// </example>
        [CakeAliasCategory("Email")]
        public CakeMailResult SendEmail(string senderName, string senderAddress, MailAddress recipient, string subject, string htmlContent, string textContent, CakeMailSettings settings)
        {
            var recipients = new[] { recipient };
            return SendEmail(senderName, senderAddress, recipients, subject, htmlContent, textContent, settings);
        }

        /// <summary>
        /// Send an email through CakeMail
        /// </summary>
        /// <param name="senderName">The name of the person sending the email</param>
        /// <param name="senderAddress">The email addresses of the person sending the email</param>
        /// <param name="recipients">The MailAddress of the recipients who will recieve the email</param>
        /// <param name="subject">The subject line of the email</param>
        /// <param name="htmlContent">The HTML content</param>
        /// <param name="textContent">The text content</param>
        /// <param name="settings">The settings to be used when sending the email</param>
        /// <returns>An instance of <see cref="CakeMailResult"/> indicating success/failure</returns>
        /// <example>
        /// <code>
        /// var apiKey = "... your api key ...";
        /// var userName = "... your username ...";
        /// var password = "... your password ...";
        /// try
        /// {
        ///     var result = CakeMail.SendEmail(
        ///         senderName: "Bob Smith",
        ///         senderAddress: "bob@example.com",
        ///         recipients: new[] { "jane@example.com", "bob@example.com" },
        ///         subject: "This is a test",
        ///         htmlContent: "<html><body>This is a test</body></html>",
        ///         textContent: "This is a test",
        ///         settings: new CakeMailEmailSettings
        ///         {
        ///         ApiKey = apiKey,
        ///         UserName = userName,
        ///         Password = password
        ///         }
        ///     );
        ///     if (result.Ok)
        ///     {
        ///         Information("Email succcessfully sent");
        ///     }
        ///     else
        ///     {
        ///         Error("Failed to send email: {0}", result.Error);
        ///     }
        /// }
        /// catch(Exception ex)
        /// {
        ///     Error("{0}", ex);
        /// }
        /// </code>
        /// </example>
        [CakeAliasCategory("Email")]
        public CakeMailResult SendEmail(string senderName, string senderAddress, IEnumerable<MailAddress> recipients, string subject, string htmlContent, string textContent, CakeMailSettings settings)
        {
            var recipientsAddress = recipients.Select(r => r.Address).ToArray();
            return SendEmail(senderName, senderAddress, recipientsAddress, subject, htmlContent, textContent, settings);
        }

        /// <summary>
        /// Send an email through CakeMail
        /// </summary>
        /// <param name="senderName">The name of the person sending the email</param>
        /// <param name="senderAddress">The email addresses of the person sending the email</param>
        /// <param name="recipientsAddress">The email addresses of the recipients who will recieve the email</param>
        /// <param name="subject">The subject line of the email</param>
        /// <param name="htmlContent">The HTML content</param>
        /// <param name="textContent">The text content</param>
        /// <param name="settings">The settings to be used when sending the email</param>
        /// <returns>An instance of <see cref="CakeMailResult"/> indicating success/failure</returns>
        /// <example>
        /// <code>
        /// var apiKey = "... your api key ...";
        /// var userName = "... your username ...";
        /// var password = "... your password ...";
        /// try
        /// {
        ///     var result = CakeMail.SendEmail(
        ///         senderName: "Bob Smith",
        ///         senderAddress: "bob@example.com",
        ///         recipients: new[] { "jane@example.com", "bob@example.com" },
        ///         subject: "This is a test",
        ///         htmlContent: "<html><body>This is a test</body></html>",
        ///         textContent: "This is a test",
        ///         settings: new CakeMailEmailSettings
        ///         {
        ///         ApiKey = apiKey,
        ///         UserName = userName,
        ///         Password = password
        ///         }
        ///     );
        ///     if (result.Ok)
        ///     {
        ///         Information("Email succcessfully sent");
        ///     }
        ///     else
        ///     {
        ///         Error("Failed to send email: {0}", result.Error);
        ///     }
        /// }
        /// catch(Exception ex)
        /// {
        ///     Error("{0}", ex);
        /// }
        /// </code>
        /// </example>
        [CakeAliasCategory("Email")]
        public CakeMailResult SendEmail(string senderName, string senderAddress, IEnumerable<string> recipientsAddress, string subject, string htmlContent, string textContent, CakeMailSettings settings)
        {
            try
            {
                if (settings == null)
                {
                    throw new ArgumentNullException(nameof(settings));
                }

                if (string.IsNullOrWhiteSpace(senderAddress))
                {
                    throw new ArgumentNullException(nameof(senderAddress), "You must specify the 'from' email address.");
                }

                if (string.IsNullOrWhiteSpace(subject))
                {
                    throw new ArgumentNullException(nameof(subject), "You must specify the subject.");
                }

                if (string.IsNullOrWhiteSpace(htmlContent) && string.IsNullOrEmpty(textContent))
                {
                    throw new ArgumentException("You must specify the HTML content and/or the text content. We can't send an empty email.");
                }

                if (recipientsAddress == null || !recipientsAddress.Any(r => !string.IsNullOrWhiteSpace(r)))
                {
                    throw new ArgumentNullException(nameof(recipientsAddress), "You must specify at least one recipient.");
                }

                var safeRecipients = recipientsAddress.Where(r => !string.IsNullOrEmpty(r));
                if (!safeRecipients.Any())
                {
                    throw new CakeException("None of the recipients you specified have an email address");
                }

                var client = new CakeMailRestClient(settings.ApiKey);
                _context.Verbose("Sending email to {0} via the CakeMail API...", string.Join(", ", safeRecipients.ToArray()));

                var loginInfo = client.Users.LoginAsync(settings.UserName, settings.Password).Result;
                var userKey = loginInfo.UserKey;

                // CakeMail does not support sending a relay to multiple recipients, therefore we must send one email to each recipient
                foreach (var recipientAddres in safeRecipients)
                {
                    client.Relays.SendWithoutTrackingAsync(userKey, recipientAddres, subject, htmlContent, textContent, senderAddress, senderName).Wait();
                }

                return new CakeMailResult(true, DateTime.UtcNow.ToString("u"), string.Empty);
            }
            catch (Exception e)
            {
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }

                if (settings.ThrowOnFail.HasValue && settings.ThrowOnFail.Value)
                {
                    throw new CakeException(e.Message);
                }
                else
                {
                    return new CakeMailResult(false, DateTime.UtcNow.ToString("u"), e.Message);
                }
            }
        }
    }
}
