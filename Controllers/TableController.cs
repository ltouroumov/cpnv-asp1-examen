using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP1Examen.Models;

namespace ASP1Examen.Controllers
{
    public class TableController : Controller
    {
        //
        // GET: /Table/

        public ActionResult Index()
        {
            var gen = new TableGeneratorOptions { Generate = false };

            if (Request.Params.AllKeys.Contains("Rows") && Request.Params.AllKeys.Contains("Cols"))
            {
                var cols = int.Parse(Request.Params["Cols"]);
                var rows = int.Parse(Request.Params["Rows"]);

                gen.Generate = true;
                gen.Rows = rows;
                gen.Cols = cols;
            }

            return View(gen);
        }

    }
}
