using System;
using Cake.Common.Diagnostics;
using Cake.Core;
using CakeMail.RestClient;

namespace Cake.CakeMail.Email
{
    /// <summary>
    /// The actual worker for interacting with CakeMail's API
    /// </summary>
    internal static class CakeMailApi
    {
        /// <summary>
        /// Sends an email via the CakeMail API, based on the provided settings
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="senderName">The name of the person sending the email</param>
        /// <param name="senderAddress">The email address of the person sending the email</param>
        /// <param name="recipientAddress">The email address of the person who will recieve the email</param>
        /// <param name="subject">The subject line of the email</param>
        /// <param name="htmlContent">The HTML content</param>
        /// <param name="textContent">The text content</param>
        /// <param name="settings">The settings to be used when sending the email</param>
        /// <returns>An instance of <see cref="CakeMailResult"/> indicating success/failure</returns>
        internal static CakeMailResult SendEmail(this ICakeContext context, string senderName, string senderAddress, string recipientAddress, string subject, string htmlContent, string textContent, CakeMailSettings settings)
        {
            try
            {
                var cakeMail = new CakeMailRestClient(settings.ApiKey);

                var loginInfo = cakeMail.Users.LoginAsync(settings.UserName, settings.Password).Result;
                var userKey = loginInfo.UserKey;

                context.Verbose("Sending email to {0} via the CakeMail API...", recipientAddress);

                cakeMail.Relays.SendWithoutTrackingAsync(userKey, recipientAddress, subject, htmlContent, textContent, senderAddress, senderName).Wait();

                return new CakeMailResult(true, DateTime.UtcNow.ToString("u"), string.Empty);
            }
            catch (Exception e)
            {
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