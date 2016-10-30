using Cake.Core.Annotations;

namespace Cake.CakeMail.Email
{
    /// <summary>
    /// Class that lets you override default API settings
    /// </summary>
    [CakeAliasCategory("CakeMail")]
    public sealed class CakeMailSettings
    {
        /// <summary>
        /// Gets or sets the ApiKey used for authentication.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the username used for authentication.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password used for authentication.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the Optional flag for if should throw exception on failure
        /// </summary>
        public bool? ThrowOnFail { get; set; }
    }
}