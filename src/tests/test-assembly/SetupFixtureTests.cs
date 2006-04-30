using System;
using System.Collections;
using System.Text;
using NUnit.Framework;

namespace NUnit.TestUtilities
{
    /// <summary>
    /// A helper to Verify that Setup/Teardown 'events' occur, and that they are in the correct order...
    /// </summary>
    public class SimpleEventRecorder
    {
        private static System.Collections.Queue _events;

        /// <summary>
        /// Initializes the <see cref="T:EventRegistrar"/> 'static' class.
        /// </summary>
        static SimpleEventRecorder()
        {
            _events = new System.Collections.Queue();
        }

        /// <summary>
        /// Registers an event.
        /// </summary>
        /// <param name="evnt">The event to register.</param>
        public static void RegisterEvent(string evnt)
        {
            System.Console.WriteLine(evnt);
            _events.Enqueue(evnt);
        }


        /// <summary>
        /// Verifies the specified expected events occurred and that they occurred in the specified order.
        /// </summary>
        /// <param name="expectedEvents">The expected events.</param>
        public static void Verify(params string[] expectedEvents)
        {
            foreach (string expected in expectedEvents)
            {
                if (_events.Count == 0)
                    throw new AssertionException(string.Format("Not enough events occurred.\n\tThe next expected event was: \"{0}\"", expected));
                string actual = _events.Dequeue() as string;
                if (expected != actual)
                    throw new AssertionException(string.Format("Actual event doesn't match expected event.\n\texpected:{0}\n\tactual:{1}", expected, actual));
            }
        }

        /// <summary>
        /// Clears any unverified events.
        /// </summary>
        public static void Clear()
        {
            _events.Clear();
        }
    }
}

namespace NUnit.TestData.SetupFixture
{
    namespace Namespace1
    {
        #region SomeTestFixture
        [TestFixture]
        public class SomeTestFixture
        {
            [TestFixtureSetUp]
            public void FixtureSetup()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("FixtureSetup");
            }

            [SetUp]
            public void Setup()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("Setup");
            }

            [Test]
            public void Test()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("Test");
            }

            [TearDown]
            public void TearDown()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("TearDown");
            }

            [TestFixtureTearDown]
            public void FixtureTearDown()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("FixtureTearDown");
            }
        }
        #endregion SomeTestFixture

        [SetUpFixture]
        public class NUnitNamespaceSetUpFixture
        {
            [TestFixtureSetUp]
            public void DoNamespaceSetUp()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("NamespaceSetup");
            }

            [TestFixtureTearDown]
            public void DoNamespaceTearDown()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("NamespaceTearDown");
            }
        }
    }

    namespace Namespace2
    {

        #region SomeTestFixture
        /// <summary>
        /// Summary description for SetUpFixtureTests.
        /// </summary>
        [TestFixture]
        public class SomeTestFixture
        {


            [TestFixtureSetUp]
            public void FixtureSetup()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("FixtureSetup");
            }

            [SetUp]
            public void Setup()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("Setup");
            }

            [Test]
            public void Test()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("Test");
            }

            [TearDown]
            public void TearDown()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("TearDown");
            }

            [TestFixtureTearDown]
            public void FixtureTearDown()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("FixtureTearDown");
            }
        }
        #endregion SomeTestFixture

        #region SomeTestFixture2
        [TestFixture]
        public class SomeTestFixture2
        {


            [TestFixtureSetUp]
            public void FixtureSetup()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("FixtureSetup");
            }

            [SetUp]
            public void Setup()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("Setup");
            }

            [Test]
            public void Test()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("Test");
            }

            [TearDown]
            public void TearDown()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("TearDown");
            }

            [TestFixtureTearDown]
            public void FixtureTearDown()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("FixtureTearDown");
            }
        }
        #endregion SomeTestFixture2

        [SetUpFixture]
        public class NUnitNamespaceSetUpFixture
        {
            [TestFixtureSetUp]
            public void DoNamespaceSetUp()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("NamespaceSetup");
            }

            [TestFixtureTearDown]
            public void DoNamespaceTearDown()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("NamespaceTearDown");
            }
        }
    }

    namespace Namespace3
    {
        namespace SubNamespace
        {


            #region SomeTestFixture
            [TestFixture]
            public class SomeTestFixture
            {
                [TestFixtureSetUp]
                public void FixtureSetup()
                {
                    TestUtilities.SimpleEventRecorder.RegisterEvent("FixtureSetup");
                }

                [SetUp]
                public void Setup()
                {
                    TestUtilities.SimpleEventRecorder.RegisterEvent("Setup");
                }

                [Test]
                public void Test()
                {
                    TestUtilities.SimpleEventRecorder.RegisterEvent("Test");
                }

                [TearDown]
                public void TearDown()
                {
                    TestUtilities.SimpleEventRecorder.RegisterEvent("TearDown");
                }

                [TestFixtureTearDown]
                public void FixtureTearDown()
                {
                    TestUtilities.SimpleEventRecorder.RegisterEvent("FixtureTearDown");
                }
            }
            #endregion SomeTestFixture

            [SetUpFixture]
            public class NUnitNamespaceSetUpFixture
            {
                [TestFixtureSetUp]
                public void DoNamespaceSetUp()
                {
                    TestUtilities.SimpleEventRecorder.RegisterEvent("SubNamespaceSetup");
                }

                [TestFixtureTearDown]
                public void DoNamespaceTearDown()
                {
                    TestUtilities.SimpleEventRecorder.RegisterEvent("SubNamespaceTearDown");
                }
            }

        }


        #region SomeTestFixture
        [TestFixture]
        public class SomeTestFixture
        {
            [TestFixtureSetUp]
            public void FixtureSetup()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("FixtureSetup");
            }

            [SetUp]
            public void Setup()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("Setup");
            }

            [Test]
            public void Test()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("Test");
            }

            [TearDown]
            public void TearDown()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("TearDown");
            }

            [TestFixtureTearDown]
            public void FixtureTearDown()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("FixtureTearDown");
            }
        }
        #endregion SomeTestFixture

        [SetUpFixture]
        public class NUnitNamespaceSetUpFixture
        {
            [TestFixtureSetUp]
            public void DoNamespaceSetUp()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("NamespaceSetup");
            }

            [TestFixtureTearDown]
            public void DoNamespaceTearDown()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("NamespaceTearDown");
            }
        }
    }

    namespace Namespace4
    {
        #region SomeTestFixture
        [TestFixture]
        public class SomeTestFixture
        {
            [TestFixtureSetUp]
            public void FixtureSetup()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("FixtureSetup");
            }

            [SetUp]
            public void Setup()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("Setup");
            }

            [Test]
            public void Test()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("Test");
            }

            [TearDown]
            public void TearDown()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("TearDown");
            }

            [TestFixtureTearDown]
            public void FixtureTearDown()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("FixtureTearDown");
            }
        }
        #endregion SomeTestFixture

        [SetUpFixture]
        public class NUnitNamespaceSetUpFixture
        {
            [TestFixtureSetUp]
            public void DoNamespaceSetUp()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("NamespaceSetup");
            }

            [TestFixtureTearDown]
            public void DoNamespaceTearDown()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("NamespaceTearDown");
            }
        }

        [SetUpFixture]
        public class NUnitNamespaceSetUpFixture2
        {
            [TestFixtureSetUp]
            public void DoNamespaceSetUp()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("NamespaceSetup2");
            }

            [TestFixtureTearDown]
            public void DoNamespaceTearDown()
            {
                TestUtilities.SimpleEventRecorder.RegisterEvent("NamespaceTearDown2");
            }
        }
    }
}
#region NoNamespaceSetupFixture
[SetUpFixture]
public class NoNamespaceSetupFixture
{
    [TestFixtureSetUp]
    public void DoNamespaceSetUp()
    {
        NUnit.TestUtilities.SimpleEventRecorder.RegisterEvent("RootNamespaceSetup");
    }

    [TestFixtureTearDown]
    public void DoNamespaceTearDown()
    {
        NUnit.TestUtilities.SimpleEventRecorder.RegisterEvent("RootNamespaceTearDown");
    }
}

[TestFixture]
public class SomeTestFixture
{
    [Test]
    public void Test()
    {
        NUnit.TestUtilities.SimpleEventRecorder.RegisterEvent("Test");
    }
}
#endregion NoNamespaceSetupFixture