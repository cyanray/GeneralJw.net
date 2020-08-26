using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeJw;
using System;
using System.Collections.Generic;
using System.Text;
using FakeJw.Models;

namespace FakeJw.Tests
{
    [TestClass()]
    public class FakeJwTests
    {
        [TestMethod()]
        public void GetSchoolsTest()
        {
            var schools = FakeJw.GetSchoolsAsync().GetAwaiter().GetResult();
            if (schools.Count != 2) Assert.Fail();
        }

        [TestMethod()]
        public void LoginTest()
        {
            if (FakeJw.PasswordRequired == false) Assert.Fail();
            var jw = FakeJw.LoginAsync(null, null, null).GetAwaiter().GetResult();
            if (jw == null) Assert.Fail();
        }

        [TestMethod()]
        public void GetStudentInfoAsyncTest()
        {
            var schools = FakeJw.GetSchoolsAsync().GetAwaiter().GetResult();
            var school = schools[0];
            var jw = FakeJw.LoginAsync(school, null, null).GetAwaiter().GetResult();
            var studentInfo = jw.GetStudentInfoAsync().GetAwaiter().GetResult();
            if(studentInfo == null) Assert.Fail();
            if (studentInfo.Name != "StudentName") Assert.Fail();
        }
    }
}