using System;
using MethodBoundaryAspect.Fody.UnitTests.TestAssembly.NetFramework.Aspects;

namespace MethodBoundaryAspect.Fody.UnitTests.TestAssembly.NetFramework
{
    public class ClassWithGenericMethodWithConstraint
    {
        [SetInstanceValueAspect]
        public string DoItWithImplementedConstraint<T>(T test) where T : ITestClass
        {
            return test.Test();
        }

        [SetInstanceValueAspect]
        public void DoItWithClassConstraint<T>(T test) where T : class
        {
#pragma warning disable CS0219 // Variable is assigned but its value is never used
            T t = default(T);
#pragma warning restore CS0219 // Variable is assigned but its value is never used
        }

        [SetInstanceValueAspect]
        public void DoItWithStructConstraint<T>(T test) where T : struct
        {
#pragma warning disable CS0219 // Variable is assigned but its value is never used
            T t = default(T);
#pragma warning restore CS0219 // Variable is assigned but its value is never used
        }

        [SetInstanceValueAspect]
        public void DoItWithNewConstraint<T>(T test) where T : new()
        {
            T t = new T();
        }
    }

    public interface ITestClass
    {
        string Test();
    }

    [Serializable]
    public class TestClass : ITestClass
    {
        public string Test()
        {
            return "Test succeeded";
        }
    }

    [Serializable]
    public struct TestStruct
    {
        public string Test;
    }

    [Serializable]
    public class InvalidTestClass
    {
        public InvalidTestClass(string test)
        {

        }
    }
}