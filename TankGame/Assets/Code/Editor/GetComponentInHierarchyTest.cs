using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace TankGame.Testing
{
    public class GetComponentInHierarchyTest
    {
        private GameObject _parent;
        private GameObject _child;
        private GameObject _grandChild;

        private GetComponentInHierarchyTester Setup
            (bool includeInactive, bool componentInParent, bool setActive)
        {
            _parent = new GameObject();
            _child = new GameObject();
            _grandChild = new GameObject();

            _child.transform.SetParent(_parent.transform);
            _grandChild.transform.SetParent(_child.transform);

            GetComponentInHierarchyTester tester = _child.AddComponent<GetComponentInHierarchyTester>();
            tester.Setup(includeInactive, componentInParent, setActive);
            return tester;
        }

        [Test]
        public void GetComponentInHierarchyTest_ComponentInChild_IncludeInactive_SetActive()
        {
            GetComponentInHierarchyTester tester = Setup(includeInactive: true, componentInParent: false, setActive: true);

            TestComponent result = tester.Run();
            Assert.NotNull(result);
        }

        [Test]
        public void GetComponentInHierarchyTest_ComponentInChild_DontIncludeInactive_SetActive()
        {
            GetComponentInHierarchyTester tester = Setup(includeInactive: false, componentInParent: false, setActive: true);

            TestComponent result = tester.Run();
            Assert.NotNull(result);
        }

        [Test]
        public void GetComponentInHierarchyTest_ComponentInChild_IncludeInactive_DontSetActive()
        {
            GetComponentInHierarchyTester tester = Setup(includeInactive: true, componentInParent: false, setActive: false);

            TestComponent result = tester.Run();
            Assert.NotNull(result);
        }

        [Test]
        public void GetComponentInHierarchyTest_ComponentInChild_DontIncludeInactive_DontSetActive()
        {
            GetComponentInHierarchyTester tester = Setup(includeInactive: false, componentInParent: false, setActive: false);

            TestComponent result = tester.Run();
            Assert.IsNull(result);
        }

        [Test]
        public void GetComponentInHierarchyTest_ComponentInParent_IncludeInactive_SetActive()
        {
            GetComponentInHierarchyTester tester = Setup(includeInactive: true, componentInParent: true, setActive: true);

            TestComponent result = tester.Run();
            Assert.NotNull(result);
        }

        [Test]
        public void GetComponentInHierarchyTest_ComponentInParent_DontIncludeInactive_SetActive()
        {
            GetComponentInHierarchyTester tester = Setup(includeInactive: false, componentInParent: true, setActive: true);

            TestComponent result = tester.Run();
            Assert.NotNull(result);
        }

        [Test]
        public void GetComponentInHierarchyTest_ComponentInParent_IncludeInactive_DontSetActive()
        {
            GetComponentInHierarchyTester tester = Setup(includeInactive: true, componentInParent: true, setActive: false);

            TestComponent result = tester.Run();
            Assert.NotNull(result);
        }

        [Test]
        public void GetComponentInHierarchyTest_ComponentInParent_DontIncludeInactive_DontSetActive()
        {
            GetComponentInHierarchyTester tester = Setup(includeInactive: false, componentInParent: true, setActive: false);

            TestComponent result = tester.Run();
            Assert.IsNull(result);
        }
    }
}
