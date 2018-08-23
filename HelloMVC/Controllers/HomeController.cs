using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using HelloMVC.Models;

namespace HelloMVC.Controllers
{

    public class HomeController : Controller
    {
        SqlConnection myConnection = new SqlConnection("Data Source=localhost;Initial Catalog=ProTri;Integrated Security=True");

        public static List<CustomerViewModel> customerList = new List<CustomerViewModel>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Customers()
        {
            GlobalViewModel globalModel = new GlobalViewModel();
            //List<GenderViewModel> genders = new List<GenderViewModel>();
            //List<LanguageViewModel> languages = new List<LanguageViewModel>();
            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand("SELECT * FROM Gender", myConnection);
                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    GenderViewModel gender = new GenderViewModel();
                    gender.ID = myReader["GenderID"].ToString();
                    gender.Description = myReader["GenderDescription"].ToString();
                    //genders.Add(gender);

                    globalModel.genders.Add(gender);
                }

                myConnection.Close();
                myConnection.Open();

                SqlCommand myNewCommand = new SqlCommand("SELECT * FROM Preferred_Language", myConnection);
                SqlDataReader myNewReader = myNewCommand.ExecuteReader();

                while (myNewReader.Read())
                {
                    LanguageViewModel language = new LanguageViewModel();
                    language.ID = myNewReader["LanguageID"].ToString();
                    language.Name = myNewReader["LanguageName"].ToString();
                    //languages.Add(language);

                    globalModel.languages.Add(language);
                }
            }
            catch (Exception err)
            {
                ViewBag.Message = err.Message;
            }
            finally
            {
                myConnection.Close();
            }

            return View(globalModel);
        }

        public ActionResult DoInsert(string gender, string name, string surname, DateTime dob, string number, string email, string address, string username, string password, string language, string role, string type, int status, string version)
        {
            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("Insert into Customer VALUES('GEN3','"+gender+"', '"+name+"','"+surname+"','"+dob+"','"+number+"', '"+email+"', '"+address+"', '"+username+"', '"+password+"', '"+language+"', '"+role+"', '"+type+"', '"+status+"', '"+version+"')", myConnection);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                ViewBag.Message = err.Message;
            }
            finally
            {
                myConnection.Close();
            }

            return View("Customers");
        }
        public ActionResult SearchCustomers()
        {
            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("SELECT Customer.CustomerID, Customer.Customer_Name, Customer.Customer_Surname, Customer.Customer_DateOfBirth,  Customer.Customer_ContactNumber, Customer.Customer_Email, Customer.Customer_Address, Customer.Customer_Username, Customer.Customer_Password, Customer.Customer_Status, Customer.Customer_Version, Customer.GenderID, Gender.GenderDescription, Customer.LanguageID, Preferred_Language.LanguageName, Customer.Access_LevelID, User_Roles.Access_LevelDescription, Customer.UserTypeID, User_Type.UserTypeDescription FROM Customer INNER JOIN Gender ON Customer.GenderID = Gender.GenderID INNER JOIN Preferred_Language ON Customer.LanguageID = Preferred_Language.LanguageID INNER JOIN User_Roles ON Customer.Access_LevelID = User_Roles.Access_LevelID INNER JOIN User_Type ON Customer.UserTypeID = User_Type.UserTypeID", myConnection);
                SqlDataReader myReader = myCommand.ExecuteReader();
                customerList.Clear();
                while (myReader.Read())
                {
                    CustomerViewModel customer = new CustomerViewModel();
                    customer.ID = myReader["CustomerID"].ToString();
                    customer.Name = myReader["Customer_Name"].ToString();
                    customer.Surname = myReader["Customer_Surname"].ToString();
                    customer.Date = (DateTime)myReader["Customer_DateOfBirth"];
                    customer.ContactNumber = myReader["Customer_ContactNumber"].ToString();
                    customer.Email = myReader["Customer_Email"].ToString();
                    customer.Address = myReader["Customer_Address"].ToString();
                    customer.Username = myReader["Customer_Username"].ToString();
                    customer.Password = myReader["Customer_Password"].ToString();

                    customer.Gender.ID = myReader["GenderID"].ToString();
                    customer.Gender.Description = myReader["GenderDescription"].ToString();

                    customer.Language.ID = myReader["LanguageID"].ToString();
                    customer.Language.Name = myReader["LanguageName"].ToString();

                    customer.UserRole.ID = myReader["Access_LevelID"].ToString();
                    customer.UserRole.Description = myReader["Access_LevelDescription"].ToString();

                    //customer.UserType.ID = myReader["UserTypeID"].ToString();
                    //customer.UserType.Description = myReader["UserTypeDescription"].ToString();

                    customerList.Add(customer);
                }
            }
            catch (Exception err)
            {
                ViewBag.Message = err.Message;
            }
            finally
            {
                myConnection.Close();
            }

            return View(customerList);
        }

        public ActionResult MaintainCustomers()
        {
            ViewBag.Message = "Maintain customers";

            return View();
        }

        public ActionResult DeleteCustomers()
        {
            ViewBag.Message = "Delete customers";
            return View();
        }
        public ActionResult Employees()
        {
            ViewBag.Message = "Employees";

            return View();
        }

        public ActionResult DeleteEmployees()
        {
            ViewBag.Message = "Delete employees";

            return View();
        }

        public ActionResult Products()
        {
            ViewBag.Message = "Add a new product";
            return View();
        }

        public ActionResult SearchEmployees()
        {
            ViewBag.Message = "Search for an employee";

            return View();
        }

        public ActionResult MaintainEmployees()
        {
            ViewBag.Message = "Maintain employee";

            return View();
        }
        public ActionResult SearchProducts()
        {
            ViewBag.Message = "Search for a product";
            return View();
        }
        public ActionResult MaintainProducts()
        {
            ViewBag.Message = "Maintain products";
            return View();
        }
        public ActionResult Ordering()
        {
            ViewBag.Message = "Ordering";
            return View();
        }

        public ActionResult SearchOrders()
        {
            ViewBag.Message = "Search for a order";
            return View();
        }

        public ActionResult CancelOrders()
        {
            ViewBag.Message = "Cancel an order";
            return View();
        }

        public ActionResult CapturePayments()
        {
            ViewBag.Message = "Capture a payment";
            return View();
        }

        public ActionResult CompletePackingOrders()
        {
            ViewBag.Message = "Complete a packing order";
            return View();
        }

        public ActionResult AssignOrdersToWarehouse()
        {
            ViewBag.Message = "Assign an order to a warehouse";
            return View();
        }

        public ActionResult AssignOrdersToCouriers()
        {
            ViewBag.Message = "Assign an order to a courier";
            return View();
        }

        public ActionResult CaptureOrderReturns()
        {
            ViewBag.Message = "Capture an order return";
            return View();
        }

        public ActionResult Supplier()
        {
            ViewBag.Message = "Suppliers";
            return View();
        }

        public ActionResult SearchSuppliers()
        {
            ViewBag.Message = "Search for a supplier";

            return View();
        }

        public ActionResult MaintainSuppliers()
        {
            ViewBag.Message = "Maintain suppliers";

            return View();
        }

        public ActionResult SupplierOrdering()
        {
            ViewBag.Message = "Supplier Ordering";
            return View();
        }

        public ActionResult Courier()
        {
            ViewBag.Message = "Courier";
            return View();
        }

        public ActionResult SearchCouriers()
        {
            ViewBag.Message = "Search for a courier";

            return View();
        }

        public ActionResult MaintainCouriers()
        {
            ViewBag.Message = "Maintain couriers";

            return View();
        }

        public ActionResult DeleteCouriers()
        {
            ViewBag.Message = "Delete couriers";

            return View();
        }

        public ActionResult Reporting()
        {
            ViewBag.Message = "Reporting";
            return View();
        }

        public ActionResult Warehouse()
        {
            ViewBag.Message = "Warehouse";
            return View();
        }

        public ActionResult UserRoles()
        {
            ViewBag.Message = "User Roles";
            return View();
        }

        public ActionResult SearchWarehouses()
        {
            ViewBag.Message = "Search for a warehouse";

            return View();
        }

        public ActionResult MaintainWarehouses()
        {
            ViewBag.Message = "Maintain warehouses";

            return View();
        }

        public ActionResult SearchUserRoles()
        {
            ViewBag.Message = "Search for a user role";

            return View();
        }

        public ActionResult MaintainUserRoles()
        {
            ViewBag.Message = "Maintain user roles";

            return View();
        }

        public ActionResult PlaceOrder()
        {
            ViewBag.Message = "Place order";

            return View();
        }

        public ActionResult PlacePurchaseOrder()
        {
            ViewBag.Message = "Place purchase order";

            return View();
        }

        public ActionResult SearchPurchaseOrder()
        {
            ViewBag.Message = "Search purchase order";

            return View();
        }

        public ActionResult CancelPurchaseOrder()
        {
            ViewBag.Message = "Cancel purchase order";

            return View();
        }

        public ActionResult CapturePurchasePayment()
        {
            ViewBag.Message = "Capture purchase payment";

            return View();
        }

        public ActionResult ReceivePurchaseOrder()
        {
            ViewBag.Message = "Receive purchase order";

            return View();
        }

        public ActionResult ViewSupplierBackOrders()
        {
            ViewBag.Message = "View supplier back orders";

            return View();
        }

        public ActionResult CaptureSupplierReturns()
        {
            ViewBag.Message = "Capture supplier returns";

            return View();
        }

        public ActionResult ProductTypes()
        {
            ViewBag.Message = "Add product type";

            return View();
        }

        public ActionResult SearchProductTypes()
        {
            ViewBag.Message = "Search product type";

            return View();
        }

        public ActionResult MaintainProductTypes()
        {
            ViewBag.Message = "Maintain product type";

            return View();
        }

        public ActionResult CaptureStockTake()
        {
            ViewBag.Message = "Capture Stock Take";

            return View();
        }

        public ActionResult ViewCourierOrders()
        {
            ViewBag.Message = "View Courier Orders";

            return View();
        }
    }
}