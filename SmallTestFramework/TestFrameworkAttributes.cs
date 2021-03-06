﻿using System;

namespace SmallTestFramework
{
    /// <summary>
    /// Attribute to use on methods
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class TestMethodAttribute : Attribute
    {

    }

    /// <summary>
    /// Attribute should be called before every test
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class TestStartAttribute : Attribute
    {

    }
    
    /// <summary>
    /// Attribute should be called after every test
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class TestStopAttribute : Attribute
    {

    }


    /// <summary>
    /// Attribute for classes
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TestClassAttribute : Attribute
    {

    }


    /// <summary>
    /// Attribute for classes
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ExpectedExceptionAttribute : Attribute
    {

    }
}
