using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventSchedule.UI.Classes
{
    public interface IUserControlCmd
    {
        void PositioningOnScreen(Size size);
        void Clear();
    }
}
