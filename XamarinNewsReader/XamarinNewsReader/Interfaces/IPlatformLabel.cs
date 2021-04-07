using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinNewsReader
{
    public interface IPlatformLabel
    {
        string GetLabel();

        string GetLabel(string additionalLabel);

        string GetLabel(string additionalLabel, bool addVersion);
    }
}
