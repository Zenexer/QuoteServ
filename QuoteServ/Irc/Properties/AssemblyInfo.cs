/*
 * $Id: AssemblyInfo.cs 214 2007-04-06 14:12:17Z meebey $
 * $URL: svn://svn.qnetp.net/smartirc/SmartIrc4net/tags/0.4.0/src/AssemblyInfo.cs $
 * $Rev: 214 $
 * $Author: meebey $
 * $Date: 2007-04-06 16:12:17 +0200 (Fri, 06 Apr 2007) $
 *
 * SmartIrc4net - the IRC library for .NET/C# <http://smartirc4net.sf.net>
 *
 * Copyright (c) 2003-2005 Mirco Bauer <meebey@meebey.net> <http://www.meebey.net>
 * 
 * Full LGPL License: <http://www.gnu.org/licenses/lgpl.txt>
 * 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]

[assembly: AssemblyTitle("SmartIrc4net")]
[assembly: AssemblyDescription("IRC Library for CLI (mono/.NET)")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("qNETp")]
[assembly: AssemblyProduct("SmartIrc4net")]
[assembly: AssemblyCopyright("Copyright © 2003-2012 Mirco Bauer <meebey@meebey.net>; Copyright © 2012 Earth2Me")]
[assembly: AssemblyTrademark("Earth2Me is a trademark of Paul Buonopane.")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyVersion("0.4.0.*")]

#if DEBUG
[assembly: AssemblyConfiguration("DEBUG")]
#else
[assembly: AssemblyConfiguration("RELEASE")]
#endif

#if DELAY_SIGN
[assembly: AssemblyDelaySign(true)]
[assembly: AssemblyKeyFile("../Keys/Irc.snk")]
#else
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
#endif
