/*
 * LICENSE NOTICE:
 * Changing the copyright information in this file is a violation of the license.
 */

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]

[assembly: AssemblyTitle("QuoteServ")]
[assembly: AssemblyDescription("IRC Quote Bot")]
[assembly: AssemblyCompany("Earth2Me")]
[assembly: AssemblyProduct("QuoteServ")]
[assembly: AssemblyCopyright("Copyright © 2012 Earth2Me")]
[assembly: AssemblyTrademark("Earth2Me is a trademark of Paul Buonopane.")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyVersion("1.0.0.*")]

#if DEBUG
[assembly: AssemblyConfiguration("DEBUG")]
#else
[assembly: AssemblyConfiguration("RELEASE")]
#endif

#if DELAY_SIGN
[assembly: AssemblyDelaySign(true)]
[assembly: AssemblyKeyFile("../Keys/QuoteServ.snk")]
#else
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
#endif
