#region Copyright (c) 2003, James W. Newkirk, Michael C. Two, Alexei A. Vorontsov, Charlie Poole, Philip A. Craig
/************************************************************************************
'
' Copyright  2002-2003 James W. Newkirk, Michael C. Two, Alexei A. Vorontsov, Charlie Poole
' Copyright  2000-2002 Philip A. Craig
'
' This software is provided 'as-is', without any express or implied warranty. In no 
' event will the authors be held liable for any damages arising from the use of this 
' software.
' 
' Permission is granted to anyone to use this software for any purpose, including 
' commercial applications, and to alter it and redistribute it freely, subject to the 
' following restrictions:
'
' 1. The origin of this software must not be misrepresented; you must not claim that 
' you wrote the original software. If you use this software in a product, an 
' acknowledgment (see the following) in the product documentation is required.
'
' Portions Copyright  2002-2003 James W. Newkirk, Michael C. Two, Alexei A. Vorontsov, Charlie Poole
' or Copyright  2000-2002 Philip A. Craig
'
' 2. Altered source versions must be plainly marked as such, and must not be 
' misrepresented as being the original software.
'
' 3. This notice may not be removed or altered from any source distribution.
'
'***********************************************************************************/
#endregion

using System;
using NUnit.Framework;
using NUnit.Tests.Assemblies;
using NUnit.Core.Builders;

namespace NUnit.Core.Tests
{
	/// <summary>
	/// TestNode construction tests. Does not repeat tests
	/// for the TestInfo base class.
	/// </summary>
	[TestFixture]	
	public class TestNodeTests
	{
		TestSuite testSuite;
		TestSuite testFixture;
		NUnit.Core.TestCase testCase1;

		[SetUp]
		public void SetUp()
		{
			testSuite = new TestSuite("MyTestSuite");
			testFixture = TestFixtureBuilder.Make( typeof( MockTestFixture ) );
			testSuite.Add( testFixture );

			testCase1 = (NUnit.Core.TestCase)testFixture.Tests[0];
		}

		[Test]
		public void ConstructFromSuite()
		{
			TestNode test = new TestNode( testSuite );
			Assert.IsNotNull( test.Tests );
			Assert.AreEqual( test.TestCount, CountTests( test ) );
		}

		private int CountTests( TestNode node )
		{
			if ( node.IsTestCase )
				return 1;

			int count = 0;
			if ( node.Tests != null )
				foreach( TestNode child in node.Tests )
					count += CountTests( child );
				
			return count;
		}

		[Test]
		public void ConstructFromTestCase()
		{
			TestNode test = new TestNode( testCase1 );
			Assert.IsNull( test.Tests );
		}
	}
}