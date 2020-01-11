using CarSales.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CarSales.Services
{
    public interface IVehicleManager
    {
        List<SelectListItem> GetTypes();
    }
}
