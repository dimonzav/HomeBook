namespace HomeBook.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using HomeBook.Models;

    public class BankAccountTypeModel
    {
        public BankAccountTypeModel(BankAccountType accountType)
        {
            this.TypeName = accountType.TypeName;
        }
        public int BankAccountTypeId { get; set; }

        public string TypeName { get; set; }
    }
}
