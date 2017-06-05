﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.cheeses = CheeseData.GetAll();

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(Cheese newCheese)
        {
            // Add the new cheese to my existing cheeses
            CheeseData.Add(newCheese);

            return Redirect("/Cheese");
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheese";
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int [] cheeseIds)
        {
            // TODO
            foreach(int cheeseId in cheeseIds)
            {
                CheeseData.Remove(cheeseId);
            }
            return Redirect("/");
        }
        // Handle requests to /Cheese/Edit/cheeseId (URL segment)
        [Route("/Cheese/Edit/{cheeseId}")]
        public IActionResult Edit(int cheeseId)
        {
            ViewBag.title = "Edit Cheese";
            ViewBag.editCheese = CheeseData.GetById(cheeseId);
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Edit/{cheeseId}")]
        public IActionResult Edit(int cheeseId, string name, string description)
        {
            // TODO
            // Delete the existing entry
            Cheese editCheese = CheeseData.GetById(cheeseId);
            editCheese.Name = name;
            editCheese.Description = description;
            return Redirect("/");
        }
    }
}
