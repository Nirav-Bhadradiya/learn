using MvcApplication2.Models;
using System.Linq;
using System.Web.Mvc;
using MvcApplication2.ViewModels;

namespace MvcApplication2.Controllers
{
    public class DynamoDbController : Controller
    {
        //
        // GET: /DynamoDb/
        DynamoDbListTableViewModel dynamoViewModel = new DynamoDbListTableViewModel();
        DynamoDbDemoService service = new DynamoDbDemoService();

        public ActionResult Index()
        {
            dynamoViewModel.dynamoDbtableLists = service.GetTablesList();

            return View("Index", dynamoViewModel);
        }


        public ActionResult DescribeTable()
        {
            dynamoViewModel.AttributeDefinition = service.GetTableInstance(service.GetTablesList().FirstOrDefault());

            return View("DescribeTable", dynamoViewModel);
        }

    }
}
