using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bartender_Application_by_Devon_Bishop.Models;

namespace Bartender_Application_by_Devon_Bishop.Controllers
{
    public class OrderController : Controller
    {
        private OrderIDRepository repository;

        public OrderController(OrderIDRepository repo)
        {
            repository = repo;
        }

        //View all of the orders
        [HttpGet]
        public ViewResult List()
        {
            ViewBag.name = null;
            return View(repository.Order);
        }

        [HttpPost]
        //View the list of orders
        public ViewResult List(string Name)
        {

            ViewBag.name = Name;

            return View(repository.Order);

        }


        [HttpGet]
        public ViewResult orderInfo(string name)
        {

            ViewBag.name = name;
            return View();
        }
        [HttpPost]
        public ViewResult orderInfo(Order ordr)
        {
            return View("orderInfo", ordr);
        }


        //Display order
        public ViewResult orderInfo(int Id) => View(repository.Order.FirstOrDefault(p => p.ID == Id));

        //Save order
        [HttpPost]
        public IActionResult orderInfo(Order order)
        {
            if (ModelState.IsValid)
            {
                repository.SaveOrder(order);
                TempData["message"] = $"{order.Customer} 's order has been saved";
                return RedirectToAction("orderInfo");
            }
            else
            {
                return View(order);
            }
        }
        //create an order
        public ViewResult Create() => View("orderInfo", new Order());

        //Delete an order
        public IActionResult Delete(int ID)
        {
            Order deleteOrder = repository.DeleteOrder(ID);

            return RedirectToAction("list");

        }
    }
}