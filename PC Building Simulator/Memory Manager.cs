using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_Building_Simulator
{
    internal class MemoryManager
    {
        private buildmenu buildMenuForm;
        private productmenu productMenuForm;
        private productspecs productSpecsForm;
        private MainApp mainApp;

        public MemoryManager(buildmenu buildMenuForm)
        {
            this.buildMenuForm = buildMenuForm;
        }
        public MemoryManager(MainApp mainApp)
        {
            this.mainApp = mainApp;
        }

        public MemoryManager(productmenu productMenuForm)
        {
            this.productMenuForm = productMenuForm;
        }

        public MemoryManager(productspecs productSpecsForm)
        {
            this.productSpecsForm = productSpecsForm;
        }

        public void DisposeAllMenuForms()
        {
            if (buildMenuForm != null)
            {
                buildMenuForm.Dispose();
                buildMenuForm = null;
            }
            if (productMenuForm != null)
            {
                productMenuForm.Dispose();
                productMenuForm = null;
            }
            if (productSpecsForm != null)
            {
                productSpecsForm.Dispose();
                productSpecsForm = null;
            }
        }
    }
}
