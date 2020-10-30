using Lecture09.App.Services;
using System;
using System.Windows;

namespace Lecture09.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider Container => IoCContainer.Container;
    }
}
