using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GravitonEcoV2.Updaters.HttpHandlers
{
    public class HttpUpdater : HttpRequestUpdater
    {
        public HttpUpdater(Control controlMaxValue, Control controlMinValue, Control controlAvgValue, string alias)
            : base(controlMaxValue, controlMinValue, controlAvgValue, alias)
        {
        }

        protected override async Task UpdateAsync()
        {
            while (true)
            {
                await UpdateControlAsync();
            }
        }
    }
}