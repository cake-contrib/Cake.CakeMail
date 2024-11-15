using Cake.Core;
using Cake.Core.Annotations;
using System;

[assembly: CLSCompliant(true)]

namespace Cake.CakeMail
{
	/// <summary>
	/// <para>Contains aliases related to <see href="https://cakemail.com/">CakeMail</see>.</para>
	/// <para>
	/// In order to use the commands for this addin, you will need to include the following in your build.cake file to download and
	/// reference from NuGet.org:
	/// <code>
	/// #addin Cake.CakeMail
	/// </code>
	/// </para>
	/// </summary>
	[CakeAliasCategory("CakeMail")]
	public static class CakeMailAliases
	{
		/// <summary>
		/// Gets a <see cref="CakeMailProvider"/> instance that can be used for communicating with CakeMailProvider API.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <returns>A <see cref="CakeMailProvider"/> instance.</returns>
		[CakePropertyAlias(Cache = true)]
		[CakeNamespaceImport("Cake.CakeMail.Email")]
		public static CakeMailProvider CakeMail(this ICakeContext context)
		{
			ArgumentNullException.ThrowIfNull(context, nameof(context));
			return new CakeMailProvider(context);
		}
	}
}
