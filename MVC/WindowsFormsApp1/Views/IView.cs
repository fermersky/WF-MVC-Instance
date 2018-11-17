using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Controllers;

namespace WindowsFormsApp1.Views
{
    public interface IView
    {
        Controller Controller { set; get; }

    }
}
