using MethodBoundaryAspect.Fody.UnitTests.TestAssembly.NetFramework.Aspects;

namespace MethodBoundaryAspect.Fody.UnitTests.TestAssembly.NetFramework
{
    public class ClassWithIndexer
    {
        [PropertyAspect]
        public bool this[object value] => true;

        [PropertyAspect]
        public bool this[string value] => true;

        public static void DummyMethod()
        {
        }
    }
}