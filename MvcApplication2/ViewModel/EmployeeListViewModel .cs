using System.Collections.Generic;

namespace MvcApplication2.ViewModels
{
    public class EmployeeListViewModel : BaseViewModel
    {
        public List<EmployeeViewModel> Employees { get; set; }
        //public string UserName { get; set; }

        //public FooterViewModel FooterData { get; set; }
    }
}