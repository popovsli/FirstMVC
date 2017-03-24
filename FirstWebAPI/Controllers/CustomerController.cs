using FirstWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstWebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        public Customer GET()
        {
            Customer c = new Customer();
            c.CustomerName = "Sukesh Marla";
            c.Designation = "Corporate Trainer";
            return c;
        }

        public Customer POST(Customer c)
        {
            c.CustomerName += " New";
            c.Designation += " New";
            return c;
        }

       
    }
}
