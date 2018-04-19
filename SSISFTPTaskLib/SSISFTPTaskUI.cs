using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Dts.Runtime.Design;

namespace SSISFTPTaskLib
{
    public class SSISFTPTaskUI : IDtsTaskUI
    {
        private TaskHost taskHostValue;


        public void Initialize(TaskHost taskHost, IServiceProvider serviceProvider)
        {
            this.taskHostValue = taskHost;
        }

        public ContainerControl GetView()
        {
            return new SSISFTPTaskUIForm(taskHostValue);
        }

        public void Delete(IWin32Window parentWindow)
        {
        }

        public void New(IWin32Window parentWindow)
        {
        }
    }
}
