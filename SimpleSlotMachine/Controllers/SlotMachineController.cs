using SimpleSlotMachine.Models;
using SimpleSlotMachine.Repositories.Interfaces;
using SimpleSlotMachine.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SimpleSlotMachine.UI.Controllers
{
    public class SlotMachineController : Controller
    {
        private readonly ISymbolRepository repository;
        public SlotMachineController(ISymbolRepository repository)
        {
            this.repository = repository;
        }
        public ActionResult Index(bool gotErrors = false)
        {
            MainViewModel viewModel = new MainViewModel();

            if (TempData["model"] != null)
                viewModel = TempData["model"] as MainViewModel;

            if (gotErrors)
            {
                ViewBag.Error = "Not enough balance.";
            }
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Spin(FormCollection form)
        {
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            MainViewModel model = new MainViewModel();
            var stakeAmount = decimal.Parse(form["stakeAmount"]);
            if (Session["Balance"] != null)
            {
                model.GameStarted = true;
                model.TotalCredits = decimal.Parse(Session["Balance"].ToString());
                TempData["model"] = model;
            }
            if (model.TotalCredits > 0 && model.TotalCredits >= stakeAmount)
            {
                model.TotalCredits -= stakeAmount;

                List<Row> newRows = repository.GetResultRows();
                model.Rows = newRows;

                decimal totalCoefficient = repository.CalculateTotal(newRows);
                decimal currentWin = (stakeAmount * totalCoefficient) - stakeAmount;

                if (currentWin > 0)
                    model.TotalCredits += currentWin + stakeAmount;
                else
                    currentWin = 0;

                model.CurrentWin = currentWin;

                TempData["model"] = model;
                Session["Balance"] = model.TotalCredits;
            }
            else
            {
                return RedirectToAction("Index", new { gotErrors = true });
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public void SetBalance(FormCollection form)
        {
            Session["Balance"] = decimal.Parse(form["balanceAmount"]);
        }

    }
}